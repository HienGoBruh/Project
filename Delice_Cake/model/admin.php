<?php
class ModelAdmin {
    public static function get_limit($table, $offset, $limit = 5) {
        require_once __DIR__ . '/../config/db.php';

        $db = new connect();
        $sql = "SELECT * FROM `$table` LIMIT ?, ?";
        $stmt = $db->db->prepare($sql);
        $stmt->bindValue(1, (int)$offset, PDO::PARAM_INT);
        $stmt->bindValue(2, (int)$limit, PDO::PARAM_INT);
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public static function get_search_limit($table, $searchColumn, $keyword, $offset, $limit = 5) {
        require_once __DIR__ . '/../config/db.php';

        $db = new connect();
        $sql = "SELECT * FROM `$table` WHERE `$searchColumn` LIKE ? LIMIT ?, ?";
        $stmt = $db->db->prepare($sql);
        $stmt->bindValue(1, '%' . $keyword . '%', PDO::PARAM_STR);
        $stmt->bindValue(2, (int)$offset, PDO::PARAM_INT);
        $stmt->bindValue(3, (int)$limit, PDO::PARAM_INT);
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public static function generateAutoCode($table, $column, $prefix, $length) {
        require_once __DIR__ . '/../config/db.php';

        $db = new connect();
        $sql = "SELECT MAX($column) AS max_code FROM `$table` WHERE $column LIKE ?";
        $stmt = $db->db->prepare($sql);
        $stmt->execute([$prefix . '%']);
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        if ($row && $row['max_code']) {
            $number = (int)substr($row['max_code'], strlen($prefix));
            $number++;
        } else {
            $number = 1;
        }
        return $prefix . str_pad($number, $length - strlen($prefix), '0', STR_PAD_LEFT);
    }

    public function get_by_id1($table, $id_field, $id_value) {
        require_once __DIR__ . '/../config/db.php';

        $db = new connect();
        $sql = "SELECT * FROM `$table` WHERE `$id_field` = ?";
        $stmt = $db->db->prepare($sql);
        $stmt->execute([$id_value]);
        return $stmt->fetch(PDO::FETCH_ASSOC);
    }

    public function insert($table, $data) {
        require_once __DIR__ . '/../config/db.php';

        $db = new connect();
        $columns = implode(',', array_keys($data));
        $placeholders = rtrim(str_repeat('?,', count($data)), ',');
        $sql = "INSERT INTO `$table` ($columns) VALUES ($placeholders)";
        $stmt = $db->db->prepare($sql);
        $stmt->execute(array_values($data));
    }

    public function update($table, $id_field, $id_value, $data) {
        require_once __DIR__ . '/../config/db.php';

        $db = new connect();
        $updates = implode(', ', array_map(fn($col) => "`$col` = ?", array_keys($data)));
        $sql = "UPDATE `$table` SET $updates WHERE `$id_field` = ?";
        $stmt = $db->db->prepare($sql);
        $stmt->execute([...array_values($data), $id_value]);
    }

    public function delete($table, $id_field, $id_value) {
        require_once __DIR__ . '/../config/db.php';

        $db = new connect();
        $db->db->exec('SET FOREIGN_KEY_CHECKS = 0');
        $sql = "DELETE FROM `$table` WHERE `$id_field` = ?";
        $stmt = $db->db->prepare($sql);
        $stmt->execute([$id_value]);
        $db->db->exec('SET FOREIGN_KEY_CHECKS = 1');
        if ($stmt->rowCount() === 0) {
            throw new PDOException('Không tìm thấy bản ghi để xóa');
        }
    }
}
?>