<?php
// KẾT NỐI CSDL
include ('DBCONN.PHP');

// Lấy tên thể loại / chủ đề / yêu cầu khuyến mãi từ GET
$catName = isset($_GET['cat']) ? $_GET['cat'] : '';
if(empty($catName)) {
    die("Không có thể loại nào được chọn.");
}

// Thoát chuỗi để tránh lỗi SQL injection
$catSafe = $conn->real_escape_string($catName);

// 1. Miễn phí => price_value = 0
// 2. Có tính phí => price_value > 0
// 3. KM Khủng => discount_value > 0
// 4. Sale tháng => discount_name = 'Sale tháng'
// 5. Mặc định => categories_name = $catName
$whereCondition = "";

if ($catName === 'Miễn phí') {
    $whereCondition = "p.price_value = 0";
} elseif ($catName === 'Có tính phí' || $catName === 'Có trả phí') {
    // Tùy bạn thống nhất tên hiển thị, code này chấp nhận cả 2
    $whereCondition = "p.price_value > 0";
} elseif ($catName === 'KM Khủng') {
    // Hiển thị toàn bộ game đang có discount (discount_value > 0)
    $whereCondition = "d.discount_value > 0";
} elseif ($catName === 'Sale tháng' || $catName === 'KM trong tháng') {
    // Tùy link menu bạn dùng
    $whereCondition = "d.discount_name = 'Sale tháng'";
} else {
    // Mặc định => tìm theo categories_name
    $whereCondition = "c.categories_name = '{$catSafe}'";
}

// Tạo câu lệnh SQL với WHERE động
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
WHERE $whereCondition
GROUP BY g.game_id
";

$result = $conn->query($sql);
$games = [];
if ($result && $result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        // Tách ảnh
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

// Hàm tính giá sau giảm và phần trăm giảm
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
  <title>GameZ - <?php echo htmlspecialchars($catName); ?></title>
  <!-- Link Bootstrap 5.3 -->
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
  
  <!-- Load File HTML -->
  <script src="script/load_htmlfile.js"></script>
  <style>
    /* Nền tổng thể */
    body {
      background-color: #fff !important;
      margin: 0;
      padding: 0;
    }
    h3.special-deals-title {
      
      margin: 20px 0 20px 0;
    }
    .game-card {
        background-color: #1b2838;
        /* Xóa toàn bộ border, shadow */
        border: none !important;
        box-shadow: none !important;

        border-radius: 5px;
        overflow: hidden;
        color: #fff;
        /* Giúp card full chiều cao cột */
        height: 100%;
        display: flex;
        flex-direction: column;
        justify-content: space-between;
    }
    /* Ảnh game */
    .position-relative img {
      width: 100%;
      height: 200px;
      object-fit: cover;
    }
    /* Vùng footer card */
    .game-card-footer {
      background-color: #0E1821;
      padding: 8px 12px;
      /* Cố định chiều cao tối thiểu để tránh nhảy lung tung */
      min-height: 70px;
    }
    /* Badge giảm giá */
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
    /* Tên game */
    .game-title {
      font-size: 1rem;
      font-weight: 600;
      margin: 0;
      white-space: nowrap;
      overflow: hidden;
      text-overflow: ellipsis;
      color: #fff;
    }
    /* Giá cũ và giá mới */
    .old-price {
      font-size: 0.85rem;
      text-decoration: line-through;
      color: #999;
    }
    .new-price {
      font-size: 1rem;
      color: #b6f94f; /* Màu xanh sáng, tùy chỉnh */
      font-weight: 700;
    }
  </style>
</head>
<body>

    <?php include 'module/header.php'; ?>
    <div class="container my-2">
        <h3 class="special-deals-title text-center"><?php echo htmlspecialchars($catName); ?></h3>
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <?php if (empty($games)): ?>
            <div class="col">
                <p class="text-white">Không tìm thấy game nào với điều kiện <strong><?php echo htmlspecialchars($catName); ?></strong>.</p>
            </div>
            <?php else: ?>
            <?php foreach ($games as $game): ?>
                <div class="col">
                <a href="chitiet.php?id=<?php echo $game['game_id']; ?>" style="text-decoration: none; color: inherit;">
                    <div class="card game-card">
                    <div class="position-relative">
                        <?php 
                        // Ảnh đầu tiên hoặc placeholder
                        $imgSrc = !empty($game['images']) 
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
                    </div> <!-- end game-card-footer -->
                    </div> <!-- end card -->
                </a>
                </div> <!-- end col -->
            <?php endforeach; ?>

            <?php endif; ?>
        </div> <!-- end row -->
    </div> <!-- end container -->
    <!-- Danh sách game -->
    <?php include 'module/index_m/dsgame.php'; ?>

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
