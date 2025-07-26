<?php
class MasterModel
{
    //Hàm được dùng để đổ dữ liệu ra bảng khi gán giá trị bảng
    public static function get_all_from($table)
    {
        $db = new connect();
        $select = "select * from $table";
        $result = $db->getList($select);
        return $result;
    }
    public static function getLIMIT($table, $limit = null)
    {
        $db = new connect();
        $select = "SELECT * FROM $table";
        if ($limit !== null) {
            $select .= " LIMIT $limit";
        }
        $result = $db->getList($select);
        return $result;
    }
    
    public static function get_by_id($table, $column, $value)
    {
        require_once 'config/db.php';
        $db = new connect();
        $select = "SELECT * FROM $table WHERE $column = '$value'";
        $result = $db->getlist($select);
        return $result;
    }
    public static function get_dk($table, $condition = "", $order = "", $limit = "")
    {
        $db = new connect();
        $select = "SELECT * FROM $table";

        if (!empty($condition)) {
            $select .= " WHERE $condition";
        }
        if (!empty($order)) {
            $select .= " ORDER BY $order";
        }
        if (!empty($limit)) {
            $select .= " LIMIT $limit";
        }

        $result = $db->getList($select);
        return $result->fetchAll(PDO::FETCH_ASSOC);
    }
    // Hàm phân trang tái sử dụng
    public function getPagingData($table, $where = '', $orderBy = '', $start = 0, $limit = 4) {
        $db = new connect();
        $sql = "SELECT * FROM $table";
        if (!empty($where)) $sql .= " WHERE $where";
        if (!empty($orderBy)) $sql .= " ORDER BY $orderBy";
        $sql .= " LIMIT $start, $limit";
        return $db->getList($sql);
    }

    // Hàm đếm tổng dòng
    public function getTotalRows($table, $where = '') {
        $db = new connect();
        $sql = "SELECT COUNT(*) AS total FROM $table";
        if (!empty($where)) $sql .= " WHERE $where";
        $result = $db->getInstance($sql);
        return $result['total'];
    }

    public static function insertUser($maNguoiDung, $fullname, $username, $email, $address, $tel, $password, $loaiNguoiDung, $ngayDangKy) {
        $db = new connect();
        $query = "INSERT INTO tbl_nguoidung (ma_nguoidung, ho_ten, ten_dang_nhap, email, dia_chi, so_dien_thoai, mat_khau, loai_nguoi_dung, ngay_dang_ky)
                  VALUES ('$maNguoiDung', '$fullname', '$username', '$email', '$address', '$tel', '$password', '$loaiNguoiDung', '$ngayDangKy')";
        return $db->exec($query);
    }

    public static function insertCustomer($idNguoiDung) {
        $db = new connect();
        $query = "INSERT INTO tbl_khachhang (id_nguoidung, diem_tich_luy) VALUES ('$idNguoiDung', 0)";
        return $db->exec($query);
    }

    public static function getMaxUserId() {
        $db = new connect();
        $query = "SELECT MAX(id_nguoidung) as max_id FROM tbl_nguoidung";
        $result = $db->getInstance($query);
        return $result ? $result['max_id'] : 0;
    }

    public static function checkExist($field, $value) {
        $db = new connect();
        $query = "SELECT COUNT(*) as total FROM tbl_nguoidung WHERE $field = '$value'";
        $result = $db->getInstance($query);
        return $result['total'] > 0;
    }

    public static function checkLogin($username, $password) {
        $db = new connect();
        $hashedPassword = md5($password); // mã hóa MD5
        $query = "SELECT * FROM tbl_nguoidung WHERE ten_dang_nhap = '$username' AND mat_khau = '$hashedPassword'";
        return $db->getInstance($query); // trả về 1 dòng hoặc null
    }
    public static function getUser($username) {
        $db = new connect();
        $query = "SELECT * FROM tbl_nguoidung WHERE ten_dang_nhap = '$username'";
        return $db->getInstance($query); // trả về 1 dòng hoặc null
    }
}
?>
