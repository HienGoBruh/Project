<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Đăng nhập tài khoản</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.7.1/css/all.min.css">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f1f1f1;
        }
        .register-form {
            max-width: 500px;
            margin: 50px auto;
            background: #fff;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            padding: 20px 30px;
        }
        .register-form h2 {
            font-size: 18px;
            text-align: center;
            font-weight: bold;
            margin-bottom: 20px;
        }
        .register-form .btn-primary {
            background-color: #dc3545;
            border-color: #dc3545;
        }
        .register-form .btn-primary:hover {
            background-color: #b02a37;
        }
        .social-buttons .btn {
            width: 48%;
            margin: 5px 1%;
        }
        .social-buttons .btn-google {
            background-color: #db4437;
            color: white;
        }
        .social-buttons .btn-facebook {
            background-color: #4267B2;
            color: white;
        }
        .social-buttons .btn i {
            margin-right: 8px;
        }
        .form-check-label {
            font-size: 14px;
        }
        .register-footer {
            text-align: center;
            font-size: 14px;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <?php require_once 'view/route.php'; require_once 'config/baseURL.php'; ?>
    <div class="container">
        <div class="register-form">
            <h2>ĐĂNG NHẬP</h2>
            <form id="Login" name="Login" action="<?= BASE_URL ?>?controller=Login&action=confirm" method="post">
                <div class="mb-3">
                    <input type="text" name="txtusername" class="form-control" placeholder="User name" required>
                </div>
                <div class="mb-3">
                    <input type="password" name="txtpassword" class="form-control" placeholder="Passwords" required>
                </div>
                <button type="submit" class="btn btn-primary w-100 mt-3">LOGIN</button>
            </form>
            <div class="register-footer">
                <a href="" style="color: black;">You don't have account? - </a> <a href="dangky.html">signup now!</a>
            </div>
            <div class="text-center mt-4">
                <a href="index.html" class="btn btn-outline-secondary">
                    <i class="fa fa-home"></i> Back to Home
                </a>
            </div>
        </div>
    </div>
    
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
