<?php
session_start();
include 'DBCONN.PHP';
mysqli_set_charset($conn, "utf8");

// Nếu người dùng chưa đăng nhập, chuyển hướng sang trang đăng nhập
if (!isset($_SESSION['user'])) {
    header("Location: dangnhap.php");
    exit;
}

$user_id = $_SESSION['user']['user_Id'];

// Truy vấn lấy danh sách game đã sở hữu từ user_library, kết hợp với bảng game
$sql = "SELECT 
            ul.*, 
            g.game_id,
            g.game_name, 
            g.game_details, 
            (SELECT gi.img_url 
             FROM game_img gi 
             WHERE gi.game_id = g.game_id 
             LIMIT 1) AS img_url
        FROM user_library ul
        JOIN game g ON ul.game_id = g.game_id
        WHERE ul.user_id = '$user_id'
        ORDER BY ul.purchase_date DESC";
$result = mysqli_query($conn, $sql);
$owned_games = [];
if ($result && mysqli_num_rows($result) > 0) {
    while ($row = mysqli_fetch_assoc($result)) {
        $owned_games[] = $row;
    }
}
?>
<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <title>Thư viện của tôi</title>
    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <style>
        
        a {
            color: white;
        }
        .game-card {
            background-color: #2C3E50;
            border-radius: 10px;
            overflow: hidden;
            margin-bottom: 20px;
            transition: transform 0.2s;
        }
        .game-card:hover {
            transform: scale(1.02);
        }
        .game-card img {
            width: 100%;
            height: 140px;
            object-fit: cover;
        }
        .game-card-body {
            padding: 15px;
        }
        .game-card-title {
            font-size: 1.2rem;
            font-weight: bold;
        }
        .purchase-date {
            font-size: 0.9rem;
            color: #ccc;
        }
    </style>
</head>
<body style="background-color: #1B2838;">
    <?php include 'module/header.php'; ?>
    <div class="container mt-5">
        <h1 class="mb-4 text-white text-center">THƯ VIỆN GAME</h1>
        <?php if (count($owned_games) > 0): ?>
            <div class="row">
                <?php foreach ($owned_games as $game): ?>
                    <div class="col-md-3 col-sm-6 mb-4">
                        <div class="game-card">
                            <?php if (!empty($game['img_url'])): ?>
                                <img src="<?php echo $game['img_url']; ?>" alt="<?php echo htmlspecialchars($game['game_name']); ?>">
                            <?php else: ?>
                                <img src="default_image.jpg" alt="No Image">
                            <?php endif; ?>
                            <div class="game-card-body">
                                <p class="game-card-title text-white"><?php echo htmlspecialchars($game['game_name']); ?></p>
                                <p class="purchase-date">Mua: <?php echo date("d/m/Y", strtotime($game['purchase_date'])); ?></p>
                                
                                <a href="" class="btn btn-primary btn-sm">Chơi ngay</a>
                            </div>
                        </div>
                    </div>
                <?php endforeach; ?>
            </div>
        <?php else: ?>
            <p>Bạn chưa sở hữu game nào. Hãy truy cập cửa hàng để mua game!</p>
        <?php endif; ?>
    </div>
    <!-- Fixed -->
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
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
