<?php
// Cấu hình kết nối CSDL
$servername = "sql204.infinityfree.com";
$dbUsername = "if0_39033364";
$dbPassword = "VP3aMpsyxQ6B";
$dbname = "if0_39033364_tranhiendz";

// Nếu form được gửi đi (method POST), thực hiện xử lý đăng ký
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Tạo kết nối đến CSDL
    $conn = new mysqli($servername, $dbUsername, $dbPassword, $dbname);
    $conn->set_charset("utf8");
    if ($conn->connect_error) {
        die("Kết nối thất bại: " . $conn->connect_error);
    }

    // Lấy dữ liệu từ form và loại bỏ khoảng trắng
    $user_Name = trim($_POST['user_Name']);
    $email     = trim($_POST['email']);
    $Password  = trim($_POST['Password']); // Nên dùng password_hash() để mã hóa mật khẩu trong dự án thực tế
    $created_at = date("Y-m-d");
    $role       = "user";

    // Kiểm tra xem tên đăng nhập hoặc email đã tồn tại hay chưa
    $sql = "SELECT * FROM `user` WHERE `user_Name` = ? OR `email` = ?";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param("ss", $user_Name, $email);
    $stmt->execute();
    $result = $stmt->get_result();

    if ($result->num_rows > 0) {
        // Nếu đã tồn tại, thông báo lỗi và quay lại trang đăng ký
        echo "<script>alert('Tên đăng nhập hoặc email đã tồn tại!'); window.location.href='" . $_SERVER['PHP_SELF'] . "';</script>";
        exit();
    } else {
        // Lấy user_id lớn nhất hiện có theo thứ tự
        $sql_id = "SELECT MAX(CAST(SUBSTRING(user_Id, 2) AS UNSIGNED)) as max_id FROM `user`";
        $result_id = $conn->query($sql_id);
        $row = $result_id->fetch_assoc();
        if ($row["max_id"] !== null) {
            $nextId = "u" . ((int)$row["max_id"] + 1);
        } else {
            $nextId = "u1";
        }
        
        // Chèn tài khoản mới vào CSDL
        $sql = "INSERT INTO `user` (`user_Id`, `user_Name`, `email`, `Password`, `created_at`, `role`)
                VALUES (?, ?, ?, ?, ?, ?)";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param("ssssss", $nextId, $user_Name, $email, $Password, $created_at, $role);
        if ($stmt->execute()) {
            // Sau khi đăng ký thành công, chuyển hướng sang trang đăng nhập
            echo "<script>alert('Đăng ký thành công!'); window.location.href='dangnhap.php';</script>";
            exit();
        } else {
            echo "Lỗi khi đăng ký: " . $stmt->error;
        }
    }
    // Đóng kết nối
    $stmt->close();
    $conn->close();
}
?>

<!DOCTYPE html>
<html lang="vi">
<head>
  <meta charset="UTF-8">
  <title>Đăng ký tài khoản</title>
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css">
  <style>
    body {
      font-family: Arial, sans-serif;
      background-color: #f1f1f1;
    }
    .register-form {
      max-width: 500px;
      margin: 50px auto;
      background: #fff;
      border-radius: 8px;
      box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
      padding: 20px 30px;
    }
    .register-form h2 {
      font-size: 18px;
      text-align: center;
      font-weight: bold;
      margin-bottom: 20px;
    }
  </style>
</head>
<body>
  <div class="container">
    <div class="register-form">
      <h2>ĐĂNG KÝ TÀI KHOẢN</h2>
      <form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="post">
        <div class="mb-3">
          <input type="text" name="user_Name" class="form-control" placeholder="Tên đăng nhập" required>
        </div>
        <div class="mb-3">
          <input type="email" name="email" class="form-control" placeholder="Email" required>
        </div>
        <div class="mb-3">
          <input type="password" name="Password" class="form-control" placeholder="Mật khẩu" required>
        </div>
        <button type="submit" class="btn btn-primary w-100">Đăng ký</button>
      </form>
      <div class="mt-3 text-center">
        Bạn đã có tài khoản? <a href="dangnhap.php">Đăng nhập ngay!</a>
      </div>
      <div class="text-center mt-4">
          <a href="index.php" class="btn btn-outline-secondary">
              <i class="fas fa-arrow-left"></i> Quay về trang chủ
          </a>
      </div>
    </div>
  </div>
</body>
</html>
