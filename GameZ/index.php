<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- Font Awsome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.7.1/css/all.min.css">
    <!-- Boostrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    
    <!-- favicon -->
    <link rel="icon" type="image/x-icon" href="favicon.ico">
    <!-- Load File HTML -->
    <script src="script/load_htmlfile.js"></script>

    <!-- CSS -->
    <link rel="stylesheet" href="css/carousel.css">
    
    <title>GameZ Store</title>
</head>

<body style="font-family: system-ui, -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif; background-color:rgb(238, 240, 242);">

    <?php include 'module/header.php'; ?>
    <div id="dropdown"></div>
    
    <!-- Carousel QC -->
    <?php
        // Kết nối đến CSDL
        include ('DBCONN.PHP');

        // SQL truy vấn lấy thông tin game 
        $sql = "SELECT  
                    g.game_id,
                    g.game_name,
                    p.price_value,
                    d.discount_value
                FROM game g
                JOIN game_price p ON g.game_id = p.game_id
                JOIN game_discounts gd ON g.game_id = gd.game_id
                JOIN discounts d ON gd.discount_id = d.discount_id
                WHERE d.start_date <= CURDATE() AND d.end_date >= CURDATE()
                LIMIT 4";

        $result = $conn->query($sql);

        // Tạo mảng lưu các bản ghi để dùng lại cho indicators và slides
        $slides = [];
        if ($result->num_rows > 0) {
            while ($row = $result->fetch_assoc()){
                $slides[] = $row;
            }
        }
        ?>
        <div class="container mt-4">
            <div id="gameCarousel" class="carousel slide" data-bs-ride="carousel">
                <!-- Indicators -->
                <div class="carousel-indicators">
                    <?php 
                    foreach ($slides as $index => $slide) {
                        $activeClass = ($index == 0) ? 'active' : '';
                        ?>
                        <button type="button" data-bs-target="#gameCarousel" data-bs-slide-to="<?php echo $index; ?>" 
                                class="<?php echo $activeClass; ?> bg-primary-subtle" 
                                aria-current="<?php echo ($index == 0 ? 'true' : 'false'); ?>" 
                                aria-label="Slide <?php echo $index+1; ?>"></button>
                        <?php
                    }
                    ?>
                </div>

                <div class="carousel-inner">
                    <h6 class=" ms-3">ÐÁNG CHÚ Ý & NÊN XEM</h6>
                    <?php 
                    if (!empty($slides)) {
                        foreach ($slides as $index => $row) {
                            $activeClass = ($index == 0) ? 'active' : '';
                            $gameId = $row['game_id'];

                            // Truy vấn lấy danh sách ảnh của game theo thứ tự tăng dần của id (hoặc thứ tự phù hợp)
                            $sqlImages = "SELECT img_url FROM game_img WHERE game_id = '$gameId' ORDER BY img_id ASC";
                            $resultImages = $conn->query($sqlImages);
                            $images = [];
                            if ($resultImages->num_rows > 0) {
                                while($img = $resultImages->fetch_assoc()){
                                    $images[] = $img['img_url'];
                                }
                            }
                            // Ảnh đại diện
                            $bigImage = isset($images[0]) ? $images[0] : '';

                            // Các ảnh thumbnail
                            if (count($images) >= 4) {
                                $thumbs = array_slice($images, 1, 3);
                                $thumbs[] = $images[0];
                            } else {
                                // Nếu không đủ 4 ảnh, sử dụng các ảnh có được và lặp lại ảnh đầu tiên cho đủ 4 ảnh
                                $thumbs = array_slice($images, 1);
                                while(count($thumbs) < 3) {
                                    $thumbs[] = $images[0];
                                }
                                $thumbs[] = $images[0];
                            }
                            
                            // Tính giá sau khi giảm:
                            // Nếu discount_value > 100 thì tính giảm giá theo giá trị cố định, ngược lại giảm theo phần trăm
                            $originalPrice = $row['price_value'];
                            if ($originalPrice > 0 && $row['discount_value'] > 0) {
                                if ($row['discount_value'] > 100) {
                                    $discountedPrice = $originalPrice - $row['discount_value'];
                                } else {
                                    $discountedPrice = $originalPrice - ($originalPrice * $row['discount_value'] / 100);
                                }
                            } else {
                                $discountedPrice = $originalPrice;
                            }
                            ?>
                            <a href="chitiet.php?id=<?php echo $gameId; ?>" style="text-decoration: none; color: inherit;">
                                <div class="carousel-item <?php echo $activeClass; ?>">
                                    <div class="container">
                                        <div class="row g-0">
                                            <!-- Cột bên trái: Ảnh lớn -->
                                            <div class="col-md-8">
                                                <div class="big-image">
                                                    <img src="<?php echo $bigImage; ?>" alt="Ảnh đại diện của <?php echo $row['game_name']; ?>">
                                                </div>
                                            </div>
                                            <!-- Cột bên phải: Thông tin game -->
                                            <div class="col-md-4 info-panel p-4 d-none d-lg-block">
                                                <h3 class="mb-3"><?php echo $row['game_name']; ?></h3>
                                                <!-- Thumbnails: hiển thị 4 ảnh theo thứ tự đã định nghĩa -->
                                                <div class="row row-cols-2 thumbnail-grid">
                                                    <?php foreach ($thumbs as $thumb): ?>
                                                    <div class="col">
                                                        <img src="<?php echo $thumb; ?>" alt="Thumbnail">
                                                    </div>
                                                    <?php endforeach; ?>
                                                </div>
                                                <!-- Thông tin game -->
                                                <div class="game-info mt-3">
                                                    <p class="rounded-1 px-1 mb-3" style="background-color: gray; width: fit-content;">
                                                        Nổi bật
                                                    </p>
                                                    <p>
                                                        <strong>
                                                            <?php 
                                                            if ($originalPrice > 0) {
                                                                if($row['discount_value'] > 0) {
                                                                    // Hiển thị giá gốc bị gạch ngang và giá sau giảm
                                                                    echo '<span style="text-decoration: line-through; color: #888;">' 
                                                                        . number_format($originalPrice, 0, ',', '.') . 'đ</span> ';
                                                                    echo '<span>' . number_format($discountedPrice, 0, ',', '.') . 'đ</span>';
                                                                } else {
                                                                    echo number_format($originalPrice, 0, ',', '.') . 'đ';
                                                                }
                                                            } else {
                                                                echo 'Miễn Phí';
                                                            }
                                                            ?>
                                                        </strong>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </a>
                            <?php
                        }
                    } else {
                        echo '<p>Không có game nào được tìm thấy.</p>';
                    }
                    ?>
                </div>

                <!-- Nút điều hướng carousel trái/phải -->
                <button class="carousel-control-prev" type="button" data-bs-target="#gameCarousel" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true" style="width: 40px; height: 80px;"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#gameCarousel" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true" style="width: 40px; height: 80px;"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>
        </div>
        <?php 
        $conn->close();
    ?>
    <!-- Game Giảm giá -->
    <?php include 'module/index_m/hotdiscount.php'; ?>

    <!-- Duyệt theo thể loại -->
    <?php include 'module/index_m/duyettheloai.php'; ?>
    
    <!-- Danh sách game -->
    <?php include 'module/index_m/dsgame.php'; ?>

    <!-- Footer -->
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
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>

</body>
</html>