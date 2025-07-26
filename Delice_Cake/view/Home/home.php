<!DOCTYPE html>
<html lang="en">
    
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    
    <title>Delice Bakery</title>
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
								<li class="active"><a href="index.html">Home</a></li>
								<li><a href="blog.html">Blog</a></li>
								<li class="dropdown submenu">
									<a class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Shop</a>
									<ul class="dropdown-menu">
										
										<li><a href="product.html">Our Cakes</a></li>
										<li><a href="<?= BASE_URL ?>?controller=Cart&action=index">Your Cart</a></li>
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
        
        <!--================Slider Area =================-->
        <section class="main_slider_area">
            <div id="main_slider5" class="rev_slider" data-version="5.3.1.6">
                <ul>
                    <li data-index="rs-1587" data-transition="fade" data-slotamount="default" data-hideafterloop="0" data-hideslideonmobile="off"  data-easein="default" data-easeout="default" data-masterspeed="300"  data-thumb="public/img/home-slider/slider-12.jpg"  data-rotate="0"  data-saveperformance="off"  data-title="Creative" data-param1="01" data-param2="" data-param3="" data-param4="" data-param5="" data-param6="" data-param7="" data-param8="" data-param9="" data-param10="" data-description="">
                    <!-- MAIN IMAGE -->
                    <img src="public/img/home-slider/slider-12.jpg"  alt="" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" data-bgparallax="5" class="rev-slidebg" data-no-retina>

                        <!-- LAYER NR. 1 -->
                        <div class="slider_text_box">
                            <div class="tp-caption tp-resizeme price" 
                            data-x="['left','left','left','15','15','15']" data-hoffset="['300','300','15','15','15','0']" 
                            data-y="['top','top','top','top']" 
                            data-voffset="['120','120','70','70','115','130']" 
                            data-fontsize="['60','60','60','40','30']"
                            data-lineheight="['76','76','76','50','40']"
                            data-width="['780','780','780','400']"
                            data-height="none"
                            data-whitespace="normal"
                            data-type="text" 
                            data-responsive_offset="on" 
                            data-frames="[{&quot;delay&quot;:10,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;0&quot;,&quot;from&quot;:&quot;y:[-100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;&quot;,&quot;mask&quot;:&quot;x:0px;y:0px;s:inherit;e:inherit;&quot;,&quot;to&quot;:&quot;o:1;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;},{&quot;delay&quot;:&quot;wait&quot;,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;999&quot;,&quot;to&quot;:&quot;y:[175%];&quot;,&quot;mask&quot;:&quot;x:inherit;y:inherit;s:inherit;e:inherit;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;}]"
                            data-textAlign="['left','left','left','left']"><h3>NEW</h3></div>
                            
                            <div class="tp-caption tp-resizeme first_text" 
                            data-x="['right','right','left','15','15','15']" data-hoffset="['-150','0','15','15','15','0']" 
                            data-y="['top','top','top','top']" 
                            data-voffset="['155','155','155','155','235','230']" 
                            data-fontsize="['60','60','60','40','30']"
                            data-lineheight="['76','76','76','50','40']"
                            data-width="['780','740','780','780','700','400']"
                            data-height="none"
                            data-whitespace="normal"
                            data-type="text" 
                            data-responsive_offset="on" 
                            data-frames="[{&quot;delay&quot;:10,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;0&quot;,&quot;from&quot;:&quot;y:[-100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;&quot;,&quot;mask&quot;:&quot;x:0px;y:0px;s:inherit;e:inherit;&quot;,&quot;to&quot;:&quot;o:1;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;},{&quot;delay&quot;:&quot;wait&quot;,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;999&quot;,&quot;to&quot;:&quot;y:[175%];&quot;,&quot;mask&quot;:&quot;x:inherit;y:inherit;s:inherit;e:inherit;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;}]"
                            data-textAlign="['left','left','left','left']">Quality Cake ... <br /> with sweet, eggs & breads</div>
                            
                            <div class="tp-caption tp-resizeme secand_text" 
                                data-x="['right','right','left','15','15','15']" 
                                data-hoffset="['0','110','15','15','15','0']" 
                                data-y="['top','top','top','top']" data-voffset="['316','316','316','270','330','320']"  
                                data-fontsize="['20','20','20','20','16']"
                                data-lineheight="['28','28','28','28']"
                                data-width="['620','620','620','620','500','380']"
                                data-height="none"
                                data-whitespace="normal"
                                data-type="text" 
                                data-responsive_offset="on"
                                data-transform_idle="o:1;"
                                data-frames="[{&quot;delay&quot;:10,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;0&quot;,&quot;from&quot;:&quot;y:[100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;opacity:0;&quot;,&quot;mask&quot;:&quot;x:0px;y:[100%];s:inherit;e:inherit;&quot;,&quot;to&quot;:&quot;o:1;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;},{&quot;delay&quot;:&quot;wait&quot;,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;999&quot;,&quot;to&quot;:&quot;y:[175%];&quot;,&quot;mask&quot;:&quot;x:inherit;y:inherit;s:inherit;e:inherit;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;}]">"Crafted with care, our quality cakes blend sweetness, farm-fresh eggs, and fluffy bread for a taste you'll remember."
                            </div>
                            
                            <div class="tp-caption tp-resizeme slider_button" 
                                data-x="['right','right','left','15','15','15']" data-hoffset="['0','0','15','0','0','0']" 
                                data-y="['top','top','top','top']" data-voffset="['405','405','405','355','400','415']" 
                                data-fontsize="['14','14','14','14']"
                                data-lineheight="['46','46','46','46']"
                                data-width="['620','740','620','620','300']"
                                data-height="none"
                                data-whitespace="normal"
                                data-type="text" 
                                data-responsive_offset="on" 
                                data-frames="[{&quot;delay&quot;:10,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;0&quot;,&quot;from&quot;:&quot;y:[100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;opacity:0;&quot;,&quot;mask&quot;:&quot;x:0px;y:[100%];s:inherit;e:inherit;&quot;,&quot;to&quot;:&quot;o:1;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;},{&quot;delay&quot;:&quot;wait&quot;,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;999&quot;,&quot;to&quot;:&quot;y:[175%];&quot;,&quot;mask&quot;:&quot;x:inherit;y:inherit;s:inherit;e:inherit;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;}]">
                                
                            </div>
                        </div>
                    </li>
                    <li data-index="rs-1588" data-transition="fade" data-slotamount="default" data-hideafterloop="0" data-hideslideonmobile="off"  data-easein="default" data-easeout="default" data-masterspeed="300"  data-thumb="public/img/home-slider/slider-13.jpg"  data-rotate="0"  data-saveperformance="off"  data-title="Creative" data-param1="01" data-param2="" data-param3="" data-param4="" data-param5="" data-param6="" data-param7="" data-param8="" data-param9="" data-param10="" data-description="">
                    <!-- MAIN IMAGE -->
                    <img src="public/img/home-slider/slider-13.jpg"  alt="" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" data-bgparallax="5" class="rev-slidebg" data-no-retina>
                    <!-- LAYERS -->
                        <!-- LAYERS -->

                        <!-- LAYER NR. 1 -->
                        <div class="slider_text_box">
                           
                           <div class="tp-caption tp-resizeme price" 
                            data-x="['left','left','left','15','15','15']" data-hoffset="['300','300','15','15','15','0']" 
                            data-y="['top','top','top','top']" 
                            data-voffset="['120','120','70','70','115','130']" 
                            data-fontsize="['60','60','60','40','30']"
                            data-lineheight="['76','76','76','50','40']"
                            data-width="['780','780','780','400']"
                            data-height="none"
                            data-whitespace="normal"
                            data-type="text" 
                            data-responsive_offset="on" 
                            data-frames="[{&quot;delay&quot;:10,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;0&quot;,&quot;from&quot;:&quot;y:[-100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;&quot;,&quot;mask&quot;:&quot;x:0px;y:0px;s:inherit;e:inherit;&quot;,&quot;to&quot;:&quot;o:1;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;},{&quot;delay&quot;:&quot;wait&quot;,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;999&quot;,&quot;to&quot;:&quot;y:[175%];&quot;,&quot;mask&quot;:&quot;x:inherit;y:inherit;s:inherit;e:inherit;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;}]"
                            data-textAlign="['left','left','left','left']"><h3>NEW</h3></div>
                           
                            <div class="tp-caption tp-resizeme first_text" 
                            data-x="['right','right','left','15','15','15']" data-hoffset="['-150','0','15','15','15','0']" 
                            data-y="['top','top','top','top']" 
                            data-voffset="['155','155','155','155','235','230']" 
                            data-fontsize="['60','60','60','40','30']"
                            data-lineheight="['76','76','76','50','40']"
                            data-width="['780','740','780','780','700','400']"
                            data-height="none"
                            data-whitespace="normal"
                            data-type="text" 
                            data-responsive_offset="on" 
                            data-frames="[{&quot;delay&quot;:10,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;0&quot;,&quot;from&quot;:&quot;y:[-100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;&quot;,&quot;mask&quot;:&quot;x:0px;y:0px;s:inherit;e:inherit;&quot;,&quot;to&quot;:&quot;o:1;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;},{&quot;delay&quot;:&quot;wait&quot;,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;999&quot;,&quot;to&quot;:&quot;y:[175%];&quot;,&quot;mask&quot;:&quot;x:inherit;y:inherit;s:inherit;e:inherit;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;}]"
                            data-textAlign="['left','left','left','left']">Cake Bakery ... <br /> make delicious products</div>
                            
                            <div class="tp-caption tp-resizeme secand_text" 
                                data-x="['right','right','left','15','15','15']" 
                                data-hoffset="['0','110','15','15','15','0']" 
                                data-y="['top','top','top','top']" data-voffset="['316','316','316','270','330','320']"  
                                data-fontsize="['20','20','20','20','16']"
                                data-lineheight="['28','28','28','28']"
                                data-width="['620','620','620','620','500','380']"
                                data-height="none"
                                data-whitespace="normal"
                                data-type="text" 
                                data-responsive_offset="on"
                                data-transform_idle="o:1;"
                                data-frames="[{&quot;delay&quot;:10,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;0&quot;,&quot;from&quot;:&quot;y:[100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;opacity:0;&quot;,&quot;mask&quot;:&quot;x:0px;y:[100%];s:inherit;e:inherit;&quot;,&quot;to&quot;:&quot;o:1;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;},{&quot;delay&quot;:&quot;wait&quot;,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;999&quot;,&quot;to&quot;:&quot;y:[175%];&quot;,&quot;mask&quot;:&quot;x:inherit;y:inherit;s:inherit;e:inherit;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;}]">"Freshly baked, lovingly made & Cake Bakery delivers deliciousness in every product."
                            </div>
                            
                            <div class="tp-caption tp-resizeme slider_button" 
                                data-x="['right','right','left','15','15','15']" data-hoffset="['0','0','15','0','0','0']" 
                                data-y="['top','top','top','top']" data-voffset="['405','405','405','355','400','415']" 
                                data-fontsize="['14','14','14','14']"
                                data-lineheight="['46','46','46','46']"
                                data-width="['620','740','620','620','300']"
                                data-height="none"
                                data-whitespace="normal"
                                data-type="text" 
                                data-responsive_offset="on" 
                                data-frames="[{&quot;delay&quot;:10,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;0&quot;,&quot;from&quot;:&quot;y:[100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;opacity:0;&quot;,&quot;mask&quot;:&quot;x:0px;y:[100%];s:inherit;e:inherit;&quot;,&quot;to&quot;:&quot;o:1;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;},{&quot;delay&quot;:&quot;wait&quot;,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;999&quot;,&quot;to&quot;:&quot;y:[175%];&quot;,&quot;mask&quot;:&quot;x:inherit;y:inherit;s:inherit;e:inherit;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;}]">
                                
                            </div>
                        </div>
                    </li>
                    <li data-index="rs-1589" data-transition="fade" data-slotamount="default" data-hideafterloop="0" data-hideslideonmobile="off"  data-easein="default" data-easeout="default" data-masterspeed="300"  data-thumb="public/img/home-slider/slider-14.jpg"  data-rotate="0"  data-saveperformance="off"  data-title="Creative" data-param1="01" data-param2="" data-param3="" data-param4="" data-param5="" data-param6="" data-param7="" data-param8="" data-param9="" data-param10="" data-description="">
                    <!-- MAIN IMAGE -->
                    <img src="public/img/home-slider/slider-14.jpg"  alt="" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" data-bgparallax="5" class="rev-slidebg" data-no-retina>
                    <!-- LAYERS -->
                        <!-- LAYERS -->

                        <!-- LAYER NR. 1 -->
                        <div class="slider_text_box">
                           
                           <div class="tp-caption tp-resizeme price" 
                            data-x="['left','left','left','15','15','15']" data-hoffset="['300','300','15','15','15','0']" 
                            data-y="['top','top','top','top']" 
                            data-voffset="['120','120','70','70','115','130']" 
                            data-fontsize="['60','60','60','40','30']"
                            data-lineheight="['76','76','76','50','40']"
                            data-width="['780','780','780','400']"
                            data-height="none"
                            data-whitespace="normal"
                            data-type="text" 
                            data-responsive_offset="on" 
                            data-frames="[{&quot;delay&quot;:10,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;0&quot;,&quot;from&quot;:&quot;y:[-100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;&quot;,&quot;mask&quot;:&quot;x:0px;y:0px;s:inherit;e:inherit;&quot;,&quot;to&quot;:&quot;o:1;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;},{&quot;delay&quot;:&quot;wait&quot;,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;999&quot;,&quot;to&quot;:&quot;y:[175%];&quot;,&quot;mask&quot;:&quot;x:inherit;y:inherit;s:inherit;e:inherit;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;}]"
                            data-textAlign="['left','left','left','left']"><h3>NEW</h3></div>
                           
                            <div class="tp-caption tp-resizeme first_text" 
                            data-x="['right','right','left','15','15','15']" data-hoffset="['-150','0','15','15','15','0']" 
                            data-y="['top','top','top','top']" 
                            data-voffset="['155','155','155','155','235','230']" 
                            data-fontsize="['60','60','60','40','30']"
                            data-lineheight="['76','76','76','50','40']"
                            data-width="['780','740','780','780','700','400']"
                            data-height="none"
                            data-whitespace="normal"
                            data-type="text" 
                            data-responsive_offset="on" 
                            data-frames="[{&quot;delay&quot;:10,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;0&quot;,&quot;from&quot;:&quot;y:[-100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;&quot;,&quot;mask&quot;:&quot;x:0px;y:0px;s:inherit;e:inherit;&quot;,&quot;to&quot;:&quot;o:1;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;},{&quot;delay&quot;:&quot;wait&quot;,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;999&quot;,&quot;to&quot;:&quot;y:[175%];&quot;,&quot;mask&quot;:&quot;x:inherit;y:inherit;s:inherit;e:inherit;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;}]"
                            data-textAlign="['left','left','left','left']">Cake Flavors ... <br /> made with care and love</div>
                            
                            <div class="tp-caption tp-resizeme secand_text" 
                                data-x="['right','right','left','15','15','15']" 
                                data-hoffset="['0','110','15','15','15','0']" 
                                data-y="['top','top','top','top']" data-voffset="['316','316','316','270','330','320']"  
                                data-fontsize="['20','20','20','20','16']"
                                data-lineheight="['28','28','28','28']"
                                data-width="['620','620','620','620','500','380']"
                                data-height="none"
                                data-whitespace="normal"
                                data-type="text" 
                                data-responsive_offset="on"
                                data-transform_idle="o:1;"
                                data-frames="[{&quot;delay&quot;:10,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;0&quot;,&quot;from&quot;:&quot;y:[100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;opacity:0;&quot;,&quot;mask&quot;:&quot;x:0px;y:[100%];s:inherit;e:inherit;&quot;,&quot;to&quot;:&quot;o:1;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;},{&quot;delay&quot;:&quot;wait&quot;,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;999&quot;,&quot;to&quot;:&quot;y:[175%];&quot;,&quot;mask&quot;:&quot;x:inherit;y:inherit;s:inherit;e:inherit;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;}]">"Discover the taste of love in every flavor we bake."
                            </div>
                            
                            <div class="tp-caption tp-resizeme slider_button" 
                                data-x="['right','right','left','15','15','15']" data-hoffset="['0','0','15','0','0','0']" 
                                data-y="['top','top','top','top']" data-voffset="['405','405','405','355','400','415']" 
                                data-fontsize="['14','14','14','14']"
                                data-lineheight="['46','46','46','46']"
                                data-width="['620','740','620','620','300']"
                                data-height="none"
                                data-whitespace="normal"
                                data-type="text" 
                                data-responsive_offset="on" 
                                data-frames="[{&quot;delay&quot;:10,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;0&quot;,&quot;from&quot;:&quot;y:[100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;opacity:0;&quot;,&quot;mask&quot;:&quot;x:0px;y:[100%];s:inherit;e:inherit;&quot;,&quot;to&quot;:&quot;o:1;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;},{&quot;delay&quot;:&quot;wait&quot;,&quot;speed&quot;:1500,&quot;frame&quot;:&quot;999&quot;,&quot;to&quot;:&quot;y:[175%];&quot;,&quot;mask&quot;:&quot;x:inherit;y:inherit;s:inherit;e:inherit;&quot;,&quot;ease&quot;:&quot;Power2.easeInOut&quot;}]">
                                
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </section>
        <!--================End Slider Area =================-->
        
        <!--================Welcome Area =================-->
        <section class="welcome_bakery_area pink_cake_feature">
        	<div class="container">
        		<div class="cake_feature_inner">
      				<div class="title_view_all">
						<div class="float-left">
							<div class="main_w_title">
								<h2>Our Featured Cakes</h2>
								<h5> Best Choices for you</h5>
							</div>
						</div>
						<div class="float-right">
							<a class="pest_btn" href="#">View all Products</a>
						</div>
					</div>
       				<div class="cake_feature_slider owl-carousel">
						<?php
							require_once 'model/product.php';
							$model = new ModelProduct();
							$result = $model->getSP();
							foreach ($result as $value) { ?>

							<div class="item">
								<div class="cake_feature_item">
									<div class="cake_img">
										
										<img style="max-width: 100%; height: 200px; object-fit: cover;" src="public/img/product/<?php echo $value['hinh_anh']; ?>" alt="">
									</div>
									<div class="cake_text">
										
										<h4>$<?php echo $value['gia']; ?></h4>
										<a href="<?= BASE_URL ?>?controller=Product&action=ProductDetail&id=<?php echo $value['id_banh']; ?>">
											<h3><?php echo $value['ten_banh']; ?></h3>
										</a>
										<a class="pest_btn" href="javascript:void(0)" onclick="addToCart(<?= $value['id_banh'] ?>)">Add to cart</a>
									</div>
								</div>
							</div>

						<?php }
						?>
       					
       					
       				</div>
        		</div>
        	</div>
        </section>
        <!--================End Welcome Area =================-->
        
        <!--================Special Recipe Area =================-->
        <section class="special_recipe_area">
        	<div class="container">
        		<div class="special_recipe_slider owl-carousel">
					<?php
						require_once 'model/news.php';
						$model = new ModelNews();
						$result = $model->getNEWSHOME();
						foreach ($result as $value) { ?>

						<div class="item">
							<div class="media">
								<div class="d-flex">
									<img src="public/img/blog/<?php echo $value['hinh_anh']; ?>" alt="">
								</div>
								<div class="media-body">
									<h4><?php echo $value['tieu_de']; ?></h4>
									<p><?php echo $value['noi_dung']; ?></p>
									<a class="w_view_btn" href="<?= BASE_URL ?>?controller=News&action=NewsDetail&id=<?php echo $value[0]; ?>">View Details</a>
								</div>
							</div>
						</div>

        			<?php }
					?>
        		</div>
        	</div>
        </section>
        <!--================End Special Recipe Area =================-->

        <!--================New Arivals Area =================-->
        <section class="new_arivals_area p_100">
        	<div class="container">
        		<div class="single_pest_title">
					<h2>New Arrivals</h2>
				</div>
        		<div class="row arivals_inner">
        			<div class="col-lg-6 col-sm-7">
					<?php
						require_once 'model/product.php';
						$model = new ModelProduct();
						$result = $model->getSPMAX1();
						foreach ($result as $value) { ?>

        				<div class="arivals_chocolate">
							<a style="background: none;" href="<?= BASE_URL ?>?controller=Product&action=ProductDetail&id=<?php echo $value[0]; ?>">
								<div class="arivals_pic">
									<img class="img-fluid" src="public/img/product/<?php echo $value['hinh_anh']; ?>" alt="">
									<div class="price_text">
										<h5>$<?php echo $value['gia']; ?></h5>
									</div>
								</div>
								<div class="arivals_text" style="margin-left: 100px;">
									<h4 style="font-size: 40px; margin-top: -30px; width: 200px; height: auto;"><strong><?php echo $value['ten_banh']; ?></strong></h4>
									<p style="font-size: 30px; font-weight: bold; color: #A5504E; display: inline-block; background: #F7E7D2; padding: 10px; border-radius: 5%; margin-top: 10px;">Highest</p>	
								</div>	
							</a>
							
        				</div>
						
						<?php }
					?>
        			</div>
        			<div class="col-lg-6">
        				<div class="arivals_slider owl-carousel">
							<?php
								require_once 'model/product.php';
								$model = new ModelProduct();
								$result = $model->getSPGIA();
								foreach ($result as $value) { ?>

        					<div class="item">
        						<div class="cake_feature_item">
									<div class="cake_img">
										<img style="object-fit: cover; height: 200px;" src="public/img/product/<?php echo $value['hinh_anh']; ?>" alt="">
									</div>
									<div class="cake_text">
										<h4>$<?php echo $value['gia']; ?></h4>
										<a href="<?= BASE_URL ?>?controller=Product&action=ProductDetail&id=<?php echo $value['id_banh']; ?>">
											<h3><?php echo $value['ten_banh']; ?></h3>
										</a>
										
										<a class="pest_btn" href="javascript:void(0)" onclick="addToCart(<?= $value['id_banh'] ?>)">Add to cart</a>
									</div>
								</div>
        					</div>
        					
							<?php }
						?>
        				</div>
        			</div>
        		</div>
        	</div>
        </section>
        <!--================End New Arivals Area =================-->
        
        <!--================Client Says Area =================-->
        <section class="client_says_area p_100">
        	<div class="container">
        		<div class="client_says_inner">
        			<div class="c_says_title">
        				<h2>Reviews From Famous</h2>
        			</div>
        			<div class="client_says_slider owl-carousel">
        				<div class="item">
        					<div class="media">
        						<div class="d-flex">
        							<img src="public/img/client/gordonramsay-97eh.jpg" alt="">
        							<h3>“</h3>
        						</div>
        						<div class="media-body">
        							<p>Now this is what I call a proper bakery. The sponge? Incredibly light. The cream? Smooth, not overly sweet — just beautifully balanced. The chocolate cupcake had depth — rich, indulgent, but not cloying. Whoever’s behind this clearly understands flavor, texture, and precision. It’s simple, elegant, and bloody delicious. If you’re serious about good desserts, don’t walk — run to this place.</p>
        							<h5>- Gordon Ramsay</h5>
        						</div>
        					</div>
        				</div>
        				<div class="item">
        					<div class="media">
        						<div class="d-flex">
        							<img src="public/img/client/sonyside.png" alt="">
        						</div>
        						<div class="media-body">
        							<p>Okay, let me tell you something… this bakery SLAPS! The tiramisu? It hits harder than my morning coffee. The wedding cake? It's so elegant I almost felt underdressed eating it. This place doesn’t mess around – it’s dessert done right. Friendly staff, gorgeous cakes, and flavors that’ll punch your taste buds in the face… in a good way. 11/10, I’m coming back with my whole crew!</p>
        							<h5>- Sony Side</h5>
        						</div>
        					</div>
        				</div>
        				<div class="item">
        					<div class="media">
        						<div class="d-flex">
        							<img style="width: 200px;" src="public/img/client/ninohome.jpg" alt="">
        						</div>
        						<div class="media-body">
        							<p>Mình tính đi mua một cái bánh ăn chơi thôi, ai ngờ nghiện luôn. Bánh mềm, thơm, béo, ăn vào là muốn khóc thét vì ngon. Topping thì đầy đặn, ngọt vừa phải, không bị ngán. Nói chung là: bánh ngon, decor xinh, nhân viên cute, rất đáng tiền.
Mình không biết viết review sao cho chuyên nghiệp, chứ thật ra là… mình ăn gần hết cái hộp bánh mới nhớ ra chưa chụp hình. Huhu, lần sau sẽ chụp rồi đăng sống ảo nha. Chốt lại: nên thử. Thử rồi sẽ mê. Mê rồi đừng trách!</p>
        							<h5>- Nino Home</h5>
        						</div>
        					</div>
        				</div>
        			</div>
        		</div>
        	</div>
        </section>
        <!--================End Client Says Area =================-->
        
        <!--================Latest News Area =================-->
        <section class="latest_news_area golden_bg p_100">
        	<div class="container">
        		<div class="main_title">
					<h2>Latest Blog</h2>
					<h5>an turn into your instructor your helper, your </h5>
				</div>
       			<div class="row latest_news_inner">
					<?php
						require_once 'model/news.php';
						$model = new ModelNews();
						$result = $model->get1LATESTNEWS();
						foreach ($result as $value) { ?>				

       				<div class="col-lg-4 col-md-6">
       					<div class="l_news_image">
							<a href="<?= BASE_URL ?>?controller=News&action=NewsDetail&id=<?php echo $value['id_tintuc']; ?>">
								<div class="l_news_img">
									<img style="height: 387px; width: 370px;" class="img-fluid" src="public/img/blog/<?php echo $value['hinh_anh']; ?>" alt="">
								</div>
								<div class="l_news_hover">
									<p><h5 style="color: black;"><?php echo $value['ngay_xuatban']; ?></h5></p>
									<p><h4 style="color: black; background-color: #797979;"><?php echo $value['tieu_de']; ?></h4></p>

								</div>
							</a>
       						
       					</div>
       				</div>

					<?php }
					?>

					<?php
						require_once 'model/news.php';
						$model = new ModelNews();
						$result = $model->getLATESTNEWS();
						foreach ($result as $value) { ?>	

       				<div class="col-lg-4 col-md-6">
       					<div class="l_news_item">
							<a href="<?= BASE_URL ?>?controller=News&action=NewsDetail&id=<?php echo $value['id_tintuc']; ?>">
								<div class="l_news_img">
									<img class="img-fluid" src="public/img/blog/<?php echo $value['hinh_anh']; ?>" alt="">
								</div>
								<div class="l_news_text">
									<p><h5><?php echo $value['ngay_xuatban']; ?></h5></p>
									<p><h4><?php echo $value['tieu_de']; ?></h4></p>
									<p><?php echo $value['noi_dung']; ?></p>
								</div>
							</a>
       						
       					</div>
       				</div>
       				
					<?php }
					?>
       			</div>
        	</div>
        </section>
        <!--================End Latest News Area =================-->
        
        <!--================Bakery Video Area =================-->
        <section class="bakery_video_area">
        	<div class="container">
        		<div class="video_inner">
        			<h3>Real Taste</h3>
        			<p>A light, sour wheat dough with roasted walnuts and freshly picked rosemary, thyme, poppy seeds, parsley and sage</p>
        			<div class="media">
        				<div class="d-flex">
        					<a class="popup-youtube" href="http://www.youtube.com/watch?v=0O2aH4XLbto"><i class="flaticon-play-button"></i></a>
        				</div>
        				<div class="media-body">
        					<h5>Watch intro video <br />about us</h5>
        				</div>
        			</div>
        		</div>
        	</div>
        </section>
        <!--================End Bakery Video Area =================-->
        
        <!--================Footer Area =================-->
        <footer class="footer_area">
        	<div class="footer_widgets">
        		<div class="container">
        			<div class="row footer_wd_inner">
        				<div class="col-lg-3 col-6">
        					<aside class="f_widget f_about_widget">
        						<img src="public/img/footer-logo.png" alt="">
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