<?php
// Kết nối CSDL
include 'DBCONN.PHP';

// Lấy từ khóa tìm kiếm từ GET
$q = isset($_GET['q']) ? $_GET['q'] : '';
if (empty($q)) {
    // Nếu không có từ khóa, chuyển về trang chủ hoặc thông báo lỗi
    header("Location: index.php");
    exit;
}

// Thoát chuỗi để tránh lỗi SQL injection
$qSafe = $conn->real_escape_string($q);

// Truy vấn CSDL
// Chúng ta sử dụng các CASE để tính điểm (score) dựa trên các trường ưu tiên
$sql = "
SELECT 
    g.game_id,
    g.game_name,
    g.game_details,
    p.price_value,
    d.discount_type,
    d.discount_value,
    d.discount_name,
    GROUP_CONCAT(DISTINCT c.categories_name SEPARATOR ', ') AS categories_list,
    GROUP_CONCAT(DISTINCT gi.img_url SEPARATOR '|') AS images_list,
    (
        (CASE WHEN c.categories_name LIKE '%$qSafe%' THEN 2 ELSE 0 END) +
        (CASE WHEN d.discount_name LIKE '%$qSafe%' THEN 2 ELSE 0 END) +
        (CASE WHEN g.game_name LIKE '%$qSafe%' THEN 1 ELSE 0 END) +
        (CASE WHEN g.game_details LIKE '%$qSafe%' THEN 1 ELSE 0 END)
    ) AS score
FROM game g
LEFT JOIN game_price p ON g.game_id = p.game_id
LEFT JOIN game_discounts gd ON g.game_id = gd.game_id
LEFT JOIN discounts d ON gd.discount_id = d.discount_id
LEFT JOIN categories_game cg ON g.game_id = cg.gameID
LEFT JOIN categories c ON cg.categoriesID = c.categories_id
LEFT JOIN game_img gi ON g.game_id = gi.game_id
WHERE 
    c.categories_name LIKE '%$qSafe%'
    OR d.discount_name LIKE '%$qSafe%'
    OR g.game_name LIKE '%$qSafe%'
    OR g.game_details LIKE '%$qSafe%'
GROUP BY g.game_id
ORDER BY score DESC
";

$result = $conn->query($sql);

// Lưu kết quả truy vấn
$games = [];
if ($result && $result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        // Tách danh sách ảnh thành mảng
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

// Hàm tính giá sau giảm (nếu cần hiển thị giá)
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
?>

<!DOCTYPE html>
<html lang="vi">
<head>
  <meta charset="UTF-8">
  <title>Kết quả tìm kiếm: <?php echo htmlspecialchars($q); ?></title>
  <!-- Load File HTML -->
  <script src="script/load_htmlfile.js"></script>
  <link rel="stylesheet" href="css/carousel.css">
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
  <style>
    body {
      background-color: #1B2838 !important;
    }
    h2.title {
      color: #fff;
      margin: 20px 0;
    }
    .game-card {
      background-color: #1b2838;
      border: none;
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
<div id="dropdown"></div>
<div class="container my-4">

  <h2 class="title">Kết quả tìm kiếm cho: "<?php echo htmlspecialchars($q); ?>"</h2>

  <div class="row row-cols-1 row-cols-md-3 g-4">
    <?php if (empty($games)): ?>
      <div class="col">
        <p class="text-white">Không tìm thấy game nào phù hợp với từ khóa "<strong><?php echo htmlspecialchars($q); ?></strong>".</p>
      </div>
    <?php else: ?>
      <?php foreach ($games as $game): ?>
        <div class="col">
          <!-- Bọc toàn bộ card game trong thẻ <a> để chuyển hướng -->
          <a href="chitiet.php?id=<?php echo $game['game_id']; ?>" style="text-decoration: none; color: inherit;">
            <div class="card game-card">
              <div class="position-relative">
                <?php
                  // Ảnh đầu tiên hoặc placeholder
                  $imgSrc = (!empty($game['images'])) 
                            ? $game['images'][0] 
                            : 'https://via.placeholder.com/300x200?text=No+Image';
                ?>
                <img src="<?php echo htmlspecialchars($imgSrc); ?>" alt="Game <?php echo htmlspecialchars($game['game_name']); ?>">
                <?php 
                // Tính discount
                $price = floatval($game['price_value']);
                $discountType = $game['discount_type'];
                $discountValue = $game['discount_value'];
                $calc = calcFinalPrice($price, $discountType, $discountValue);
                if ($calc['discountPercent'] > 0): ?>
                  <div class="discount-badge">
                    -<?php echo $calc['discountPercent']; ?>%
                  </div>
                <?php endif; ?>
              </div>
              <!-- Footer -->
              <div class="game-card-footer">
                <?php if ($calc['discountPercent'] > 0): ?>
                  <!-- Nếu có giảm giá -->
                  <!-- Dòng 1: Tên game (trái) + Giá gốc (phải) -->
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
                  <!-- Dòng 2: Giá mới bên phải -->
                  <div class="row align-items-center">
                    <div class="col"></div>
                    <div class="col-auto text-end">
                      <span class="new-price">
                        <?php echo number_format($calc['finalPrice'], 0, ',', '.'); ?>₫
                      </span>
                    </div>
                  </div>
                <?php else: ?>
                  <!-- Không giảm giá hoặc game miễn phí -->
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
              </div> <!-- end game-card-footer -->
            </div> <!-- end card -->
          </a>
        </div> <!-- end col -->
      <?php endforeach; ?>
    <?php endif; ?>
  </div> <!-- end row -->
</div> <!-- end container -->

<!-- Game Giảm giá -->
<?php include 'module/index_m/hotdiscount.php'; ?>

<!-- Duyệt theo thể loại -->
<?php include 'module/index_m/duyettheloai.php'; ?>

<footer id="footer"></footer>
<!-- Fixed -->
<script>
    document.addEventListener("DOMContentLoaded", function () {
        window.addEventListener('scroll', function () {
            if (window.scrollY > 50) {
                document.getElementById('navbar_top').classList.add('fixed-top');
                // add padding top to show content behind navbar
                navbar_height = document.querySelector('.navbar').offsetHeight;
                document.body.style.paddingTop = navbar_height + 'px';
            } else {
                document.getElementById('navbar_top').classList.remove('fixed-top');
                // remove padding top from body
                document.body.style.paddingTop = '0';
            }
        });
    }); 
</script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
