<?php
//Kế thừa hàm get_all_from($table) từ file master.php
class ModelCart extends MasterModel{

public function get_cart_items($user_id) {
    $sql = "SELECT * FROM tbl_ctgiohang cthd 
            JOIN tbl_giohang gh ON cthd.id_giohang = gh.id_giohang 
            JOIN tbl_banh b ON cthd.id_banh = b.id_banh 
            WHERE gh.id_nguoidung = $user_id";
    
    $db = new connect();
    $result = $db->getlist($sql);
    
    return $result;
}

    public function addCartItem($user_id, $product_id, $quantity = 1) {
    try {
        $db = new connect();

        $user_id = (int) $user_id;
        $product_id = (int) $product_id;
        $quantity = (int) $quantity;

        // Kiểm tra giỏ hàng
        $sql = "SELECT id_giohang FROM tbl_giohang WHERE id_nguoidung = $user_id";
        $result = $db->getInstance($sql);

        if (!$result) {
            // Tạo mới giỏ hàng
            $sql_insert = "INSERT INTO tbl_giohang (id_nguoidung) VALUES ($user_id)";
            $db->exec($sql_insert);

            // Lấy lại ID giỏ hàng
            $sql = "SELECT id_giohang FROM tbl_giohang WHERE id_nguoidung = $user_id ORDER BY id_giohang DESC LIMIT 1";
            $result = $db->getInstance($sql);
        }

        if (!$result) return false;

        $id_giohang = $result['id_giohang'];

        // Kiểm tra sản phẩm
        $sql = "SELECT so_luong FROM tbl_ctgiohang WHERE id_giohang = $id_giohang AND id_banh = $product_id";
        $item = $db->getInstance($sql);

        if ($item) {
            $sql_update = "UPDATE tbl_ctgiohang SET so_luong = so_luong + $quantity WHERE id_giohang = $id_giohang AND id_banh = $product_id";
            $db->exec($sql_update);
        } else {
            $sql_insert = "INSERT INTO tbl_ctgiohang (id_giohang, id_banh, so_luong) VALUES ($id_giohang, $product_id, $quantity)";
            $db->exec($sql_insert);
        }

        return true;

    } catch (Exception $e) {
        // Ghi log nếu cần
        return false;
    }
}

public function editCartItem($user_id, $product_id, $new_quantity) {
    $db = new connect();

    $sql = "SELECT id_giohang FROM tbl_giohang WHERE id_nguoidung = $user_id";
    $result = $db->getInstance($sql);

    if ($result) {
        $id_giohang = $result['id_giohang'];
        $sql = "UPDATE tbl_ctgiohang SET so_luong = $new_quantity WHERE id_giohang = $id_giohang AND id_banh = $product_id";
        $db->exec($sql);
    }
}
public function deleteCartItem($user_id, $product_id) {
    $db = new connect();

    $sql = "SELECT id_giohang FROM tbl_giohang WHERE id_nguoidung = $user_id";
    $result = $db->getInstance($sql);

    if ($result) {
        $id_giohang = $result['id_giohang'];
        $sql = "DELETE FROM tbl_ctgiohang WHERE id_giohang = $id_giohang AND id_banh = $product_id";
        $db->exec($sql);
    }
}

}
?>