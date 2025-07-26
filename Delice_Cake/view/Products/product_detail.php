<?php
require_once 'config/baseURL.php'; 
if (isset($result)):
    foreach ($result as $value): ?>
<?php
	require_once 'model/product.php';
	$RVCount = $model->countRVbySP($value['id_banh']);
?>
<!DOCTYPE html>
<html lang="en">
    
<head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>Cake - Detail</title>
    </head>
    <body>
        
        <!--================Main Header Area =================-->
		<header class="main_header_area five_header">
			<div class="top_header_area row m0">
				<div class="container">
					<div class="float-left">
						<a href="tell:+18004567890"><i class="fa fa-phone" aria-hidden="true"></i> + (1800) 456 7890</a>
						<a href="mainto:info@cakebakery.com"><i class="fa fa-envelope-o" aria-hidden="true"></i> info@cakebakery.com</a>
					</div>
					<div class="float-right">
						<ul class="h_social list_style">
							<li><a href="#"><i class="fa fa-facebook"></i></a></li>
							<li><a href="#"><i class="fa fa-twitter"></i></a></li>
							<li><a href="#"><i class="fa fa-google-plus"></i></a></li>
							<li><a href="#"><i class="fa fa-linkedin"></i></a></li>
						</ul>
						<ul class="h_search list_style">
							<?php
							
								if (session_status() === PHP_SESSION_NONE) {
									session_start();
								}
								if(isset($_SESSION['id_nguoidung'])) {
									require_once 'config/db.php';
									$user = $_SESSION['id_nguoidung'];
								$db = new connect();
								$sql = "SELECT SUM(so_luong) as cart_count FROM tbl_ctgiohang cthd JOIN tbl_giohang gh ON cthd.id_giohang = gh.id_giohang WHERE gh.id_nguoidung = $user";
								$result = $db->getInstance($sql);
								$cart_count = $result['cart_count'] ? htmlspecialchars($result['cart_count']) : 0;
								} else {
									$cart_count = 0; // Default value if not set
								}
							?>
							
									<li class="shop_cart">
										<a href="<?= BASE_URL ?>?controller=Cart&action=index">
											<i class="lnr lnr-cart"></i>
											<span class="cart_count"><?= $cart_count ?></span>
										</a>
									</li>
							


							<li><a class="popup-with-zoom-anim" href="#test-search"><i class="fa fa-search"></i></a></li>
						</ul>
					</div>
				</div>
			</div>
			<div class="main_menu_two">
				<div class="container">
					<nav class="navbar navbar-expand-lg navbar-light bg-light">
						<a class="navbar-brand" href="index.html"><img style="width: 180px; height: 40px;" src="public/img/logo-Delice1.png" alt=""></a>
						<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
							<span class="my_toggle_menu">
                            	<span></span>
                            	<span></span>
                            	<span></span>
                            </span>
						</button>
						<div class="collapse navbar-collapse" id="navbarSupportedContent">
							<ul class="navbar-nav justify-content-end">
								<li><a href="index.html">Home</a></li>
								<li><a href="blog.html">Blog</a></li>
								<li class="dropdown submenu active">
									<a class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Shop</a>
									<ul class="dropdown-menu">
										
										<li><a href="product.html">Our Cakes</a></li>
										<li><a href="cart.html">Your Cart</a></li>
										<li><a href="checkout.html">Checkout</a></li>
									</ul>
								</li>
								<li class="dropdown submenu">
									<a class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Contact Us</a>
									<ul class="dropdown-menu">
										<li><a href="shop.html">About Us</a></li>
										<li><a href="product-details.html">Testimonials</a></li>
										<li><a href="contact.html">Contact Us</a></li>
										
									</ul>
								</li>
								<li style="display: flex; align-items: center; justify-content: center;">
									<i class="fa fa-user-circle-o font-large" style="color: #74C0FC;"></i> 
									<?php
										if (session_status() === PHP_SESSION_NONE) {
											session_start();
										}
										if (isset($_SESSION['ten_dang_nhap'])) {
											$ten_dang_nhap = htmlspecialchars($_SESSION['ten_dang_nhap']);
											echo "<a href='#' onclick='confirmLogout()' style='margin-left: 5px; text-decoration: none; color: black;'>$ten_dang_nhap</a>";
										} else {
											echo '<a href="dangnhap.html" style="margin-left: 5px; text-decoration: none;">Login</a>';
										}
									?>
								</li>
							</ul>
							
						</div>
					</nav>
				</div>
			</div>
		</header>
        <!--================End Main Header Area =================-->
        
        <!--================End Main Header Area =================-->
        <section class="banner_area">
        	<div class="container">
        		<div class="banner_text">
        			<h3>Product Details</h3>
        			<ul>
        				<li><a href="index.html">Home</a></li>
        				<li><a href="product-details.html">Product Details</a></li>
        			</ul>
        		</div>
        	</div>
        </section>
        <!--================End Main Header Area =================-->
        
        <!--================Product Details Area =================-->
        <section class="product_details_area p_100">
        	<div class="container">
        		<div class="row product_d_price">
        			<div class="col-lg-6">
        				<div class="product_img"><img style="width: 525px; height: 426px;" class="img-fluid" src="public/img/product/<?php echo $value['hinh_anh']; ?>" alt=""></div>
        			</div>
        			<div class="col-lg-6">
        				<div class="product_details_text">
        					<h4><?php echo $value['ten_banh']; ?></h4>
        					<p><strong><?php echo $value['mo_ta']; ?></strong><br><?php echo $value['thanhphan']; ?></p>
							
        					<h5>Price : <span>$<?php echo $value['gia']; ?></span></h5>
        					<div class="quantity_box">
								<label for="quantity">Quantity :</label>
								<input type="text" placeholder="1" id="quantity" value="1">
							</div>
							<a class="pink_more pest_btn" href="javascript:void(0)" onclick="addToCart(<?= $value['id_banh'] ?>)">Add to cart</a>

        				</div>
        			</div>
        		</div>
        		<div class="product_tab_area">
					<nav>
						<div class="nav nav-tabs" id="nav-tab" role="tablist">
							<a class="nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">Descripton</a>
							<a class="nav-item nav-link" id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false">Specification</a>
							
							<a class="nav-item nav-link" id="nav-contact-tab" data-toggle="tab" href="#nav-contact" role="tab" aria-controls="nav-contact" aria-selected="false">Review (<?= $RVCount ?>)</a>
						</div>
					</nav>
					<div class="tab-content" id="nav-tabContent">
						<div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
							<p><?php echo $value['mo_ta']; ?></p>
							<p><?php echo $value['thanhphan']; ?></p>
						</div>
						<div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
							<p><?php echo $value['thanhphan']; ?></p>
						</div>
						<div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab">
							<?php
require_once 'model/master.php';
$model = new MasterModel();
$id_banh = isset($_GET['id']) ? (int)$_GET['id'] : 0;

// Lấy danh sách bình luận
$comments = $model->get_dk('tbl_binhluan_banh', "id_banh = $id_banh", 'ngay_dang DESC');

// Kiểm tra người dùng đã bình luận chưa
$da_binh_luan = false;
$id_binh_luan_cua_user = 0;

if (isset($_SESSION['id_nguoidung'])) {
    foreach ($comments as $cmt) {
        if ((int)$cmt['id_nguoidung'] === (int)$_SESSION['id_nguoidung']) {
            $da_binh_luan = true;
            $id_binh_luan_cua_user = $cmt['id_bl'];
            break;
        }
    }
}
?>
<div id="comments-container">
    <!-- Nội dung comment và form sẽ được load bằng AJAX -->
</div>
						</div>
					</div>
        		</div>
        	</div>
        </section>
        <!--================End Product Details Area =================-->
        
        <!--================Newsletter Area =================-->
        <section class="newsletter_area">
        	<div class="container">
        		<div class="row newsletter_inner">
        			<div class="col-lg-6">
        				<div class="news_left_text">
        					<h4>Join our Newsletter list to get all the latest offers, discounts and other benefits</h4>
        				</div>
        			</div>
        			<div class="col-lg-6">
        				<div class="newsletter_form">
							<div class="input-group">
								<input type="text" class="form-control" placeholder="Enter your email address">
								<div class="input-group-append">
									<button class="btn btn-outline-secondary" type="button">Subscribe Now</button>
								</div>
							</div>
        				</div>
        			</div>
        		</div>
        	</div>
        </section>
        <!--================End Newsletter Area =================-->
        
        <!--================Footer Area =================-->
        <footer class="footer_area">
        	<div class="footer_widgets">
        		<div class="container">
        			<div class="row footer_wd_inner">
        				<div class="col-lg-3 col-6">
        					<aside class="f_widget f_about_widget">
        						<img src="img/footer-logo.png" alt="">
        						<p>At vero eos et accusamus et iusto odio dignissimos ducimus qui bland itiis praesentium voluptatum deleniti atque corrupti.</p>
        						<ul class="nav">
        							<li><a href="#"><i class="fa fa-facebook"></i></a></li>
        							<li><a href="#"><i class="fa fa-linkedin"></i></a></li>
        							<li><a href="#"><i class="fa fa-twitter"></i></a></li>
        							<li><a href="#"><i class="fa fa-google-plus"></i></a></li>
        						</ul>
        					</aside>
        				</div>
        				<div class="col-lg-3 col-6">
        					<aside class="f_widget f_link_widget">
        						<div class="f_title">
        							<h3>Quick links</h3>
        						</div>
        						<ul class="list_style">
        							<li><a href="#">Your Account</a></li>
        							<li><a href="#">View Order</a></li>
        							<li><a href="#">Privacy Policy</a></li>
        							<li><a href="#">Terms & Conditionis</a></li>
        						</ul>
        					</aside>
        				</div>
        				<div class="col-lg-3 col-6">
        					<aside class="f_widget f_link_widget">
        						<div class="f_title">
        							<h3>Work Times</h3>
        						</div>
        						<ul class="list_style">
        							<li><a href="#">Mon. :  Fri.: 8 am - 8 pm</a></li>
        							<li><a href="#">Sat. : 9am - 4pm</a></li>
        							<li><a href="#">Sun. : Closed</a></li>
        						</ul>
        					</aside>
        				</div>
        				<div class="col-lg-3 col-6">
        					<aside class="f_widget f_contact_widget">
        						<div class="f_title">
        							<h3>Contact Info</h3>
        						</div>
        						<h4>(1800) 574 9687</h4>
        						<p>Justshiop Store <br />256, baker Street,, New Youk, 5245</p>
        						<h5>cakebakery@contact.co.in</h5>
        					</aside>
        				</div>
        			</div>
        		</div>
        	</div>
        	<div class="footer_copyright">
        		<div class="container">
        			<div class="copyright_inner">
        				<div class="float-left">
        					<h5><a target="_blank" href="https://www.templatespoint.net">Templates Point</a></h5>
        				</div>
        				<div class="float-right">
        					<a href="#">Purchase Now</a>
        				</div>
        			</div>
        		</div>
        	</div>
        </footer>
        <!--================End Footer Area =================-->
        
        
        <!--================Search Box Area =================-->
        <div class="search_area zoom-anim-dialog mfp-hide" id="test-search">
			<div class="search_box_inner">
				<h3>Search</h3>
				<form action="<?= BASE_URL ?>" method="GET">
					<input type="hidden" name="controller" value="Product">
					<input type="hidden" name="action" value="ProductResult">

					<div class="input-group">
						<input type="text" class="form-control" name="keyword" placeholder="Enter Search Keywords" required>
						<span class="input-group-btn">
							<button class="btn btn-default" type="submit">
								<i class="icon icon-Search"></i>
							</button>
						</span>
					</div>
				</form>
			</div>
		</div>
        <!--================End Search Box Area =================-->
    </body>
<script>
    let currentEditId = null;

function loadComments(id_banh) {
    let url = `index.php?controller=Product&action=ProductDetail&id=${id_banh}&ajax=1`;
    if (currentEditId) url += `&edit=${currentEditId}`;

    fetch(url)
        .then(res => res.text())
        .then(html => {
            document.getElementById("comments-container").innerHTML = html;


            document.querySelectorAll(".edit-comment").forEach(btn => {
                btn.addEventListener("click", function (e) {
                    e.preventDefault();
                    currentEditId = this.dataset.idbl;
                    loadComments(id_banh);
                });
            });

            document.querySelectorAll(".cancel-edit").forEach(btn => {
                btn.addEventListener("click", function (e) {
                    e.preventDefault();
                    currentEditId = null;
                    loadComments(id_banh);
                });
            });
        });
}

document.addEventListener("DOMContentLoaded", function () {
    const id_banh = <?= $id_banh ?>;
    loadComments(id_banh);
});

</script>
</html>

    <?php
endforeach; endif;

?>