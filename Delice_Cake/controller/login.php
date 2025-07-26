<?php
class Login{
    public static function index(){
        require_once "view/user/login.php";
    }
    public static function confirm() {
        if (empty($_POST['txtusername']) || empty($_POST['txtpassword'])) {
            echo "<script>alert('Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!'); window.history.back();</script>";
            return;
        }

        $username = $_POST['txtusername'];
        $password = $_POST['txtpassword'];

        require_once 'model/login.php';
        $model = new ModelLogin();

        // Kiểm tra xem username có tồn tại không
        $user = $model->getUserByUsername($username);
        if (!$user) {
            echo "<script>alert('Tên đăng nhập không tồn tại!'); window.history.back();</script>";
            return;
        }

        // Kiểm tra mật khẩu
        $hashedPassword = md5($password);
        if ($user['mat_khau'] !== $hashedPassword) {
            echo "<script>alert('Mật khẩu không đúng!'); window.history.back();</script>";
            return;
        }

        // Đăng nhập thành công
        $_SESSION['id_nguoidung'] = $user['id_nguoidung'];
        $_SESSION['ten_dang_nhap'] = $user['ten_dang_nhap'];
        $_SESSION['vai_tro'] = $user['loai_nguoi_dung'];

        echo "<script>alert('Đăng nhập thành công!');</script>";

        // Phân quyền
        if ($user['loai_nguoi_dung'] == 'nhanvien' || $user['loai_nguoi_dung'] == 'admin') {
            echo "<script>window.location.href='index.php?controller=Admin&action=index&page=danhmuc';</script>";
        } else {
            echo "<script>window.location.href='index.php';</script>";
        }
    }
public static function logout() {
    if (isset($_GET['action']) && $_GET['action'] === 'logout') {
        if (session_status() === PHP_SESSION_NONE) {
            session_start();
        }

        // Xóa toàn bộ biến session
        unset($_SESSION['id_nguoi_dung']);
        unset($_SESSION['ten_dang_nhap']);
        unset($_SESSION['vai_tro']);

        // Hủy luôn session (xoá file session trên server, xoá cookie PHPSESSID)
        session_destroy();

        // Chuyển về trang chủ hoặc trang login
        header("Location: index.php");
        exit();
    }
}

    

}
?>
