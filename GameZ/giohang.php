<?php
if (session_status() == PHP_SESSION_NONE) {
    session_start();
}
include 'DBCONN.PHP';
mysqli_set_charset($conn, "utf8");

// Nếu người dùng chưa đăng nhập, chuyển hướng sang trang đăng nhập
if (!isset($_SESSION['user'])) {
    header("Location: dangnhap.php");
    exit;
}
$user_id = $_SESSION['user']['user_Id'];

// Truy vấn lấy danh sách sản phẩm trong giỏ hàng với ảnh dùng subquery
$sqlCart = "SELECT 
    c.cart_id, 
    c.game_id, 
    c.time_add, 
    c.price_at_add_time, 
    g.game_name,
    (SELECT gi.img_url 
     FROM game_img gi 
     WHERE gi.game_id = g.game_id 
     LIMIT 1) AS img_url
FROM cart c
JOIN game g ON c.game_id = g.game_id
WHERE c.user_id = '$user_id'
ORDER BY c.time_add DESC";
$resultCart = mysqli_query($conn, $sqlCart);
$total_items = mysqli_num_rows($resultCart);

// Truy vấn tính tổng tiền của giỏ hàng
$sqlTotal = "SELECT SUM(price_at_add_time) AS total FROM cart WHERE user_id = '$user_id'";
$resultTotal = mysqli_query($conn, $sqlTotal);
$rowTotal = mysqli_fetch_assoc($resultTotal);
$total_price = $rowTotal['total'] ?? 0;
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.7.1/css/all.min.css">
    <!-- Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- favicon -->
    <link rel="icon" type="image/x-icon" href="favicon.ico">
    <!-- Load File HTML -->
    <script src="script/load_htmlfile.js"></script>
    <title>GameZ Store</title>
    <style>
        /* CSS cho container ảnh theo tỉ lệ 16:9 */
        .img-container {
            width: 160px; /* Chiều rộng cố định */
            height: 90px; /* Chiều cao = 160 * 9/16 */
            border: 1px solid white;
            overflow: hidden;
        }
        .img-container img {
            width: 100%;
            height: auto;
            object-fit: cover;
        }
        /* CSS cho đường line ngăn cách giữa các sản phẩm */
        .separator {
            border-top: 2px solid #ccc;
            margin: 20px 0;
        }
    </style>
</head>
<body style="font-family: system-ui, -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif; background-color: #1B2838;">
    <?php include 'module/header.php'; ?>
    <div id="dropdown"></div>
    
    <section style="padding-top:100px;">
        <div class="container h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col">
                    <div style="text-align: center; margin-bottom: 40px;">
                        <p>
                            <span style="font-weight: 600; color: black;" class="h2 my-bag text-white">
                                GIỎ HÀNG CỦA BẠN
                            </span>
                        </p>
                        <p>
                            <span style="font-weight: 400;" class="text-white">
                                Hiện đang có <?php echo $total_items; ?> sản phẩm
                            </span>
                        </p>
                    </div>
                     
                    <div class="card-body p-4">
                        <?php while($row = mysqli_fetch_assoc($resultCart)): ?>
                        <div class="container-md w-100">
                            <div class="row">
                                <!-- Container ảnh với tỉ lệ 16:9 -->
                                <div class="col-md-2 col-4 text-white">
                                    <div class="img-container">
                                        <?php if (!empty($row['img_url'])): ?>
                                            <img src="<?php echo $row['img_url']; ?>" 
                                                 alt="<?php echo htmlspecialchars($row['game_name']); ?>">
                                        <?php else: ?>
                                            <img src="default_image.jpg" 
                                                 alt="No Image">
                                        <?php endif; ?>
                                    </div>
                                </div>
                                <!-- Thông tin game -->
                                <div class="col-md-4 col-8 d-flex">
                                    <div>
                                        <p class="lead-text m-0 text-white">
                                            <?php echo htmlspecialchars($row['game_name']); ?>
                                        </p>
                                        <p class="small-text text-white">
                                            Đơn giá: 
                                            <span style="color: red !important;">
                                                <?php echo number_format($row['price_at_add_time']); ?>
                                            </span>
                                        </p>
                                    </div>
                                </div>
                                <!-- Thành tiền và link XÓA -->
                                <div class="col-md d-flex justify-content-end">
                                    <div>
                                        <p class="small-text mb-2 text-white">
                                            Thành tiền: 
                                            <span><?php echo number_format($row['price_at_add_time']); ?>Đ</span>
                                        </p>
                                        <p style="text-align: right; font-size: 13px; font-weight: 300;" class="small-textx mb-0">
                                            <a href="delete_cart.php?cart_id=<?php echo $row['cart_id']; ?>" 
                                               style="color: red; text-decoration: none;">
                                                XÓA
                                            </a>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <!-- Đường line ngăn cách -->
                            <hr class="separator">
                        </div>
                        <?php endwhile; ?>
                    </div>

                    <div class="card-body p-4 pt-0">
                        <div class="container-md w-100">
                            <!-- Nút xóa hết giỏ hàng -->
                            <div class="d-flex justify-content-end mb-3">
                                <a href="delete_cart.php?clear_cart=1" onclick="return confirm('Bạn có chắc muốn xóa hết giỏ hàng không?');">
                                    <button type="button" style="background-color: red;" class="btn shadow-none rounded-0 text-white">XÓA HẾT</button>
                                </a>
                            </div>
                            <div class="row">
                                <p class="mb-0 d-flex align-items-center justify-content-end">
                                    <span class="small fs-6 me-2 text-white">Tổng cộng:</span>
                                    <span class="lead fs-4 fw-light" style="color: red !important;">
                                        <?php echo number_format($total_price); ?>Đ
                                    </span>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="container">
                        <div class="d-flex justify-content-end p-4 pt-0">
                            <a href="sanpham.php">
                                <button type="button" style="background-color: black;" class="btn shadow-none rounded-0 me-2 text-white">
                                    TIẾP TỤC MUA HÀNG
                                </button>
                            </a>

                            <?php if ($total_items > 0): ?>
                                <!-- Nếu có sản phẩm trong giỏ hàng thì cho sang trang thanh toán -->
                                <a href="thanhtoan.php">
                                    <button type="button" style="background-color: red;" class="btn shadow-none rounded-0 text-white">
                                        THANH TOÁN NGAY
                                    </button>
                                </a>
                            <?php else: ?>
                                <!-- Nếu giỏ hàng trống thì hiển thị cảnh báo (không dẫn link đi đâu) -->
                                <button type="button" style="background-color: red;" 
                                        class="btn shadow-none rounded-0 text-white"
                                        onclick="alert('Giỏ hàng đang trống, không thể thanh toán!');">
                                    THANH TOÁN NGAY
                                </button>
                            <?php endif; ?>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Footer -->
    <footer id="footer"></footer>
    <!-- Fixed Script -->
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            window.addEventListener('scroll', function () {
                if (window.scrollY > 50) {
                    document.getElementById('navbar_top').classList.add('fixed-top');
                    var navbar_height = document.querySelector('.navbar').offsetHeight;
                    document.body.style.paddingTop = navbar_height + 'px';
                } else {
                    document.getElementById('navbar_top').classList.remove('fixed-top');
                    document.body.style.paddingTop = '0';
                }
            });
        });
    </script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
