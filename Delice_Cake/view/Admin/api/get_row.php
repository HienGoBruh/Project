<?php
ini_set('display_errors', 1);
error_reporting(E_ALL);
header('Content-Type: application/json');

require_once __DIR__ . '/../../../model/admin.php'; // ✅ Sửa đúng đường dẫn
$result = new ModelAdmin();

$page = $_GET['page'] ?? '';
$id = $_GET['id'] ?? '';

$tableMap = [
    'danhmuc' => ['table' => 'tbl_danhmuc_banh', 'id_field' => 'id_danhmuc'],
    'banh' => ['table' => 'tbl_banh', 'id_field' => 'id_banh'],
    'nguoidung' => ['table' => 'tbl_nguoidung', 'id_field' => 'id_nguoidung'],
    'khuyenmai' => ['table' => 'tbl_khuyenmai', 'id_field' => 'id_km'],
    'tintuc' => ['table' => 'tbl_tintuc', 'id_field' => 'id_tintuc'],
    'loaitintuc' => ['table' => 'tbl_loaitintuc', 'id_field' => 'id_loai'],
    'vanchuyen' => ['table' => 'tbl_vanchuyen', 'id_field' => 'id_vanchuyen'],
    'pttt' => ['table' => 'pttt', 'id_field' => 'MAPTTT'],
    'binhluanbanh' => ['table' => 'tbl_binhluan_banh', 'id_field' => 'id_bl'],
    'binhluantintuc' => ['table' => 'tbl_binhluan_tintuc', 'id_field' => 'id_bl']
];

if (!isset($tableMap[$page])) {
    echo json_encode(['error' => 'Trang không hợp lệ']);
    exit;
}

$table = $tableMap[$page]['table'];
$id_field = $tableMap[$page]['id_field'];

$data = $result->get_by_id1($table, $id_field, $id);

if (!$data) {
    echo json_encode(['error' => 'Không tìm thấy dữ liệu']);
} else {
    echo json_encode($data);
}
