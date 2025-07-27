<?php 
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    
    <link rel="icon" href="public/img/logo-Delice.png" type="image/x-icon" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Delice Bakery</title>

    <!-- Icon css link -->
    <link href="public/css/font-awesome.min.css" rel="stylesheet">
    <link href="public/vendors/linearicons/style.css" rel="stylesheet">
    <link href="public/vendors/flat-icon/flaticon.css" rel="stylesheet">
    <link href="public/vendors/stroke-icon/style.css" rel="stylesheet">
    <!-- Bootstrap -->
    <link href="public/css/bootstrap.min.css" rel="stylesheet">
    
    <!-- Rev slider css -->
    <link href="public/vendors/revolution/css/settings.css" rel="stylesheet">
    <link href="public/vendors/revolution/css/layers.css" rel="stylesheet">
    <link href="public/vendors/revolution/css/navigation.css" rel="stylesheet">
    <link href="public/vendors/animate-css/animate.css" rel="stylesheet">
    
    <!-- Extra plugin css -->
    <link href="public/vendors/owl-carousel/owl.carousel.min.css" rel="stylesheet">
    <link href="public/vendors/magnifc-popup/magnific-popup.css" rel="stylesheet">
    <link href="public/vendors/nice-select/css/nice-select.css" rel="stylesheet">
    <link href="public/vendors/jquery-ui/jquery-ui.min.css" rel="stylesheet">
    
    <link href="public/css/style.css" rel="stylesheet">
    <link href="public/css/responsive.css" rel="stylesheet">

    <style>
		.font-large {
			font-size: 40px !important;
			
		}
	</style>
    <!-- <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.7.2/css/all.min.css" rel="stylesheet"> -->
    
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <?php session_start(); ?>
	<?php require_once 'view/route.php'; ?>

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="public/js/jquery-3.2.1.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="public/js/popper.min.js"></script>
    <script src="public/js/bootstrap.min.js"></script>
    <!-- Rev slider js -->
    <script src="public/vendors/revolution/js/jquery.themepunch.tools.min.js"></script>
    <script src="public/vendors/revolution/js/jquery.themepunch.revolution.min.js"></script>
    <script src="public/vendors/revolution/js/extensions/revolution.extension.actions.min.js"></script>
    <script src="public/vendors/revolution/js/extensions/revolution.extension.video.min.js"></script>
    <script src="public/vendors/revolution/js/extensions/revolution.extension.slideanims.min.js"></script>
    <script src="public/vendors/revolution/js/extensions/revolution.extension.layeranimation.min.js"></script>
    <script src="public/vendors/revolution/js/extensions/revolution.extension.navigation.min.js"></script>
    <!-- Extra plugin js -->
    <script src="public/vendors/owl-carousel/owl.carousel.min.js"></script>
    <script src="public/vendors/magnifc-popup/jquery.magnific-popup.min.js"></script>
    <script src="public/vendors/datetime-picker/js/moment.min.js"></script>
    <script src="public/vendors/isotope/imagesloaded.pkgd.min.js"></script>
    <script src="public/vendors/isotope/isotope.pkgd.min.js"></script>
    <script src="public/vendors/datetime-picker/js/bootstrap-datetimepicker.min.js"></script>
    <script src="public/vendors/nice-select/js/jquery.nice-select.min.js"></script>
    <script src="public/vendors/jquery-ui/jquery-ui.min.js"></script>
    <script src="public/vendors/lightbox/simpleLightbox.min.js"></script>
    
    <script src="public/js/theme.js"></script>

    <script>
        function confirmLogout() {
            if (confirm("Do you want to logout?")) {
                window.location.href = "<?= BASE_URL ?>?controller=Login&action=logout";
            }
        }
    </script>

    <script>
        $(function() {
            
            // Khi nhấn Filter, redirect có query price
            $(".filter_price a").click(function(e) {
                e.preventDefault();
                let min = $("#slider-range").slider("values", 0);
                let max = $("#slider-range").slider("values", 1);

                // Lấy các tham số sort, page hiện tại nếu có
                const url = new URL(window.location.href);
                const sort = url.searchParams.get("sort") || "";
                const page = url.searchParams.get("page") || 1;

                window.location.href = `?controller=Product&action=index&page=${page}&sort=${sort}&price_min=${min}&price_max=${max}`;
            });
        });
    </script>

    <script>
        function addToCart(id_banh) {
            let quantity = 1;
            const qtyInput = document.querySelector('#quantity');

            if (qtyInput) {
                quantity = parseInt(qtyInput.value);
                if (isNaN(quantity) || quantity <= 0) {
                    alert("Vui lòng nhập số lượng hợp lệ!");
                    return;
                }
            }

            fetch(`<?= BASE_URL ?>?controller=Cart&action=add&id_banh=${id_banh}&so_luong=${quantity}`)
                .then(response => response.text())
                .then(data => {
                    if (data.trim() === "success") {
                        alert("Đã thêm vào giỏ hàng thành công!");
                        updateCartCount();
                    } else if (data.trim() === "login_required") {
                        window.location.href = "<?= BASE_URL ?>?controller=Login&action=index";
                    } else {
                        alert("Lỗi không xác định: " + data);
                    }
                });
        }


        function updateCartCount() {
            fetch("<?= BASE_URL ?>?controller=Cart&action=getCartCount")
                .then(res => res.text())
                .then(count => {
                    document.querySelectorAll(".cart_count").forEach(el => {
                        el.textContent = count;
                    });
                });
        }

    </script>

   <script>
function addComment(id_banh) {
    const form = document.getElementById("commentForm");
    const formData = new FormData(form);

    fetch(`<?= BASE_URL ?>?controller=CommentBanh&action=add`, {
        method: "POST",
        body: formData,
        headers: {
            'X-Requested-With': 'XMLHttpRequest'
        }
    })
    .then(res => res.text())
    .then(data => {
        data = data.trim();
                console.log('Response:', data); // Log để debug
        if (data.includes("success")) {

            alert("Đã bình luận thành công!");
            form.reset();
            loadComments(id_banh);
        } else {
            alert("Lỗi: " + data);
        }
    })
    .catch(error => {
         console.error('Error:', error);
        alert("Lỗi kết nối: " + error);
    });
}

function updateComment(form, id_banh) {
    const formData = new FormData(form);
    fetch(`<?= BASE_URL ?>?controller=CommentBanh&action=update`, {
        method: "POST",
        body: formData,
        headers: {
            'X-Requested-With': 'XMLHttpRequest'
        }
    })
    .then(res => res.text())
    .then(data => {
        data = data.trim();
        console.log('Response:', data); // Log để debug
        if (data.includes("success")) {

            alert("Đã cập nhật bình luận!");
                        currentEditId = null; // ✅ Reset về null để không hiển thị form sửa
            loadComments(id_banh); // Reload danh sách bình luận
        } else {
            alert("Lỗi khi cập nhật: " + data);
        }
    })
    .catch(error => {
        console.error('Error:', error);
        alert("Lỗi kết nối: " + error);
    });
    return false; // Ngăn submit form
}
function addComment1(id_banh) {
    const form = document.getElementById("commentForm");
    const formData = new FormData(form);

    fetch(`<?= BASE_URL ?>?controller=Comment&action=add`, {
        method: "POST",
        body: formData,
        headers: {
            'X-Requested-With': 'XMLHttpRequest'
        }
    })
    .then(res => res.text())
    .then(data => {
        data = data.trim();
                console.log('Response:', data); // Log để debug
        if (data.includes("success")) {

            alert("Đã bình luận thành công!");
            form.reset();
            loadComments(id_banh);
        } else {
            alert("Lỗi: " + data);
        }
    })
    .catch(error => {
         console.error('Error:', error);
        alert("Lỗi kết nối: " + error);
    });
}

function updateComment1(form, id_banh) {
    const formData = new FormData(form);
    fetch(`<?= BASE_URL ?>?controller=Comment&action=update`, {
        method: "POST",
        body: formData,
        headers: {
            'X-Requested-With': 'XMLHttpRequest'
        }
    })
    .then(res => res.text())
    .then(data => {
        data = data.trim();
        console.log('Response:', data); // Log để debug
        if (data.includes("success")) {

            alert("Đã cập nhật bình luận!");
                        currentEditId = null; // ✅ Reset về null để không hiển thị form sửa
            loadComments(id_banh); // Reload danh sách bình luận
        } else {
            alert("Lỗi khi cập nhật: " + data);
        }
    })
    .catch(error => {
        console.error('Error:', error);
        alert("Lỗi kết nối: " + error);
    });
    return false; // Ngăn submit form
}
</script>
</body>
</html>