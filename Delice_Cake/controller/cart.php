<?php
class Cart {
    public static function index() {
        if (session_status() === PHP_SESSION_NONE) {
            session_start();
        }

        $cart_items = [];

        if (isset($_SESSION['id_nguoidung'])) {
            $user = (int) $_SESSION['id_nguoidung'];
            require_once 'model/cart.php';
            $cart = new ModelCart();

            try {
                $cart_items = $cart->get_cart_items($user);
                require_once "view/cart/cart.php";
            } catch (Exception $e) {
                error_log("Lỗi lấy giỏ hàng: " . $e->getMessage());
                $cart_items = [];
            }
        }
        else {
            header("Location: index.php?controller=Login&action=index");
            exit();
        }
        
    }

    public static function add() {
        if (session_status() === PHP_SESSION_NONE) session_start();

        if (isset($_SESSION['id_nguoidung']) && isset($_GET['id_banh'])) {
            $user = (int) $_SESSION['id_nguoidung'];
            $id_banh = (int) $_GET['id_banh'];
            $so_luong = isset($_GET['so_luong']) ? (int) $_GET['so_luong'] : 1;

            require_once 'model/cart.php';
            $cart = new ModelCart();
            $cart->addCartItem($user, $id_banh, $so_luong);

            echo "success"; 
        } else {
            echo "login_required";
        }
        exit();
    }



    public static function getCartCount() {
        if (session_status() === PHP_SESSION_NONE) session_start();

        if (isset($_SESSION['id_nguoidung'])) {
            require_once 'config/db.php';
            $user = (int) $_SESSION['id_nguoidung'];
            $db = new connect();
            $sql = "SELECT SUM(so_luong) as cart_count 
                    FROM tbl_ctgiohang cthd 
                    JOIN tbl_giohang gh ON cthd.id_giohang = gh.id_giohang 
                    WHERE gh.id_nguoidung = $user";
            $result = $db->getInstance($sql);
            echo (int) ($result['cart_count'] ?? 0);
        } else {
            echo 0;
        }
        exit();
    }



    public static function update() {
        if (session_status() === PHP_SESSION_NONE) session_start();

        if (isset($_SESSION['id_nguoidung']) && isset($_POST['id_banh']) && isset($_POST['so_luong'])) {
            $user = (int) $_SESSION['id_nguoidung'];
            $id_banh = (int) $_POST['id_banh'];
            $so_luong = (int) $_POST['so_luong'];

            require_once 'model/cart.php';
            $cart = new ModelCart();
            $cart->editCartItem($user, $id_banh, $so_luong);

            header("Location: index.php?controller=Cart&action=index");
            exit();
        } else {
            header("Location: index.php?controller=Cart&action=index");
            exit();
        }
    }

    public static function delete() {
        if (session_status() === PHP_SESSION_NONE) session_start();

        if (isset($_SESSION['id_nguoidung']) && isset($_GET['id_banh'])) {
            $user = (int) $_SESSION['id_nguoidung'];
            $id_banh = (int) $_GET['id_banh'];

            require_once 'model/cart.php';
            $cart = new ModelCart();
            $cart->deleteCartItem($user, $id_banh);
            unset($_SESSION['applied_coupon']); // Xóa mã giảm giá khi xóa sản phẩm

            header("Location: index.php?controller=Cart&action=index");
            exit();
        } else {
            header("Location: index.php?controller=Cart&action=index");
            exit();
        }
    }
    public static function apply_coupon() {
    if (session_status() === PHP_SESSION_NONE) session_start();

    if (!isset($_SESSION['id_nguoidung']) || !isset($_POST['coupon_code'])) {
        header("Location: index.php?controller=Cart&action=index");
        return;
    }

    $code = trim($_POST['coupon_code']);
    $db = new connect();

    $now = date('Y-m-d H:i:s');
    $sql = "SELECT * FROM tbl_khuyenmai WHERE id_km = '$code' 
            AND ngay_bat_dau <= '$now' AND ngay_ket_thuc >= '$now'";
    $coupon = $db->getInstance($sql);

    if ($coupon) {
        $_SESSION['applied_coupon'] = $coupon;
    } else {
        unset($_SESSION['applied_coupon']); // xóa nếu sai
    }

    header("Location: index.php?controller=Cart&action=index");
}

}
?>
