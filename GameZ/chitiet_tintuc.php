<?php
// KẾT NỐI CSDL
include('DBCONN.PHP');

// Kiểm tra và lấy news_id từ URL
$news_id = isset($_GET['news_id']) ? $_GET['news_id'] : '';
if ($news_id === '') {
    die("Bài viết không tồn tại!");
}

// Truy vấn lấy chi tiết tin tức (THÊM MÔ TẢ)
$sql = "SELECT title, description, content, image, author, created_at FROM news WHERE news_id = ?";
$stmt = $conn->prepare($sql);
$stmt->bind_param("s", $news_id);
$stmt->execute();
$result = $stmt->get_result();

if ($result->num_rows == 0) {
    die("Bài viết không tồn tại!");
}

$news = $result->fetch_assoc();
$stmt->close();
$conn->close();
?>

<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <title><?= htmlspecialchars($news['title']) ?></title>
    <!-- Load File HTML -->
    <script src="script/load_htmlfile.js"></script>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <style>
        body { background-color: #1B2838 !important; color: white; }
        .news-container { max-width: 800px; margin: auto; padding: 20px; background: rgba(0, 0, 0, 0.2); border-radius: 10px; }
        .news-title { font-size: 1.8rem; font-weight: bold; color: aliceblue; }
        .news-meta { font-size: 0.9rem; color: whitesmoke; margin-bottom: 10px; }
        .news-description { font-size: 1rem; font-style: italic; color: #ccc; margin-bottom: 10px; }
        .news-content { font-size: 1rem; line-height: 1.6; color: white; }
        .news-image { width: 100%; max-height: 400px; object-fit: cover; border-radius: 10px; margin-bottom: 20px; }
        .btn-back { margin-top: 20px; background: #007bff; color: white; border-radius: 5px; padding: 10px 15px; display: inline-block; text-decoration: none; }
        .btn-back:hover { background: #0056b3; }
    </style>
</head>
<body>
<?php include 'module/header.php'; ?>

<div class="container py-4">
    <div class="news-container">
        <h1 class="news-title"><?= htmlspecialchars($news['title']) ?></h1>
        <p class="news-meta">Tác giả: <?= htmlspecialchars($news['author'] ?: 'Không rõ') ?> | Ngày đăng: <?= date('d/m/Y', strtotime($news['created_at'])) ?></p>
        <p class="news-description"><?= nl2br(htmlspecialchars($news['description'] ?: 'Không có mô tả')) ?></p>
        
        <img src="<?= htmlspecialchars($news['image']) ?: 'default-news.jpg' ?>" alt="News Image" class="news-image">
        
        <div class="news-content"><?= nl2br(htmlspecialchars($news['content'])) ?></div>
        <a href="tintuc.php" class="btn-back">← Quay lại danh sách</a>
    </div>
</div>
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
</body>
</html>
