<?php
// Bật hiển thị lỗi (nếu cần debug)
error_reporting(E_ALL);
ini_set('display_errors', 1);

// Kết nối DB
include ('DBCONN.PHP');

// Truy vấn: chỉ lấy 1 ảnh cho mỗi game (subquery)
$sql = "
    SELECT 
        g.game_id,
        g.game_name,
        p.price_value,
        d.discount_value,
        (
            SELECT i2.img_url 
            FROM game_img i2 
            WHERE i2.game_id = g.game_id 
            LIMIT 1
        ) AS img_url
    FROM game g
    JOIN game_price p ON g.game_id = p.game_id
    JOIN game_discounts gd ON g.game_id = gd.game_id
    JOIN discounts d ON gd.discount_id = d.discount_id
    WHERE d.start_date <= CURDATE() AND d.end_date >= CURDATE()
    ORDER BY g.game_id ASC
    LIMIT 9;
";

$result = $conn->query($sql);

// Lưu tất cả dữ liệu vào mảng $games
$games = [];
if ($result) {
    while ($row = $result->fetch_assoc()) {
        $games[] = $row;
    }
}

// Đóng kết nối
$conn->close();

// Chia mảng $games thành các nhóm, mỗi nhóm tối đa 3 game
$chunkedGames = array_chunk($games, 3);

// Giới hạn hiển thị tối đa 3 slide
$maxSlides = 3;
?>
<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <title>Game đang giảm giá</title>
    <!-- Link CSS Bootstrap 5 -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
    <style>
        .card-img-top {
            height: 200px;
            object-fit: cover;
        }
        .discount-badge {
            position: absolute;
            top: 10px;
            left: 10px;
            background: #dc3545;
            color: #fff;
            padding: 5px 8px;
            font-size: 14px;
            border-radius: 4px;
        }
        .old-price {
            text-decoration: line-through;
            color: white !important;
        }
        .new-price {
            padding-bottom: 10px;
        }
        /* Class mới cho card body với góc dưới bo tròn */
        .custom-card-body {
            background-color: #0E1821 !important;
            border-bottom-left-radius: 10px !important;
            border-bottom-right-radius: 10px !important;
            padding: 1rem !important;
        }
        .card-a a{
            text-decoration: none;
            color: inherit;
        }
    </style>
</head>
<body>

<div class="container mt-4">
    <h6 class="mb-2">GIẢM GIÁ HOT</h6>

    <?php if (count($games) == 0): ?>
        <p class="text-center text-danger">Không có game giảm giá nào!</p>
    <?php else: ?>
    
    <!-- BẮT ĐẦU CAROUSEL -->
    <div id="discountCarousel" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-indicators indicatorsCus mb-5">
            <?php for ($i = 0; $i < min($maxSlides, count($chunkedGames)); $i++): ?>
                <button type="button" data-bs-target="#discountCarousel" data-bs-slide-to="<?php echo $i; ?>" <?php echo ($i === 0) ? 'class="active" aria-current="true"' : ''; ?> aria-label="Slide <?php echo $i+1; ?>"></button>
            <?php endfor; ?>
        </div>
        <div class="carousel-inner">

            <?php 
            // Lặp qua các nhóm (slide)
            for ($i = 0; $i < min($maxSlides, count($chunkedGames)); $i++):
                // Xác định slide đầu tiên active
                $activeClass = ($i === 0) ? 'active' : '';
            ?>
            <div class="carousel-item <?php echo $activeClass; ?>">
                <div class="row justify-content-center">
                    <?php 
                    // Lặp qua các game trong nhóm
                    foreach ($chunkedGames[$i] as $game):
                        $old_price = $game['price_value'];
                        $discount  = $game['discount_value'];
                        if ($discount > 100) {
                            // Nếu discount_value > 100: giảm giá theo giá trị cố định, tính phần trăm giảm
                            $new_price = $old_price - $discount;
                            $computed_discount = round(($discount / $old_price) * 100);
                        } else {
                            // Nếu discount_value <= 100: giảm giá theo phần trăm
                            $new_price = $old_price * (1 - $discount / 100);
                        }
                        $img_url = $game['img_url'];
                    ?>
                    <div class="col-md-4 mb-4">
                        <div class="card position-relative" style="background-color: #0E1821;">
                            <!-- Badge hiển thị discount -->
                            <div class="discount-badge">
                                -<?php 
                                    if ($discount > 100) { 
                                        echo $computed_discount . '%'; 
                                    } else { 
                                        echo $discount . '%'; 
                                    }
                                ?>
                            </div>
                            
                            <!-- Ảnh game -->
                            <a href="chitiet.php?id=<?php echo $game['game_id']; ?>">
                                <img 
                                src="<?php echo $img_url; ?>" 
                                class="card-img-top" 
                                alt="<?php echo htmlspecialchars($game['game_name']); ?>"
                                >
                            </a>
                            
                            
                            <div class="card-body text-white custom-card-body card-a">
                                <!-- Tên game -->
                                <a href="chitiet.php?id=<?php echo $game['game_id']; ?>">
                                    <h5 class="card-title text-white">
                                        <?php echo htmlspecialchars($game['game_name']); ?>
                                    </h5>
                                    
                                    <!-- Hiển thị giá cũ và giá mới -->
                                    <p class="card-text mb-1">
                                        <span class="old-price">
                                            <?php echo number_format($old_price, 0, ',', '.'); ?>₫
                                        </span>
                                    </p>
                                    <p class="card-text text-danger fw-bold new-price">
                                        <?php echo number_format($new_price, 0, ',', '.'); ?>₫
                                    </p>
                                </a>
                                
                                
                            </div>
                        </div>
                    </div>
                    <?php endforeach; // end foreach game ?>
                </div>
            </div>
            <?php endfor; // end for slides ?>

        </div> <!-- end .carousel-inner -->

        <!-- Nút điều khiển Carousel được đưa ra ngoài carousel -->
        <button class="carousel-control-prev d-none d-lg-block" type="button" data-bs-target="#discountCarousel" data-bs-slide="prev">
            <span class="carousel-control-prev-icon me-3" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next d-none d-lg-block" type="button" data-bs-target="#discountCarousel" data-bs-slide="next">
            <span class="carousel-control-next-icon ms-3" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>
    <!-- KẾT THÚC CAROUSEL -->

    <?php endif; ?>

</div>

<!-- Bootstrap JS -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
