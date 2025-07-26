<?php
class News
{
    public static function NewsDetail()
    {
            require_once "model/master.php";
    require_once "model/news.php";
    $model = new ModelNews();

    $modelMaster = new MasterModel();

    $id_banh = isset($_GET['id']) ? (int)$_GET['id'] : 0;
    $is_ajax = isset($_GET['ajax']) && $_GET['ajax'] == 1;
    $editId = isset($_GET['edit']) ? (int)$_GET['edit'] : null;


    $result = $model->get_news_by_id($id_banh);

    // Lấy bình luận cho sản phẩm
    $comments = $modelMaster->get_dk('tbl_binhluan_tintuc', "id_tintuc = $id_banh", 'ngay_dang DESC');

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
            include "view/News/comments_partial.php";
            $output = ob_get_clean(); // Lấy nội dung và xóa buffer
            echo $output; // Gửi nội dung
            exit; // Đảm bảo thoát hoàn toàn
        }

    // Trang sản phẩm chi tiết bình thường
    require_once "view/News/news_detail.php";
    }
    public static function BlogView()
    {
        require_once 'model/news.php';
        $model = new ModelNews();

        $limit = 4; // mỗi trang 3 bài
        $page = isset($_GET['page']) ? (int)$_GET['page'] : 1;
        if ($page < 1) $page = 1;
        $start = ($page - 1) * $limit;

        $totalNews = $model->getTotalNews();
        $totalPages = ceil($totalNews / $limit);
        
        $news = $model->getPagedNews($start, $limit);

        require_once 'view/News/blog.php';
    }
}
?>