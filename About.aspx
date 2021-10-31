<%@ Page Language="C#" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BooksMahal | About Us </title>
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
	<link href="css/style1.css" rel='stylesheet' type='text/css' />
	<link href="css/fontawesome-all.css" rel="stylesheet" />
	<link href="css/Search.css" rel="stylesheet" />
	<link href="//fonts.googleapis.com/css?family=Inconsolata:400,700" rel="stylesheet" />
	<link href="//fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800" rel="stylesheet" />
	<style>
		#signinbtn, #signoutbtn, #informer, #showbtn {
			display: none;
		}
		.addtocart {
			margin-top: 10px;
			background: none;
			border: 0.5px solid lightgray;
			border-radius: 0;
			color: gray;
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
			background: url(images/logo100px.png) center no-repeat #ffffff;
		}

		.after-click {
			position: fixed;
			left: 0px;
			right: 0px;
			z-index: 9999;
			width: 100%;
			height: 100%;
			opacity: 0.9;
			background: url(images/logo100px.png) center no-repeat #ffffff;
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
						<a class="navbar-brand click-on" href="Home" style="text-transform:none;margin-bottom:15px;">
							<img src="images/Logo_.png" style="width:60%;"/>
						</a>
					</h1>
				</div>

				<div class="col-lg-3 text-center mt-lg-4" style="margin-bottom:15px;">
					<a id="signinbtn" class="click-on" href="User_Zone" style="color:dimgray;padding:13px 15px;border:0.5px solid lightgray;text-decoration:none;" title="Sign In">
						<i class="fa fa-user"></i></a>
					<a id="signoutbtn" class="click-on" href="SignOut" style="color:dimgray;padding:13px 15px;border:0.5px solid lightgray;text-decoration:none;" title="Sign Out">
						<i class="fa fa-power-off"></i></a>
					<a href="Cart" class="click-on" style="color:dimgray;padding:13px;border:0.5px solid lightgray;" title="Cart"><i class="fas fa-cart-arrow-down"></i> <asp:Label runat="server" ID="addeditems" Text="0"></asp:Label></a>
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
						<li class="nav-item">
							<a class="nav-link ml-lg-0 click-on" href="Home">Home
								<span class="sr-only">(current)</span>
							</a>
						</li>
						<li class="nav-item active">
							<a class="nav-link click-on" href="About">About</a>
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
													<a href="Shop?for=Engg. Quantums" class="click-on">Engg. Quantums</a>
												</li>
												<li class="">
													<a href="Shop?for=GATE Books" class="click-on"> GATE Books</a>
												</li>
												<li>
													<a href="Shop?for=SSC Books" class="click-on">SSC Books</a>
												</li>
												<li class="mt-3">
													<h5>View more pages</h5>
												</li>
												<li class="mt-2">
													<a href="About" class="click-on">About</a>
												</li>
												<li>
													<a href="Track_Your_Order" class="click-on">Track Order</a>
												</li>
											</ul>
										</div>
										<div class="col-md-4 media-list span4 text-left">
											<h5 class="tittle-w3layouts-sub"> SSC Books </h5>
											<div class="media-mini mt-3">
												<a href="Shop?for=SSC Books" class="click-on">
													<img src="images/ssc_Kiran.jpg" class="img-fluid" alt="" style="height:200px;width:150px;"/>
												</a>
											</div>
										</div>
										<div class="col-md-4 media-list span4 text-left">
											<h5 class="tittle-w3layouts-sub">GATE Books </h5>
											<div class="media-mini mt-3">
												<a href="Shop?for=GATE Books" class="click-on">
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
													<a href="Shop?for=Novels" class="click-on">Novels</a>
												</li>
												<li class="">
													<a href="Shop?for=Competatives" class="click-on">Competatives</a>
												</li>
												<li>
													<a href="Shop?for=Biography" class="click-on">Biography</a>
												</li>
												<li>
													<a href="Shop?for=School Books (6th to 10th)" class="click-on">School Books (6th-10th)</a>
												</li>
												<li>
													<a href="Shop?for=School Books (11th-12th)" class="click-on">School Books (11th-12th)</a>
												</li>
											</ul>
										</div>
										<div class="col-md-4 media-list span4 text-left">
											<h5 class="tittle-w3layouts-sub"> Text Books </h5>
											<ul>
												<li class="media-mini mt-3">
													<a href="Shop?for=Engg. Books" class="click-on">Engg. Books</a>
												</li>
												<li>
													<a href="Shop?for=Law Books" class="click-on">Law Books</a>
												</li>
												<li>
													<a href="Shop?for=Medical Books" class="click-on">Medical Books</a>
												</li>
												<li>
													<a href="Shop?for=Diploma" class="click-on">Diploma</a>
												</li>
												<li>
													<a href="Shop?for=NCERT" class="click-on">NCERT</a>
												</li>
											</ul>

										</div>
										<div class="col-md-4 media-list span4 text-left">

											<h5 class="tittle-w3layouts-sub-nav">Stationery</h5>
											<ul>
												<li class="media-mini mt-3">
													<a href="Shop?for=Note Books" class="click-on">Note Books</a>
												</li>
												<li>
													<a href="Shop?for=Diary" class="click-on">Diary</a>
												</li>
												<li>
													<a href="Shop?for=Calculator" class="click-on">Calculator</a>
												</li>
												<li>
													<a href="Shop?for=Geometry Box" class="click-on">Geometry Box</a>
												</li>
												<li>
													<a href="Shop?for=Chart Papers" class="click-on">Chart Papers</a>
												</li>
											</ul>
										</div>
									</div>
									<hr />
								</li>
							</ul>
						</li>
						<li class="nav-item">
							<a class="nav-link click-on" href="Contact">Contact</a>
						</li>
					</ul>

				</div>
			</nav>
		</header>
		<!-- //header -->
		<!-- banner -->
		<div class="banner_inner">
			<div class="services-breadcrumb">
				<div class="inner_breadcrumb">
					<ul class="short">
						<li>
							<a href="Home">Home</a>
							<i>|</i>
						</li>
						<li>About Us</li>
					</ul>
				</div>
			</div>
		</div>
		<!--//banner -->
	</div>
	<!--//banner-sec-->
	<!-- top Products -->
	<section class="banner-bottom-wthreelayouts py-lg-5 py-3">
		<div class="container-fluid">

			<div class="inner-sec-shop px-lg-4 px-3">
				<div class="about-content py-lg-5 py-3">
					<div class="row">

						<div class="col-lg-6 p-0">
							<img src="images/About_Us.jpg" alt="About Us" class="img-fluid" />
						</div>
						<div class="col-lg-6 about-info">
							<h3 class="tittle-w3layouts text-left mb-lg-5 mb-3">About Us</h3>
							<p class="my-xl-4 my-lg-3 my-md-4 my-3 text-justify">
								BooksMahal.com is India's Largest Online Book Store. It carries
								the prestige of over 2 years of retail experience. The company 
								is Headquartered in New Delhi and has it's offices in Meerut.
								We are also providing a old books at huge discount and try to increase
								best customer experience.
							</p>

							<a href="shop.html" class="btn btn-sm animated-button gibson-three mt-4">Shop Now</a>

						</div>
					</div>
				</div>
				<h3 class="tittle-w3layouts text-center my-lg-4 my-4">Our Team</h3>
				<div class="partners-info">
					<div class="row mt-lg-5 mt-3">
						<div class="col-sm-3 team-main-gd">
							<div class="team-grid text-center">
								<div class="team-img">
									<img class="img-fluid rounded" src="images/usericon.png" alt="" />
								</div>
								<div class="team-info">
									<h4>Manish Prashad</h4>
									<span>Description </span>
									<ul class="d-flex justify-content-center py-3 social-icons">
										<li>
											<a href="http://www.facebook.com/manishpsd" target="_blank">
												<i class="fab fa-facebook-f"></i>
											</a>
										</li>
										<li class="mx-3">
											<a href="http://twitter.com/manish-prasad" target="_blank">
												<i class="fab fa-twitter"></i>
											</a>
										</li>
										<li>
											<a href="http://www.linkedin.com/in/manish-prasad-281835143" target="_blank">
												<i class="fab fa-linkedin-in"></i>
											</a>
										</li>
									</ul>
								</div>
							</div>
						</div>
					 <div class="col-sm-3 team-main-gd">
							<div class="team-grid text-center">
								<div class="team-img">
									<img class="img-fluid rounded" src="images/usericon.png" alt="" />
								</div>
								<div class="team-info">
									<h4>Manish Agrahari</h4>
									<span>Description </span>
									<ul class="d-flex justify-content-center py-3 social-icons">
										<li>
											<a href="http://www.facebook.com/manishpsd" target="_blank">
												<i class="fab fa-facebook-f"></i>
											</a>
										</li>
										<li class="mx-3">
											<a href="http://twitter.com/manish-prasad" target="_blank">
												<i class="fab fa-twitter"></i>
											</a>
										</li>
										<li>
											<a href="http://www.linkedin.com/in/manish-prasad-281835143" target="_blank">
												<i class="fab fa-linkedin-in"></i>
											</a>
										</li>
									</ul>
								</div>
							</div>
						</div>
						<div class="col-sm-3 team-main-gd">
							<div class="team-grid text-center">
								<div class="team-img">
									<img class="img-fluid rounded" src="images/usericon.png" alt="" />
								</div>
								<div class="team-info">
									<h4>Vinay Verma</h4>
									<span>Description </span>
									<ul class="d-flex justify-content-center py-3 social-icons">
										<li>
											<a href="http://www.facebook.com/manishpsd" target="_blank">
												<i class="fab fa-facebook-f"></i>
											</a>
										</li>
										<li class="mx-3">
											<a href="http://twitter.com/manish-prasad" target="_blank">
												<i class="fab fa-twitter"></i>
											</a>
										</li>
										<li>
											<a href="http://www.linkedin.com/in/manish-prasad-281835143" target="_blank">
												<i class="fab fa-linkedin-in"></i>
											</a>
										</li>
									</ul>
								</div>
							</div>
						</div>
						<div class="col-sm-3 team-main-gd">
							<div class="team-grid text-center">
								<div class="team-img">
									<img class="img-fluid rounded" src="images/usericon.png" alt="" />
								</div>
								<div class="team-info">
									<h4>Prashant Kannaujia</h4>
									<span>Description </span>
									<ul class="d-flex justify-content-center py-3 social-icons">
										<li>
											<a href="https://www.facebook.com/prashant.kannoujiya" target="_blank">
												<i class="fab fa-facebook-f"></i>
											</a>
										</li>
										<li class="mx-3">
											<a href="#" target="_blank">
												<i class="fab fa-twitter"></i>
											</a>
										</li>
										<li>
											<a href="https://www.linkedin.com/in/prashant-kannaujiya-79a458153/" target="_blank">
												<i class="fab fa-linkedin-in"></i>
											</a>
										</li>
									</ul>
								</div>
							</div>
						</div>
						<div class="col-sm-3 team-main-gd">
							<div class="team-grid text-center">
								<div class="team-img">
									<img class="img-fluid rounded" src="images/usericon.png" alt="" />
								</div>
								<div class="team-info">
									<h4>Shivam Vishwakarma</h4>
									<span>Description </span>
									<ul class="d-flex justify-content-center py-3 social-icons">
										<li>
											<a href="http://www.facebook.com/samsberk" target="_blank">
												<i class="fab fa-facebook-f"></i>
											</a>
										</li>
										<li class="mx-3">
											<a href="http://twitter.com/samsberk" target="_blank">
												<i class="fab fa-twitter"></i>
											</a>
										</li>
										<li>
											<a href="http://www.linkedin.com/in/samsberk" target="_blank">
												<i class="fab fa-linkedin-in"></i>
											</a>
										</li>
									</ul>
								</div>
							</div>
						</div>
						<div class="col-sm-3 team-main-gd">
							<div class="team-grid text-center">
								<div class="team-img">
									<img class="img-fluid rounded" src="images/usericon.png" alt="" />
								</div>
								<div class="team-info">
									<h4>Vishal Maurya</h4>
									<span>Description </span>
									<ul class="d-flex justify-content-center py-3 social-icons">
										<li>
											<a href="https://www.facebook.com/v1s.m4u" target="_blank">
												<i class="fab fa-facebook-f"></i>
											</a>
										</li>
										<li class="mx-3">
											<a href="https://twitter.com/v1s_m4u" target="_blank">
												<i class="fab fa-twitter"></i>
											</a>
										</li>
										<li>
											<a href="https://www.linkedin.com/in/vishal-maurya-085527b1" target="_blank">
												<i class="fab fa-linkedin-in"></i>
											</a>
										</li>
									</ul>
								</div>
							</div>
						</div>
					</div>
				</div>
				<!-- /grids -->
				<div class="bottom-sub-grid-content py-lg-5 py-3">
					<div class="row">
						<div class="col-lg-4 bottom-sub-grid text-center">
							<div class="bt-icon">

								<span class="far fa-hand-paper"></span>
							</div>

							<h4 class="sub-tittle-w3layouts my-lg-4 my-3">Top Products</h4>
							<p>
								We are totally work towards product Satisfaction & boast up customer experience.
							</p>
							<p>
								<a href="Shop" class="btn btn-sm animated-button gibson-three mt-4">Shop Now</a>
							</p>
						</div>
						<!-- /.col-lg-4 -->
						<div class="col-lg-4 bottom-sub-grid text-center">
							<div class="bt-icon">
								<span class="fas fa-rocket"></span>
							</div>

							<h4 class="sub-tittle-w3layouts my-lg-4 my-3">Fast Shipping</h4>
							<p>
								Booksmahal provides the fast delivery facility to door. We are provides books within a day.
							</p>
							<p>
								<a href="Shop" class="btn btn-sm animated-button gibson-three mt-4">Shop Now</a>
							</p>
						</div>
						<!-- /.col-lg-4 -->
						<div class="col-lg-4 bottom-sub-grid text-center">
							<div class="bt-icon">
								<span class="fa fa-user-secret"></span>
							</div>

							<h4 class="sub-tittle-w3layouts my-lg-4 my-3">24*7 Support</h4>
							<p>
								Got a question? Look no further Browse our Contact us page and submit your query there.
							</p>
							<p>
								<a href="Shop" class="btn btn-sm animated-button gibson-three mt-4">Shop Now</a>
							</p>
						</div>
						<!-- /.col-lg-4 -->
					</div>
				</div>
				<!-- //grids -->
				

				<!-- /testimonials -->
				<div class="testimonials py-lg-4 py-3 mt-4">
					<div class="testimonials-inner py-lg-4 py-3">
						<h3 class="tittle-w3layouts text-center my-lg-4 my-4">Tesimonials</h3>
						<div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
							<div class="carousel-inner" role="listbox">
								<div class="carousel-item active">
									<div class="testimonials_grid text-center">
										<h3>Deepshikha
											<span>Customer</span>
										</h3>
										<label>India</label>
										<p>
											Excellent experience through this book shopping site. Early delivery. Its great opportunity for our student friend circle.
										</p>
									</div>
								</div>
								<div class="carousel-item">
									<div class="testimonials_grid text-center">
										<h3>Anupam
											<span>Customer</span>
										</h3>
										<label>India</label>
										<p>
											This website is helpful for those students, who is far from the book store.
											Great features and offers are available all times.
										</p>
									</div>
								</div>
								<div class="carousel-item">
									<div class="testimonials_grid text-center">
										<h3>Akash
											<span>Customer</span>
										</h3>
										<label>India</label>
										<p>It is very quick responsive site. I like the fast delivery of the site ever. Awesome service,very good offer available always.</p>
									</div>
								</div>
								<div class="carousel-item">
									<div class="testimonials_grid text-center">
										<h3>Manish
											<span>Customer</span>
										</h3>
										<label>India</label>
										<p>Good Experience with booksmahal One of the best online store with variety of books and it cost hardly 50% off on second hand books.</p>
									</div>
								</div>
								<a class="carousel-control-prev test" href="#carouselExampleControls" role="button" data-slide="prev">
									<span class="fas fa-long-arrow-alt-left"></span>
									<span class="sr-only">Previous</span>
								</a>
								<a class="carousel-control-next test" href="#carouselExampleControls" role="button" data-slide="next">
									<span class="fas fa-long-arrow-alt-right" aria-hidden="true"></span>
									<span class="sr-only">Next</span>

								</a>
							</div>
						</div>
					</div>
				</div>
				<!-- //testimonials -->

				<!-- /clients-sec -->
				<div class="testimonials p-lg-5 p-3 mt-4">
					<div class="row last-section">
						<div class="col-lg-3 footer-top-w3layouts-grid-sec">
							<div class="mail-grid-icon text-center">
								<i class="fas fa-gift"></i>
							</div>
							<div class="mail-grid-text-info">
								<h3>Genuine Product</h3>
								<p>Booksmahal provide the genuine Product at Affordable price.</p>
							</div>
						</div>
						<div class="col-lg-3 footer-top-w3layouts-grid-sec">
							<div class="mail-grid-icon text-center">
								<i class="fas fa-shield-alt"></i>
							</div>
							<div class="mail-grid-text-info">
								<h3>Secure Products</h3>
								<p>Books are in good condition either old or new.</p>
							</div>
						</div>
						<div class="col-lg-3 footer-top-w3layouts-grid-sec">
							<div class="mail-grid-icon text-center">
								<i class="fas fa-dollar-sign"></i>
							</div>
							<div class="mail-grid-text-info">
								<h3>Pay on Delivery</h3>
								<p>Feel free payment process easy Pay on COD and UPI also.</p>
							</div>
						</div>
						<div class="col-lg-3 footer-top-w3layouts-grid-sec">
							<div class="mail-grid-icon text-center">
								<i class="fas fa-truck"></i>
							</div>
							<div class="mail-grid-text-info">
								<h3>Easy Delivery</h3>
								<p>Track your order status And Deliver ASAP.</p>
							</div>
						</div>
					</div>
				</div>
				<!-- //clients-sec -->

			</div>
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
								<a href="mailto:bksmhl-info@booksmahal.in">Send an E-Mail</a>
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
		<asp:Label runat="server" ID="informer"></asp:Label>
		<asp:Label runat="server" ID="showbtn"></asp:Label>
		<div class="alert-box">
			<div class="alert-dialog text-center">
				<h4><i class="fa fa-bullhorn"></i> ALERT</h4><hr />
				<asp:Label runat="server" ID="alerttext" style="font-size:17px;"></asp:Label><hr />
				<button type="button" class="btn btn-default close-alert-box">Done</button>
			</div>
		</div>
	<!--jQuery-->
	<script src="js/jquery-2.2.3.min.js"></script>
		<script src="js/Search.js"></script>
	<script type="text/javascript">
		$("#nlbtn").attr("disabled", true);
		$("#nltxt").focus(function () {
			$("#nlbtn").attr("disabled", false);
		});
		$("#nltxt").blur(function () {
			var nltxt = document.getElementById("nltxt");
			if (nltxt.value == "")
				$("#nlbtn").attr("disabled", true);
		});

	</script>
	<!-- newsletter modal -->
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
		if ($("#showbtn").text() == "signinbtn") {
			$("#signinbtn").show();
		}
		else if ($("#showbtn").text() == "signoutbtn") {
			$("#signoutbtn").show();
		}

		if ($("#informer").text() == "AlreadyRegistered") {
			$(".alert-box").show();
		}
		else if ($("#informer").text() == "QueryNotSubmitted") {
			$(".alert-box").show();
		}
		else if ($("#informer").text() == "QueryNotSubmitted") {
			$(".alert-box").show();
		}
		else if ($("#informer").text() == "MustEnterYourEmail") {
			$(".alert-box").show();
		}

	</script>
	<!--search jQuery-->
	<script src="js/modernizr-2.6.2.min.js"></script>
	<script src="js/classie-search.js"></script>
	<script src="js/demo1-search.js"></script>
	<!--//search jQuery-->
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
	<%--<!-- Count-down -->
	<script src="js/simplyCountdown.js"></script>
	<link href="css/simplyCountdown.css" rel='stylesheet' type='text/css' />
	<script>
		var d = new Date();
		simplyCountdown('simply-countdown-custom', {
			year: d.getFullYear(),
			month: d.getMonth() + 2,
			day: 25
		});
	</script>
	<!--// Count-down -->--%>
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
