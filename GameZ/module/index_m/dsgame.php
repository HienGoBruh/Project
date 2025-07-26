<?php
// KẾT NỐI CSDL
include ('DBCONN.PHP');
// TRUY VẤN LẤY THÔNG TIN GAME
$sql = "
SELECT 
  g.game_id,
  g.game_name,
  g.game_details,
  p.price_value,
  d.discount_type,
  d.discount_value,
  -- Gom tất cả thể loại (nếu có)
  GROUP_CONCAT(DISTINCT c.categories_name SEPARATOR ', ') AS categories_list,
  -- Gom tất cả ảnh (nếu có)
  GROUP_CONCAT(DISTINCT gi.img_url SEPARATOR '|') AS images_list
FROM game g
LEFT JOIN game_price p ON g.game_id = p.game_id
LEFT JOIN game_discounts gd ON g.game_id = gd.game_id
LEFT JOIN discounts d ON gd.discount_id = d.discount_id
LEFT JOIN categories_game cg ON g.game_id = cg.gameID
LEFT JOIN categories c ON cg.categoriesID = c.categories_id
LEFT JOIN game_img gi ON g.game_id = gi.game_id
GROUP BY g.game_id
";

$result = $conn->query($sql);

// CHUYỂN KẾT QUẢ VÀO MẢNG $games
$games = [];
if ($result && $result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        // Tách danh sách ảnh
        $allImages = [];
        if (!empty($row['images_list'])) {
            $allImages = explode('|', $row['images_list']);
        }
        $row['images'] = $allImages; // Mảng ảnh
        unset($row['images_list']);  // Bỏ cột tạm
        $games[] = $row;
    }
}
$conn->close();
?>

<!DOCTYPE html>
<html lang="vi">
<head>
  <meta charset="UTF-8">
  <title>Danh sách Game</title>
  <!-- Bootstrap 5.3 -->
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">

  <style>
    /* Container chính được định vị relative */
    #mainContainer {
      position: relative;
    }
    .game-item {
      padding: 10px 0;
      border-bottom: 1px solid rgba(255,255,255,0.1);
      display: flex;
      cursor: pointer;
      transition: background-color 0.2s;
    }
    .game-item:hover {
      background-color: rgba(155, 154, 154, 0.08);
    }
    /* Ảnh đại diện của game (cột trái) */
    .game-thumb {
      width: 140px;
      height: 60px;
      object-fit: cover;
      border: 1px solid #999 !important;
      margin-right: 10px;
    }
    .game-name {
      font-weight: 500;
    }
    .game-tags {
      font-size: 0.9rem;
      color:rgb(48, 47, 47) !important;
    }
    .game-price {
      font-weight: 600;
    }
    .old-price {
      text-decoration: line-through;
      margin-right: 5px;
    }
    .free-text {
      color: #b8b6b4;
      font-weight: normal;
    }
    /* Cột bên phải (chi tiết game) cố định ở trên cùng */
    #rightColumn {
      right: 0;
      width: 30%; 
      margin-top: 34px !important;
    }
    .right-panel {
      background-color:rgb(174, 174, 174);
      border: none;
      min-height: 400px;
      padding: 1rem;
    }
    .right-panel img {
      max-width: 100%;
      border-radius: 4px;
    }
    /* Screenshots hiển thị theo dạng cột dọc */
    .screenshots-wrap {
      display: flex;
      flex-direction: column;
    }
    .screenshots-wrap img {
      width: 100%;
      max-width: 100%;
      height: auto;
      object-fit: cover;
      border: 1px solid #999;
      margin-bottom: 10px;
    }
    .screenshots-wrap img:hover {
      border-color: #fff;
    }
    #gameList a {
      text-decoration: none;
      color: inherit;
    }
  </style>
</head>
<body>

<div class="container py-4" id="mainContainer">
  <div class="row" style="height: 1040px">
    <!-- Cột trái: Danh sách Game (tối đa 10 game) -->
    <div class="col-md-8">
      <h6 class="mb-3">DANH SÁCH CÁC GAME</h6>
      <div id="gameList"></div>                         
      <a href="sanpham.php" style="text-decoration: none;">
        <button type="button" class="btn" style="background-color: none; padding-left: 0;">XEM THÊM</button>
      </a>
    </div>

    <!-- Cột bên phải: Chi tiết Game (cố định ở trên cùng) -->
    <div class="col-md-4 d-none d-lg-block" id="rightColumn">
      <div class="right-panel" id="detailPanel">
        <!-- Mặc định sẽ được cập nhật với game đầu tiên -->
      </div>
    </div>
  </div>
</div>

<!-- Bootstrap JS -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

<script>
// Chuyển mảng games từ PHP sang JS
var games = <?php echo json_encode($games, JSON_UNESCAPED_UNICODE); ?>;

// Giới hạn hiển thị tối đa 10 game
var maxGames = 10;

// DOM tham chiếu
var gameListEl = document.getElementById('gameList');
var detailPanel = document.getElementById('detailPanel');

// Hàm tính giá sau giảm
function calcFinalPrice(price, discountType, discountValue) {
  if (!price || price <= 0) return { finalPrice: 0, discountPercent: 0 };
  if (!discountType || !discountValue) {
    return { finalPrice: price, discountPercent: 0 };
  }
  
  let finalP = price;
  if (discountType === 'Phần trăm') {
    finalP = price - (price * discountValue / 100);
  } else if (discountType === 'Giảm giá cố định') {
    finalP = price - discountValue;
  }
  if (finalP < 0) finalP = 0;
  
  let discountPercent = 0;
  if (discountType === 'Phần trăm') {
    discountPercent = discountValue;
  } else {
    discountPercent = Math.round((discountValue / price) * 100);
  }
  return { finalPrice: finalP, discountPercent: discountPercent };
}

// Hàm hiển thị tất cả game (tối đa 10)
function renderGames() {
  var slice = games.slice(0, maxGames);
  slice.forEach((g, i) => {
    var itemEl = createGameItem(g, i);
    gameListEl.appendChild(itemEl);
  });
  // Mặc định hiển thị game đầu tiên ở cột bên phải
  if (games.length > 0) {
    showGameDetails(0);
  }
}

// Tạo HTML cho 1 game ở cột trái
function createGameItem(g, index) {
  var a = document.createElement('a');
  a.href = 'chitiet.php?id=' + g.game_id;
  a.style.textDecoration = 'none';
  a.style.color = 'inherit';

  var div = document.createElement('div');
  div.className = 'game-item align-items-center';

  // Ảnh đại diện
  var thumbUrl = (g.images && g.images.length > 0) 
      ? g.images[0] 
      : 'https://via.placeholder.com/160x80/333/fff?text=No+Img';
  var img = document.createElement('img');
  img.className = 'game-thumb';
  img.src = thumbUrl;
  div.appendChild(img);

  // Thông tin game
  var contentDiv = document.createElement('div');
  contentDiv.style.flex = '1';
  var nameEl = document.createElement('div');
  nameEl.className = 'game-name';
  nameEl.textContent = g.game_name;
  contentDiv.appendChild(nameEl);

  var catEl = document.createElement('div');
  catEl.className = 'game-tags';
  catEl.textContent = g.categories_list ? g.categories_list : 'Không có thể loại';
  contentDiv.appendChild(catEl);
  div.appendChild(contentDiv);

  // Hiển thị giá
  var priceDiv = document.createElement('div');
  var price = parseFloat(g.price_value) || 0;
  var discountType = g.discount_type;
  var discountValue = parseFloat(g.discount_value) || 0;
  var { finalPrice } = calcFinalPrice(price, discountType, discountValue);
  if (price <= 0) {
    priceDiv.innerHTML = '<span class="game-price free-text">Miễn phí</span>';
  } else {
    if (discountType && discountValue > 0) {
      let oldP = `<span class="old-price text-dark">${price.toLocaleString('en-US')}₫</span>`;
      let newP = `<span class="game-price">${finalPrice.toLocaleString('en-US')}₫</span>`;
      priceDiv.innerHTML = oldP + newP;
    } else {
      priceDiv.innerHTML = `<span class="game-price">${price.toLocaleString('en-US')}₫</span>`;
    }
  }
  div.appendChild(priceDiv);

  // Gán sự kiện mouseenter cho div để cập nhật cột bên phải khi hover
  div.addEventListener('mouseenter', function() {
    showGameDetails(index);
  });

  // Gắn div vào thẻ a
  a.appendChild(div);
  return a;
}

// Hiển thị chi tiết game ở cột bên phải
// Các ảnh còn lại (từ g.images[1] trở đi) sẽ được xếp dọc
function showGameDetails(index) {
  var g = games[index];
  if (!g) return;

  var price = parseFloat(g.price_value) || 0;
  var discountType = g.discount_type;
  var discountValue = parseFloat(g.discount_value) || 0;
  var { finalPrice } = calcFinalPrice(price, discountType, discountValue);

  var html = `
    <h5 class="mb-3">${escapeHtml(g.game_name)}</h5>
    <p>${nl2br(escapeHtml(g.game_details || ''))}</p>
  `;

  // Hiển thị các ảnh còn lại (bỏ g.images[0])
  if (g.images && g.images.length > 1) {
    html += `<div class="screenshots-wrap">`;
    for (var i = 1; i < g.images.length; i++) {
      html += `<img src="${escapeHtml(g.images[i])}" alt="Screenshot">`;
    }
    html += `</div>`;
  } else if (g.images && g.images.length === 1) {
    html += `<p><em>Không có thêm ảnh nào khác</em></p>`;
  } else {
    html += `<div class="mb-3">
      <img src="https://via.placeholder.com/300x200/333/fff?text=No+Image" alt="No image" />
    </div>`;
  }

  // Giá
  if (price <= 0) {
    html += `<p><strong>Giá:</strong> Miễn phí</p>`;
  } else if (discountType && discountValue > 0) {
    html += `<p><strong>Giá:</strong>
      <span class="old-price">${price.toLocaleString('en-US')}₫</span>
      <span style="color:red">${finalPrice.toLocaleString('en-US')}₫</span>
    </p>`;
  } else {
    html += `<p><strong>Giá:</strong> ${price.toLocaleString('en-US')}₫</p>`;
  }

  html += `<button class="btn btn-primary">Thêm vào giỏ</button>`;
  detailPanel.innerHTML = html;
}

// Hàm escape HTML
function escapeHtml(str) {
  return str.replace(/[&<>'"]/g, function(m) {
    switch (m) {
      case '&': return '&amp;';
      case '<': return '&lt;';
      case '>': return '&gt;';
      case "'": return '&#39;';
      case '"': return '&quot;';
    }
  });
}

// Hàm chuyển \n thành <br>
function nl2br(str) {
  return str.replace(/\n/g, '<br>');
}

// Khi tải trang, hiển thị 10 game và mặc định hiển thị game đầu tiên ở cột bên phải
document.addEventListener('DOMContentLoaded', function() {
  renderGames();
  if (games.length > 0) {
    showGameDetails(0);
  }
});
</script>

</body>
</html>
