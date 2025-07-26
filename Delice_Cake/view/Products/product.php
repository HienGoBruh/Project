<!DOCTYPE html>
<html lang="en">
    
<head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>Cake - Bakery</title>
    </head>
    <body>
        <?php require_once 'view/route.php'; require_once 'config/baseURL.php'; ?>
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
        			<h3>Shop</h3>
        			<ul>
        				<li><a href="index.html">Home</a></li>
        				<li><a href="shop.html">Shop</a></li>
        			</ul>
        		</div>
        	</div>
        </section>
        <!--================End Main Header Area =================-->
        
        <!--================Product Area =================-->
        <section class="product_area p_100">
        	<div class="container">
        		<div class="row product_inner_row">
        			<div class="col-lg-9">
        				<div class="row m0 product_task_bar"> 
							<div class="product_task_inner"> 
								<div class="float-left">
									<a class="active" href="#"><i class="fa fa-th-large" aria-hidden="true"></i></a>
									<a href="#"><i class="fa fa-th-list" aria-hidden="true"></i></a>
									<span>
                                        Showing <?= $from ?> - <?= $to ?> of <?= $totalProducts ?> Products
                                    </span>

								</div>
								<div class="float-right">
									<!-- sort -->
                                    <form method="get" action="index.php" id="sortForm">
										<input type="hidden" name="controller" value="Product">
										<input type="hidden" name="action" value="index">
										<input type="hidden" name="page" value="1">

										<!-- Gán lại các filter nếu có -->
										<?php if (!empty($priceMin) || $priceMin === '0'): ?>
											<input type="hidden" name="price_min" value="<?= $priceMin ?>">
										<?php endif; ?>

										<?php if (!empty($priceMax)): ?>
											<input type="hidden" name="price_max" value="<?= $priceMax ?>">
										<?php endif; ?>

										<h4>Sort by :</h4>
										<select name="sort" class="short" onchange="document.getElementById('sortForm').submit();">
											<option value="" <?= empty($_GET['sort']) ? 'selected' : '' ?>>Default</option>
											<option value="az" <?= (isset($_GET['sort']) && $_GET['sort'] == 'az') ? 'selected' : '' ?>>A - Z</option>
											<option value="price_desc" <?= (isset($_GET['sort']) && $_GET['sort'] == 'price_desc') ? 'selected' : '' ?>>Price (High - Low)</option>
											<option value="price_asc" <?= (isset($_GET['sort']) && $_GET['sort'] == 'price_asc') ? 'selected' : '' ?>>Price (Low - High)</option>
										</select>
									</form>
                                </div>


							</div>
        				</div>
        				<div class="row product_item_inner">
                            <?php foreach ($products as $value): ?>
                            <div class="col-lg-4 col-md-4 col-6">
                                <div class="cake_feature_item">
                                    <div class="cake_img">
                                        <a href="<?= BASE_URL ?>?controller=Product&action=ProductDetail&id=<?php echo $value['id_banh']; ?>">
                                            <img style="object-fit: cover; height: 200px;" src="public/img/product/<?= $value['hinh_anh']; ?>" alt="">
                                        </a>
                                        
                                    </div>
                                    <div class="cake_text">
                                        <h4>$<?= $value['gia']; ?></h4>
                                        <a href="<?= BASE_URL ?>?controller=Product&action=ProductDetail&id=<?php echo $value['id_banh']; ?>">
                                            <h3><?= $value['ten_banh']; ?></h3>
                                        </a>
                                        
                                        <a class="pest_btn" href="javascript:void(0)" onclick="addToCart(<?= $value['id_banh'] ?>)">Add to cart</a>
                                    </div>
                                </div>
                            </div>
                            <?php endforeach; ?>
                        </div>
                        
                        <!-- PHÂN TRANG -->
                        <?php
                            $baseUrl = BASE_URL. "?controller=Product&action=index";

							if (!empty($currentSort)) {
								$baseUrl .= "&sort=" . urlencode($currentSort);
							}

							if (!empty($currentPriceMin) || $currentPriceMin === 0 || $currentPriceMin === '0') {
								$baseUrl .= "&price_min=" . urlencode($currentPriceMin);

								if (!empty($currentPriceMax) && $currentPriceMax !== $currentPriceMin) {
									$baseUrl .= "&price_max=" . urlencode($currentPriceMax);
								}
							}

                        ?>

                            <div class="product_pagination">
                                <div class="left_btn">
                                    <!-- Previous -->
									<?php if ($page > 1): ?>
										<a href="<?= $baseUrl . "&page=" . ($page - 1) ?>">
											<i class="lnr lnr-arrow-left"></i> Previous
										</a>
									<?php endif; ?>
                                </div>

                                <div class="middle_list">
                                    <nav aria-label="Page navigation example">
                                        <ul class="pagination">
                                            <!-- Page numbers -->
											<?php for ($i = 1; $i <= $totalPages; $i++): ?>
												<li class="page-item <?= ($i == $page) ? 'active' : ''; ?>">
													<a style="padding: 14px 30px" href="<?= $baseUrl . "&page=" . $i ?>">
														<?= $i; ?>
													</a>
												</li>
											<?php endfor; ?>
											<!-- End Page numbers -->
                                        </ul>
                                    </nav>
                                </div>

                                <div class="right_btn">
                                    <!-- Next -->
									<?php if ($page < $totalPages): ?>
										<a href="<?= $baseUrl . "&page=" . ($page + 1) ?>">
											Next <i class="lnr lnr-arrow-right"></i>
										</a>
									<?php endif; ?>
                                </div>
                            </div>
                        <!-- Kết thúc Phân trang -->
        			</div>
        			<div class="col-lg-3">
        				<div class="product_left_sidebar">
        					<aside class="left_sidebar search_widget">
        						<form action="<?= BASE_URL ?>" method="GET">
									<input type="hidden" name="controller" value="Product">
									<input type="hidden" name="action" value="ProductResult">

									<div class="input-group">
										<input type="text" class="form-control" name="keyword" placeholder="Enter Search Keywords">
										<div class="input-group-append">
											<button class="btn" type="submit"><i class="icon icon-Search"></i></button>
										</div>
									</div>
								</form>
        					</aside>
        					<aside class="left_sidebar p_catgories_widget">
        						<div class="p_w_title">
        							<h3>Product Categories</h3>
        						</div>
        						<ul class="list_style">
                                    <?php
										require_once 'model/product.php';
										$model = new ModelProduct();
										$result = $model->getDMSP();
										foreach ($result as $value) { 
											// $value là 1 danh mục, trong đó có ['id_danhmuc'], ['ten_danhmuc']
											$SPCount = $model->countSPtsByIdDMSP($value['id_danhmuc']); 
										?>
											<li>
												<a href="<?= BASE_URL ?>?controller=Product&action=ProductResult&category_id=<?= $value['id_danhmuc'] ?>">
													<?= htmlspecialchars($value['ten_danhmuc']) ?> (<?= $SPCount ?>)
												</a>
											</li>
									<?php } ?>
        						</ul>
        					</aside>
        					<aside class="left_sidebar p_price_widget">
        						<div class="p_w_title">
        							<h3>Filter By Price</h3>
        						</div>
        						<div class="filter_price">
									<div id="slider-range"></div>
       								<label for="amount">Price range:</label>
									<input type="text" id="amount" readonly />
       								<a href="#">Filter</a>
        						</div>
        					</aside>
        					<aside class="left_sidebar p_sale_widget">
        						<div class="p_w_title">
        							<h3>Top Sale Products</h3>
        						</div>
								<!-- Top sale -->
        						<?php
									require_once 'model/product.php';
									$model = new ModelProduct();
									$bestSellers = $model->getBestSellingProducts(5); // Lấy top 5 sản phẩm bán chạy
								?>

								<?php foreach ($bestSellers as $product): ?>
									<div class="media">
										<div class="d-flex">
											<img style="width: 70px; height: 70px; object-fit: cover;" src="public/img/product/<?= $product['hinh_anh']; ?>" alt="">
										</div>
										<div class="media-body">
											<a href="<?= BASE_URL ?>?controller=Product&action=ProductDetail&id=<?= $product['id_banh']; ?>">
												<h4><?= $product['ten_banh']; ?></h4>
											</a>
											
											<h5>$<?= $product['gia']; ?></h5>
										</div>
									</div>
								<?php endforeach; ?>

        						
        					</aside>
        				</div>
        			</div>
        		</div>
        	</div>
        </section>
        <!--================End Product Area =================-->
        
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

</html>