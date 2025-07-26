<?php
if (session_status() == PHP_SESSION_NONE) {
    session_start();
}

// Nếu có tham số logout thì xóa session và chuyển hướng về trang chủ
if (isset($_GET['logout'])) {
    session_destroy();
    header("Location: index.php");
    exit();
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.7.1/css/all.min.css">
    <title>header</title>
    <style>
        .nav-links, .log-item, .navbar-brand1 {
            color: #b0b0b0 !important;
            text-decoration: none !important; 
        }
        .nav-links:hover, .log-item:hover {
            color: #ffffff !important;
            text-decoration: underline !important;
        }
    </style>
</head>
<body>
    <header>
        <nav style="padding: 0;" class="navbar navbar-expand-lg navbar-light bg-body-tertiary">
            <div style="border-bottom: 1px solid rgba(178, 128, 128, 0.5);" class="container-fluid bg-black py-2 px-4 px-lg-5">
                <a style="margin-right: 9px;" class="navbar-brand1" href="index.php">GAMEZ | Kho Game Chất Lượng</a>
                <span style="color: #b0b0b0;">|</span>
                <ul class="navbar-nav me-auto mb-lg-0 d-lg-none">
                    <li class="nav-item">
                        <a style="font-size: 11px; padding-left: 9px; font-weight: 600; color: #fff;" class="nav-link active" aria-current="page" href="index.php">TRANG CHỦ</a>
                    </li>
                </ul>
                <div class="collapse navbar-collapse" id="navbarText">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a style="font-size: 11px; font-weight: 600; color: #fff; margin: 0;" class="nav-link active" aria-current="page" href="index.php">TRANG CHỦ</a>
                        </li>
                    </ul>
                    <span style="font-size: 11px;" class="navbar-text text-white">
                        HOTLINE: +84914938844
                    </span>
                </div>
            </div>
        </nav>
        <!-- Navbar -->
        <subnav id="navbar_top" class="navbar navbar-expand-lg navbar-light bg-body-tertiary py-0">
            <!-- Container wrapper -->
            <div class="container-fluid bg-black px-3 px-lg-5 py-2">
                <!-- Toggle button -->
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                    data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <i style="color: #fff;" class="fas fa-bars"></i>
                </button>
                <a href="index.php" class="d-block d-lg-none">
                    <img src="./img/ALogo_web.png" alt="logo" style="width: 50px;">
                </a>
                <!-- Collapsible wrapper -->
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <!-- Navbar brand -->
                    <a class="navbar-brand mt-2 mt-lg-0 text-white d-none d-lg-block" href="index.php">
                        <img src="img/ALogo_web.png" alt="logo" style="width: 50px;">
                    </a>
                    <!-- Left links -->
                    <ul style="padding-left: 12px;" class="navbar-nav me-auto">
                        <li class="nav-item me-0 me-lg-3 mb-2 mb-lg-0 mt-3 mt-lg-0">
                            <a class="nav-links fw-bold" href="index.php">TRANG CHỦ</a>
                        </li>
                        <li class="nav-item me-0 me-lg-3 mb-2 mb-lg-0">
                            <a class="nav-links fw-bold" href="sanpham.php">DANH SÁCH</a>
                        </li>
                        <li class="nav-item mb-2 mb-lg-0">
                            <a class="nav-links fw-bold" href="tintuc.php">TIN TỨC GAME</a>
                        </li>
                    </ul>
                    <!-- Thanh search -->
                    <div class="d-flex justify-content-center me-0 me-lg-3 mt-2 d-none d-lg-block">
                        <form class="d-flex search-bar" role="search" method="GET" action="kqtimkiem.php">
                            <input class="form-control me-1" type="search" name="q" placeholder="Bạn tìm gì ?" aria-label="Search"
                                   style="min-width: 220px; max-width: 400px;">
                            <button class="btn btn-light" type="submit">
                                <i class="fa-solid fa-magnifying-glass" style="color: black;"></i>
                            </button>
                        </form>
                    </div>
                    <!-- Right elements -->
                    <ul style="padding-left: 12px;" class="navbar-nav">
                        <li class="nav-item d-flex align-items-center me-0 me-lg-3 mb-2 mb-lg-0">
                            <a class="text-reset me-1" href="#">
                                <i class="fas fa-user text-white"></i>
                            </a>
                            <?php if (isset($_SESSION['user'])): ?>
                                <a class="nav-links log-item fw-bold" href="index.php?logout=1" onclick="confirmLogout()"><?php echo $_SESSION['user']['user_Name']; ?></a>
                            <?php else: ?>
                                <a class="nav-links log-item fw-bold" href="dangnhap.php">Đăng Nhập</a>
                            <?php endif; ?>
                        </li>
                        <li class="nav-item d-flex align-items-center me-0 me-lg-3 mb-2 mb-lg-0">
                            <a class="text-reset me-1" href="#">
                                <i class="fas fa-bag-shopping text-white"></i>
                            </a>
                            <a class="nav-links log-item fw-bold" href="giohang.php">Giỏ Hàng</a>
                        </li>
                        <li class="nav-item d-flex align-items-center">
                            <a class="text-reset me-1" href="#">
                                <i class="fa-solid fa-bookmark text-white"></i>
                            </a>
                            
                            <a class="nav-links log-item fw-bold" href="thuvien.php">Thư viện</a>
                        </li>
                    </ul>
                    <!-- Thanh search mobile -->
                    <div class="d-flex justify-content-center me-auto mt-2 d-block d-lg-none">
                        <form class="d-flex search-bar" role="search" method="GET" action="kqtimkiem.php">
                            <input class="form-control me-1" type="search" name="q" placeholder="Bạn tìm gì ?" aria-label="Search"
                                   style="min-width: 220px; max-width: 400px;">
                            <button class="btn btn-light" type="submit">
                                <i class="fa-solid fa-magnifying-glass" style="color: black;"></i>
                            </button>
                        </form>
                    </div>
                </div>
                <!-- Collapsible wrapper -->
            </div>
            <!-- Container wrapper -->
        </subnav>
        <!-- Navbar -->
    </header>
    <script>
function confirmLogout() {
    if (confirm("Bạn có chắc chắn muốn đăng xuất không?")) {
        window.location.href = "?logout=1"; // Nếu đồng ý, thực hiện đăng xuất
    }
    else {
        event.preventDefault(); // Nếu không đồng ý, ngăn chặn hành động mặc định
    }
}
</script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" defer></script>
</body>
</html>
