<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Single.aspx.cs" Inherits="Single" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BooksMahal | View Details for Product </title>
	<meta name="viewport" content="width=device-width, initial-scale=1"/>
	<meta charset="utf-8" />
	<meta name="keywords" content="Books mahal, BooksMahal, Books Mahal official" />
	<link id="Link1" runat="server" rel="Shortcut Icon" href="Images/fi.png" type="image/x-icon"/>
	<script>
		addEventListener("load", function () {
			setTimeout(hideURLbar, 0);
		}, false);
		function hideURLbar() {
			window.scrollTo(0, 1);
		}
	</script>
	<!-- Global site tag (gtag.js) - Google Analytics -->
	<script async src="https://www.googletagmanager.com/gtag/js?id=UA-134661051-1"></script>
	<script>
	  window.dataLayer = window.dataLayer || [];
	  function gtag(){dataLayer.push(arguments);}
	  gtag('js', new Date());
	  gtag('config', 'UA-134661051-1');
	</script>
	<link href="css/bootstrap.css" rel='stylesheet' type='text/css' />
	<link href="css/login_overlay.css" rel='stylesheet' type='text/css' />
	<link href="css/style6.css" rel='stylesheet' type='text/css' />
	<link rel="stylesheet" href="css/shop.css" type="text/css" />
	<link rel="stylesheet" href="css/owl.carousel.css" type="text/css" media="all"/>
	<link rel="stylesheet" href="css/owl.theme.css" type="text/css" media="all"/>
	<link rel="stylesheet" type="text/css" href="css/jquery-ui1.css" />
	<link href="css/easy-responsive-tabs.css" rel='stylesheet' type='text/css' />
	<link rel="stylesheet" href="css/flexslider.css" type="text/css" media="screen" />
	<link href="css/style1.css" rel='stylesheet' type='text/css' />
	<link href="css/fontawesome-all.css" rel="stylesheet" />
	<link href="css/Search.css" rel="stylesheet" />
	<link href="//fonts.googleapis.com/css?family=Inconsolata:400,700" rel="stylesheet" />
	<link href="//fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800" rel="stylesheet" />
	<style type="text/css">
		#signinbtn, #signoutbtn, #informer, #showbtn, #shownotebtn {
			display: none;
		}
		.btn-design {
			margin-top: 10px;
			border: 0.5px solid lightgray;
			border-radius: 0;
		}
		.proname {
			color: gray;
			font-size: 16px;
		}
		.alert-box {
			position: fixed;
			top: 0;
			left: 0;
			height: 100vh;
			width: 100%;
			background: rgba(0,0,0,0.8);
			display: none;
			z-index: 999;
		}
			.alert-box .alert-dialog {
				position: relative;
				top: 50vh;
				left: 50%;
				min-height: 200px;
				width: 500px;
				padding: 15px;
				background: ghostwhite;
				box-shadow: 1px 1px 25px black;
				transform: translate(-50%,-50%);
			}
		@media(max-width:768px) {
			.alert-box .alert-dialog {
				width: 90%;
			}
		}
		#loader {
			position: fixed;
			left: 0px;
			right: 0px;
			z-index: 9999;
			width: 100%;
			height: 100%;
			opacity: 0.9;
			background: url(../Images/logo100px.png) center no-repeat #ffffff;
		}

		.after-click {
			position: fixed;
			left: 0px;
			right: 0px;
			z-index: 9999;
			width: 100%;
			height: 100%;
			opacity: 0.9;
			background: url(../Images/logo100px.png) center no-repeat #ffffff;
			display: none;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
		<div id="loader"></div>
        <div class="after-click"></div>
        <div class="banner-top container-fluid" id="home">
			<!-- header -->
			<header>
				<div class="row">
					<div class="col-lg-3 text-center mt-lg-4" style="margin:15px 0px 15px 0px;">
						<a href="tel:9720410274" style="color:dimgray;padding:13px;border:0.5px solid lightgray;text-decoration:none;letter-spacing:1px;">
							Help : <i class="fa fa-mobile-alt"></i> 9720410274</a>
					</div>
					<div class="col-lg-6 logo-w3layouts text-center">
						<h1 class="logo-w3layouts" style="margin:0px;">
							<a class="navbar-brand" href="Home" style="text-transform:none;margin-bottom:15px;">
								<img src="images/Logo_.png" style="width:60%;"/>
							</a>
						</h1>
					</div>

					<div class="col-lg-3 text-center mt-lg-4" style="margin-bottom:15px;">
						<a id="signinbtn" href="User_Zone" style="color:dimgray;padding:13px 15px;border:0.5px solid lightgray;text-decoration:none;" title="Sign In">
							<i class="fa fa-user"></i></a>
						<a id="signoutbtn" href="SignOut" style="color:dimgray;padding:13px 15px;border:0.5px solid lightgray;text-decoration:none;" title="Sign Out">
							<i class="fa fa-power-off"></i></a>
						<a href="Cart" style="color:dimgray;padding:13px;border:0.5px solid lightgray;" title="Cart"><i class="fas fa-cart-arrow-down"></i> <asp:Label runat="server" ID="addeditems" Text="0"></asp:Label></a>
						<a id="trigger-overlay" href="#" style="color:dimgray;padding:13px 15px;border:0.5px solid lightgray;text-decoration:none;" title="Search"><i class="fas fa-search"></i></a>
					
					</div>
				</div>
			
				<div class="search">
					<!-- open/close -->
					<div class="overlay overlay-door">
						<button type="button" class="overlay-close">
							<i class="fa fa-times" aria-hidden="true"></i>
						</button>
						<div id="soverlay" style="position:absolute;top:50vh;left:50vw;transform:translate(-50%,-50%);width:100%;">
							<div class="panel-body">
								<div class="row">
									<div class="col-md-3"></div>
									<div class="col-md-6">
										<input type="text" id="search" onkeyup="myFunction()" placeholder="Search for names.." title="Type in a name" autocomplete="off"/>
										<%--<div class="input-group" style="height:50px;">
											<asp:TextBox runat="server" ID="searchtxt" CssClass="form-control" Placeholder="Enter Keyword" style="border-radius:0px;border:2px solid orangered;background-color:transparent;border-right:none;color:white;"></asp:TextBox>
											<asp:button runat="server" ID="searchbtn" CssClass="input-group-addon" Text="Search" style="border-radius:0px;border:2px solid orangered;background-color:transparent;border-left:none;color:orangered;"></asp:button>
										</div>--%>
										<div style="height:300px;overflow-y:auto;">
											<ul id="myUL">
												<asp:PlaceHolder ID="keywordph" runat="server"></asp:PlaceHolder>
											</ul>
										</div>
									</div>
									<div class="col-md-3"></div>
								</div>
							</div>
						</div>
					</div>
					<!-- open/close -->
				</div>
				<label class="top-log mx-auto"></label>
				<nav class="navbar navbar-expand-lg navbar-light bg-light top-header mb-2">

					<button class="navbar-toggler mx-auto" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
						aria-expanded="false" aria-label="Toggle navigation">
						<span class="navbar-toggler-icon">
						
						</span>
					</button>
					<div class="collapse navbar-collapse" id="navbarSupportedContent">
						<ul class="navbar-nav nav-mega mx-auto text-center">
							<li class="nav-item active">
								<a class="nav-link ml-lg-0" href="Home">Home
									<span class="sr-only">(current)</span>
								</a>
							</li>
							<li class="nav-item">
								<a class="nav-link" href="About">About</a>
							</li>
							<li class="nav-item dropdown">
								<a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true"
									aria-expanded="false">
									Featured
								</a>
								<ul class="dropdown-menu mega-menu ">
									<li>
										<div class="row">
											<div class="col-md-4 media-list span4 text-left">
												<h5 class="tittle-w3layouts-sub"> Featured Items </h5>
												<ul>
													<li class="media-mini mt-3">
														<a href="Shop?for=Quantums">Engg. Quantums</a>
													</li>
													<li class="">
														<a href="Shop?for=GATE_Books"> GATE Books</a>
													</li>
													<li>
														<a href="Shop?for=SSC_Books">SSC Books</a>
													</li>
													<li class="mt-3">
														<h5>View more pages</h5>
													</li>
													<li class="mt-2">
														<a href="About">About</a>
													</li>
													<li>
														<a href="Track_Your_Order">Track Order</a>
													</li>
												</ul>
											</div>
											<div class="col-md-4 media-list span4 text-left">
												<h5 class="tittle-w3layouts-sub"> SSC Books </h5>
												<div class="media-mini mt-3">
													<a href="Shop?for=SSC_Books">
														<img src="images/ssc_Kiran.jpg" class="img-fluid" alt="" style="height:200px;width:150px;"/>
													</a>
												</div>
											</div>
											<div class="col-md-4 media-list span4 text-left">
												<h5 class="tittle-w3layouts-sub">GATE Books </h5>
												<div class="media-mini mt-3">
													<a href="Shop?for=GATE_Books">
														<img src="images/1.jpg" class="img-fluid" alt="" style="height:200px;width:150px;"/>
													</a>
												</div>

											</div>
										</div>
										<hr />
									</li>
								</ul>
							</li>
							<li class="nav-item dropdown">
								<a class="nav-link dropdown-toggle" href="#" id="navbarDropdown1" role="button" data-toggle="dropdown" aria-haspopup="true"
									aria-expanded="false">
									Shop
								</a>
								<ul class="dropdown-menu mega-menu ">
									<li>
										<div class="row">
											<div class="col-md-4 media-list span4 text-left">
												<h5 class="tittle-w3layouts-sub"> Books </h5>
												<ul>
													<li class="media-mini mt-3">
														<a href="Shop?for=Novels">Novels</a>
													</li>
													<li class="">
														<a href="Shop?for=Competatives">Competatives</a>
													</li>
													<li>
														<a href="Shop?for=Biography">Biography</a>
													</li>
													<li>
														<a href="Shop?for=School_Books_6th_to_10th">School Books (6th-10th)</a>
													</li>
													<li>
														<a href="Shop?for=School_Books_11th_to_12th">School Books (11th-12th)</a>
													</li>
												</ul>
											</div>
											<div class="col-md-4 media-list span4 text-left">
												<h5 class="tittle-w3layouts-sub"> Text Books </h5>
												<ul>
													<li class="media-mini mt-3">
														<a href="Shop?for=Engg_Books">Engg. Books</a>
													</li>
													<li>
														<a href="Shop?for=Law_Books">Law Books</a>
													</li>
													<li>
														<a href="Shop?for=Medical_Books">Medical Books</a>
													</li>
													<li>
														<a href="Shop?for=Diploma">Diploma</a>
													</li>
													<li>
														<a href="Shop?for=NCERT">NCERT</a>
													</li>
												</ul>

											</div>
											<div class="col-md-4 media-list span4 text-left">

												<h5 class="tittle-w3layouts-sub-nav">Stationery</h5>
												<ul>
													<li class="media-mini mt-3">
														<a href="Shop?for=Note_Books">Note Books</a>
													</li>
													<li>
														<a href="Shop?for=Diary">Diary</a>
													</li>
													<li>
														<a href="Shop?for=Calculator">Calculator</a>
													</li>
													<li>
														<a href="Shop?for=Geometry_Box">Geometry Box</a>
													</li>
													<li>
														<a href="Shop?for=Chart_Papers">Chart Papers</a>
													</li>
												</ul>
											</div>
										</div>
										<hr />
									</li>
								</ul>
							</li>
							<li class="nav-item">
								<a class="nav-link" href="Contact">Contact</a>
							</li>
						</ul>

					</div>
				</nav>
			</header>
			<!-- banner -->
			<div class="banner_inner">
				<div class="services-breadcrumb">
					<div class="inner_breadcrumb">

						<ul class="short">
							<li>
								<a href="Home">Home</a>
								<i>|</i>
							</li>
							<li>Single Page</li>
						</ul>
					</div>
				</div>

			</div>
		
		</div>
		<!--//banner -->

		<!--/shop-->
		<section class="banner-bottom-wthreelayouts py-lg-5 py-3">
			<div class="container">
				<div class="inner-sec-shop pt-lg-4 pt-3">
					<div class="row">
						<div class="col-lg-4 single-right-left ">
							<div class="grid images_3_of_2">
								<div class="flexslider1">
									<asp:PlaceHolder runat="server" ID="picph"></asp:PlaceHolder>
									<div class="clearfix"></div>
								</div>
							</div>
						</div>
						<div class="col-lg-8 single-right-left simpleCart_shelfItem">
							<h3><asp:Label runat="server" ID="namelbl"></asp:Label></h3>
							<p><span class="item_price"><asp:Label runat="server" ID="sellplbl"></asp:Label></span><br />
								<del><asp:Label runat="server" ID="strikeplbl"></asp:Label></del><br />
								<span class="item_price"><asp:Label runat="server" ID="discountlbl"></asp:Label></span><br />
								<span class="item_price"><asp:Label runat="server" ID="tstocklbl"></asp:Label></span><br />
								
							</p>
							<div class="description">
								<h5>Check delivery, payment options and charges at your location</h5>
								<asp:TextBox runat="server" ID="pintxt" TextMode="Number" placeholder="Enter 6 Digit Pin Code" CssClass="form-control" style="margin-bottom:10px;"></asp:TextBox>
								<asp:Label runat="server" ID="checkpinlbl"></asp:Label>
								<asp:Button runat="server" ID="checkpinbtn" CssClass="btn btn-warning btn-design" Text="Check Location" OnClick="checkpinbtn_Click"/><hr />
								<asp:Button runat="server" ID="addcartbtn" CssClass="btn btn-warning btn-design btn-block" Text="Add to Cart" style="padding-top:10px;" OnClick="addcartbtn_Click"/>
								<asp:Button runat="server" ID="reqbookbtn" CssClass="btn btn-warning btn-design btn-block" Text="Request This Book" style="padding-top:10px;" OnClick="reqbookbtn_Click"/>
							</div>
						</div>
						<div class="clearfix"> </div>
					</div>
					
					<!--/tabs-->
					<div class="responsive_tabs" style="width:100%;">
						<div id="horizontalTab">
							<ul class="resp-tabs-list">
								<li>Description</li>
								<li>Information</li>
							</ul>
							<div class="resp-tabs-container">
								<!--/tab_one-->
								<div class="tab1">
									<div class="single_page" style="width:100%;">
										<div style="width:100%;padding:15px;text-align:justify;">
											<asp:Label runat="server" ID="desclbl"></asp:Label>
										</div>
									</div>
								</div>
											
								<div class="tab2">
									<div class="single_page" style="width:100%;">
										<div style="width:100%;padding:15px;">
											<pre><asp:Label runat="server" ID="infolbl"></asp:Label></pre>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
					<!--//tabs-->
				</div>
			</div>
				<div class="container-fluid">
					<!--/slide-->
					<div class="slider-img mid-sec mt-lg-5 mt-2 px-lg-5 px-3">
						<!--//banner-sec-->
						<h3 class="tittle-w3layouts text-left my-lg-4 my-3">Featured Products</h3>
						<div class="mid-slider">
							<div class="owl-carousel owl-theme row">
								<asp:PlaceHolder runat="server" ID="fproph"></asp:PlaceHolder>
							</div>
						</div>
					</div>
					<!--//slider-->
				</div>
		</section>
		<!--footer -->
	<footer class="py-lg-5 py-3">
		<div class="container-fluid px-lg-5 px-3">
			<div class="row footer-top-w3layouts">
				<div class="col-lg-3 footer-grid-w3ls">
					<div class="footer-title">
						<h3>About Us</h3>
					</div>
					<div class="footer-text">
						<p style="text-align:justify;">
							BooksMahal.com is India's Largest Online Book Store. It carries the prestige of over 2 years of retail experience.
							The company is Headquartered in New Delhi and has it's offices in Meerut.<br />
							Follow us on -
						</p>
						<ul class="footer-social text-left mt-lg-4 mt-3">
							
							<li class="mx-2">
								<a href="http://www.facebook.com/booksmahal1" target="_blank">
									<span class="fab fa-facebook-f"></span>
								</a>
							</li>
							<li class="mx-2">
								<a href="https://twitter.com/booksmahal" target="_blank">
									<span class="fab fa-twitter"></span>
								</a>
							</li>
							<li class="mx-2">
								<a href="http://www.linkedin.com/in/books-mahal" target="_blank">
									<span class="fab fa-linkedin-in"></span>
								</a>
							</li>
							<li class="mx-2">
								<a href="http://www.instagram.com/booksmahal" target="_blank">
									<span class="fab fa-instagram"></span>
								</a>
							</li>
						</ul>
					</div>
				</div>
				<div class="col-lg-3 footer-grid-w3ls">
					<div class="footer-title">
						<h3>Get in touch</h3>
					</div>
					<div class="contact-info">
						<h4>Location :</h4>
						<p style="text-align:justify;">New F-97 1st floor Raghubir Nagar, near Tagore Garden, New Delhi, Delhi 110027</p>
						<div class="phone">
							<h4>Contact :</h4>
							<p>Phone : <a href="tel:9720410274">+91 9720410274</a></p>
							<p>Email :
								<a href="mailto:booksmahal-info@booksmahal.in">Send an E-Mail</a>
							</p>
						</div>
					</div>
				</div>
				<div class="col-lg-3 footer-grid-w3ls">
					<div class="footer-title text-left">
						<h3>Quick Links</h3>
					</div>
					<ul class="links">
						<li>
							<a href="Home">Go to Home</a>
						</li>
						<li>
							<a href="Privacy_Policy">Privacy Policy</a>
						</li>
						<li>
							<a href="Cookie_Policy">Cookie Policy</a>
						</li>
						<li>
							<a href="Track_Your_Order">Track Order</a>
						</li>
						<li>
							<a href="Shop">Book Store</a>
						</li>
						<li>
							<a href="Cart">Your Cart</a>
						</li>
						<li>
							<a href="Contact">Contact Us</a>
						</li>
					</ul>
				</div>
				<div class="col-lg-3 footer-grid-w3ls">
					<div class="footer-title">
						<h3>Our Newsletters</h3>
					</div>
					<div class="footer-text">
						<p style="text-align:justify;">
							&ensp;By subscribing to our mailing list you will always get latest news and updates from us.<br />
							&ensp;You can unsubscribe in future, if you don't want to recieve any exclusive offers from BooksMahal.
						</p><br />
							<asp:TextBox runat="server" ID="nltxt" CssClass="form-control" TextMode="Email" style="width:95%;background:none;float:left;height:40px;padding-left:10px;border:1px solid orangered;margin-left:2.5%;padding-right:13%;" Placeholder="Enter Email ID" MaxLength="50"></asp:TextBox>
							<asp:Button runat="server" ID="nlbtn" CssClass="btn btn-default input-group-addon" Text="Go" style="width:10%;border:none;background:none;float:left;height:38px;border-radius:0px 3px 3px 0px;margin-left:-13%;margin-top:1px;color:orangered;font-size:12px;" OnClick="nlbtn_Click"/>
					</div>
				</div>
			</div>
			<div class="copyright-w3layouts mt-4">
				<p class="copy-right text-center">
					<a href="Privacy_Policy" target="_blank">Privacy Policy</a> | <a href="Cookie_Policy" target="_blank">Cookie Policy</a><br />
					&copy; 2019 BooksMahal.com<br />All Rights Reserved<br />
					Developed by <a href="http://www.linkedin.com/in/samsberk" target="_blank"> samsberk </a>
				</p>
			</div>
		</div>
	</footer>
	<!-- //footer -->
	<!--jQuery-->
	<script src="js/jquery-2.2.3.min.js"></script>
	<!-- newsletter modal -->
	
		<asp:Label runat="server" ID="informer"></asp:Label>
		<asp:Label runat="server" ID="showbtn"></asp:Label>
		<asp:Label runat="server" ID="shownotebtn"></asp:Label>
		<div class="alert-box">
			<div class="alert-dialog text-center">
				<h4><i class="fa fa-bullhorn"></i> ALERT</h4><hr />
				<asp:Label runat="server" ID="alerttext" style="font-size:17px;"></asp:Label><hr />
				<button type="button" class="btn btn-default close-alert-box">Done</button>
			</div>
		</div>
		<!-- //footer -->

		<!--jQuery-->
		<script src="js/jquery-2.2.3.min.js"></script>
		<!-- newsletter modal -->
		<!--search jQuery-->
		<script src="js/modernizr-2.6.2.min.js"></script>
		<script src="js/classie-search.js"></script>
		<script src="js/Search.js"></script>
		<script src="js/demo1-search.js"></script>
		<script type="text/javascript">
			$("#checkpinbtn").attr("disabled", true);
			$("#pintxt").focus(function () {
				$("#checkpinlbl").hide();
				$("#checkpinbtn").attr("disabled", false);
			});
			$("#checkpinbtn").click(function () {
				var p = document.getElementById("pintxt");
				if (p.value < 0) {
					alert("Enter Correct Pin Code");
					p.value = "";
					p.focus();
					$("#checkpinbtn").attr("disabled", true);
				}
				else if (p.value > 999999) {
					alert("Enter Correct Pin Code");
					p.value = "";
					p.focus();
					$("#checkpinbtn").attr("disabled", true);
				}
			});
		</script>
		<!--//search jQuery-->
		<script type="text/javascript">
			$(".click-on").click(function () {
				$(".after-click").fadeIn();
			});
			$(".close-alert-box").click(function () {
				$(".alert-box").hide();
			});
			var loader = document.getElementById("loader");
			window.addEventListener("load", function () {
				$("#loader").fadeOut();
			});
			var loader = document.getElementById("loader");
			window.addEventListener("load", function () {
				$("#loader").fadeOut();
			});


			if ($("#shownotebtn").text() == "zero") {
				$("#reqbookbtn").show();
				$("#addcartbtn").hide();
			}
			else {
				$("#reqbookbtn").hide();
				$("#addcartbtn").show();
			}

			if ($("#showbtn").text() == "signinbtn") {
				$("#signinbtn").show();
			}
			else if ($("#showbtn").text() == "signoutbtn") {
				$("#signoutbtn").show();
			}

			if ($("#informer").text() == "ItIsMinimumNumberofQuantity") {
				$(".alert-box").show();
			}
			else if ($("#informer").text() == "RequestedSuccessfully") {
				$(".alert-box").show();
			}

		</script>
		<!-- cart-js -->
		<script src="js/minicart.js"></script>
		<script>
			googles.render();

			googles.cart.on('googles_checkout', function (evt) {
				var items, len, i;

				if (this.subtotal() > 0) {
					items = this.items();

					for (i = 0, len = items.length; i < len; i++) {}
				}
			});
		</script>
		<!-- //cart-js -->
		<script>
			$(document).ready(function () {
				$(".button-log a").click(function () {
					$(".overlay-login").fadeToggle(200);
					$(this).toggleClass('btn-open').toggleClass('btn-close');
				});
			});
			$('.overlay-close1').on('click', function () {
				$(".overlay-login").fadeToggle(200);
				$(".button-log a").toggleClass('btn-open').toggleClass('btn-close');
				open = false;
			});
		</script>
		<!-- carousel -->
		<!-- price range (top products) -->
		<script src="js/jquery-ui.js"></script>
		<script>
			//<![CDATA[ 
			$(window).load(function () {
				$("#slider-range").slider({
					range: true,
					min: 0,
					max: 9000,
					values: [50, 6000],
					slide: function (event, ui) {
						$("#amount").val("$" + ui.values[0] + " - $" + ui.values[1]);
					}
				});
				$("#amount").val("$" + $("#slider-range").slider("values", 0) + " - $" + $("#slider-range").slider("values", 1));

			}); //]]>
		</script>
		<!-- //price range (top products) -->

		<script src="js/owl.carousel.js"></script>
		<script>
			$(document).ready(function () {
				$('.owl-carousel').owlCarousel({
					loop: true,
					margin: 10,
					responsiveClass: true,
					responsive: {
						0: {
							items: 1,
							nav: true
						},
						600: {
							items: 2,
							nav: false
						},
						900: {
							items: 3,
							nav: false
						},
						1000: {
							items: 4,
							nav: true,
							loop: false,
							margin: 20
						}
					}
				})
			})
		</script>

		<!-- //end-smooth-scrolling -->

		<!-- single -->
		<script src="js/imagezoom.js"></script>
		<!-- single -->
		<!-- script for responsive tabs -->
		<script src="js/easy-responsive-tabs.js"></script>
		<script>
			$(document).ready(function () {
				$('#horizontalTab').easyResponsiveTabs({
					type: 'default', //Types: default, vertical, accordion           
					width: 'auto', //auto or any width like 600px
					fit: true, // 100% fit in a container
					closed: 'accordion', // Start closed if in accordion view
					activate: function (event) { // Callback function if tab is switched
						var $tab = $(this);
						var $info = $('#tabInfo');
						var $name = $('span', $info);
						$name.text($tab.text());
						$info.show();
					}
				});
				$('#verticalTab').easyResponsiveTabs({
					type: 'vertical',
					width: 'auto',
					fit: true
				});
			});
		</script>
		<!-- FlexSlider -->
		<script src="js/jquery.flexslider.js"></script>
		<script>
			// Can also be used with $(document).ready()
			$(window).load(function () {
				$('.flexslider1').flexslider({
					animation: "slide",
					controlNav: "thumbnails"
				});
			});
		</script>
		<!-- //FlexSlider-->

		<!-- dropdown nav -->
		<script>
			$(document).ready(function () {
			$(".dropdown").click(
				function () {
					$('.dropdown-menu', this).stop(true, true).slideDown("fast");
					$(this).toggleClass('open');
				},
				function () {
					$('.dropdown-menu', this).stop(true, true).slideUp("fast");
					$(this).toggleClass('open');
				}
			);
		});
		</script>
		<!-- //dropdown nav -->
	<script src="js/move-top.js"></script>
    <script src="js/easing.js"></script>
    <script>
        jQuery(document).ready(function($) {
            $(".scroll").click(function(event) {
                event.preventDefault();
                $('html,body').animate({
                    scrollTop: $(this.hash).offset().top
                }, 900);
            });
        });
    </script>
    <script>
        $(document).ready(function() {
            /*
            						var defaults = {
            							  containerID: 'toTop', // fading element id
            							containerHoverID: 'toTopHover', // fading element hover id
            							scrollSpeed: 1200,
            							easingType: 'linear' 
            						 };
            						*/

            $().UItoTop({
                easingType: 'easeOutQuart'
            });

        });
    </script>
    <!--// end-smoth-scrolling -->


		<script src="js/bootstrap.js"></script>
		<!-- js file -->
    </form>
</body>
</html>
