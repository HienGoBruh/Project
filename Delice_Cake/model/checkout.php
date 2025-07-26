<?php
//Kế thừa hàm get_all_from($table) từ file master.php
class ModelCheckout extends MasterModel{
    
    public function getCart($user_id) {
        $sql = "SELECT * FROM tbl_ctgiohang cthd 
                JOIN tbl_giohang gh ON cthd.id_giohang = gh.id_giohang 
                JOIN tbl_banh b ON cthd.id_banh = b.id_banh 
                WHERE gh.id_nguoidung = :user_id";
        
        $db = new connect();
        $cmd = $db->db->prepare($sql);
        $cmd->bindValue(':user_id', $user_id, PDO::PARAM_INT);
        $cmd->execute();
        $result = $cmd->fetchAll(PDO::FETCH_ASSOC);

        return $result;
    }

    public function createOrder($data) { 
        $db = new connect();

        // Tạo ma_donhang mới
        $sql = "SELECT MAX(CAST(SUBSTRING(ma_donhang, 3) AS UNSIGNED)) AS max_ma FROM tbl_donhang";
        $stmt = $db->db->query($sql);
        $max = $stmt->fetch(PDO::FETCH_ASSOC)['max_ma'];
        $new_number = $max ? $max + 1 : 1;
        $new_ma_donhang = 'DH' . str_pad($new_number, 2, '0', STR_PAD_LEFT); // VD: DH01

        if (empty($data['id_khuyenmai'])) {
            $data['id_khuyenmai'] = null;
        }

        $sql = "INSERT INTO tbl_donhang 
                (ma_donhang, id_nguoidung, hoten, diachi, ngay_dat, tong_tien, trang_thai, note, id_khuyenmai)
                VALUES (:ma_donhang, :id_nguoidung, :hoten, :diachi, NOW(), :tong_tien, :trang_thai, :note, :id_khuyenmai)";

        $cmd = $db->db->prepare($sql);
        $cmd->bindValue(':ma_donhang', $new_ma_donhang);
        $cmd->bindValue(':id_nguoidung', $data['id_nguoidung']);
        $cmd->bindValue(':hoten', $data['hoten']);
        $cmd->bindValue(':diachi', $data['diachi']);
        $cmd->bindValue(':tong_tien', $data['tong_tien']);
        $cmd->bindValue(':trang_thai', $data['trang_thai']);
        $cmd->bindValue(':note', $data['ghichu']);
        $cmd->bindValue(':id_khuyenmai', $data['id_khuyenmai'], is_null($data['id_khuyenmai']) ? PDO::PARAM_NULL : PDO::PARAM_INT);

        $cmd->execute();
    }

    public function clearCart($user_id) {
        $db = new connect();
        $sql = "DELETE FROM tbl_ctgiohang WHERE id_giohang IN (
                    SELECT id_giohang FROM tbl_giohang WHERE id_nguoidung = :user_id
                )";
        $cmd = $db->db->prepare($sql);
        $cmd->bindValue(':user_id', $user_id);
        $cmd->execute();
    }
}   
?>
