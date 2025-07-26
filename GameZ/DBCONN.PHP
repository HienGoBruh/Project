<?php
    $conn = new mysqli('sql204.infinityfree.com', 'if0_39033364', 'VP3aMpsyxQ6B', 'if0_39033364_tranhiendz');
    $conn->set_charset("utf8");
    if ($conn->connect_error) {
        die("Kết nối thất bại: " . $conn->connect_error);
    }
?>