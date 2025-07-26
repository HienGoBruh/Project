<?php
require_once 'model/master.php';
require_once 'config/db.php';

class CommentBanh {
    public function add() {
        if (isset($_SESSION['id_nguoidung'], $_POST['id_banh'], $_POST['noi_dung'], $_POST['xephang'])) {
            $db = new connect();
            $id_nguoidung = $_SESSION['id_nguoidung'];
            $id_banh = (int)$_POST['id_banh'];
            $noi_dung = htmlspecialchars(trim($_POST['noi_dung']));
            $xephang = (int)$_POST['xephang'];

            $sql_check = "SELECT COUNT(*) FROM tbl_binhluan_banh WHERE id_banh = ? AND id_nguoidung = ?";
            $check = $db->prepare($sql_check);
            if ($check === false) {
                header('Content-Type: text/plain');
                echo "prepare_error";
                exit;
            }
            $check->execute([$id_banh, $id_nguoidung]);
            $exists = $check->fetchColumn();

            if ($exists > 0) {
                header('Content-Type: text/plain');
                echo "already_commented";
                exit;
            }

            $sql = "INSERT INTO tbl_binhluan_banh (ma_binhluan, id_nguoidung, id_banh, noi_dung, xephang) VALUES (?, ?, ?, ?, ?)";
            $ma_binhluan = 'BLB' . rand(1000, 9999);
            $stmt = $db->prepare($sql);
            if ($stmt === false) {
                header('Content-Type: text/plain');
                echo "prepare_error";
                exit;
            }

            $result = $stmt->execute([$ma_binhluan, $id_nguoidung, $id_banh, $noi_dung, $xephang]);
            if ($result === false) {
                $errorInfo = $stmt->errorInfo();
                header('Content-Type: text/plain');
                echo "fail: " . $errorInfo[2]; // In thông báo lỗi chi tiết
            } else {
                header('Content-Type: text/plain');
                echo "success";
            }
            exit;
        }
        header('Content-Type: text/plain');
        echo "login_required";
        exit;
    }

    public function update() {
        if (isset($_SESSION['id_nguoidung'], $_POST['id_bl'], $_POST['noi_dung'], $_POST['xephang'])) {
            $id_bl = (int)$_POST['id_bl'];
            $noi_dung = htmlspecialchars(trim($_POST['noi_dung']));
            $xephang = (int)$_POST['xephang'];

            $sql = "UPDATE tbl_binhluan_banh SET noi_dung = ?, xephang = ? WHERE id_bl = ? AND id_nguoidung = ?";
            $db = new connect();
            $stmt = $db->prepare($sql);
            if ($stmt === false) {
                header('Content-Type: text/plain');
                echo "prepare_error";
                exit;
            }

            $result = $stmt->execute([$noi_dung, $xephang, $id_bl, $_SESSION['id_nguoidung']]);
            if ($result === false) {
                $errorInfo = $stmt->errorInfo();
                header('Content-Type: text/plain');
                echo "fail: " . $errorInfo[2]; // In thông báo lỗi chi tiết
            } else {
                header('Content-Type: text/plain');
                echo "success";
            }
            exit;
        }
        header('Content-Type: text/plain');
        echo "invalid";
        exit;
    }
}