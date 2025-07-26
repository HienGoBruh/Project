<?php
//Kế thừa hàm get_all_from($table) từ file master.php
class ModelProduct extends MasterModel{
    function getSP(){
        
        return parent::getLIMIT('tbl_banh', 8);
    }
    function get_product_by_id($id)
    {
        return parent::get_by_id('tbl_banh', 'id_banh', $id);
    }
    function getSPMAX1(){
        return parent::get_dk('tbl_banh', 'gia = (SELECT MAX(gia) FROM tbl_banh)', '', 1);
    }
    function getSPGIA() {
        return parent::get_dk('tbl_banh', 'gia < (SELECT MAX(gia) FROM tbl_banh)', 'gia DESC', 4);
    }

    public function countRVbySP($id_banh) {
        $db = new connect();
        $sql = "SELECT COUNT(*) as total FROM tbl_binhluan_banh WHERE id_banh = ?";
        $stmt = $db->db->prepare($sql);
        $stmt->execute([$id_banh]);
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        return $row['total'];
    }

    public function countSPtsByIdDMSP($id_danhmuc) {
        $db = new connect();
        $sql = "SELECT COUNT(*) as total FROM tbl_banh_danhmuc WHERE id_danhmuc = ?";
        $stmt = $db->db->prepare($sql);
        $stmt->execute([$id_danhmuc]);
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        return $row['total'];
    }
    function getDMSP(){
        return parent::getLIMIT('tbl_danhmuc_banh');
    }
    // Lấy tổng số tin
    public function getTotalSP($priceMin = null, $priceMax = null) {
        $db = new connect();

        $query = "SELECT COUNT(*) FROM tbl_banh WHERE 1=1";

        if ($priceMin !== null && $priceMax !== null) {
            $query .= " AND gia BETWEEN :priceMin AND :priceMax";
        }

        $stmt = $db->db->prepare($query);

        if ($priceMin !== null && $priceMax !== null) {
            $stmt->bindValue(':priceMin', (float)$priceMin, PDO::PARAM_STR);
            $stmt->bindValue(':priceMax', (float)$priceMax, PDO::PARAM_STR);
        }

        $stmt->execute();

        return $stmt->fetchColumn(); // chỉ lấy số lượng
    }


    public function getPagedSP($start, $limit, $sort = '', $priceMin = null, $priceMax = null)
    {
        $db = new connect(); // khởi tạo kết nối

        // Xử lý sắp xếp
        $orderBy = "ORDER BY ten_banh ASC"; // mặc định A-Z
        switch ($sort) {
            case 'az':
                $orderBy = "ORDER BY ten_banh ASC";
                break;
            case 'price_desc':
                $orderBy = "ORDER BY gia DESC";
                break;
            case 'price_asc':
                $orderBy = "ORDER BY gia ASC";
                break;
            case 'default':
                $orderBy = "ORDER BY id_banh DESC"; // mặc định
                break;
        }

        // Câu query cơ bản
        $query = "SELECT * FROM tbl_banh WHERE 1=1";

        // Thêm điều kiện lọc giá nếu có
        if ($priceMin !== null && $priceMax !== null) {
            $query .= " AND gia BETWEEN :priceMin AND :priceMax";
        }

        // Thêm phần sắp xếp và phân trang
        $query .= " $orderBy LIMIT :start, :limit";

        $stmt = $db->db->prepare($query);

        // Gán các giá trị vào câu truy vấn
        if ($priceMin !== null && $priceMax !== null) {
            $stmt->bindValue(':priceMin', (float)$priceMin, PDO::PARAM_STR);
            $stmt->bindValue(':priceMax', (float)$priceMax, PDO::PARAM_STR);
        }

        $stmt->bindValue(':start', (int)$start, PDO::PARAM_INT);
        $stmt->bindValue(':limit', (int)$limit, PDO::PARAM_INT);

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    // Lấy sản phẩm bán chạy nhất
    public function getBestSellingProducts($limit = 5) {
        $db = new connect();
        $query = "
            SELECT b.*, SUM(ct.so_luong) as total_sold
            FROM tbl_ctdonhang ct
            JOIN tbl_banh b ON ct.id_banh = b.id_banh
            GROUP BY ct.id_banh
            ORDER BY total_sold DESC
            LIMIT :limit
        ";
        $stmt = $db->db->prepare($query);
        $stmt->bindValue(':limit', (int)$limit, PDO::PARAM_INT);
        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function searchProductsByKeyword($keyword)
    {
        $db = new connect();
        $query = "SELECT * FROM tbl_banh WHERE ten_banh LIKE :keyword";
        $stmt = $db->db->prepare($query);
        $stmt->bindValue(':keyword', '%' . $keyword . '%', PDO::PARAM_STR);
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function getProductsByCategory($categoryId)
    {
        $db = new connect();
        $query = "SELECT b.*
                FROM tbl_banh b
                INNER JOIN tbl_banh_danhmuc bd ON b.id_banh = bd.id_banh
                WHERE bd.id_danhmuc = :categoryId";
        $stmt = $db->db->prepare($query);
        $stmt->bindValue(':categoryId', $categoryId, PDO::PARAM_INT);
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function searchOrFilterProduct($keyword = '', $categoryId = null, $start = 0, $limit = 6)
    {
        $db = new connect();
        $query = "SELECT DISTINCT b.*
                FROM tbl_banh b
                LEFT JOIN tbl_banh_danhmuc bd ON b.id_banh = bd.id_banh
                WHERE 1=1";

        if (!empty($keyword)) {
            $query .= " AND b.ten_banh LIKE :keyword";
        }

        if (!empty($categoryId)) {
            $query .= " AND bd.id_danhmuc = :categoryId";
        }

        $query .= " LIMIT :start, :limit";

        $stmt = $db->db->prepare($query);

        if (!empty($keyword)) {
            $stmt->bindValue(':keyword', '%' . $keyword . '%', PDO::PARAM_STR);
        }

        if (!empty($categoryId)) {
            $stmt->bindValue(':categoryId', $categoryId, PDO::PARAM_INT);
        }

        $stmt->bindValue(':start', (int)$start, PDO::PARAM_INT);
        $stmt->bindValue(':limit', (int)$limit, PDO::PARAM_INT);

        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function getTotalSearchOrFilter($keyword = '', $categoryId = null)
    {
        $db = new connect();
        $query = "SELECT COUNT(DISTINCT b.id_banh) as total
                FROM tbl_banh b
                LEFT JOIN tbl_banh_danhmuc bd ON b.id_banh = bd.id_banh
                WHERE 1=1";

        if (!empty($keyword)) {
            $query .= " AND b.ten_banh LIKE :keyword";
        }

        if (!empty($categoryId)) {
            $query .= " AND bd.id_danhmuc = :categoryId";
        }

        $stmt = $db->db->prepare($query);

        if (!empty($keyword)) {
            $stmt->bindValue(':keyword', '%' . $keyword . '%', PDO::PARAM_STR);
        }

        if (!empty($categoryId)) {
            $stmt->bindValue(':categoryId', $categoryId, PDO::PARAM_INT);
        }

        $stmt->execute();
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        return $row ? (int)$row['total'] : 0;
    }


}
?>