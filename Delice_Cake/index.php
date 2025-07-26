<?php
require_once 'model/master.php';

if (isset($_GET['controller'], $_GET['action'])) {
    $controller = $_GET['controller'];
    $action = $_GET['action'];
} else {
    $controller = 'Home';
    $action = 'index';
}

// Nếu là trang quản trị
if ($controller == 'Admin') {
    // Nếu là request AJAX từ admin (ví dụ load phân trang, thêm, xóa...)
    $isAjax = isset($_SERVER['HTTP_X_REQUESTED_WITH']) && $_SERVER['HTTP_X_REQUESTED_WITH'] === 'XMLHttpRequest';

    if ($isAjax) {
        require_once 'view/Admin/route.php'; // gọi controller xử lý logic
        exit; // kết thúc sớm, không load layout
    }

    // Trang admin bình thường
    require_once 'view/Admin/layout.php';
} else {
    // Với các controller khác
    $apiActions = [
        'Cart|getCartCount',
        'Cart|add'
    ];

    $currentAction = $controller . '|' . $action;

    if (in_array($currentAction, $apiActions)) {
        require_once 'view/route.php'; // các xử lý API nhỏ, không layout
    } else {
        require_once 'view/Layout/layout.php'; // trang frontend có layout
    }
}
