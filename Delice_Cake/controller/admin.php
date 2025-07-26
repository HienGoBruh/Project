<?php
class Admin {
    private $tableMap = [
        'danhmuc' => ['table' => 'tbl_danhmuc_banh', 'id_field' => 'id_danhmuc', 'search_column' => 'ten_danhmuc'],
        'banh' => ['table' => 'tbl_banh', 'id_field' => 'id_banh', 'search_column' => 'ten_banh'],
        'nguoidung' => ['table' => 'tbl_nguoidung', 'id_field' => 'id_nguoidung', 'search_column' => 'ho_ten'],
        'khuyenmai' => ['table' => 'tbl_khuyenmai', 'id_field' => 'id_km', 'search_column' => 'loai'],
        'tintuc' => ['table' => 'tbl_tintuc', 'id_field' => 'id_tintuc', 'search_column' => 'tieu_de'],
        'loaitintuc' => ['table' => 'tbl_loaitintuc', 'id_field' => 'id_loai', 'search_column' => 'ten_loai'],
        'vanchuyen' => ['table' => 'tbl_vanchuyen', 'id_field' => 'id_vanchuyen', 'search_column' => 'ten_dvvc'],
        'pttt' => ['table' => 'pttt', 'id_field' => 'MAPTTT', 'search_column' => 'TENPTTT'],
        'binhluanbanh' => ['table' => 'tbl_binhluan_banh', 'id_field' => 'id_bl', 'search_column' => 'noi_dung'],
        'binhluantintuc' => ['table' => 'tbl_binhluan_tintuc', 'id_field' => 'id_bl', 'search_column' => 'noi_dung'],
        'ctdonhang' => ['table' => 'tbl_ctdonhang', 'id_field' => 'id_ctdh', 'search_column' => 'id_donhang'],
        'hoadon' => ['table' => 'tbl_hoadon', 'id_field' => 'id_hoadon', 'search_column' => 'trang_thai'],
        'donhang' => ['table' => 'tbl_donhang', 'id_field' => 'id_donhang', 'search_column' => 'trang_thai']
    ];

    public function index() {
        $page = isset($_GET['page']) ? $_GET['page'] : 'danhmuc';
        require_once 'view/Admin/index.php';
    }

    public function loadData() {
        ini_set('display_errors', 0);
        error_reporting(E_ALL);
        header('Content-Type: application/json');

        require_once 'model/admin.php';
        $page = $_GET['page'] ?? '';
        $offset = (int)($_GET['offset'] ?? 0);
        $limit = 5;
        $keyword = trim($_GET['keyword'] ?? '');

        if (!isset($this->tableMap[$page])) {
            echo json_encode(['error' => 'Invalid page']);
            exit;
        }

        $table = $this->tableMap[$page]['table'];
        $id_field = $this->tableMap[$page]['id_field'];
        $search_column = $this->tableMap[$page]['search_column'];

        try {
            $result = new ModelAdmin();
            $data = $keyword !== '' ? 
                $result->get_search_limit($table, $search_column, $keyword, $offset, $limit) : 
                $result->get_limit($table, $offset, $limit);

            $response = ['thead' => '', 'tbody' => ''];
            $jsonPath = "view/Admin/field/{$page}.json";
            if (!file_exists($jsonPath)) {
                echo json_encode(['error' => "File JSON không tồn tại: $jsonPath"]);
                exit;
            }
            $json = json_decode(file_get_contents($jsonPath), true);
            if (!$json || !isset($json['fields'])) {
                echo json_encode(['error' => "File JSON không hợp lệ: $jsonPath"]);
                exit;
            }
            $fields = $json['fields'];
            $imagePath = $json['upload_path'] ?? [];

            if ($offset == 0) {
                foreach ($fields as $key => $info) {
                    $response['thead'] .= '<th>' . htmlspecialchars($info['label']) . '</th>';
                }
                $response['thead'] .= '<th>Hành động</th>';
            }

            $onlyDeletePages = ['ctdonhang', 'donhang', 'hoadon'];
            foreach ($data as $row) {
                $response['tbody'] .= '<tr>';
                foreach ($fields as $field => $info) {
                    $response['tbody'] .= '<td>';
                    if ($info['type'] == 'image' && isset($imagePath[$field])) {
                        $response['tbody'] .= '<img src="' . $imagePath[$field] . ($row[$field] ?? '') . '" width="60">';
                    } else {
                        $response['tbody'] .= htmlspecialchars($row[$field] ?? '');
                    }
                    $response['tbody'] .= '</td>';
                }
                $response['tbody'] .= '<td>';
                if (!in_array($page, $onlyDeletePages)) {
                    $response['tbody'] .= '<button type="button" class="btn btn-warning btn-edit" data-id="' . htmlspecialchars($row[$id_field] ?? '') . '">Sửa</button> ';
                }
                $response['tbody'] .= '<button class="btn btn-danger btn-delete" data-id="' . htmlspecialchars($row[$id_field] ?? '') . '">Xóa</button>';
                $response['tbody'] .= '</td></tr>';
            }
            echo json_encode($response);
        } catch (Exception $e) {
            echo json_encode(['error' => 'Lỗi tải dữ liệu: ' . $e->getMessage()]);
        }
    }

    public function insertOrUpdate() {
        ini_set('display_errors', 0);
        error_reporting(E_ALL);
        header('Content-Type: application/json');

        require_once 'model/admin.php';
        $model = new ModelAdmin();
        $table = $_POST['table'] ?? '';
        $id_field = $_POST['id_field'] ?? '';
        $data = $_POST;

        if (!isset($this->tableMap[$table])) {
            echo json_encode(['error' => 'Invalid table']);
            exit;
        }
        $table = $this->tableMap[$table]['table'];

        try {
            foreach ($_FILES as $field => $file) {
                if ($file['error'] == 0) {
                    $ext = pathinfo($file['name'], PATHINFO_EXTENSION);
                    $newName = uniqid() . '.' . $ext;
                    $uploadDir = $_POST['upload_path'][$field] ?? 'uploads/';
                    if (!is_dir($uploadDir)) {
                        mkdir($uploadDir, 0755, true);
                    }
                    move_uploaded_file($file['tmp_name'], $uploadDir . $newName);
                    $data[$field] = $newName;
                }
            }
            $id = $data['id'] ?? '';
            unset($data['table'], $data['id_field'], $data['id'], $data['upload_path']);
            if ($id == '') {
                if (isset($data['mat_khau']) && $data['mat_khau'] != '') {
                    $data['mat_khau'] = password_hash($data['mat_khau'], PASSWORD_DEFAULT);
                }
                $model->insert($table, $data);
            } else {
                if (isset($data['mat_khau'])) {
                    if ($data['mat_khau'] != '') {
                        $data['mat_khau'] = password_hash($data['mat_khau'], PASSWORD_DEFAULT);
                    } else {
                        unset($data['mat_khau']);
                    }
                }
                $model->update($table, $id_field, $id, $data);
            }
            echo json_encode(['status' => 'success']);
        } catch (Exception $e) {
            echo json_encode(['error' => 'Lỗi lưu dữ liệu: ' . $e->getMessage()]);
        }
    }

    public function delete() {
        ini_set('display_errors', 0);
        error_reporting(E_ALL);
        header('Content-Type: application/json');

        require_once 'model/admin.php';
        $model = new ModelAdmin();
        $page = $_POST['table'] ?? '';
        $id_field = $_POST['id_field'] ?? '';
        $id = $_POST['id'] ?? '';

        if (!isset($this->tableMap[$page])) {
            echo json_encode(['error' => 'Invalid page']);
            exit;
        }
        $table = $this->tableMap[$page]['table'];

        if (!$table || !$id_field || !$id) {
            echo json_encode(['error' => 'Dữ liệu không hợp lệ']);
            exit;
        }

        try {
            $model->delete($table, $id_field, $id);
            echo json_encode(['status' => 'deleted']);
        } catch (Exception $e) {
            echo json_encode(['error' => 'Lỗi xóa: ' . $e->getMessage()]);
        }
    }

    public function generateCode() {
        ini_set('display_errors', 0);
        error_reporting(E_ALL);
        header('Content-Type: application/json');

        require_once 'model/admin.php';
        $model = new ModelAdmin();
        $page = $_GET['page'] ?? '';
        $codeMap = [
            'danhmuc' => ['table' => 'tbl_danhmuc_banh', 'column' => 'ma_danhmuc', 'prefix' => 'DM'],
            'banh' => ['table' => 'tbl_banh', 'column' => 'ma_banh', 'prefix' => 'B'],
            'nguoidung' => ['table' => 'tbl_nguoidung', 'column' => 'ma_nguoidung', 'prefix' => 'ND'],
            'khuyenmai' => ['table' => 'tbl_khuyenmai', 'column' => 'ma_khuyenmai', 'prefix' => 'KM'],
            'tintuc' => ['table' => 'tbl_tintuc', 'column' => 'ma_tintuc', 'prefix' => 'TT'],
            'loaitintuc' => ['table' => 'tbl_loaitintuc', 'column' => 'ma_loai', 'prefix' => 'LTT'],
            'vanchuyen' => ['table' => 'tbl_vanchuyen', 'column' => 'ma_vanchuyen', 'prefix' => 'VC'],
            'pttt' => ['table' => 'pttt', 'column' => 'MAPTTT', 'prefix' => 'PTTT'],
            'binhluanbanh' => ['table' => 'tbl_binhluan_banh', 'column' => 'ma_binhluan', 'prefix' => 'BLB'],
            'binhluantintuc' => ['table' => 'tbl_binhluan_tintuc', 'column' => 'ma_binhluan', 'prefix' => 'BLT']
        ];

        if (!isset($codeMap[$page])) {
            echo json_encode(['error' => 'Invalid page']);
            exit;
        }

        try {
            $table = $codeMap[$page]['table'];
            $column = $codeMap[$page]['column'];
            $prefix = $codeMap[$page]['prefix'];
            $prefix_length = strlen($prefix) + 2; // Giả sử mã có độ dài cố định là 5 ký tự sau tiền tố
            $code = $model->generateAutoCode($table, $column, $prefix, $prefix_length);
            echo json_encode(['code' => $code]);
        } catch (Exception $e) {
            echo json_encode(['error' => 'Lỗi tạo mã: ' . $e->getMessage()]);
        }
    }

    public function getOptions() {
        ini_set('display_errors', 0);
        error_reporting(E_ALL);
        header('Content-Type: application/json');

        require_once 'model/admin.php';
        $model = new ModelAdmin();
        $table = $_GET['table'] ?? '';
        $valueField = $_GET['value'] ?? '';
        $labelField = $_GET['label'] ?? '';

        if (!$table || !$valueField || !$labelField) {
            echo json_encode(['error' => 'Dữ liệu không hợp lệ']);
            exit;
        }

        try {
            $sql = "SELECT `$valueField`, `$labelField` FROM `$table`";
            $db = new connect();
            $stmt = $db->db->query($sql);
            $rows = $stmt->fetchAll(PDO::FETCH_ASSOC);
            $options = [];
            foreach ($rows as $row) {
                $options[$row[$valueField]] = $row[$labelField];
            }
            echo json_encode($options);
        } catch (Exception $e) {
            echo json_encode(['error' => 'Lỗi tải options: ' . $e->getMessage()]);
        }
    }
}
?>