<?php
session_start();
include 'DBCONN.PHP';
mysqli_set_charset($conn, "utf8");

// Kiểm tra đăng nhập (nếu chưa đăng nhập thì chuyển hướng)
if (!isset($_SESSION['user'])) {
    header("Location: dangnhap.php");
    exit;
}

// Lấy user_id từ session
$user_id = $_SESSION['user']['user_Id'];

// Truy vấn lấy sản phẩm từ giỏ hàng cùng với thông tin game và chỉ 1 hình ảnh
$sql = "SELECT 
            cart.*, 
            game.game_name, 
            game.game_details, 
            (SELECT gi.img_url 
             FROM game_img gi 
             WHERE gi.game_id = game.game_id 
             LIMIT 1) AS img_url
        FROM cart 
        JOIN game ON cart.game_id = game.game_id 
        WHERE cart.user_id = '$user_id'";
$result = mysqli_query($conn, $sql);
$cart_items = [];
$total = 0;
if($result && mysqli_num_rows($result) > 0){
    while($row = mysqli_fetch_assoc($result)){
        $cart_items[] = $row;
        $total += $row['price_at_add_time'];
    }
}

// Xử lý form thanh toán khi submit
$error = "";
if($_SERVER['REQUEST_METHOD'] == 'POST'){
    $payment_method = $_POST['payment'] ?? "";
    if(empty($payment_method)){
        $error = "Vui lòng chọn phương thức thanh toán!";
    } else {
        if($payment_method == 'atm'){
            // Lấy thông tin thẻ ATM
            $card_number = trim($_POST['card_number'] ?? "");
            $card_name   = trim($_POST['card_name'] ?? "");
            $expiry      = trim($_POST['expiry'] ?? "");
            $cvv         = trim($_POST['cvv'] ?? "");
            if(empty($card_number) || empty($card_name) || empty($expiry) || empty($cvv)){
                $error = "Vui lòng điền đầy đủ thông tin thẻ ATM!";
            }
        } elseif($payment_method == 'paypal'){
            // Lấy email PayPal
            $paypal_email = trim($_POST['paypal_email'] ?? "");
            if(empty($paypal_email)){
                $error = "Vui lòng điền email PayPal!";
            }
        }
    }
    
    if(empty($error)){
        // Tạo mã đơn hàng mới: đếm số đơn hàng hiện có và tăng thêm 1
        $sql_order_count = "SELECT COUNT(*) as total FROM purchase_order";
        $result_order_count = mysqli_query($conn, $sql_order_count);
        $row_count = mysqli_fetch_assoc($result_order_count);
        $new_order_number = $row_count['total'] + 1;
        $order_id = "order" . $new_order_number;

        // Xác định phương thức thanh toán
        if ($payment_method == 'atm') {
            $pay_method = "ATM nội địa";
        } elseif ($payment_method == 'paypal') {
            $pay_method = "Paypal";
        }

        // Lấy ngày mua hiện tại
        $purchase_date = date("Y-m-d");

        // Chèn thông tin đơn hàng vào bảng purchase_order (status = 'Hoàn tất')
        $insert_purchase_order = "
            INSERT INTO purchase_order (order_id, user_id, purchase_date, status, total_price, pay_method) 
            VALUES ('$order_id', '$user_id', '$purchase_date', 'Hoàn tất', '$total', '$pay_method')";
        
        if(mysqli_query($conn, $insert_purchase_order)){
            // Chèn dữ liệu vào order_detail
            foreach($cart_items as $item){
                $game_id = $item['game_id'];
                $price_at_add = $item['price_at_add_time'];
                $insert_order_detail = "
                    INSERT INTO order_detail (order_id, game_id, price_at_add) 
                    VALUES ('$order_id', '$game_id', '$price_at_add')";
                mysqli_query($conn, $insert_order_detail);
            }

            // Bước 1: Lấy số dòng hiện có trong user_library để tạo ID mới
            $sql_lib_count = "SELECT COUNT(*) as total_lib FROM user_library";
            $result_lib_count = mysqli_query($conn, $sql_lib_count);
            $row_lib_count = mysqli_fetch_assoc($result_lib_count);
            $libCount = $row_lib_count['total_lib'];

            // Bước 2: Thêm game vào user_library
            foreach($cart_items as $item){
                $game_id = $item['game_id'];
                
                // Tạo userlibrary_id theo format "libX" (bạn có thể tùy chỉnh)
                $libCount++;
                $userlibrary_id = "lib" . $libCount;

                // Chèn vào user_library
                $insert_user_library = "
                    INSERT INTO user_library (userlibrary_id, user_id, game_id, purchase_date)
                    VALUES ('$userlibrary_id', '$user_id', '$game_id', '$purchase_date')";
                mysqli_query($conn, $insert_user_library);
            }

            // Xóa các sản phẩm đã thanh toán khỏi giỏ hàng
            $delete_cart = "DELETE FROM cart WHERE user_id = '$user_id'";
            mysqli_query($conn, $delete_cart);
            
            // Chuyển hướng đến trang hoàn tất thanh toán
            header("Location: htthanhtoan.html");
            exit();
        } else {
            $error = "Lỗi khi lưu thông tin đơn hàng.";
        }
    }
}
?>
<!DOCTYPE html>
<html lang="vi">
<head>
  <meta charset="UTF-8">
  <title>Thanh toán</title>

  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.7.1/css/all.min.css">
  <!-- Bootstrap CSS -->
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
  <style>
    /* Global style: đổi nền thành #1B2838 và màu chữ trắng */
    body {
        background-color: #1B2838 !important;
        color: white !important;
    }
    a {
        color: white !important;
        text-decoration: none;
    }
    /* Nếu có class bg-light thì override lại */
    .bg-light {
        background-color: #1B2838 !important;
    }
    .image-square {
      position: relative;
      overflow: hidden; 
    }
    .image-square img {
      width: 147px;
      height: 83px;
      object-fit: cover;
      display: block; 
    }
  </style>
</head>
<body>

  <section class="bg-light py-5">
    <div class="container">
      <div class="row">
        <!-- Cột trái: Form thanh toán và danh sách sản phẩm (phiên bản mobile) -->
        <div class="col-xl-8 col-lg-8 mb-4">
          <div class="p-4 px-0 pt-0 d-flex justify-content-between">
            <div>
              <a href="">
                <!-- Đổi màu chữ từ đen sang trắng -->
                <h5 style="font-size: 30px; font-weight: 400;">GAMEZ - THANH TOÁN</h5>
              </a>
              <div class="px-4 py-2 d-none d-lg-block">
                <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                  <ol class="breadcrumb">
                    <li class="me-2"><a href="giohang.php">Giỏ hàng</a></li>
                    <li class="me-2">/</li>
                    <li class="fw-medium"><a>Thông tin giao hàng</a></li>
                  </ol>
                </nav>
              </div>
            </div>
          </div>
          <!-- Danh sách sản phẩm cho mobile -->
          <div class="d-block d-lg-none">
            <div class="p-4 px-0 pt-0">
              <h6 class="text-white mb-4">Sản phẩm</h6>
              <?php foreach($cart_items as $item): ?>
              <div class="d-flex align-items-center mb-4">
                <div class="me-3 position-relative image-square">
                  <span class="position-absolute top-0 start-100 translate-middle badge rounded-pill badge-secondary">1</span>
                  <img 
                    src="<?php echo $item['img_url']; ?>" 
                    alt="<?php echo htmlspecialchars($item['game_name']); ?>" 
                    class="rounded border" 
                  />
                </div>
                <div>
                  <a href="#" class="nav-link">
                    <?php echo htmlspecialchars($item['game_name']); ?>
                  </a>
                  <div class="price text-white">
                    <?php echo number_format($item['price_at_add_time'],0,",","."); ?>₫
                  </div>
                </div>
              </div>
              <?php endforeach; ?>
              <hr />
              <div class="d-flex justify-content-between">
                <p class="mb-2">Thành tiền:</p>
                <p class="mb-2 fw-bold"><?php echo number_format($total,0,",","."); ?>₫</p>
              </div>
              <div class="input-group mt-2 mb-5">
                <input type="text" class="form-checkout form-control rounded-0 py-4" placeholder="Mã ưu đãi" />
                <button class="btn bg-black shadow-none text-white text-primary border rounded-0">Áp dụng</button>
              </div>
              <hr />
            </div>
          </div>
          <!-- Hiển thị thông báo lỗi nếu có -->
          <?php if(!empty($error)): ?>
            <div class="alert alert-danger"><?php echo $error; ?></div>
          <?php endif; ?>
          <!-- Form thanh toán -->
          <form method="post" action="">
            <div class="p-4 px-0 pt-0">
              <h5 class="card-title my-3">Phương thức thanh toán</h5>
              <div class="row">
                <div class="col">
                  <div class="accordion rounded-0" id="accordionPayment">
                    <!-- Thẻ ATM -->
                    <div class="accordion-item rounded-0 mb-3">
                      <h2 class="h5 px-3 py-3 accordion-header d-flex justify-content-between align-items-center">
                        <div class="form-check w-100 collapsed" data-bs-toggle="collapse" data-bs-target="#collapseCC" aria-expanded="false">
                          <input class="form-check-input" type="radio" name="payment" id="payment1" value="atm">
                          <label class="form-check-label pt-1 fs-6" for="payment1">Thẻ ATM nội địa/Internet Banking | OnePay</label>
                        </div>
                      </h2>
                      <div id="collapseCC" class="accordion-collapse collapse show" data-bs-parent="#accordionPayment">
                        <div class="accordion-body">
                          <div class="mb-3">
                            <input type="text" name="card_number" class="form-control form-checkout rounded-0" placeholder="Mã số thẻ">
                          </div>
                          <div class="row">
                            <div class="col-lg-6">
                              <div class="mb-3">
                                <input type="text" name="card_name" class="form-control form-checkout rounded-0" placeholder="Tên chủ thẻ">
                              </div>
                            </div>
                            <div class="col-lg-3">
                              <div class="mb-3">
                                <input type="text" name="expiry" class="form-control form-checkout rounded-0" placeholder="MM/YY">
                              </div>
                            </div>
                            <div class="col-lg-3">
                              <div class="mb-3">
                                <input type="password" name="cvv" class="form-control form-checkout rounded-0" placeholder="CVV">
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                    <!-- PayPal -->
                    <div class="accordion-item mb-3 rounded-0 border">
                      <h2 class="h5 px-3 py-3 accordion-header d-flex justify-content-between align-items-center">
                        <div class="form-check w-100 collapsed" data-bs-toggle="collapse" data-bs-target="#collapsePP" aria-expanded="false">
                          <input class="form-check-input" type="radio" name="payment" id="payment2" value="paypal">
                          <label class="form-check-label pt-1 fs-6" for="payment2">Thanh toán online bằng Paypal | OnePay</label>
                        </div>
                      </h2>
                      <div id="collapsePP" class="accordion-collapse collapse" data-bs-parent="#accordionPayment">
                        <div class="accordion-body">
                          <div class="px-2 col-lg-6 mb-3">
                            <input type="email" name="paypal_email" class="form-control form-checkout rounded-0" placeholder="Email">
                          </div>
                        </div>
                      </div>
                    </div>
		<!--Chuyển khoản ngân hàng-->
		<div class="accordion-item mb-3 rounded-0 border">
                      <h2 class="h5 px-3 py-3 accordion-header d-flex justify-content-between align-items-center">
                        <div class="form-check w-100 collapsed" data-bs-toggle="collapse" data-bs-target="#collapseCK" aria-expanded="false">
                          <input class="form-check-input" type="radio" name="payment" id="payment3" value="cknganhang">
                          <label class="form-check-label pt-1 fs-6" for="payment3">Chuyển Khoản Ngân Hàng | VietQR</label>
                        </div>
                      </h2>
                      <div id="collapseCK" class="accordion-collapse collapse" data-bs-parent="#accordionPayment">
                        <div class="accordion-body">
                          <div class="px-2 col-lg-6 mb-3">
                            <img src="img/QRGAMEZ.png" alt="" class="form-control form-checkout rounded-0">
                          </div>
                        </div>
                      </div>
                   </div>
		<!-- End -->
                  </div>
                </div>
              </div>

              <hr>
              
              <div class="float-end">
                <a href="index.php" style="padding: 15px 40px; background-color: black;" class="btn btn-checkout rounded-0 btn-light border text-white">
                    Trang chủ
                </a>
                <a href="giohang.php" style="padding: 15px 40px; background-color:rgb(106, 148, 40);" class="btn btn-checkout rounded-0 btn-light border text-white">
                    Giỏ hàng
                </a>
                <button type="submit" style="padding: 15px 40px; background-color: red;" class="btn btn-checkout rounded-0 btn-success shadow-0 border">
                  Hoàn tất đơn hàng
                </button>
              </div>
            </div>
          </form>
        </div>
        <!-- Cột phải: Danh sách sản phẩm (phiên bản desktop) -->
        <div class="col-xl-4 col-lg-4 d-flex justify-content-center justify-content-lg-end d-none d-lg-block" style="margin-top: 150px;">
          <div class="ms-lg-4 mt-4 mt-lg-0" style="max-width: 320px;">
            <h6 class="text-white mb-4">Sản phẩm</h6>
            <?php foreach($cart_items as $item): ?>
            <div class="d-flex align-items-center mb-4">
              <div class="me-3 position-relative image-square">
                <span class="position-absolute top-0 start-100 translate-middle badge rounded-pill badge-secondary">1</span>
                <img 
                  src="<?php echo $item['img_url']; ?>" 
                  alt="<?php echo htmlspecialchars($item['game_name']); ?>" 
                  class=""
                />
              </div>
              <div>
                <a href="#" class="nav-link"><?php echo htmlspecialchars($item['game_name']); ?></a>
                <div class="price text-white"><?php echo number_format($item['price_at_add_time'],0,",","."); ?>₫</div>
              </div>
            </div>
            <?php endforeach; ?>
            <hr />
            <div class="d-flex justify-content-between">
              <p class="mb-2">Thành tiền:</p>
              <p class="mb-2 fw-bold"><?php echo number_format($total,0,",","."); ?>₫</p>
            </div>
            <div class="input-group mt-2 mb-4">
              <input type="text" class="form-checkout form-control rounded-0 py-4" placeholder="Mã ưu đãi" />
              <button class="btn bg-black shadow-none text-white text-primary border rounded-0">Áp dụng</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
  <!-- Bootstrap JS -->
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
