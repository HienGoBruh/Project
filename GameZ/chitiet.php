<?php
if (session_status() == PHP_SESSION_NONE) {
    session_start();
}
include 'DBCONN.PHP';
mysqli_set_charset($conn, "utf8");

// Xử lý yêu cầu thêm vào giỏ hàng qua POST
if (isset($_POST['action']) && $_POST['action'] === 'addToCart') {
    // Kiểm tra đăng nhập
    if (!isset($_SESSION['user'])) {
        echo json_encode(['status' => 'error', 'message' => 'Vui lòng đăng nhập để thêm vào giỏ hàng.']);
        exit;
    }
    
    $game_id = $_POST['game_id'];
    $user_id = $_SESSION['user']['user_Id'];

    // Kiểm tra nếu game đã có trong giỏ hàng của user
    $sqlCheck = "SELECT * FROM cart WHERE user_id = '$user_id' AND game_id = '$game_id'";
    $resultCheck = mysqli_query($conn, $sqlCheck);
    if (mysqli_num_rows($resultCheck) > 0) {
        echo json_encode(['status' => 'error', 'message' => 'Game đã có trong giỏ hàng.']);
        exit;
    }
    
    /* Truy vấn lấy giá hiện hành của game và thông tin giảm giá nếu có.
       Nếu có giảm giá: discount_value <= 100: giảm theo %; >100: giảm theo số tiền.
    */
    $sqlPrice = "SELECT gp.price_value, di.discount_value 
                 FROM game_price gp 
                 LEFT JOIN game_discounts gd ON gp.game_id = gd.game_id 
                 LEFT JOIN discounts di ON gd.discount_id = di.discount_id 
                 WHERE gp.game_id = '$game_id' 
                 ORDER BY gp.start_date DESC 
                 LIMIT 1";
    $resultPrice = mysqli_query($conn, $sqlPrice);
    if ($resultPrice && mysqli_num_rows($resultPrice) > 0) {
        $rowPrice = mysqli_fetch_assoc($resultPrice);
        $price = $rowPrice['price_value'];
        if (isset($rowPrice['discount_value']) && $rowPrice['discount_value'] > 0) {
            $discount = $rowPrice['discount_value'];
            if ($discount <= 100) {
                $finalPrice = $price * (1 - $discount / 100);
            } else {
                $finalPrice = $price - $discount;
            }
        } else {
            $finalPrice = $price;
        }
    } else {
        echo json_encode(['status' => 'error', 'message' => 'Không tìm thấy giá của game.']);
        exit;
    }
    
    // Sinh cart_id theo dạng "cart" + số thứ tự dựa trên giá trị số lớn nhất hiện có
    $sqlMax = "SELECT MAX(CAST(SUBSTRING(cart_id, 5) AS UNSIGNED)) AS max_id FROM cart WHERE cart_id LIKE 'cart%'";
    $resultMax = mysqli_query($conn, $sqlMax);
    $rowMax = mysqli_fetch_assoc($resultMax);
    $max_id = isset($rowMax['max_id']) ? $rowMax['max_id'] : 0;
    $cart_id = "cart" . ($max_id + 1);
    
    $time_add = date('Y-m-d');

    // Chèn dữ liệu vào bảng cart
    $sqlInsert = "INSERT INTO cart (cart_id, time_add, game_id, user_id, price_at_add_time)
                  VALUES ('$cart_id', '$time_add', '$game_id', '$user_id', '$finalPrice')";
    if (mysqli_query($conn, $sqlInsert)) {
        echo json_encode(['status' => 'success']);
    } else {
        echo json_encode(['status' => 'error', 'message' => mysqli_error($conn)]);
    }
    exit;
}

// Nếu không phải POST thêm vào giỏ hàng, hiển thị trang chi tiết game
$game_id = $_GET['id'] ?? $_GET['game_id'] ?? null;

// Truy vấn dữ liệu game chi tiết
$sqlGame = "SELECT 
    g.game_id, 
    g.game_name, 
    GROUP_CONCAT(DISTINCT c.categories_name ORDER BY c.categories_name ASC SEPARATOR ', ') AS categories,
    GROUP_CONCAT(DISTINCT d.developers_name ORDER BY d.developers_name ASC SEPARATOR ', ') AS developers,
    gp.price_value,
    di.discount_name,
    di.discount_value,
    GROUP_CONCAT(DISTINCT gi.img_url ORDER BY gi.img_id ASC SEPARATOR ', ') AS images,
    sr.min_os, sr.min_cpu, sr.min_ram, sr.min_gpu, sr.min_storage,
    sr.rec_os, sr.rec_cpu, sr.rec_ram, sr.rec_gpu, sr.rec_storage,
    g.game_details,
    AVG(r.rating) AS avg_rating,
    COUNT(DISTINCT(r.reviews_id)) AS total_reviews
FROM game g
LEFT JOIN categories_game cg ON g.game_id = cg.gameID
LEFT JOIN categories c ON cg.categoriesID = c.categories_id
LEFT JOIN game_developers gd ON g.game_id = gd.game_id
LEFT JOIN developers d ON gd.developers_id = d.developers_id
LEFT JOIN game_price gp ON g.game_id = gp.game_id
LEFT JOIN game_discounts gd2 ON g.game_id = gd2.game_id
LEFT JOIN discounts di ON gd2.discount_id = di.discount_id
LEFT JOIN game_img gi ON g.game_id = gi.game_id
LEFT JOIN system_requirements sr ON g.game_id = sr.game_id
LEFT JOIN reviews r ON g.game_id = r.game_id
WHERE g.game_id = '$game_id'
GROUP BY g.game_id, gp.price_value, di.discount_name, di.discount_value, 
        sr.min_os, sr.min_cpu, sr.min_ram, sr.min_gpu, sr.min_storage,
        sr.rec_os, sr.rec_cpu, sr.rec_ram, sr.rec_gpu, sr.rec_storage, g.game_details;";
$resultGame = mysqli_query($conn, $sqlGame);
$game = mysqli_fetch_assoc($resultGame);

$alreadyOwned = false;
$hasReviewed = false;
$userReview = null;

if (isset($_SESSION['user'])) {
    $user_id = $_SESSION['user']['user_Id'] ?? null;
    
    // Kiểm tra xem user đã sở hữu game hay chưa
    $sqlOwned = "SELECT * FROM user_library WHERE user_id = '$user_id' AND game_id = '$game_id'";
    $resultOwned = mysqli_query($conn, $sqlOwned);
    if ($resultOwned && mysqli_num_rows($resultOwned) > 0) {
        $alreadyOwned = true;
    }
    
    // Kiểm tra xem user đã đánh giá game này chưa
    $sqlCheck = "SELECT * FROM reviews WHERE user_id = '$user_id' AND game_id = '$game_id'";
    $resultCheck = mysqli_query($conn, $sqlCheck);
    if ($resultCheck && mysqli_num_rows($resultCheck) > 0) {
        $hasReviewed = true;
        $userReview = mysqli_fetch_assoc($resultCheck);
    }
}

if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['action'])) {
    if (!isset($_SESSION['user'])) {
        echo json_encode(['status' => 'error', 'message' => 'Bạn cần đăng nhập để đánh giá.']);
        exit;
    }
    
    if (!$alreadyOwned) {
        echo json_encode(['status' => 'error', 'message' => 'Bạn cần sở hữu game này để đánh giá.']);
        exit;
    }

    $user_id = $_SESSION['user']['user_Id'];
    $game_id = $_POST['game_id'];
    $rating = $_POST['rating'];
    $comment = trim($_POST['comment']);
    $review_date = date('Y-m-d H:i:s');

    if ($_POST['action'] === 'submitReview') {
        if ($hasReviewed) {
            echo json_encode(['status' => 'error', 'message' => 'Bạn đã đánh giá game này rồi!']);
            exit;
        }

        // Sinh review_id mới
        $sqlMax = "SELECT MAX(CAST(SUBSTRING(reviews_id, 3) AS UNSIGNED)) AS max_id FROM reviews WHERE reviews_id LIKE 'rv%'";
        $resultMax = mysqli_query($conn, $sqlMax);
        $rowMax = mysqli_fetch_assoc($resultMax);
        $max_id = isset($rowMax['max_id']) ? $rowMax['max_id'] : 0;
        $review_id = "rv" . ($max_id + 1);

        $sqlInsert = "INSERT INTO reviews (reviews_id, user_id, game_id, rating, comment, review_date) 
                      VALUES ('$review_id', '$user_id', '$game_id', '$rating', '$comment', '$review_date')";
        
        if (mysqli_query($conn, $sqlInsert)) {
            echo json_encode(['status' => 'success']);
        } else {
            echo json_encode(['status' => 'error', 'message' => 'Lỗi khi thêm đánh giá!']);
        }
    } elseif ($_POST['action'] === 'editReview') {
        if (!$hasReviewed) {
            echo json_encode(['status' => 'error', 'message' => 'Bạn chưa có đánh giá để chỉnh sửa.']);
            exit;
        }
    
        $sqlUpdate = "UPDATE reviews SET rating='$rating', comment='$comment', review_date='$review_date' 
                      WHERE user_id='$user_id' AND game_id='$game_id'";
    
        if (mysqli_query($conn, $sqlUpdate)) {
            echo json_encode(['status' => 'success']);
        } else {
            echo json_encode(['status' => 'error', 'message' => 'Lỗi khi cập nhật đánh giá: ' . mysqli_error($conn)]);
        }
    }
    exit;
}

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
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" defer></script>
    <title><?php echo isset($game['game_name']) ? $game['game_name'] : "Chi tiết game"; ?></title>
    <style>
        body {
            font-family: system-ui, -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
            background-color: #1B2838 !important;
            color: white !important;
        }
        .game-title {
            font-size: 50px;
            font-weight: bold;
            margin-bottom: 20px;
        }
        .price-box {
            background: rgb(19, 2, 255);
            padding: 15px;
            border-radius: 10px;
            text-align: center;
        }
        .carousel img {
            border-radius: 10px;
            max-height: 500px;
            object-fit: cover;
        }
        @media (max-width: 768px) {
            .game-title {
                font-size: 30px;
            }
        }
    </style>
</head>
<body>

    <?php include 'module/header.php'; ?>
    <div id="dropdown"></div>

    <div class="container mt-5">
        <?php if ($game): ?>
            <p class="game-title"><?php echo $game['game_name']; ?></p>

            <div class="row">
                <!-- Hiển thị hình ảnh game -->
                <div class="col-lg-8">
                    <div id="gameCarousel" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-indicators">
                            <?php
                            $images = explode(', ', $game['images']);
                            foreach ($images as $index => $img) {
                                echo "<button type='button' data-bs-target='#gameCarousel' data-bs-slide-to='$index' " . ($index == 0 ? "class='active'" : "") . "></button>";
                            }
                            ?>
                        </div>
                        <div class="carousel-inner">
                            <?php
                            foreach ($images as $index => $img) {
                                echo "<div class='carousel-item " . ($index == 0 ? "active" : "") . "'>
                                        <img src='$img' class='d-block w-100'>
                                      </div>";
                            }
                            ?>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#gameCarousel" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon"></span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#gameCarousel" data-bs-slide="next">
                            <span class="carousel-control-next-icon"></span>
                        </button>
                    </div>
                </div>

                <!-- Hiển thị thông tin game -->
                <div class="col-lg-4">
                    <h3><?php echo $game['game_name']; ?></h3>
                    <p><strong>Thể loại:</strong> <?php echo $game['categories']; ?></p>
                    <p><strong>Nhà phát triển:</strong> <?php echo $game['developers']; ?></p>

                    <!-- Giá và giảm giá -->
                    <div class="price-box">
                        <h4>
                            <?php
                            if (isset($game['discount_value']) && $game['discount_value'] > 0) {
                                if ($game['discount_value'] <= 100) {
                                    $discounted_price = $game['price_value'] * (1 - $game['discount_value'] / 100);
                                    echo "<del>" . number_format($game['price_value']) . " VND</del> ";
                                    echo "<span class='text-warning'>" . number_format($discounted_price) . " VND (-{$game['discount_value']}%)</span>";
                                } elseif ($game['discount_value'] > 100) {
                                    $discounted_price = $game['price_value'] - $game['discount_value'];
                                    echo "<del>" . number_format($game['price_value']) . " VND</del> ";
                                    echo "<span class='text-warning'>" . number_format($discounted_price) . " VND (-" . number_format($game['discount_value']) . " VND)</span>";
                                }
                            } else {
                                if ($game['price_value'] == 0) {
                                    echo "<span class='text-light'>Miễn phí</span>";
                                } else {
                                    echo "<span class='text-light'>" . number_format($game['price_value']) . " VND</span>";
                                }
                            }
                            ?>
                        </h4>
                    </div>

                    <!-- Nút Thêm vào Giỏ Hàng -->
                    <?php if ($alreadyOwned): ?>
                        <button class="btn btn-secondary w-100 mt-3" disabled>
                            <i class="fas fa-check"></i> Đã sở hữu
                        </button>
                    <?php else: ?>
                        <button class="btn btn-danger w-100 mt-3" onclick="addToCart('<?php echo $game['game_id']; ?>')">
                            <i class="fas fa-shopping-cart"></i> Thêm vào giỏ hàng
                        </button>
                    <?php endif; ?>

                    <p><strong>Đánh giá:</strong> <?php echo round($game['avg_rating'], 1); ?> ⭐ (<?php echo $game['total_reviews']; ?> đánh giá)</p>
                </div>
            </div>

            <!-- Mô tả game -->
            <div class="row mt-5">
                <div class="col-lg-12">
                    <h4>Mô tả</h4>
                    <p><?php echo $game['game_details']; ?></p>
                </div>
            </div>

            <!-- Yêu cầu hệ thống -->
            <div class="row mt-5">
                <div class="col-lg-6">
                    <h4>Yêu cầu tối thiểu</h4>
                    <ul>
                        <li>HĐH: <?php echo $game['min_os']; ?></li>
                        <li>CPU: <?php echo $game['min_cpu']; ?></li>
                        <li>RAM: <?php echo $game['min_ram']; ?></li>
                        <li>GPU: <?php echo $game['min_gpu']; ?></li>
                        <li>Lưu trữ: <?php echo $game['min_storage']; ?></li>
                    </ul>
                </div>
                <div class="col-lg-6">
                    <h4>Yêu cầu đề nghị</h4>
                    <ul>
                        <li>HĐH: <?php echo $game['rec_os']; ?></li>
                        <li>CPU: <?php echo $game['rec_cpu']; ?></li>
                        <li>RAM: <?php echo $game['rec_ram']; ?></li>
                        <li>GPU: <?php echo $game['rec_gpu']; ?></li>
                        <li>Lưu trữ: <?php echo $game['rec_storage']; ?></li>
                    </ul>
                </div>
            </div>
        <?php else: ?>
            <p class="text-danger">Không tìm thấy game.</p>
        <?php endif; ?>
        
        <!-- Phần đánh giá của người dùng -->
        <div class="row mt-5">
            <div class="col-lg-12">
            <h4>Đánh giá từ người chơi</h4>

            <?php if (isset($_SESSION['user']) && $alreadyOwned): ?>
    <h5 class="text-light">Đánh giá của bạn</h5>

    <?php if ($hasReviewed): ?>
        <div class="list-group-item bg-primary text-light mb-3 p-3 rounded">
            <h5>Bạn <span class="text-warning"><?php echo str_repeat("⭐", $userReview['rating']); ?></span></h5>
            <p><?php echo nl2br(htmlspecialchars($userReview['comment'])); ?></p>
            <small class="text-light"><?php echo date('d/m/Y', strtotime($userReview['review_date'])); ?></small><br>
            <button id="editReviewBtn" class="btn btn-warning mt-2"
                data-rating="<?php echo $userReview['rating']; ?>"
                data-comment="<?php echo htmlspecialchars($userReview['comment']); ?>">
                Chỉnh sửa đánh giá
            </button>
        </div>

        <!-- Form chỉnh sửa đánh giá (ban đầu ẩn) -->
        <form id="editReviewForm" style="display: none;">
            <input type="hidden" name="review_id" value="<?php echo $userReview['reviews_id']; ?>">
            <input type="hidden" name="user_id" value="<?php echo $_SESSION['user']['user_Id']; ?>">
            <input type="hidden" name="game_id" value="<?php echo $game['game_id']; ?>">
            
            <div class="mb-3">
                <label for="editRating" class="form-label">Đánh giá (1-5 sao):</label>
                <select id="editRating" name="rating" class="form-select" required>
                    <option value="5">⭐⭐⭐⭐⭐ - Tuyệt vời</option>
                    <option value="4">⭐⭐⭐⭐ - Tốt</option>
                    <option value="3">⭐⭐⭐ - Trung bình</option>
                    <option value="2">⭐⭐ - Kém</option>
                    <option value="1">⭐ - Rất tệ</option>
                </select>
            </div>

            <div class="mb-3">
                <label for="editComment" class="form-label">Bình luận:</label>
                <textarea id="editComment" name="comment" class="form-control" rows="3" required></textarea>
            </div>

            <button type="submit" class="btn btn-warning"><i class="fas fa-edit"></i> Cập nhật đánh giá</button>
            <button type="button" id="cancelEdit" class="btn btn-secondary">Hủy</button>
        </form>

    <?php else: ?>
        <!-- Form đánh giá mới -->
        <form id="reviewForm">
            <input type="hidden" name="user_id" value="<?php echo $_SESSION['user']['user_Id']; ?>">
            <input type="hidden" name="game_id" value="<?php echo $game['game_id']; ?>">
            
            <div class="mb-3">
                <label for="rating" class="form-label">Đánh giá (1-5 sao):</label>
                <select id="rating" name="rating" class="form-select" required>
                    <option value="5">⭐⭐⭐⭐⭐ - Tuyệt vời</option>
                    <option value="4">⭐⭐⭐⭐ - Tốt</option>
                    <option value="3">⭐⭐⭐ - Trung bình</option>
                    <option value="2">⭐⭐ - Kém</option>
                    <option value="1">⭐ - Rất tệ</option>
                </select>
            </div>

            <div class="mb-3">
                <label for="comment" class="form-label">Bình luận:</label>
                <textarea id="comment" name="comment" class="form-control" rows="3" required></textarea>
            </div>

            <button type="submit" class="btn btn-primary"><i class="fas fa-paper-plane"></i> Gửi đánh giá</button>
        </form>
    <?php endif; ?>
<?php endif; ?>

<!-- Hiển thị các đánh giá khác -->
<?php
if (isset($user_id)) {
    $sqlOtherReviews = "SELECT reviews.*, user.user_Name FROM reviews 
                        JOIN user ON reviews.user_id = user.user_Id 
                        WHERE reviews.game_id = '$game_id' AND reviews.user_id != '$user_id' 
                        ORDER BY reviews.review_date DESC";
    $otherReviews = mysqli_query($conn, $sqlOtherReviews);
}
else
{
    $sqlOtherReviews = "SELECT reviews.*, user.user_Name FROM reviews 
                        JOIN user ON reviews.user_id = user.user_Id 
                        WHERE reviews.game_id = '$game_id' 
                        ORDER BY reviews.review_date DESC";
    $otherReviews = mysqli_query($conn, $sqlOtherReviews);
}
$hasAnyReview = $hasReviewed || mysqli_num_rows($otherReviews) > 0;
if (!$hasAnyReview): ?>
   <p class="text-light">Chưa có đánh giá nào. Hãy là người đầu tiên đánh giá!</p>
<?php else: ?>
    <div class="list-group">
        <?php while ($review = mysqli_fetch_assoc($otherReviews)): ?>
            <div class="list-group-item bg-dark text-light mb-3 p-3 rounded">
                <h5><?php echo htmlspecialchars($review['user_Name']); ?>
                    <span class="text-warning"><?php echo str_repeat("⭐", $review['rating']); ?></span>
                </h5>
                <p><?php echo nl2br(htmlspecialchars($review['comment'])); ?></p>
                <small class="text-light"><?php echo date('d/m/Y', strtotime($review['review_date'])); ?></small>
            </div>
        <?php endwhile; ?>
    </div>
    
<?php endif; ?>



    <footer id="footer"></footer>

    <!-- JavaScript xử lý Thêm vào Giỏ Hàng và lưu thông tin đánh giá vào database -->
    <script>
       document.addEventListener("DOMContentLoaded", function () {
    const reviewForm = document.getElementById("reviewForm");
    const editButton = document.getElementById("editReviewBtn");
    const cancelEdit = document.getElementById("cancelEdit");

    // Xử lý gửi form đánh giá (thêm mới hoặc chỉnh sửa)
    if (reviewForm) {
        reviewForm.addEventListener("submit", async function (event) {
            event.preventDefault();

            let formData = new FormData(this);
            let isEdit = this.getAttribute("data-edit") === "true"; // Kiểm tra trạng thái chỉnh sửa
            formData.append("action", isEdit ? "editReview" : "submitReview");

            try {
                let response = await fetch(window.location.href, {
                    method: "POST",
                    body: new URLSearchParams(formData),
                });

                let data = await response.json();
                console.log("Server Response:", data); // Kiểm tra response từ server

                if (data.status === "success") {
                    alert(isEdit ? "Đánh giá đã được cập nhật!" : "Đánh giá của bạn đã được gửi!");
                    location.reload(); // Cập nhật danh sách đánh giá
                } else {
                    alert("Lỗi: " + data.message);
                }
            } catch (error) {
                console.error("Lỗi khi gửi request:", error);
                alert("Có lỗi xảy ra, vui lòng thử lại!");
            }
        });
    }

    // Nếu có nút "Chỉnh sửa đánh giá", xử lý sự kiện click
    if (editButton) {
        editButton.addEventListener("click", function () {
            let userRating = this.getAttribute("data-rating");  // Lấy số sao đánh giá cũ
            let userComment = this.getAttribute("data-comment"); // Lấy bình luận cũ

            // Điền dữ liệu cũ vào form
            document.getElementById("rating").value = userRating;
            document.getElementById("comment").value = userComment;

            // Đổi form thành chế độ "chỉnh sửa"
            reviewForm.setAttribute("data-edit", "true");

            // Đổi chữ nút submit
            reviewForm.querySelector("button[type='submit']").textContent = "Cập nhật đánh giá";
        });
    }

    // Xử lý khi người dùng muốn hủy chỉnh sửa
    if (cancelEdit) {
        cancelEdit.addEventListener("click", function () {
            reviewForm.removeAttribute("data-edit"); // Xóa trạng thái chỉnh sửa
            reviewForm.reset(); // Xóa dữ liệu form
            reviewForm.querySelector("button[type='submit']").textContent = "Gửi đánh giá";
        });
    }
});
document.addEventListener("DOMContentLoaded", function () {
    const editReviewBtn = document.getElementById("editReviewBtn");
    const editReviewForm = document.getElementById("editReviewForm");
    const cancelEdit = document.getElementById("cancelEdit");

    if (editReviewBtn && editReviewForm) {
        editReviewBtn.addEventListener("click", function () {
            console.log("Bấm nút chỉnh sửa đánh giá"); // Debug

            const rating = this.getAttribute("data-rating");
            const comment = this.getAttribute("data-comment");

            document.getElementById("editRating").value = rating;
            document.getElementById("editComment").value = comment;

            editReviewForm.style.display = "block";
            editReviewBtn.style.display = "none"; // Ẩn nút chỉnh sửa khi form hiển thị
        });
    }

    if (cancelEdit && editReviewForm) {
        cancelEdit.addEventListener("click", function () {
            editReviewForm.style.display = "none";
            editReviewBtn.style.display = "block"; // Hiện lại nút chỉnh sửa
        });
    }
});
document.addEventListener("DOMContentLoaded", function () {
    const editReviewForm = document.getElementById("editReviewForm");

    if (editReviewForm) {
        editReviewForm.addEventListener("submit", async function (event) {
            event.preventDefault();

            let formData = new FormData(this);
            formData.append("action", "editReview");

            console.log("🔹 Dữ liệu gửi đi:", Object.fromEntries(formData)); // Kiểm tra dữ liệu

            try {
                let response = await fetch(window.location.href, {
                    method: "POST",
                    body: new URLSearchParams(formData),
                });

                let data = await response.json();
                console.log("🔹 Phản hồi từ server:", data);

                if (data.status === "success") {
                    alert("🎉 Đánh giá đã được cập nhật!");
                    location.reload();
                } else {
                    alert("❌ Lỗi: " + data.message);
                }
            } catch (error) {
                console.error("🚨 Lỗi khi gửi request:", error);
                alert("Có lỗi xảy ra, vui lòng thử lại!");
            }
        });
    }
});



        function addToCart(gameId) {
            fetch(window.location.href, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
                body: 'action=addToCart&game_id=' + encodeURIComponent(gameId)
            })
            .then(response => response.json())
            .then(data => {
                if (data.status === 'success') {
                    alert('Game đã được thêm vào giỏ hàng!');
                } else {
                    alert('Lỗi: ' + data.message);
                }
            })
            .catch(error => {
                console.error('Error:', error);
                alert('Đã có lỗi xảy ra.');
            });
        }
    </script>
</body>
</html>
