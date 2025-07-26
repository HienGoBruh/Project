<?php
// Kết nối CSDL
include ('DBCONN.PHP');

// Truy vấn chỉ lấy thể loại có ảnh (img_url không rỗng)
$sql = "SELECT categories_name, img_url
        FROM categories
        WHERE img_url IS NOT NULL
          AND img_url <> ''
        LIMIT 12;";

$result = $conn->query($sql);

// Mảng chứa các thể loại
$categories = [];
if ($result && $result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $categories[] = [
            'categories_name' => $row['categories_name'],
            'img_url'         => $row['img_url']
        ];
    }
}
$conn->close();

// Chia mảng $categories thành các nhóm, mỗi nhóm tối đa 4 thể loại
$chunkedCategories = array_chunk($categories, 4);
?>

<!DOCTYPE html>
<html lang="vi">
<head>
  <meta charset="UTF-8">
  <title>Duyệt theo thể loại</title>
  <!-- Link CSS Bootstrap 5.3 -->
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
  <style>
    /* Nền tối cho khu vực */
    section.topic-section {
      padding: 2rem 0;
      background-color:rgb(238, 240, 242);
    }
    .topic-section h6 {
      color: #fff;
      margin-bottom: 1rem;
    }

    /* Card tùy chỉnh cho các chủ đề */
    .topic-card {
      background-color: #0E1821;
      border: none;
      border-radius: 8px;
      overflow: hidden;
      position: relative;
      height: 200px; /* chiều cao tùy ý */
      color: #fff;
      text-align: center;
      transition: transform 0.3s;
      background-size: cover;
      background-position: center;
    }
    .topic-card:hover {
      transform: scale(1.03); /* zoom ảnh */
    }
    .topic-card::before {
      content: "";
      position: absolute;
      inset: 0;
      background: rgba(0, 0, 0, 0.4);
      transition: background 0.3s ease;
    }
    .topic-card:hover::before {
      background: rgba(0, 0, 0, 0.2);
    }

    /* Nút hiển thị tên chủ đề */
    .topic-card span.btn-topic {
      position: absolute;
      top: 50%;
      left: 50%;
      transform: translate(-50%, -50%);
      background-color: #fff;
      color: transparent;
      font-weight: bold;
      border: 1px solid #fff;
      -webkit-text-fill-color: transparent;
      -webkit-background-clip: text;
      background-clip: text;
      padding: 0.5rem 1rem;
      transition: all 0.3s ease;
      z-index: 1;
      white-space: nowrap;
      display: inline-block;
    }
    /* Khi hover card, nút chạy xuống đáy */
    .topic-card:hover span.btn-topic {
      top: auto;
      bottom: 10px;
      left: 50%;
      transform: translateX(-50%);
    }
  </style>
</head>
<body>

<section class="topic-section">
  <div class="container">
    <h6 class="text-uppercase" style="color:black;">Duyệt theo thể loại</h6>

    <?php if (empty($categories)): ?>
      <!-- Trường hợp không có thể loại nào -->
      <p class="text-center text-white">Chưa có thể loại nào!</p>
    <?php else: ?>
      <div id="topicCarousel" class="carousel slide" data-bs-ride="carousel">
        
        <!-- Indicators (các chấm) -->
        <div class="carousel-indicators">
          <?php for ($i = 0; $i < count($chunkedCategories); $i++): ?>
            <button type="button" 
                    data-bs-target="#topicCarousel" 
                    data-bs-slide-to="<?php echo $i; ?>" 
                    <?php echo ($i === 0) ? 'class="active" aria-current="true"' : ''; ?>
                    aria-label="Slide <?php echo ($i+1); ?>">
            </button>
          <?php endfor; ?>
        </div>

        <div class="carousel-inner align-items-center">
          <?php foreach ($chunkedCategories as $slideIndex => $categoryGroup): ?>
            <?php $activeClass = ($slideIndex === 0) ? 'active' : ''; ?>

            <div class="carousel-item <?php echo $activeClass; ?>">
              <div class="row g-3 justify-content-center">
              <?php foreach ($categoryGroup as $catData): ?>
              <?php 
                $catName = htmlspecialchars($catData['categories_name']);
                $catImg  = htmlspecialchars($catData['img_url']);
              ?>
              <div class="col-12 col-sm-6 col-md-3">
                <!-- Bao toàn bộ topic-card trong 1 thẻ a -->
                <a href="hientheloai.php?cat=<?php echo urlencode($catName); ?>" class="text-decoration-none">
                  <div class="topic-card" style="background-image: url('<?php echo $catImg; ?>');">
                    
                    <span class="btn-topic rounded">
                      <?php echo $catName; ?>
                    </span>
                  </div>
                </a>
              </div>
            <?php endforeach; ?>
              </div>
            </div>

          <?php endforeach; ?>
        </div><!-- .carousel-inner -->

        <!-- Nút điều hướng trái/phải -->
        <button class="carousel-control-prev" type="button" data-bs-target="#topicCarousel" data-bs-slide="prev">
          <span class="carousel-control-prev-icon me-3" aria-hidden="true"></span>
          <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#topicCarousel" data-bs-slide="next">
          <span class="carousel-control-next-icon ms-3" aria-hidden="true"></span>
          <span class="visually-hidden">Next</span>
        </button>

      </div> <!-- end #topicCarousel -->
    <?php endif; ?>

  </div> <!-- end .container -->
</section>

<!-- Bootstrap JS -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
