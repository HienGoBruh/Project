<?php
session_start();

// Cấu hình kết nối CSDL
$servername  = "sql204.infinityfree.com";
$dbUsername  = "if0_39033364";
$dbPassword  = "VP3aMpsyxQ6B";
$dbname      = "if0_39033364_tranhiendz";

// Nếu form được gửi đi (method POST), thực hiện xử lý đăng nhập
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Lấy dữ liệu từ form và loại bỏ khoảng trắng
    $txtusername = trim($_POST['txtusername']); // Đây là tên đăng nhập
    $txtpassword = trim($_POST['txtpassword']);

    // Tạo kết nối đến CSDL
    $conn = new mysqli($servername, $dbUsername, $dbPassword, $dbname);
    $conn->set_charset("utf8");
    if ($conn->connect_error) {
        die("Kết nối thất bại: " . $conn->connect_error);
    }

    // Truy vấn kiểm tra đăng nhập theo tên đăng nhập và mật khẩu (trong ví dụ này dùng so sánh trực tiếp)
    $sql = "SELECT * FROM `user` WHERE `user_Name` = ? AND `Password` = ?";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param("ss", $txtusername, $txtpassword);
    $stmt->execute();
    $result = $stmt->get_result();

    // Nếu tìm thấy tài khoản
    if ($result->num_rows > 0) {
        $row = $result->fetch_assoc();
        // Kiểm tra vai trò của tài khoản
        if ($row['role'] == 'admin') {
            // Nếu là admin, chuyển hướng sang trang admin.php
            echo "<script>alert('Giao diện người dùng không thể đăng nhập trang quản trị!'); window.location.href='" . $_SERVER['PHP_SELF'] . "';</script>";
            exit();
        } else {
            // Nếu là user, lưu thông tin đăng nhập vào session và chuyển sang trang index.php
            $_SESSION['user'] = $row;
            header("Location: index.php");
            exit();
        }
    } else {
        // Nếu không khớp, hiển thị thông báo lỗi và quay lại trang đăng nhập
        echo "<script>alert('Sai thông tin đăng nhập!'); window.location.href='" . $_SERVER['PHP_SELF'] . "';</script>";
        exit();
    }
    
    $stmt->close();
    $conn->close();
}
?>

<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Đăng nhập tài khoản</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.7.1/css/all.min.css">
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
        .register-form .btn-primary {
            background-color: #dc3545;
            border-color: #dc3545;
        }
        .register-form .btn-primary:hover {
            background-color: #b02a37;
        }
        .social-buttons .btn {
            width: 48%;
            margin: 5px 1%;
        }
        .social-buttons .btn-google {
            background-color: #db4437;
            color: white;
        }
        .social-buttons .btn-facebook {
            background-color: #4267B2;
            color: white;
        }
        .social-buttons .btn i {
            margin-right: 8px;
        }
        .form-check-label {
            font-size: 14px;
        }
        .register-footer {
            text-align: center;
            font-size: 14px;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="register-form">
            <h2>ĐĂNG NHẬP</h2>
            <form id="Login" name="Login" action="<?php echo $_SERVER['PHP_SELF']; ?>" method="post">
                <div class="mb-3">
                    <input type="text" name="txtusername" class="form-control" placeholder="Tên đăng nhập" required>
                </div>
                <div class="mb-3">
                    <input type="password" name="txtpassword" class="form-control" placeholder="Mật khẩu" required>
                </div>
                <button type="submit" class="btn btn-primary w-100 mt-3">ĐĂNG NHẬP</button>
            </form>
            <div class="register-footer">
                Bạn chưa có tài khoản? <a href="dangky.php">Đăng ký ngay!</a>
            </div>
            <div class="text-center mt-4">
                <a href="index.php" class="btn btn-outline-secondary">
                    <i class="fas fa-arrow-left"></i> Quay về trang chủ
                </a>
            </div>
        </div>
    </div>
    
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
