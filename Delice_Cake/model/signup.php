<?php
require_once 'model/master.php';

class ModelSignup extends MasterModel {

    public function insert($fullname, $username, $email, $address, $tel, $password) {
        $maxId = self::getMaxUserId();
        $nextId = $maxId + 1;
        $maNguoiDung = 'ND' . str_pad($nextId, 2, '0', STR_PAD_LEFT);
        $loaiNguoiDung = 'khach';
        $ngayDangKy = date('Y-m-d');

        // Mã hóa mật khẩu bằng md5
        $hashedPassword = md5($password);

        $result1 = self::insertUser($maNguoiDung, $fullname, $username, $email, $address, $tel, $hashedPassword, $loaiNguoiDung, $ngayDangKy);
        if ($result1) {
            $db = new connect();
            $idNguoiDung = $db->getInstance("SELECT id_nguoidung FROM tbl_nguoidung WHERE ma_nguoidung = '$maNguoiDung'")['id_nguoidung'];
            $result2 = self::insertCustomer($idNguoiDung);
            return $result2;
        }
        return false;
    }


    public function isDuplicate($username, $email, $tel) {
        return [
            'username' => parent::checkExist('ten_dang_nhap', $username),
            'email' => parent::checkExist('email', $email),
            'tel' => parent::checkExist('so_dien_thoai', $tel),
        ];
    }
}
?>
