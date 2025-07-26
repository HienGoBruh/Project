<?php
// KẾT NỐI CSDL
include('DBCONN.PHP');

// Số tin tức trên mỗi trang
$newsPerPage = 5;

// Xác định trang hiện tại
$page = isset($_GET['page']) ? (int)$_GET['page'] : 1;
$page = max($page, 1); // Không cho phép trang nhỏ hơn 1

// Tính OFFSET cho truy vấn SQL
$offset = ($page - 1) * $newsPerPage;

// Lấy danh sách tin tức theo trang
$sql = "SELECT news_id, title, description, image, author, created_at 
        FROM news 
        ORDER BY created_at DESC 
        LIMIT $newsPerPage OFFSET $offset";
$result = $conn->query($sql);

// Đưa dữ liệu vào mảng
$newsList = [];
if ($result && $result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $newsList[] = $row;
    }
}

// Lấy tổng số tin tức để tính số trang
$totalNewsQuery = "SELECT COUNT(*) AS total FROM news";
$totalResult = $conn->query($totalNewsQuery);
$totalRow = $totalResult->fetch_assoc();
$totalNews = (int) $totalRow['total'];

// Tính tổng số trang
$totalPages = ceil($totalNews / $newsPerPage);

$conn->close();
?>

<!DOCTYPE html>
<html lang="vi">
<head>
  <meta charset="UTF-8">
  <title>Danh sách Tin tức</title>

  <!-- Load File HTML -->
  <script src="script/load_htmlfile.js"></script>
  <!-- Boostrap -->
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
  <style>
    .news-item {
      padding: 10px 0;
      border-bottom: 1px solid rgba(0,0,0,0.1);
      display: flex;
      cursor: pointer;
      transition: background-color 0.2s;
    }
    .news-item:hover { background-color:rgb(5, 5, 5); }
    .news-thumb { width: 140px; height: 80px; object-fit: cover; border: 1px solid #ccc; margin-right: 10px; }
    .news-title { font-weight: bold; font-size: 1.1rem; color: aliceblue;}
    .news-desc { font-size: 0.9rem; color: white; }
    .news-meta { font-size: 0.8rem; color: whitesmoke; }
  </style>
</head>
<body style="background-color: #1B2838;">
<?php include 'module/header.php'; ?>
<div id="dropdown"></div>
<div class="container py-4">
  <h4 class="mb-3 text-white">Danh sách Tin tức</h4>
  <div id="newsList">
    <?php foreach ($newsList as $news): ?>
      <a href="chitiet_tintuc.php?news_id=<?= htmlspecialchars($news['news_id']) ?>" style="text-decoration: none; color: inherit;">
        <div class="news-item">
          <img class="news-thumb" src="<?= htmlspecialchars($news['image']) ?: 'default-news.jpg' ?>" alt="News Image">
          <div>
            <div class="news-title"> <?= htmlspecialchars($news['title']) ?> </div>
            <div class="news-desc"> <?= nl2br(htmlspecialchars($news['description'] ?: '')) ?> </div>
            <div class="news-meta">Tác giả: <?= htmlspecialchars($news['author'] ?: 'Không rõ') ?> | <?= date('d/m/Y', strtotime($news['created_at'])) ?></div>
          </div>
        </div>
      </a>
    <?php endforeach; ?>
  </div>

  <!-- Phân trang -->
  <nav class="mt-4">
    <ul class="pagination justify-content-center">
      <?php if ($page > 1): ?>
        <li class="page-item"><a class="page-link" href="?page=<?= $page - 1 ?>">« Trước</a></li>
      <?php endif; ?>

      <?php for ($i = 1; $i <= $totalPages; $i++): ?>
        <li class="page-item <?= ($i == $page) ? 'active' : '' ?>">
          <a class="page-link" href="?page=<?= $i ?>"><?= $i ?></a>
        </li>
      <?php endfor; ?>

      <?php if ($page < $totalPages): ?>
        <li class="page-item"><a class="page-link" href="?page=<?= $page + 1 ?>">Sau »</a></li>
      <?php endif; ?>
    </ul>
  </nav>
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
