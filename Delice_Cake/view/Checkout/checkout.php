<!DOCTYPE html>
<html lang="en">
    
<head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1"> 
        <title>Cake - Bakery</title>
    </head>
    <body>
        <?php 
		require_once 'view/route.php'; 
		require_once 'config/baseURL.php'; 
		?>
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
							<?php 
								if (!isset($_SESSION['id_nguoidung'])) {
								?>
									<li class="shop_cart" style="display: none;">
										<a href="<?= BASE_URL ?>?controller=Cart&action=index">
											<i class="lnr lnr-cart"></i>
											<span class="cart_count"><?= $cart_count ?></span>
										</a>
									</li>
								<?php
								} else {
								?>
									<li class="shop_cart">
										<a href="<?= BASE_URL ?>?controller=Cart&action=index">
											<i class="lnr lnr-cart"></i>
											<span class="cart_count"><?= $cart_count ?></span>
										</a>
									</li>
							<?php
								}
							?>


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
        			<h3>Chekout</h3>
        			<ul>
        				<li><a href="index.html">Home</a></li>
        				<li><a href="checkout.html">Chekout</a></li>
        			</ul>
        		</div>
        	</div>
        </section>
        <!--================End Main Header Area =================-->
        
        <!--================Billing Details Area =================-->    
        <section class="billing_details_area p_100">
            <div class="container">
                <div class="return_option">
                	<h4>Return to Cart ? <a href="cart.html">Click here</a></h4>
                </div>
                <div class="row">
                	<div class="col-lg-7">
               	    	<div class="main_title">
               	    		<h2>Billing Details</h2>
               	    	</div>
                		<div class="billing_form_area">
                			<form class="billing_form row" action="index.php?controller=Checkout&action=placeOrder" method="post" id="contactForm" novalidate="novalidate">
								<div class="form-group col-md-6">
								    <label for="first">Full Name *</label>
									<input type="text" class="form-control" id="name" name="name" placeholder="First Name" required>
								</div>
								<div class="form-group col-md-12">
								    <label for="address">Address *</label>
									<input type="text" class="form-control" id="address" name="address" placeholder="Street Address" required>
								</div>
								<div class="form-group col-md-12">
								    <label for="city">Town / City *</label>
									<input type="text" class="form-control" id="city" name="city" placeholder="Town /City" >
								</div>
								<div class="form-group col-md-6">
								    <label for="state1">State / Country *</label>
									<select class="product_select" id="state1">
                                        <option data-display="Select an option">Select an option</option>
                                        <option value="1">Việt Nam</option>
                                       
                                    </select>
								</div>
								<div class="form-group col-md-6">
								    <label for="zip">Postcode / Zip *</label>
									<input type="text" class="form-control" id="zip" name="zip" placeholder="Postcode / Zip">
								</div>
								<div class="form-group col-md-6">
								    <label for="email">Email Address *</label>
									<input type="email" class="form-control" id="email" name="email" placeholder="Email Address">
								</div>
								<div class="form-group col-md-6">
								    <label for="phone">Phone *</label>
									<input type="text" class="form-control" id="phone" name="phone" placeholder="Select an option" required>
								</div>
								
								<div class="select_check2 col-md-12">
									<div class="creat_account">
										<input type="checkbox" id="f-option2" name="selector">
										<label for="f-option2">Ship to a different address?</label>
										<div class="check"></div>
									</div>
								</div>
								<div class="form-group col-md-12">
									<label for="phone">Order Notes</label>
									<textarea class="form-control" name="message" id="message" rows="1" placeholder="Note about your order. e.g. special note for delivery"></textarea>
								</div>
                                <button type="submit" value="submit" class="btn pest_btn">Place Order</button>
							</form>
                		</div>
                	</div>
                	<div class="col-lg-5">
                		<div class="order_box_price">
                			<div class="main_title">
                				<h2>Your Order</h2>
                			</div>
							<div class="payment_list">
								<div class="price_single_cost">
                                    <h5>Products <span>Total</span></h5>
                                    <?php
                                        require_once 'model/checkout.php';
                                        $model = new ModelCheckout();
                                        $userid = (int) $_SESSION['id_nguoidung'];
                                        $result = $model->getCart($userid);
                                        foreach ($result as $value) { ?>
                                            <h5><?= htmlspecialchars($value['ten_banh']) ?> x <?= htmlspecialchars($value['so_luong']) ?> 
                                                <span>$<?= number_format($value['gia'] * $value['so_luong'], 2) ?></span>
                                            </h5>
                                        <?php }
						            ?>
                                    
                                    <h4>Subtotal <span>$<?= number_format($total, 2) ?></span></h4>

                                    
                                    <h5>Discount
                                        <span>−$<?= number_format($discount, 2) ?></span>
                                    </h5>
                                    
                                    <h5>Shipping And Handling <span class="text_f">Free Shipping</span></h5>

                                    <h3>Total <span>$<?= number_format($final_total, 2) ?></span></h3>
                                </div>

								<div id="accordion" class="accordion_area">
                                    <br>
                                    <h5>CHECKOUT METHOD</h5>
									<div class="card">
										<div class="card-header" id="headingOne">
											<h5 class="mb-0">
												<button class="btn btn-link" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                                Chuyển khoản ngân hàng
												</button>
											</h5>
										</div>
										<div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordion">
											<div class="card-body">
											Quét mã QR để thanh toán
											</div>
										</div>
									</div>
									<div class="card">
										<div class="card-header" id="headingTwo">
											<h5 class="mb-0">
												<button class="btn btn-link collapsed" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
												Nhận tiền khi giao hàng
												</button>
											</h5>
										</div>
										<div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordion">
											<div class="card-body">
											Hãy chuẩn bị tiền mặt khi giao hàng. Chúng tôi sẽ giao hàng đến địa chỉ của bạn và nhận tiền mặt trực tiếp.
											</div>
										</div>
									</div>
									
								</div>
								
							</div>
						</div>
                	</div>
                </div>
            </div>
        </section>
        <!--================End Billing Details Area =================-->   
        
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
                <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search for...">
                    <span class="input-group-btn">
                        <button class="btn btn-default" type="button"><i class="icon icon-Search"></i></button>
                    </span>
                </div>
            </div>
        </div>
        <!--================End Search Box Area =================-->
    </body>

</html>