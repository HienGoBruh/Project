<?php
//Để chuyển hướng, kiểm soát các controller đang có trong dự án
    //Gọi tầng controller
    require_once 'controller/' .$controller. '.php';
    //Gọi database
    require_once 'config/db.php';
    
    //Dùng switch để hiện giao diện bằng URL
    switch ($controller)
    {
        case 'Home':
        $controller = new Home();
        break;

        case 'News':
        $controller = new News();
        break;

        case 'Product':
        $controller = new Product();
        break;

        case 'Signup':
        $controller = new Signup();
        break;

        case 'Login':
        $controller = new Login();
        break;
        
        case 'Cart':
        $controller = new Cart();
        break;

        case 'Checkout':
        $controller = new Checkout();
        break;
                case 'Comment':
        $controller = new CommentController();
        break;
        case 'CommentBanh':
        $controller = new CommentBanh();
        break;
    }
    $controller->{$action}();
    
        
?>