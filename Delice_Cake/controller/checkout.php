<?php
class Checkout{
    public static function index() {
        if (session_status() === PHP_SESSION_NONE) session_start();

        if (!isset($_SESSION['id_nguoidung'])) {
            header("Location: index.php?controller=Login&action=index");
            return;
        }

        require_once "model/checkout.php";
        $cartC = new ModelCheckout();
        $user_id = (int) $_SESSION['id_nguoidung'];
        $cartC_items = $cartC->getCart($user_id);

        if ($cartC_items === false || !is_array($cartC_items) || count($cartC_items) === 0) {
            echo "<script>alert('Giỏ hàng trống!'); window.location.href='index.php?controller=Cart&action=index';</script>";
            exit;
        }

        // Tính tổng tiền
        $total = 0;
        foreach ($cartC_items as $item) {
            $total += $item['gia'] * $item['so_luong'];
        }
        $final_total = 0;
        // Tính giảm giá nếu có
        $discount = 0;
        if (isset($_SESSION['applied_coupon'])) {
            $coupon = $_SESSION['applied_coupon'];
            if ($coupon['loai'] === 'percent') {
                $discount = $total * $coupon['gia_tri'] / 100;
            } else {
                $discount = $coupon['gia_tri'];
            }
        }
        if ($total - $discount < 0) {
            $final_total = 0;
        }
        else
        {
            $final_total = $total - $discount;
        }
        

        
        require_once "view/Checkout/checkout.php";
    }

    public static function placeOrder() {
        if (session_status() === PHP_SESSION_NONE) session_start();

        if (!isset($_SESSION['id_nguoidung'])) {
            header("Location: index.php?controller=Login&action=index");
            return;
        }

        require_once "model/checkout.php";
        $checkoutModel = new ModelCheckout();

        $user_id = (int) $_SESSION['id_nguoidung'];
        $cart_items = $checkoutModel->getCart($user_id);

        if ($cart_items === false || !is_array($cart_items) || count($cart_items) === 0) {
            echo "<script>alert('Giỏ hàng trống!'); window.location.href='index.php?controller=Cart&action=index';</script>";
            exit;
        }

        // Tính tổng tiền
        $total = 0;
        foreach ($cart_items as $item) {
            $total += $item['gia'] * $item['so_luong'];
        }

        // Tính giảm giá nếu có
        $discount = 0;
        $id_khuyenmai = null;
        
        // Tính giảm giá nếu có
        $discount = 0;
        if (isset($_SESSION['applied_coupon'])) {
            $coupon = $_SESSION['applied_coupon'];
            if ($coupon['loai'] === 'percent') {
                $discount = $total * $coupon['gia_tri'] / 100;
            } else {
                $discount = $coupon['gia_tri'];
            }
        }
        if ($total - $discount < 0) {
            $final_total = 0;
        }
        else
        {
            $final_total = $total - $discount;
        }
        

        // Lấy dữ liệu từ form
        $hoten = $_POST['name'] ?? '';
        $diachi = $_POST['address'] ?? '';
        $ghichu = $_POST['message'] ?? '';

        // Kiểm tra các trường bắt buộc
        if ($hoten === '' || $diachi === '') {
            echo "<script>alert('Vui lòng nhập đầy đủ họ tên và địa chỉ!'); window.history.back();</script>";
            exit;
        }
        // Tạo đơn hàng
        $checkoutModel->createOrder([
            'id_nguoidung' => $user_id,
            'hoten' => $hoten,
            'diachi' => $diachi,
            'tong_tien' => $final_total,
            'trang_thai' => 'cho',
            'ghichu' => $ghichu,
            'id_khuyenmai' => $id_khuyenmai
        ]);

        // Xoá giỏ hàng sau khi đặt
        $checkoutModel->clearCart($user_id);

        // Chuyển đến trang cảm ơn
        echo "<script>
            alert('Cảm ơn bạn đã mua hàng!');
            window.location.href = 'index.php?controller=Cart&action=index';
        </script>";
    }

}
?>
