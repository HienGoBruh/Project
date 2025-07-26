<?php
// Cấu hình kết nối CSDL
$host     = 'sql204.infinityfree.com';
$dbname   = 'if0_39033364_tranhiendz';
$username = 'if0_39033364';
$password = 'VP3aMpsyxQ6B';
try {
    $pdo = new PDO("mysql:host=$host;dbname=$dbname;charset=utf8", $username, $password);
    $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
} catch(PDOException $e) {
    die("Kết nối CSDL thất bại: " . $e->getMessage());
}

// Hàm kiểm tra chuỗi rỗng
function isBlank($value) {
    return trim($value) === "";
}

// Hàm lấy ngày hiện tại theo định dạng Y-m-d
function currentDate() {
    return date("Y-m-d");
}

// Hàm tạo ID tự động
function generateId($pdo, $table, $prefix, $idColumn) {
    $stmt = $pdo->prepare("SELECT $idColumn FROM $table ORDER BY CAST(SUBSTR($idColumn, 2) AS UNSIGNED) DESC LIMIT 1");
    $stmt->execute();
    $lastId = $stmt->fetchColumn();
    $number = $lastId ? (int)substr($lastId, 1) + 1 : 1;
    return $prefix . $number;
}

// *** Mapping tĩnh cho publisherID ***
$publisherMapping = [
    'P1'  => 'Rockstar Games',
    'P10' => '2K Games',
    'P11' => 'Valve',
    'P12' => 'Chess.com',
    'P13' => 'Capcom',
    'P14' => 'Team Cherry',
    'P15' => 'ConcernedApe Chucklefish',
    'P2'  => 'CD Projekt Red',
    'P3'  => 'Xbox Game Studios',
    'P4'  => 'Nintendo',
    'P5'  => 'Electronic Arts',
    'P6'  => 'Activision',
    'P7'  => 'Beat Games',
    'P8'  => 'EA Sports',
    'P9'  => 'Fishing Planet LLC'
];

// *** Mapping động cho developerID, discounts và game ***
$developerMapping = [];
$stmtDev = $pdo->prepare("SELECT developers_id, developers_name FROM developers");
$stmtDev->execute();
while($row = $stmtDev->fetch(PDO::FETCH_ASSOC)){
    $developerMapping[$row['developers_id']] = $row['developers_name'];
}

$discountMapping = [];
$stmtDisc = $pdo->prepare("SELECT discount_id, discount_name FROM discounts");
$stmtDisc->execute();
while($row = $stmtDisc->fetch(PDO::FETCH_ASSOC)){
    $discountMapping[$row['discount_id']] = $row['discount_name'];
}

$gameMapping = [];
$stmtGame = $pdo->prepare("SELECT game_id, game_name FROM game");
$stmtGame->execute();
while($row = $stmtGame->fetch(PDO::FETCH_ASSOC)){
    $gameMapping[$row['game_id']] = $row['game_name'];
}

// Lấy danh sách tất cả các categories
$allCategories = [];
$stmtAllCategories = $pdo->prepare("SELECT categories_id, categories_name FROM categories ORDER BY categories_name ASC");
$stmtAllCategories->execute();
$allCategories = $stmtAllCategories->fetchAll(PDO::FETCH_ASSOC);

// Xử lý các yêu cầu AJAX (POST có action)
if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_GET['action'])) {
    header('Content-Type: application/json');
    $action = $_GET['action'];
    $data   = json_decode(file_get_contents('php://input'), true);
    if (!$data) {
        echo json_encode(['success' => false, 'error' => 'Không có dữ liệu']);
        exit;
    }
    
    $entity = $data['entity'] ?? '';
    
    switch ($action) {
        case 'update':
            $id = $data['id'] ?? '';
            $updateData = $data['data'] ?? [];
            if (!$entity || !$id || empty($updateData)) {
                echo json_encode(['success' => false, 'error' => 'Thiếu tham số']);
                exit;
            }
            foreach ($updateData as $field => $value) {
                if (isBlank($value) && !($entity === 'game' && $field === 'game_details')) {
                    if (($entity === 'account' || $entity === 'news') && $field === 'created_at') {
                        $updateData[$field] = currentDate();
                    } else {
                        echo json_encode(['success' => false, 'error' => "Trường $field không được để trống"]);
                        exit;
                    }
                }
            }
            if ($entity === 'game') {
                $columns = ['game_name', 'realse_date', 'publisherID', 'game_details', 'developerID'];
                $table = 'game';
                $idColumn = 'game_id';
                $assocDeveloper = $updateData['developerID'] ?? '';
                $assocDiscount = $updateData['discounts'] ?? '';
                $assocCategories = $updateData['categories'] ?? '';
                unset($updateData['categories'], $updateData['discounts']);
            } elseif ($entity === 'categories') {
                $columns = ['categories_name', 'type_id', 'img_url'];
                $table = 'categories';
                $idColumn = 'categories_id';
            } elseif ($entity === 'discounts') {
                $columns = ['discount_name', 'discount_type', 'discount_value', 'start_date', 'end_date'];
                $table = 'discounts';
                $idColumn = 'discount_id';
            } elseif ($entity === 'account') {
                $columns = ['user_Name', 'email', 'Password', 'created_at', 'role'];
                $table = 'user';
                $idColumn = 'user_Id';
            } elseif ($entity === 'news') {
                $columns = ['title', 'description', 'content', 'image', 'author', 'created_at'];
                $table = 'news';
                $idColumn = 'news_id';
            } elseif ($entity === 'game_price') {
                $columns = ['game_id', 'price_value', 'start_date', 'end_date'];
                $table = 'game_price';
                $idColumn = 'price_id';
            } elseif ($entity === 'game_img') {
                $columns = ['img_url', 'game_id'];
                $table = 'game_img';
                $idColumn = 'img_id';
            } else {
                echo json_encode(['success' => false, 'error' => 'Đối tượng không hợp lệ']);
                exit;
            }
            $setParts = [];
            $params = [];
            foreach ($columns as $col) {
                if (isset($updateData[$col])) {
                    $setParts[] = "$col = :$col";
                    $params[$col] = $updateData[$col];
                }
            }
            if (empty($setParts)) {
                echo json_encode(['success' => false, 'error' => 'Không có dữ liệu hợp lệ để cập nhật']);
                exit;
            }
            $sql = "UPDATE $table SET " . implode(', ', $setParts) . " WHERE $idColumn = :id";
            $params['id'] = $id;
            $stmt = $pdo->prepare($sql);
            if ($stmt->execute($params)) {
                if ($entity === 'game') {
                    if (isset($assocDeveloper)) {
                        $stmtDel = $pdo->prepare("DELETE FROM game_developers WHERE game_id = ?");
                        $stmtDel->execute([$id]);
                        if (!empty($assocDeveloper)) {
                            $devIds = array_filter(array_map('trim', explode(",", $assocDeveloper)));
                            $stmtIns = $pdo->prepare("INSERT INTO game_developers (developers_id, game_id) VALUES (?, ?)");
                            foreach ($devIds as $devId) {
                                $stmtIns->execute([$devId, $id]);
                            }
                        }
                    }
                    if (isset($assocDiscount)) {
                        $stmtDel = $pdo->prepare("DELETE FROM game_discounts WHERE game_id = ?");
                        $stmtDel->execute([$id]);
                        if (!empty($assocDiscount)) {
                            $discIds = array_filter(array_map('trim', explode(",", $assocDiscount)));
                            $stmtIns = $pdo->prepare("INSERT INTO game_discounts (discount_id, game_id) VALUES (?, ?)");
                            foreach ($discIds as $discId) {
                                $stmtIns->execute([$discId, $id]);
                            }
                        }
                    }
                    if (isset($assocCategories)) {
                        $catIds = array_filter(array_map('trim', explode(",", $assocCategories)));
                        $stmtDel = $pdo->prepare("DELETE FROM categories_game WHERE gameID = ?");
                        $stmtDel->execute([$id]);
                        if (!empty($catIds)) {
                            $stmtIns = $pdo->prepare("INSERT INTO categories_game (categoriesID, gameID) VALUES (?, ?)");
                            foreach ($catIds as $catId) {
                                $stmtIns->execute([$catId, $id]);
                            }
                        }
                    }
                }
                echo json_encode(['success' => true]);
            } else {
                echo json_encode(['success' => false, 'error' => 'Cập nhật thất bại']);
            }
            exit;
            break;
        
        case 'delete':
            $id = $data['id'] ?? '';
            if (!$entity || !$id) {
                echo json_encode(['success' => false, 'error' => 'Thiếu tham số']);
                exit;
            }
            if ($entity === 'game') {
                $stmtDelCat = $pdo->prepare("DELETE FROM categories_game WHERE gameID = ?");
                $stmtDelCat->execute([$id]);
                $stmtDelDisc = $pdo->prepare("DELETE FROM game_discounts WHERE game_id = ?");
                $stmtDelDisc->execute([$id]);
                $stmtDelDev = $pdo->prepare("DELETE FROM game_developers WHERE game_id = ?");
                $stmtDelDev->execute([$id]);
                $stmtDelPrice = $pdo->prepare("DELETE FROM game_price WHERE game_id = ?");
                $stmtDelPrice->execute([$id]);
                $stmtDelImg = $pdo->prepare("DELETE FROM game_img WHERE game_id = ?");
                $stmtDelImg->execute([$id]);
                $table    = 'game';
                $idColumn = 'game_id';
            } elseif ($entity === 'categories') {
                $table    = 'categories';
                $idColumn = 'categories_id';
            } elseif ($entity === 'discounts') {
                $table    = 'discounts';
                $idColumn = 'discount_id';
            } elseif ($entity === 'account') {
                $table    = 'user';
                $idColumn = 'user_Id';
            } elseif ($entity === 'news') {
                $table    = 'news';
                $idColumn = 'news_id';
            } elseif ($entity === 'game_price') {
                $table    = 'game_price';
                $idColumn = 'price_id';
            } elseif ($entity === 'game_img') {
                $table    = 'game_img';
                $idColumn = 'img_id';
            } else {
                echo json_encode(['success' => false, 'error' => 'Đối tượng không hợp lệ']);
                exit;
            }
            $sql = "DELETE FROM $table WHERE $idColumn = :id";
            $stmt = $pdo->prepare($sql);
            if ($stmt->execute(['id' => $id])) {
                echo json_encode(['success' => true]);
            } else {
                echo json_encode(['success' => false, 'error' => 'Xóa thất bại']);
            }
            exit;
            break;
        
        case 'add':
            if (!$entity) {
                echo json_encode(['success' => false, 'error' => 'Thiếu entity']);
                exit;
            }
            $newData = $data['data'] ?? [];
            if (empty($newData)) {
                echo json_encode(['success' => false, 'error' => 'Thiếu dữ liệu']);
                exit;
            }

            $prefixMap = [
                'game' => 'G', 'categories' => 'C', 'discounts' => 'D',
                'account' => 'U', 'news' => 'N', 'game_price' => 'P', 'game_img' => 'I'
            ];
            $tableMap = [
                'game' => 'game', 'categories' => 'categories', 'discounts' => 'discounts',
                'account' => 'user', 'news' => 'news', 'game_price' => 'game_price', 'game_img' => 'game_img'
            ];
            $idColumnMap = [
                'game' => 'game_id', 'categories' => 'categories_id', 'discounts' => 'discount_id',
                'account' => 'user_Id', 'news' => 'news_id', 'game_price' => 'price_id', 'game_img' => 'img_id'
            ];

            $prefix = $prefixMap[$entity];
            $table = $tableMap[$entity];
            $idColumn = $idColumnMap[$entity];
            $newId = generateId($pdo, $table, $prefix, $idColumn);
            $newData[$idColumn] = $newId;

            if ($entity === 'game') {
                $assocDeveloper = $newData['developerID'] ?? '';
                $assocDiscount = $newData['discounts'] ?? '';
                $assocCategories = $newData['categories'] ?? '';
                unset($newData['categories'], $newData['discounts']);
                $columns = ['game_id', 'game_name', 'realse_date', 'publisherID', 'game_details', 'developerID'];
                $optional = ['game_details'];
            } elseif ($entity === 'categories') {
                $columns = ['categories_id', 'categories_name', 'type_id', 'img_url'];
                $optional = ['img_url'];
            } elseif ($entity === 'discounts') {
                $columns = ['discount_id', 'discount_name', 'discount_type', 'discount_value', 'start_date', 'end_date'];
                $optional = [];
            } elseif ($entity === 'account') {
                $columns = ['user_Id', 'user_Name', 'email', 'Password', 'created_at', 'role'];
                $optional = ['created_at'];
            } elseif ($entity === 'news') {
                $columns = ['news_id', 'title', 'description', 'content', 'image', 'author', 'created_at'];
                $optional = ['created_at'];
            } elseif ($entity === 'game_price') {
                $columns = ['price_id', 'game_id', 'price_value', 'start_date', 'end_date'];
                $optional = [];
            } elseif ($entity === 'game_img') {
                $columns = ['img_id', 'img_url', 'game_id'];
                $optional = [];
            } else {
                echo json_encode(['success' => false, 'error' => 'Đối tượng không hợp lệ']);
                exit;
            }

            foreach ($columns as $col) {
                if (!in_array($col, $optional)) {
                    if (!isset($newData[$col]) || isBlank($newData[$col])) {
                        echo json_encode(['success' => false, 'error' => "Trường $col không được để trống"]);
                        exit;
                    }
                } else {
                    if (($entity === 'account' || $entity === 'news') && $col === 'created_at' && (!isset($newData[$col]) || isBlank($newData[$col]))) {
                        $newData[$col] = currentDate();
                    }
                }
            }

            $fields = [];
            $placeholders = [];
            $params = [];
            foreach ($columns as $col) {
                $fields[] = $col;
                $placeholders[] = ":$col";
                $params[$col] = $newData[$col];
            }
            $sql = "INSERT INTO $table (" . implode(',', $fields) . ") VALUES (" . implode(',', $placeholders) . ")";
            try {
                $stmt = $pdo->prepare($sql);
                if ($stmt->execute($params)) {
                    if ($entity === 'game') {
                        if (!empty($assocDeveloper)) {
                            $devIds = array_filter(array_map('trim', explode(",", $assocDeveloper)));
                            $stmtIns = $pdo->prepare("INSERT INTO game_developers (developers_id, game_id) VALUES (?, ?)");
                            foreach ($devIds as $devId) {
                                $stmtIns->execute([$devId, $newId]);
                            }
                        }
                        if (!empty($assocDiscount)) {
                            $discIds = array_filter(array_map('trim', explode(",", $assocDiscount)));
                            $stmtIns = $pdo->prepare("INSERT INTO game_discounts (discount_id, game_id) VALUES (?, ?)");
                            foreach ($discIds as $discId) {
                                $stmtIns->execute([$discId, $newId]);
                            }
                        }
                        if (!empty($assocCategories)) {
                            $catIds = array_filter(array_map('trim', explode(",", $assocCategories)));
                            $stmtIns = $pdo->prepare("INSERT INTO categories_game (categoriesID, gameID) VALUES (?, ?)");
                            foreach ($catIds as $catId) {
                                $stmtIns->execute([$catId, $newId]);
                            }
                        }
                    }
                    echo json_encode(['success' => true, 'id' => $newId]);
                } else {
                    echo json_encode(['success' => false, 'error' => 'Insert thất bại']);
                }
            } catch (PDOException $e) {
                echo json_encode(['success' => false, 'error' => 'Lỗi SQL: ' . $e->getMessage()]);
            }
            exit;
            break;
            
        default:
            echo json_encode(['success' => false, 'error' => 'Action không hợp lệ']);
            exit;
    }
}

// Nếu không phải AJAX (GET) thì hiển thị giao diện admin
$entity = isset($_GET['entity']) ? $_GET['entity'] : 'game';
$search = isset($_GET['search']) ? trim($_GET['search']) : '';

if ($entity === 'game') {
    $sql = "SELECT * FROM game";
    if ($search) {
        $sql .= " WHERE game_name LIKE :search";
    }
    $sql .= " ORDER BY CAST(SUBSTR(game_id, 2) AS UNSIGNED) ASC";
    $stmt = $pdo->prepare($sql);
    if ($search) {
        $stmt->bindValue(':search', "%$search%", PDO::PARAM_STR);
    }
    $stmt->execute();
    $records = $stmt->fetchAll(PDO::FETCH_ASSOC);
    $columns = ['game_id', 'game_name', 'realse_date', 'publisherID', 'developerID', 'game_details', 'categories', 'discounts'];
    foreach ($records as &$record) {
        $pub = $record['publisherID'] ?? '';
        $record['publisherID'] = isset($publisherMapping[$pub]) ? $publisherMapping[$pub] : $pub;
        
        $stmtDevForGame = $pdo->prepare("SELECT developers_id FROM game_developers WHERE game_id = ?");
        $stmtDevForGame->execute([$record['game_id']]);
        $devIds = $stmtDevForGame->fetchAll(PDO::FETCH_COLUMN);
        $record['developerID_raw'] = implode(", ", $devIds);
        $devNames = [];
        foreach($devIds as $devId){
            $devNames[] = isset($developerMapping[$devId]) ? $developerMapping[$devId] : $devId;
        }
        $record['developerID'] = implode(", ", $devNames);
        
        $stmtDiscForGame = $pdo->prepare("SELECT discount_id FROM game_discounts WHERE game_id = ?");
        $stmtDiscForGame->execute([$record['game_id']]);
        $discIds = $stmtDiscForGame->fetchAll(PDO::FETCH_COLUMN);
        $record['discounts_raw'] = implode(", ", $discIds);
        $discNames = [];
        foreach($discIds as $discId){
            $discNames[] = isset($discountMapping[$discId]) ? $discountMapping[$discId] : $discId;
        }
        $record['discounts'] = implode(", ", $discNames);
        
        $stmtCat = $pdo->prepare("SELECT categoriesID FROM categories_game WHERE gameID = ?");
        $stmtCat->execute([$record['game_id']]);
        $catIds = $stmtCat->fetchAll(PDO::FETCH_COLUMN);
        $record['categories_raw'] = implode(", ", $catIds);
        $catNames = [];
        foreach($catIds as $cid){
            foreach($allCategories as $cat){
                if($cat['categories_id'] === $cid){
                    $catNames[] = $cat['categories_name'];
                    break;
                }
            }
        }
        $record['categories'] = implode(", ", $catNames);
    }
    unset($record);
} elseif ($entity === 'categories') {
    $sql = "SELECT * FROM categories";
    if ($search) {
        $sql .= " WHERE categories_name LIKE :search";
    }
    $sql .= " ORDER BY CAST(SUBSTR(categories_id, 2) AS UNSIGNED) ASC";
    $stmt = $pdo->prepare($sql);
    if ($search) {
        $stmt->bindValue(':search', "%$search%", PDO::PARAM_STR);
    }
    $stmt->execute();
    $records = $stmt->fetchAll(PDO::FETCH_ASSOC);
    $columns = ['categories_id', 'categories_name', 'type_id', 'img_url'];
} elseif ($entity === 'discounts') {
    $sql = "SELECT * FROM discounts";
    if ($search) {
        $sql .= " WHERE discount_name LIKE :search";
    }
    $stmt = $pdo->prepare($sql);
    if ($search) {
        $stmt->bindValue(':search', "%$search%", PDO::PARAM_STR);
    }
    $stmt->execute();
    $records = $stmt->fetchAll(PDO::FETCH_ASSOC);
    $columns = ['discount_id', 'discount_name', 'discount_type', 'discount_value', 'start_date', 'end_date'];
} elseif ($entity === 'account') {
    $sql = "SELECT * FROM user";
    if ($search) {
        $sql .= " WHERE user_Name LIKE :search OR email LIKE :search";
    }
    $stmt = $pdo->prepare($sql);
    if ($search) {
        $stmt->bindValue(':search', "%$search%", PDO::PARAM_STR);
    }
    $stmt->execute();
    $records = $stmt->fetchAll(PDO::FETCH_ASSOC);
    $columns = ['user_Id', 'user_Name', 'email', 'Password', 'created_at', 'role'];
} elseif ($entity === 'news') {
    $sql = "SELECT * FROM news";
    if ($search) {
        $sql .= " WHERE title LIKE :search";
    }
    $sql .= " ORDER BY news_id ASC";
    $stmt = $pdo->prepare($sql);
    if ($search) {
        $stmt->bindValue(':search', "%$search%", PDO::PARAM_STR);
    }
    $stmt->execute();
    $records = $stmt->fetchAll(PDO::FETCH_ASSOC);
    $columns = ['news_id', 'title', 'description', 'content', 'image', 'author', 'created_at'];
} elseif ($entity === 'game_price') {
    $sql = "SELECT * FROM game_price ORDER BY CAST(SUBSTR(game_id, 2) AS UNSIGNED) ASC";
    $stmt = $pdo->prepare($sql);
    $stmt->execute();
    $records = $stmt->fetchAll(PDO::FETCH_ASSOC);
    $columns = ['price_id', 'game_id', 'price_value', 'start_date', 'end_date'];
} elseif ($entity === 'game_img') {
    $sql = "SELECT * FROM game_img ORDER BY CAST(SUBSTR(img_id, 2) AS UNSIGNED) ASC";
    $stmt = $pdo->prepare($sql);
    $stmt->execute();
    $records = $stmt->fetchAll(PDO::FETCH_ASSOC);
    $columns = ['img_id', 'img_url', 'game_id'];
} else {
    $stmt = $pdo->prepare("SELECT * FROM game");
    $stmt->execute();
    $records = $stmt->fetchAll(PDO::FETCH_ASSOC);
    $columns = ['game_id', 'game_name', 'realse_date', 'publisherID', 'game_details'];
    $entity  = 'game';
}
?>
<!DOCTYPE html>
<html lang="vi">
<head>
  <meta charset="UTF-8">
  <title>Admin Quản lý <?php echo ucfirst($entity); ?></title>
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
  <style>
    body { background-color: #f8f9fa; margin: 0; padding: 0; }
    h2 { margin-top: 20px; margin-bottom: 20px; }
    .table thead th { background-color: #f1f1f1; }
    .bg-editing { background-color: #fff3cd !important; }
    .nav-link.active { font-weight: bold; }
    .checkbox-container { max-height: 150px; overflow-y: auto; border: 1px solid #ddd; padding: 5px; }
  </style>
  <script>
    var publisherMapping = <?php echo json_encode($publisherMapping); ?>;
    var developerMapping = <?php echo json_encode($developerMapping); ?>;
    var discountMapping = <?php echo json_encode($discountMapping); ?>;
    var allCategories = <?php echo json_encode($allCategories); ?>;
    var gameMapping = <?php echo json_encode($gameMapping); ?>;

    function createSelect(field, currentVal, multiple = false) {
        var optionsData = {};
        if (field === 'publisherID') optionsData = publisherMapping;
        else if (field === 'developerID') optionsData = developerMapping;
        else if (field === 'discounts') optionsData = discountMapping;
        else if (field === 'game_id') optionsData = gameMapping;
        else if (field === 'role') optionsData = { 'admin': 'Admin', 'user': 'User' };
        else if (field === 'discount_type') optionsData = { 'Phần trăm': 'Phần trăm', 'Giảm giá cố định': 'Giảm giá cố định' };

        var select = document.createElement('select');
        select.className = 'form-control';
        if (multiple) select.multiple = true;
        var emptyOption = document.createElement('option');
        emptyOption.value = '';
        emptyOption.text = 'Chọn...';
        select.appendChild(emptyOption);
        for (var key in optionsData) {
            var option = document.createElement('option');
            option.value = key;
            option.text = optionsData[key];
            if (multiple && currentVal && currentVal.split(',').map(item => item.trim()).includes(key)) {
                option.selected = true;
            } else if (!multiple && key === currentVal) {
                option.selected = true;
            }
            select.appendChild(option);
        }
        return select;
    }

    function createCategoriesCheckboxes(currentVal) {
        var container = document.createElement('div');
        container.className = 'checkbox-container';
        var currentArr = currentVal ? currentVal.split(',').map(item => item.trim()) : [];
        allCategories.forEach(function(cat) {
            var div = document.createElement('div');
            div.className = 'form-check';
            var checkbox = document.createElement('input');
            checkbox.type = 'checkbox';
            checkbox.className = 'form-check-input';
            checkbox.value = cat.categories_id;
            if (currentArr.includes(cat.categories_id)) {
                checkbox.checked = true;
            }
            var label = document.createElement('label');
            label.className = 'form-check-label';
            label.textContent = cat.categories_name;
            div.appendChild(checkbox);
            div.appendChild(label);
            container.appendChild(div);
        });
        return container;
    }
  </script>
</head>
<body>
<div class="container my-4">
  <h2>Quản lý <?php echo ucfirst($entity); ?></h2>
  
  <ul class="nav nav-tabs mb-3">
    <li class="nav-item"><a class="nav-link <?php echo $entity=='game' ? 'active' : ''; ?>" href="?entity=game">Game</a></li>
    <li class="nav-item"><a class="nav-link <?php echo $entity=='categories' ? 'active' : ''; ?>" href="?entity=categories">Thể loại</a></li>
    <li class="nav-item"><a class="nav-link <?php echo $entity=='discounts' ? 'active' : ''; ?>" href="?entity=discounts">Giảm giá</a></li>
    <li class="nav-item"><a class="nav-link <?php echo $entity=='account' ? 'active' : ''; ?>" href="?entity=account">Tài khoản</a></li>
    <li class="nav-item"><a class="nav-link <?php echo $entity=='news' ? 'active' : ''; ?>" href="?entity=news">Tin tức</a></li>
    <li class="nav-item"><a class="nav-link <?php echo $entity=='game_price' ? 'active' : ''; ?>" href="?entity=game_price">Game Price</a></li>
    <li class="nav-item"><a class="nav-link <?php echo $entity=='game_img' ? 'active' : ''; ?>" href="?entity=game_img">Game Images</a></li>
    <li class="nav-item ms-auto"><a href="index.php" class="nav-link fw-bold" style="color: black;">Trang Chủ</a></li>
  </ul>
  
  <form class="mb-3" method="GET" action="">
    <div class="input-group">
      <input type="hidden" name="entity" value="<?php echo $entity; ?>">
      <input type="text" class="form-control" name="search" placeholder="Tìm kiếm <?php echo $entity; ?>" value="<?php echo htmlspecialchars($search); ?>">
      <button class="btn btn-outline-secondary" type="submit">Tìm kiếm</button>
    </div>
  </form>
  
  <button class="btn btn-success mb-3" id="addNew">Thêm mới <?php echo ucfirst($entity); ?></button>
  
  <table class="table table-bordered" id="dataTable">
    <thead>
      <tr>
        <?php foreach($columns as $col): ?>
          <th><?php echo $col; ?></th>
        <?php endforeach; ?>
        <th>Edit</th>
        <th>Delete</th>
      </tr>
    </thead>
    <tbody>
      <?php foreach($records as $record): ?>
      <tr data-id="<?php echo $record[$columns[0]]; ?>">
        <?php foreach($columns as $col): ?>
          <?php if($entity=='game'): ?>
            <?php if($col=='game_id'): ?>
              <td data-field="game_id" data-value="<?php echo htmlspecialchars($record[$col]); ?>">
                <?php echo htmlspecialchars($record[$col]); ?>
              </td>
            <?php elseif($col=='realse_date'): ?>
              <td class="editable" data-field="realse_date" data-value="<?php echo htmlspecialchars($record[$col]); ?>">
                <input type="date" class="form-control" value="<?php echo htmlspecialchars($record[$col]); ?>" readonly>
              </td>
            <?php elseif($col=='publisherID'): ?>
              <td class="editable" data-field="publisherID" data-value="<?php echo htmlspecialchars($record['publisherID']); ?>">
                <?php echo htmlspecialchars($record['publisherID']); ?>
              </td>
            <?php elseif($col=='developerID'): ?>
              <td class="editable" data-field="developerID" data-value="<?php echo htmlspecialchars($record['developerID_raw']); ?>">
                <?php echo htmlspecialchars($record['developerID']); ?>
              </td>
            <?php elseif($col=='discounts'): ?>
              <td class="editable" data-field="discounts" data-value="<?php echo htmlspecialchars($record['discounts_raw']); ?>">
                <?php echo htmlspecialchars($record['discounts']); ?>
              </td>
            <?php elseif($col=='categories'): ?>
              <td class="editable" data-field="categories" data-value="<?php echo htmlspecialchars($record['categories_raw']); ?>">
                <?php echo htmlspecialchars($record['categories']); ?>
              </td>
            <?php else: ?>
              <td class="editable" data-field="<?php echo $col; ?>" data-value="<?php echo htmlspecialchars($record[$col]); ?>">
                <?php echo htmlspecialchars($record[$col]); ?>
              </td>
            <?php endif; ?>
          <?php elseif($entity=='discounts'): ?>
            <?php if($col=='discount_id'): ?>
              <td data-field="discount_id" data-value="<?php echo htmlspecialchars($record[$col]); ?>">
                <?php echo htmlspecialchars($record[$col]); ?>
              </td>
            <?php elseif($col=='discount_type'): ?>
              <td class="editable" data-field="discount_type" data-value="<?php echo htmlspecialchars($record[$col]); ?>">
                <?php echo htmlspecialchars($record[$col]); ?>
              </td>
            <?php elseif($col=='start_date' || $col=='end_date'): ?>
              <td class="editable" data-field="<?php echo $col; ?>" data-value="<?php echo htmlspecialchars($record[$col]); ?>">
                <input type="date" class="form-control" value="<?php echo htmlspecialchars($record[$col]); ?>" readonly>
              </td>
            <?php else: ?>
              <td class="editable" data-field="<?php echo $col; ?>" data-value="<?php echo htmlspecialchars($record[$col] ?? ''); ?>">
                <?php echo htmlspecialchars($record[$col] ?? ''); ?>
              </td>
            <?php endif; ?>
          <?php elseif($entity=='categories'): ?>
            <?php if($col=='categories_id'): ?>
              <td data-field="categories_id" data-value="<?php echo htmlspecialchars($record[$col]); ?>">
                <?php echo htmlspecialchars($record[$col]); ?>
              </td>
            <?php else: ?>
              <td class="editable" data-field="<?php echo $col; ?>" data-value="<?php echo htmlspecialchars($record[$col] ?? ''); ?>">
                <?php echo htmlspecialchars($record[$col] ?? ''); ?>
              </td>
            <?php endif; ?>
          <?php else: ?>
            <?php if($col=='user_Id' || $col=='news_id' || $col=='price_id' || $col=='img_id'): ?>
              <td data-field="<?php echo $col; ?>" data-value="<?php echo htmlspecialchars($record[$col] ?? ''); ?>">
                <?php echo htmlspecialchars($record[$col] ?? ''); ?>
              </td>
            <?php else: ?>
              <td class="editable" data-field="<?php echo $col; ?>" data-value="<?php echo htmlspecialchars($record[$col] ?? ''); ?>">
                <?php echo htmlspecialchars($record[$col] ?? ''); ?>
              </td>
            <?php endif; ?>
          <?php endif; ?>
        <?php endforeach; ?>
        <td><button class="btn btn-sm btn-primary edit-btn">Edit</button></td>
        <td><button class="btn btn-sm btn-danger delete-btn">Delete</button></td>
      </tr>
      <?php endforeach; ?>
    </tbody>
  </table>
</div>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
<script>
document.querySelectorAll('.edit-btn').forEach(function(btn) {
  btn.addEventListener('click', function() {
    var row = this.closest('tr');
    var isEditing = row.classList.contains('editing');
    var delBtn = row.querySelector('.delete-btn');
    if (!isEditing) {
      row.querySelectorAll('.editable').forEach(function(cell) {
         cell.setAttribute('data-old', cell.innerHTML);
         var field = cell.getAttribute('data-field');
         var currentVal = cell.getAttribute('data-value') || '';
         if (field === 'realse_date' || field === 'start_date' || field === 'end_date' || field === 'created_at') {
             var input = document.createElement('input');
             input.type = 'date';
             input.className = 'form-control';
             input.value = currentVal;
             cell.innerHTML = '';
             cell.appendChild(input);
         } else if (field === 'publisherID' || field === 'developerID' || field === 'discounts' || field === 'game_id' || field === 'role' || field === 'discount_type') {
             var select = createSelect(field, currentVal, false);
             cell.innerHTML = '';
             cell.appendChild(select);
         } else if (field === 'categories') {
             var checkboxes = createCategoriesCheckboxes(currentVal);
             cell.innerHTML = '';
             cell.appendChild(checkboxes);
         } else {
             cell.contentEditable = "true";
             cell.classList.add('bg-editing');
         }
      });
      row.classList.add('editing');
      this.textContent = 'Save';
      if (delBtn) delBtn.textContent = 'Cancel';
    } else {
      var updatedData = {};
      row.querySelectorAll('.editable').forEach(function(cell) {
         var field = cell.getAttribute('data-field');
         if (field === 'realse_date' || field === 'start_date' || field === 'end_date' || field === 'created_at') {
             var input = cell.querySelector('input');
             updatedData[field] = input ? input.value.trim() : '';
         } else if (field === 'publisherID' || field === 'developerID' || field === 'discounts' || field === 'game_id' || field === 'role' || field === 'discount_type') {
             var select = cell.querySelector('select');
             updatedData[field] = select ? select.value : '';
         } else if (field === 'categories') {
             var selected = Array.from(cell.querySelectorAll('input[type="checkbox"]:checked')).map(cb => cb.value);
             updatedData[field] = selected.join(', ');
         } else {
             updatedData[field] = cell.textContent.trim();
         }
      });
      var recordId = row.getAttribute('data-id');
      fetch('?action=update', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          entity: '<?php echo $entity; ?>',
          id: recordId,
          data: updatedData
        })
      })
      .then(response => response.json())
      .then(result => {
        if (result.success) {
          alert('Cập nhật thành công!');
          location.reload();
        } else {
          alert('Cập nhật thất bại: ' + result.error);
        }
      })
      .catch(error => {
         console.error('Error:', error);
         alert('Có lỗi xảy ra');
      });
    }
  });
});

document.querySelectorAll('.delete-btn').forEach(function(btn) {
  btn.addEventListener('click', function() {
    var row = this.closest('tr');
    if (row.classList.contains('editing')) {
      row.querySelectorAll('.editable').forEach(function(cell) {
         var original = cell.getAttribute('data-old');
         if (original !== null) cell.innerHTML = original;
         cell.contentEditable = "false";
         cell.classList.remove('bg-editing');
      });
      row.classList.remove('editing');
      var editBtn = row.querySelector('.edit-btn');
      if (editBtn) editBtn.textContent = 'Edit';
      this.textContent = 'Delete';
    } else {
      if (!confirm('Xác nhận xóa?')) return;
      var recordId = row.getAttribute('data-id');
      fetch('?action=delete', {
         method: 'POST',
         headers: { 'Content-Type': 'application/json' },
         body: JSON.stringify({
           entity: '<?php echo $entity; ?>',
           id: recordId
         })
      })
      .then(response => response.json())
      .then(result => {
         if (result.success) {
            alert('Xóa thành công!');
            row.remove();
         } else {
            alert('Xóa thất bại: ' + result.error);
         }
      })
      .catch(error => {
         console.error('Error:', error);
         alert('Có lỗi xảy ra');
      });
    }
  });
});

document.getElementById('addNew').addEventListener('click', function() {
  var tbody = document.querySelector('#dataTable tbody');
  var newRow = document.createElement('tr');
  newRow.setAttribute('data-id', 'new');

  <?php
  $newRowCells = "";
  foreach ($columns as $col) {
      if ($entity == 'game') {
          if ($col == 'game_id') {
              $newId = generateId($pdo, 'game', 'G', 'game_id');
              $newRowCells .= "<td data-field='game_id'>$newId</td>";
          } elseif ($col == 'realse_date') {
              $newRowCells .= "<td class='editable' data-field='realse_date'><input type='date' class='form-control' value='".currentDate()."'></td>";
          } elseif ($col == 'publisherID' || $col == 'developerID' || $col == 'discounts' || $col == 'categories') {
              $newRowCells .= "<td class='editable' data-field='{$col}'></td>";
          } else {
              $newRowCells .= "<td class='editable' data-field='{$col}' contenteditable='true'></td>";
          }
      } elseif ($entity == 'discounts') {
          if ($col == 'discount_id') {
              $newId = generateId($pdo, 'discounts', 'D', 'discount_id');
              $newRowCells .= "<td data-field='discount_id'>$newId</td>";
          } elseif ($col == 'start_date' || $col == 'end_date') {
              $newRowCells .= "<td class='editable' data-field='{$col}'><input type='date' class='form-control' value='".currentDate()."'></td>";
          } elseif ($col == 'discount_type') {
              $newRowCells .= "<td class='editable' data-field='{$col}'></td>";
          } else {
              $newRowCells .= "<td class='editable' data-field='{$col}' contenteditable='true'></td>";
          }
      } elseif ($entity == 'categories') {
          if ($col == 'categories_id') {
              $newId = generateId($pdo, 'categories', 'C', 'categories_id');
              $newRowCells .= "<td data-field='categories_id'>$newId</td>";
          } else {
              $newRowCells .= "<td class='editable' data-field='{$col}' contenteditable='true'></td>";
          }
      } elseif ($entity == 'game_price') {
          if ($col == 'price_id') {
              $newId = generateId($pdo, 'game_price', 'P', 'price_id');
              $newRowCells .= "<td data-field='price_id'>$newId</td>";
          } elseif ($col == 'start_date' || $col == 'end_date') {
              $newRowCells .= "<td class='editable' data-field='{$col}'><input type='date' class='form-control' value='".currentDate()."'></td>";
          } elseif ($col == 'game_id') {
              $newRowCells .= "<td class='editable' data-field='{$col}'></td>";
          } else {
              $newRowCells .= "<td class='editable' data-field='{$col}' contenteditable='true'></td>";
          }
      } elseif ($entity == 'game_img') {
          if ($col == 'img_id') {
              $newId = generateId($pdo, 'game_img', 'I', 'img_id');
              $newRowCells .= "<td data-field='img_id'>$newId</td>";
          } elseif ($col == 'game_id') {
              $newRowCells .= "<td class='editable' data-field='{$col}'></td>";
          } else {
              $newRowCells .= "<td class='editable' data-field='{$col}' contenteditable='true'></td>";
          }
      } elseif ($entity == 'account') {
          if ($col == 'user_Id') {
              $newId = generateId($pdo, 'user', 'U', 'user_Id');
              $newRowCells .= "<td data-field='user_Id'>$newId</td>";
          } elseif ($col == 'created_at') {
              $newRowCells .= "<td class='editable' data-field='{$col}'><input type='date' class='form-control' value='".currentDate()."'></td>";
          } elseif ($col == 'role') {
              $newRowCells .= "<td class='editable' data-field='{$col}'></td>";
          } else {
              $newRowCells .= "<td class='editable' data-field='{$col}' contenteditable='true'></td>";
          }
      } elseif ($entity == 'news') {
          if ($col == 'news_id') {
              $newId = generateId($pdo, 'news', 'N', 'news_id');
              $newRowCells .= "<td data-field='news_id'>$newId</td>";
          } elseif ($col == 'created_at') {
              $newRowCells .= "<td class='editable' data-field='{$col}'><input type='date' class='form-control' value='".currentDate()."'></td>";
          } else {
              $newRowCells .= "<td class='editable' data-field='{$col}' contenteditable='true'></td>";
          }
      } else {
          $newRowCells .= "<td class='editable' data-field='{$col}' contenteditable='true'></td>";
      }
  }
  ?>
  newRow.innerHTML = `<?php echo $newRowCells; ?> <td><button class="btn btn-sm btn-primary save-new-btn">Save</button></td><td><button class="btn btn-sm btn-danger cancel-new-btn">Cancel</button></td>`;
  tbody.prepend(newRow);

  <?php if ($entity == 'game') { ?>
      newRow.querySelector('td[data-field="publisherID"]').appendChild(createSelect('publisherID', '', false));
      newRow.querySelector('td[data-field="developerID"]').appendChild(createSelect('developerID', '', false));
      newRow.querySelector('td[data-field="discounts"]').appendChild(createSelect('discounts', '', false));
      newRow.querySelector('td[data-field="categories"]').appendChild(createCategoriesCheckboxes(''));
  <?php } elseif ($entity == 'discounts') { ?>
      newRow.querySelector('td[data-field="discount_type"]').appendChild(createSelect('discount_type', '', false));
  <?php } elseif ($entity == 'game_price') { ?>
      newRow.querySelector('td[data-field="game_id"]').appendChild(createSelect('game_id', '', false));
  <?php } elseif ($entity == 'game_img') { ?>
      newRow.querySelector('td[data-field="game_id"]').appendChild(createSelect('game_id', '', false));
  <?php } elseif ($entity == 'account') { ?>
      newRow.querySelector('td[data-field="role"]').appendChild(createSelect('role', '', false));
  <?php } ?>

  newRow.querySelector('.save-new-btn').addEventListener('click', function() {
    var cells = newRow.querySelectorAll('td');
    var newData = {};
    cells.forEach(function(cell) {
       var field = cell.getAttribute('data-field');
       if (field) {
         if (field === 'game_id' || field === 'discount_id' || field === 'categories_id' || field === 'user_Id' || field === 'news_id' || field === 'price_id' || field === 'img_id') {
             newData[field] = cell.textContent.trim();
         } else if (field === 'realse_date' || field === 'start_date' || field === 'end_date' || field === 'created_at') {
             var input = cell.querySelector('input');
             newData[field] = input ? input.value.trim() : '';
         } else if (field === 'publisherID' || field === 'developerID' || field === 'discounts' || field === 'game_id' || field === 'role' || field === 'discount_type') {
             var select = cell.querySelector('select');
             newData[field] = select ? select.value : '';
         } else if (field === 'categories') {
             var selected = Array.from(cell.querySelectorAll('input[type="checkbox"]:checked')).map(cb => cb.value);
             newData[field] = selected.join(', ');
         } else {
             newData[field] = cell.textContent.trim();
         }
       }
    });
    console.log('Data gửi đi:', newData); // Debug dữ liệu gửi đi
    fetch('?action=add', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        entity: '<?php echo $entity; ?>',
        data: newData
      })
    })
    .then(response => response.json())
    .then(result => {
      console.log('Kết quả từ server:', result); // Debug kết quả từ server
      if (result.success) {
        alert('Thêm mới thành công!');
        location.reload();
      } else {
        alert('Thêm mới thất bại: ' + result.error);
      }
    })
    .catch(error => {
      console.error('Lỗi:', error);
      alert('Có lỗi xảy ra');
    });
  });

  newRow.querySelector('.cancel-new-btn').addEventListener('click', function() {
    newRow.remove();
  });
});
</script>
</body>
</html>