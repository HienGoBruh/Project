<?php
// KẾT NỐI CSDL
include ('DBCONN.PHP');

// Hàm tính giá sau giảm và phần trăm giảm (đặt ở đầu file để dùng cho cả AJAX và load trang)
function calcFinalPrice($price, $discountType, $discountValue) {
    $price = floatval($price);
    $discountValue = floatval($discountValue);
    if ($price <= 0) {
        return ['finalPrice' => 0, 'discountPercent' => 0];
    }
    if (!$discountType || $discountValue <= 0) {
        return ['finalPrice' => $price, 'discountPercent' => 0];
    }
    if ($discountType === 'Phần trăm') {
        $finalPrice = $price - ($price * $discountValue / 100);
        $discountPercent = $discountValue;
    } elseif ($discountType === 'Giảm giá cố định') {
        $finalPrice = $price - $discountValue;
        $discountPercent = round(($discountValue / $price) * 100);
    } else {
        $finalPrice = $price;
        $discountPercent = 0;
    }
    if ($finalPrice < 0) $finalPrice = 0;
    return ['finalPrice' => $finalPrice, 'discountPercent' => $discountPercent];
}

// Nếu là AJAX request load thêm game, thì chỉ trả về HTML của các card game
if (isset($_GET['ajax']) && $_GET['ajax'] == 1) {
    $offset = isset($_GET['offset']) ? intval($_GET['offset']) : 0;
    $limit = 6;
    $sql = "
    SELECT 
        g.game_id,
        g.game_name,
        g.game_details,
        p.price_value,
        d.discount_type,
        d.discount_value,
        GROUP_CONCAT(DISTINCT c.categories_name SEPARATOR ', ') AS categories_list,
        GROUP_CONCAT(DISTINCT gi.img_url SEPARATOR '|') AS images_list
    FROM game g
    LEFT JOIN game_price p ON g.game_id = p.game_id
    LEFT JOIN game_discounts gd ON g.game_id = gd.game_id
    LEFT JOIN discounts d ON gd.discount_id = d.discount_id
    LEFT JOIN categories_game cg ON g.game_id = cg.gameID
    LEFT JOIN categories c ON cg.categoriesID = c.categories_id
    LEFT JOIN game_img gi ON g.game_id = gi.game_id
    GROUP BY g.game_id
    ORDER BY g.game_id
    LIMIT $offset, $limit
    ";
    $result = $conn->query($sql);
    if ($result && $result->num_rows > 0) {
        while ($row = $result->fetch_assoc()) {
            // Tách ảnh
            $images = [];
            if (!empty($row['images_list'])) {
                $images = explode('|', $row['images_list']);
            }
            $row['images'] = $images;
            ?>
            <div class="col">
                <a href="chitiet.php?id=<?php echo $row['game_id']; ?>" style="text-decoration: none; color: inherit;">
                    <div class="card game-card">
                        <div class="position-relative">
                            <?php 
                            $imgSrc = !empty($row['images']) 
                                        ? $row['images'][0] 
                                        : 'https://via.placeholder.com/300x200?text=No+Image';
                            ?>
                            <img src="<?php echo htmlspecialchars($imgSrc); ?>" alt="Game <?php echo htmlspecialchars($row['game_name']); ?>">
                            <?php 
                            $price = floatval($row['price_value']);
                            $discountType = $row['discount_type'];
                            $discountValue = $row['discount_value'];
                            $calc = calcFinalPrice($price, $discountType, $discountValue);
                            if ($calc['discountPercent'] > 0): 
                            ?>
                            <div class="discount-badge">
                                -<?php echo $calc['discountPercent']; ?>%
                            </div>
                            <?php endif; ?>
                        </div>
                        <!-- Footer -->
                        <div class="game-card-footer">
                            <?php if ($calc['discountPercent'] > 0): ?>
                            <div class="row align-items-center">
                                <div class="col">
                                    <h5 class="game-title mb-0">
                                        <?php echo htmlspecialchars($row['game_name']); ?>
                                    </h5>
                                </div>
                                <div class="col-auto text-end">
                                    <span class="old-price">
                                        <?php echo number_format($price, 0, ',', '.'); ?>₫
                                    </span>
                                </div>
                            </div>
                            <div class="row align-items-center">
                                <div class="col"></div>
                                <div class="col-auto text-end">
                                    <span class="new-price">
                                        <?php echo number_format($calc['finalPrice'], 0, ',', '.'); ?>₫
                                    </span>
                                </div>
                            </div>
                            <?php else: ?>
                            <div class="row align-items-center">
                                <div class="col">
                                    <h5 class="game-title mb-0">
                                        <?php echo htmlspecialchars($row['game_name']); ?>
                                    </h5>
                                </div>
                                <div class="col-auto text-end">
                                    <?php if ($price <= 0): ?>
                                        <span class="new-price">Miễn phí</span>
                                    <?php else: ?>
                                        <span class="new-price">
                                            <?php echo number_format($price, 0, ',', '.'); ?>₫
                                        </span>
                                    <?php endif; ?>
                                </div>
                            </div>
                            <?php endif; ?>
                        </div>
                    </div>
                </a>
            </div>
            <?php
        }
    }
    $conn->close();
    exit;
}

// Nếu không phải AJAX, load trang bình thường với 6 game đầu tiên
$offset = 0;
$limit = 6;

// Lấy tổng số game từ CSDL (chỉ đếm game khác nhau)
$sqlCount = "SELECT COUNT(DISTINCT game_id) as total FROM game";
$resultCount = $conn->query($sqlCount);
$totalGames = 0;
if ($resultCount && $resultCount->num_rows > 0) {
    $rowCount = $resultCount->fetch_assoc();
    $totalGames = $rowCount['total'];
}

$sql = "
SELECT 
    g.game_id,
    g.game_name,
    g.game_details,
    p.price_value,
    d.discount_type,
    d.discount_value,
    GROUP_CONCAT(DISTINCT c.categories_name SEPARATOR ', ') AS categories_list,
    GROUP_CONCAT(DISTINCT gi.img_url SEPARATOR '|') AS images_list
FROM game g
LEFT JOIN game_price p ON g.game_id = p.game_id
LEFT JOIN game_discounts gd ON g.game_id = gd.game_id
LEFT JOIN discounts d ON gd.discount_id = d.discount_id
LEFT JOIN categories_game cg ON g.game_id = cg.gameID
LEFT JOIN categories c ON cg.categoriesID = c.categories_id
LEFT JOIN game_img gi ON g.game_id = gi.game_id
GROUP BY g.game_id
ORDER BY g.game_id
LIMIT $offset, $limit
";
$result = $conn->query($sql);
$games = [];
if ($result && $result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $images = [];
        if (!empty($row['images_list'])) {
            $images = explode('|', $row['images_list']);
        }
        $row['images'] = $images;
        unset($row['images_list']);
        $games[] = $row;
    }
}
$conn->close();
?>

<!DOCTYPE html>
<html lang="vi">
<head>
  <meta charset="UTF-8">
  <title>GameZ</title>
  <!-- Link Bootstrap 5.3 -->
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
  <!-- Load File HTML -->
  <script src="script/load_htmlfile.js"></script>
  <style>
    /* Nền tổng thể */
    body {
      background-color: rgb(238, 240, 242) !important;
      margin: 0;
      padding: 0;
    }
    h3.special-deals-title {
      margin: 20px 0;
    }
    .game-card {
        background-color: #1b2838;
        border: none !important;
        box-shadow: none !important;
        border-radius: 5px;
        overflow: hidden;
        color: #fff;
        height: 100%;
        display: flex;
        flex-direction: column;
        justify-content: space-between;
    }
    .position-relative img {
      width: 100%;
      height: 200px;
      object-fit: cover;
    }
    .game-card-footer {
      background-color: #0E1821;
      padding: 8px 12px;
      min-height: 70px;
    }
    .discount-badge {
      position: absolute;
      top: 8px;
      left: 8px;
      background-color: #4caf50;
      color: #fff;
      padding: 4px 8px;
      font-weight: 700;
      font-size: 0.9rem;
      border-radius: 4px;
      white-space: nowrap;
      z-index: 2;
    }
    .game-title {
      font-size: 1rem;
      font-weight: 600;
      margin: 0;
      white-space: nowrap;
      overflow: hidden;
      text-overflow: ellipsis;
      color: #fff;
    }
    .old-price {
      font-size: 0.85rem;
      text-decoration: line-through;
      color: #999;
    }
    .new-price {
      font-size: 1rem;
      color: #b6f94f;
      font-weight: 700;
    }
  </style>
</head>
<body>
    
    <?php include 'module/header.php'; ?>
    <div class="container my-2">
        <h3 class="special-deals-title text-center">DANH SÁCH GAME</h3>
        <div class="row row-cols-1 row-cols-md-3 g-4" id="gamesContainer">
            <?php foreach ($games as $game): ?>
                <div class="col">
                    <a href="chitiet.php?id=<?php echo $game['game_id']; ?>" style="text-decoration: none; color: inherit;">
                        <div class="card game-card">
                            <div class="position-relative">
                                <?php 
                                $imgSrc = !empty($game['images']) 
                                            ? $game['images'][0] 
                                            : 'https://via.placeholder.com/300x200?text=No+Image';
                                ?>
                                <img src="<?php echo htmlspecialchars($imgSrc); ?>" alt="Game <?php echo htmlspecialchars($game['game_name']); ?>">
                                <?php 
                                $price = floatval($game['price_value']);
                                $discountType = $game['discount_type'];
                                $discountValue = $game['discount_value'];
                                $calc = calcFinalPrice($price, $discountType, $discountValue);
                                if ($calc['discountPercent'] > 0): 
                                ?>
                                <div class="discount-badge">
                                    -<?php echo $calc['discountPercent']; ?>%
                                </div>
                                <?php endif; ?>
                            </div>
                            <div class="game-card-footer">
                                <?php if ($calc['discountPercent'] > 0): ?>
                                <div class="row align-items-center">
                                    <div class="col">
                                        <h5 class="game-title mb-0">
                                            <?php echo htmlspecialchars($game['game_name']); ?>
                                        </h5>
                                    </div>
                                    <div class="col-auto text-end">
                                        <span class="old-price">
                                            <?php echo number_format($price, 0, ',', '.'); ?>₫
                                        </span>
                                    </div>
                                </div>
                                <div class="row align-items-center">
                                    <div class="col"></div>
                                    <div class="col-auto text-end">
                                        <span class="new-price">
                                            <?php echo number_format($calc['finalPrice'], 0, ',', '.'); ?>₫
                                        </span>
                                    </div>
                                </div>
                                <?php else: ?>
                                <div class="row align-items-center">
                                    <div class="col">
                                        <h5 class="game-title mb-0">
                                            <?php echo htmlspecialchars($game['game_name']); ?>
                                        </h5>
                                    </div>
                                    <div class="col-auto text-end">
                                        <?php if ($price <= 0): ?>
                                            <span class="new-price">Miễn phí</span>
                                        <?php else: ?>
                                            <span class="new-price">
                                                <?php echo number_format($price, 0, ',', '.'); ?>₫
                                            </span>
                                        <?php endif; ?>
                                    </div>
                                </div>
                                <?php endif; ?>
                            </div>
                        </div>
                    </a>
                </div>
            <?php endforeach; ?>
        </div>

        <!-- Nút xem thêm -->
        <div class="text-center my-4">
            <button id="loadMoreBtn" class="btn btn-primary">Xem thêm</button>
        </div>
    </div>

    <footer id="footer"></footer>

    <!-- JS load thêm game qua AJAX -->
    <script>
        let offset = 6; // Đã load 6 game đầu tiên
        const totalGames = <?php echo $totalGames; ?>; // Tổng số game lấy từ CSDL
        const loadMoreBtn = document.getElementById('loadMoreBtn');
        const gamesContainer = document.getElementById('gamesContainer');

        loadMoreBtn.addEventListener('click', function() {
            fetch('?ajax=1&offset=' + offset)
                .then(response => response.text())
                .then(data => {
                    if(data.trim() !== ''){
                        gamesContainer.insertAdjacentHTML('beforeend', data);
                        offset += 6;
                        // Nếu số game đã load đủ hoặc vượt quá tổng số game, ẩn nút
                        if(offset >= totalGames){
                            loadMoreBtn.style.display = 'none';
                        }
                    } else {
                        loadMoreBtn.style.display = 'none';
                    }
                })
                .catch(error => console.error('Error loading more games:', error));
        });
    </script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
