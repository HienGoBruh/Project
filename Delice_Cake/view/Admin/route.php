<?php
//Để chuyển hướng, kiểm soát các controller đang có trong dự án
    //Gọi tầng controller
    require_once 'controller/' .$controller. '.php';
    //Gọi database
    require_once 'config/db.php';
    
    //Dùng switch để hiện giao diện bằng URL
    switch ($controller)
    {
        case 'Admin':
            $controller = new Admin();
            break;
    }
    $controller->{$action}();
    
        
?>