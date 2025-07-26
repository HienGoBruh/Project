<?php
class Product
{
public static function ProductDetail()
{
    require_once "model/product.php";
    require_once "model/master.php";
    $model = new ModelProduct();
    $modelMaster = new MasterModel();

    $id_banh = isset($_GET['id']) ? (int)$_GET['id'] : 0;
    $is_ajax = isset($_GET['ajax']) && $_GET['ajax'] == 1;
    $editId = isset($_GET['edit']) ? (int)$_GET['edit'] : null;


    $result = $model->get_product_by_id($id_banh);

    // Lấy bình luận cho sản phẩm
    $comments = $modelMaster->get_dk('tbl_binhluan_banh', "id_banh = $id_banh", 'ngay_dang DESC');

    // Kiểm tra người dùng đã bình luận chưa
    $da_binh_luan = false;
    $id_binh_luan_cua_user = 0;
    if (isset($_SESSION['id_nguoidung'])) {
        foreach ($comments as $cmt) {
            if ((int)$cmt['id_nguoidung'] === (int)$_SESSION['id_nguoidung']) {
                $da_binh_luan = true;
                $id_binh_luan_cua_user = $cmt['id_bl'];
                break;
            }
        }
    }

    if ($is_ajax) {
            // Gửi ra phần danh sách bình luận HTML riêng (partial view)
            ob_start(); // Bắt đầu buffer
            include "view/Products/comments_partial.php";
            $output = ob_get_clean(); // Lấy nội dung và xóa buffer
            echo $output; // Gửi nội dung
            exit; // Đảm bảo thoát hoàn toàn
        }

    // Trang sản phẩm chi tiết bình thường
    require_once "view/Products/product_detail.php";
}
   public static function index()
    {
        require_once 'model/product.php';
        $model = new ModelProduct();

        $limit = 6;
        $page = isset($_GET['page']) ? (int)$_GET['page'] : 1;
        if ($page < 1) $page = 1;
        $start = ($page - 1) * $limit;

        $sort = isset($_GET['sort']) ? $_GET['sort'] : 'default';

        $priceMin = isset($_GET['price_min']) ? (int)$_GET['price_min'] : 0;
        $priceMax = isset($_GET['price_max']) ? (int)$_GET['price_max'] : 999;

        $totalProducts = $model->getTotalSP($priceMin, $priceMax);
        $totalPages = ceil($totalProducts / $limit);

        $products = $model->getPagedSP($start, $limit, $sort, $priceMin, $priceMax);

        $from = $start + 1;
        $to = min($start + $limit, $totalProducts);

        $currentSort = $sort;
        $currentPriceMin = $priceMin;
        $currentPriceMax = $priceMax;

        require_once "view/Products/product.php";
    }

    public static function ProductResult()
    {
        require_once "model/product.php";
        $model = new ModelProduct();

        $keyword = isset($_GET['keyword']) ? trim($_GET['keyword']) : '';
        $categoryId = isset($_GET['category_id']) ? (int)$_GET['category_id'] : null;
        $page = isset($_GET['page']) ? (int)$_GET['page'] : 1;
        $limit = 6;

        if ($page < 1) $page = 1;
        $start = ($page - 1) * $limit;

        // Lấy danh sách sản phẩm theo từ khóa hoặc danh mục
        $products = $model->searchOrFilterProduct($keyword, $categoryId, $start, $limit);

        // Tổng số sản phẩm để phân trang
        $totalProducts = $model->getTotalSearchOrFilter($keyword, $categoryId);
        $totalPages = ceil($totalProducts / $limit);

        // Tính vị trí từ...đến để hiển thị
        $from = ($totalProducts > 0) ? ($start + 1) : 0;
        $to = min($start + $limit, $totalProducts);

        require_once "view/Products/product_result.php";
    }



}
?>