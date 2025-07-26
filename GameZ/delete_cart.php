<?php
if (session_status() == PHP_SESSION_NONE) {
    session_start();
}
include 'DBCONN.PHP';
mysqli_set_charset($conn, "utf8");

// Kiểm tra đăng nhập
if (!isset($_SESSION['user'])) {
    header("Location: dangnhap.php");
    exit;
}

$user_id = $_SESSION['user']['user_Id'];

// Nếu có tham số clear_cart, xóa hết giỏ hàng của user hiện tại
if (isset($_GET['clear_cart']) && $_GET['clear_cart'] == 1) {
    $sql = "DELETE FROM cart WHERE user_id = '$user_id'";
    mysqli_query($conn, $sql);
} elseif (isset($_GET['cart_id'])) {
    // Xóa một sản phẩm cụ thể khỏi giỏ hàng
    $cart_id = $_GET['cart_id'];
    $sql = "DELETE FROM cart WHERE cart_id = '$cart_id' AND user_id = '$user_id'";
    mysqli_query($conn, $sql);
}

header("Location: giohang.php");
exit;
?>
