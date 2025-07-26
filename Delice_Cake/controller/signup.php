<?php
class Signup{
    public static function index(){
        require_once "view/user/signup.php";
    }
    public static function confirm() {
        $fullname = $_POST['fullname'];
        $username = $_POST['user_Name'];
        $email = $_POST['email'];
        $address = $_POST['address'];
        $tel = $_POST['tel'];
        $password = $_POST['Password'];

        require_once 'model/signup.php';
        $model = new ModelSignup();
        $dupe = $model->isDuplicate($username, $email, $tel);

        if ($dupe['username']) {
            echo "<script>alert('Tên đăng nhập đã tồn tại!'); window.history.back();</script>";
        } elseif ($dupe['email']) {
            echo "<script>alert('Email đã tồn tại!'); window.history.back();</script>";
        } elseif ($dupe['tel']) {
            echo "<script>alert('Số điện thoại đã tồn tại!'); window.history.back();</script>";
        } else {
            $result = $model->insert($fullname, $username, $email, $address, $tel, $password);
            if ($result) {
                echo "<script>alert('Đăng ký thành công!'); window.location.href='?controller=Login';</script>";
            } else {
                echo "<script>alert('Đăng ký thất bại!'); window.history.back();</script>";
            }
        }
    }
}
?>
