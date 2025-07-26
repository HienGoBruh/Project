<!DOCTYPE html>
<html lang="vi">
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1">
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

    .form-row {
      display: flex;
      gap: 10px;
      margin-bottom: 15px;
    }

    .form-row input {
      flex: 1;
    }

    .mb-3 {
      margin-bottom: 15px;
    }

    .form-control {
      width: 100%;
      padding: 10px;
      border: 1px solid #ccc;
      border-radius: 4px;
    }

    .btn {
      padding: 10px;
      border: none;
      cursor: pointer;
      border-radius: 4px;
    }

    .btn-primary {
      background-color: #007bff;
      color: white;
    }

    .btn-outline-secondary {
      background: white;
      border: 1px solid #ccc;
      color: black;
    }

    .btn-outline-secondary:hover {
      background: #eee;
    }

    .text-center {
      text-align: center;
    }

    .w-100 {
      width: 100%;
    }

    .mt-3 {
      margin-top: 1rem;
    }

    .mt-4 {
      margin-top: 1.5rem;
    }

  </style>
</head>
<body>
  <?php require_once 'view/route.php'; require_once 'config/baseURL.php'; ?>
  <div class="container">
    <div class="register-form">
      <h2>ĐĂNG KÝ TÀI KHOẢN</h2>
      <form action="<?= BASE_URL ?>?controller=Signup&action=confirm" method="post">
        
        <!-- Full name & User name -->
        <div class="form-row">
          <input type="text" name="fullname" class="form-control" placeholder="Full name" required>
          <input type="text" name="user_Name" class="form-control" placeholder="User name" required>
        </div>

        <!-- Email -->
        <div class="mb-3">
          <input type="email" name="email" class="form-control" placeholder="Email" required>
        </div>

        <!-- Address -->
        <div class="mb-3">
          <input type="text" name="address" class="form-control" placeholder="Address" required>
        </div>

        <!-- Telephone & Password -->
        <div class="form-row">
          <input type="tel" name="tel" class="form-control" placeholder="Telephone" required>
          <input type="password" name="Password" class="form-control" placeholder="Password" required>
        </div>

        <!-- Submit button -->
        <button type="submit" class="btn btn-primary w-100">SIGNUP</button>
      </form>

      <div class="mt-3 text-center">
        <a href="" style="color: black;">You have an account? - </a> <a href="dangnhap.html">login now!</a>
      </div>

      <div class="text-center mt-4">
        <a href="index.html" class="btn btn-outline-secondary">
          <i class="fa fa-home"></i> Back to Home
        </a>
      </div>
    </div>
  </div>
</body>
</html>
