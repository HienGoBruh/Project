<?php
//Kế thừa hàm get_all_from($table) từ file master.php
class ModelNews extends MasterModel{
    
    function get_news_by_id($id)
    {
        
        return parent::get_by_id('tbl_tintuc', 'id_tintuc', $id);
    }
    function getNEWSHOME(){
        
        return parent::getLIMIT('tbl_tintuc', 4);
    }
    
    function get1LATESTNEWS(){
        return parent::get_dk('tbl_tintuc', 'ngay_xuatban = (SELECT MAX(ngay_xuatban) FROM tbl_tintuc)', '', 1);
    }
    function getLATESTNEWS() {
        return parent::get_dk('tbl_tintuc', '', 'ngay_xuatban ASC', 2);
    }
    // Lấy tổng số tin
    function getTotalNews() {
        return parent::getTotalRows('tbl_tintuc');
    }

    // Lấy danh sách tin theo phân trang
    function getPagedNews($start, $limit) {
        return parent::getPagingData('tbl_tintuc', '', 'ngay_xuatban DESC', $start, $limit);
    }
    // Lấy tất cả bình luận theo id tin tức
    public function countCommentsByNewsId($id_tintuc) {
        $db = new connect();
        $sql = "SELECT COUNT(*) as total FROM tbl_binhluan_tintuc WHERE id_tintuc = ?";
        $stmt = $db->db->prepare($sql);
        $stmt->execute([$id_tintuc]);
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        return $row['total'];
    }
}
?>