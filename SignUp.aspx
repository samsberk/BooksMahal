<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>BooksMahal | User Zone | Sign In | Sign Up | Forgot Password </title>
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
	<style type="text/css">
		#signinbox, #formbox, #signupbox, #otpbox, #forgotbox, #forgototpbox, #resetpassbox{
			display:none;
		}
		#informer, #show, #showbtn, #signoutbtn{
			display:none;
		}
		label{
			font-size:14px;
		}
		.box-center {
			width: 100%;
			min-height: 260px;
			background: rgba(255,255,255,0.6);
			padding: 20px;
		}
		.box-center h4{
			text-align:center;
		}
		.alert-box{
			position:fixed;
			top:0;
			left:0;
			height:100vh;
			width:100%;
			background:rgba(0,0,0,0.8);
			display:none;
			z-index:999;
		}
		.alert-box .alert-dialog{
			position:relative;
			top:50vh;
			left:50%;
			min-height:200px;
			width:500px;
			padding:15px;
			background:ghostwhite;
			box-shadow:1px 1px 25px black;
			transform:translate(-50%,-50%);
		}
		@media(max-width:768px) {
			.alert-box .alert-dialog{
				width:90%;
			}
		}
		#loader {
	position: fixed;
	left: 0px;
	right: 0px;
	z-index: 99999;
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
		<!-- //header -->
		<!-- banner -->
	</div>
	<div style="min-height:80vh;padding:50px 0px;background:url('images/bm1.jpg') center no-repeat;">
		<div class="col-sm-4" style="margin-left:50vw;transform:translateX(-50%);">
			<div id="signupbox" class="box-center text-center">
				<h4>Sign Up with</h4><hr />
				<asp:TextBox runat="server" ID="signupidtxt" TextMode="Email" MaxLength="50" CssClass="form-control" placeholder="Enter Email ID" style="text-transform:lowercase;margin-bottom:10px;"></asp:TextBox>
				<asp:TextBox runat="server" ID="signuppasstxt" TextMode="Password" MaxLength="20" CssClass="form-control" placeholder="Choose Password" style="margin-bottom:10px;"></asp:TextBox>
				<asp:TextBox runat="server" ID="signuprepasstxt" TextMode="Password" MaxLength="20" CssClass="form-control" placeholder="Re-enter Password" style="margin-bottom:10px;"></asp:TextBox>
				<asp:Button runat="server" ID="supbtn" CssClass="btn btn-success click-on" Text="Sign Up" style="margin-top:10px;" OnClick="supbtn_Click"/><br /><hr />
				<a class="click-on" href="User_Zone?f=Sign_In" style="text-decoration:none;"><i class="fa fa-arrow-left"></i> Already have an Account</a><br />
			</div>
			<div id="signinbox" class="box-center text-center">
				<h4>Sign-In Here</h4><hr />
				<asp:TextBox runat="server" ID="loginidtxt" TextMode="Email" MaxLength="50" CssClass="form-control" placeholder="Enter Email ID" style="text-transform:lowercase;margin-bottom:10px;"></asp:TextBox>
				<asp:TextBox runat="server" ID="loginpasstxt" TextMode="Password" MaxLength="20" CssClass="form-control" placeholder="Enter Password" style="margin-bottom:10px;"></asp:TextBox>
				<asp:CheckBox runat="server" ID="chkbxrmbrme" Text="&ensp;Remember Me" style="user-select:none;"/><br />
				<asp:Button runat="server" ID="loginbtn" CssClass="btn btn-success click-on" Text="Sign In" style="margin-top:10px;" OnClick="loginbtn_Click"/><br />
				<hr /><a class="click-on" href="User_Zone?f=Forgot_Password" style="text-decoration:none;">Forgot Password <i class="fa fa-key"></i></a>
				<hr /><a class="click-on" href="User_Zone?f=Sign_Up" style="text-decoration:none;">Don't Have Any Account <i class="fa fa-arrow-right"></i></a><br />
			</div>
			<div id="formbox" class="box-center">
				<h4>Complete Your Profile</h4><hr />
				<label for="mobiletxt">Mobile Number (10 Digit) :</label>
				<asp:TextBox runat="server" ID="mobiletxt" TextMode="Number" CssClass="form-control" placeholder="10 Digit Contact Number" style="margin-bottom:10px;"></asp:TextBox>
				<label for="nametxt">Full Name :</label>
				<asp:TextBox runat="server" ID="nametxt" MaxLength="50" CssClass="form-control" placeholder="Full Name" style="text-transform:uppercase;margin-bottom:10px;"></asp:TextBox>
				<label for="addresstxt">Complete Address (Saperated with Comma ',') :</label>
				<asp:TextBox runat="server" ID="addresstxt" MaxLength="150" CssClass="form-control" placeholder="Complete Address" style="text-transform:uppercase;margin-bottom:10px;"></asp:TextBox>
				<label for="pintxt">PIN Code :</label>
				<asp:TextBox runat="server" ID="pintxt" CssClass="form-control" TextMode="Number" placeholder="PIN Code" style="margin-bottom:10px;"></asp:TextBox>
				<br /><center><asp:Button runat="server" ID="formbtn" CssClass="btn btn-success click-on" Text="Submit" OnClick="formbtn_Click" /></center>
			</div>
			<div id="otpbox" class="box-center">
				<h4>Enter OTP</h4>
				<span class="form-text text-muted text-center" style="margin-bottom:10px;font-size:12px;">If you <b>LEAVE</b> this page, OTP session will be discarded.</span><hr />
				<asp:TextBox runat="server" ID="otptxt" TextMode="Number" CssClass="form-control" placeholder="Enter OTP" style="margin-bottom:7px;"></asp:TextBox>
				<span class="form-text text-muted" style="margin-bottom:10px;font-size:12px;">Check your <b>INBOX</b>. May be, It is present in <b>SPAM</b> folder.</span>
				<asp:Button runat="server" ID="resendotpbtn" CssClass="btn btn-warning fa-pull-left click-on" Text="Resend" OnClick="resendotpbtn_Click"/>
				<asp:Button runat="server" ID="subotpbtn" CssClass="btn btn-success fa-pull-right click-on" Text="Submit" OnClick="subotpbtn_Click"/>
			</div>
			<div id="forgotbox" class="box-center text-center">
				<h4>Recover Password</h4><hr />
				<asp:TextBox runat="server" ID="forgotidtxt" TextMode="Email" MaxLength="50" CssClass="form-control" placeholder="Enter Email ID" style="text-transform:lowercase;margin-bottom:10px;"></asp:TextBox>
				<span class="form-text text-muted" style="margin-bottom:10px;font-size:12px;">An OTP will send to given Email ID.</span>
				<asp:Button runat="server" ID="forgotbtn" CssClass="btn btn-success click-on" Text="Verify Email ID" style="margin-top:10px;" OnClick="forgotbtn_Click"/>
				<hr />
				<a class="click-on" href="User_Zone?f=Sign_In" style="text-decoration:none;"><i class="fa fa-arrow-left"></i> Go for Sign In</a><hr />
				<a class="click-on" href="User_Zone?f=Sign_Up" style="text-decoration:none;"><i class="fa fa-arrow-left"></i> Go for Sign Up</a><br />
			</div>
			<div id="forgototpbox" class="box-center">
				<h4>Enter OTP</h4>
				<span class="form-text text-muted text-center" style="margin-bottom:10px;font-size:12px;">If you <b>LEAVE</b> this page,<br /> OTP session will be discarded.</span><hr />
				<asp:TextBox runat="server" ID="forgototptxt" TextMode="Number" CssClass="form-control" placeholder="Enter OTP" style="margin-bottom:7px;"></asp:TextBox>
				<span class="form-text text-muted" style="margin-bottom:10px;font-size:12px;">Check your <b>INBOX</b>. May be, It is present in <b>SPAM</b> folder.</span>
				<asp:Button runat="server" ID="forgototpresendbtn" CssClass="btn btn-warning fa-pull-left click-on" Text="Resend" OnClick="forgototpresendbtn_Click"/>
				<asp:Button runat="server" ID="forgototpbtn" CssClass="btn btn-success fa-pull-right click-on" Text="Submit" OnClick="forgototpbtn_Click"/>
			</div>
			<div id="resetpassbox" class="box-center text-center">
				<h4>Enter New Password</h4>
				<span class="form-text text-muted text-center" style="margin-bottom:10px;font-size:12px;">This link will available for only <b>20 MINUTES</b>.</span><hr />
				<asp:TextBox runat="server" ID="resetpasstxt" TextMode="Password" MaxLength="20" CssClass="form-control" placeholder="Choose Password" style="margin-bottom:10px;"></asp:TextBox>
				<asp:TextBox runat="server" ID="resetrepasstxt" TextMode="Password" MaxLength="20" CssClass="form-control" placeholder="Re-enter Password" style="margin-bottom:10px;"></asp:TextBox>
				<asp:Button runat="server" ID="resetpassbtn" CssClass="btn btn-success click-on" Text="Reset Password" style="margin-top:10px;" OnClick="resetpassbtn_Click"/><br />
			</div>
		</div>
	</div>
	<!-- about -->
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
	<!-- Modal -->
	<!-- Modal -->
	<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-hidden="true">
		<div class="modal-dialog" role="document">
			<div class="modal-content">
				<div class="modal-header">

					<button type="button" class="close" data-dismiss="modal" aria-label="Close">
						<span aria-hidden="true">&times;</span>
					</button>
				</div>
				<div class="modal-body text-center p-5 mx-auto mw-100">
					<h6>Join our newsletter and get</h6>
					<h3>50% Off for your first Pair of Eye wear</h3>
					<div class="login newsletter">
						<%--<form action="#" method="post">
							<div class="form-group">
								<label class="mb-2">Email address</label>
								<input type="email" class="form-control" id="exampleInputEmail2" aria-describedby="emailHelp" placeholder="" />
							</div>
							<button type="submit" class="btn btn-primary submit mb-4">Get 50% Off</button>
						</form>--%>
						<p class="text-center">
							<a href="#">No thanks I want to pay full Price</a>
						</p>
					</div>
				</div>

			</div>
		</div>
	</div>
		<asp:Label runat="server" ID="informer"></asp:Label>
		<asp:Label runat="server" ID="show"></asp:Label>
		<asp:Label runat="server" ID="showbtn"></asp:Label>
		<div class="alert-box">
			<div class="alert-dialog text-center">
				<h4><i class="fa fa-bullhorn"></i> ALERT</h4><hr />
				<asp:Label runat="server" ID="alerttext" style="font-size:17px;"></asp:Label><hr />
				<button type="button" class="btn btn-default close-alert-box">Done</button>
			</div>
		</div>
	</form>
	

	<!--search jQuery-->
	<script src="js/modernizr-2.6.2.min.js"></script>
	<script src="js/classie-search.js"></script>
	<script src="js/Search.js"></script>
	<script src="js/demo1-search.js"></script>
	<!--//search jQuery-->
	<script type="text/javascript">
		$(".click-on").click(function () {
			$(".after-click").fadeIn();
		});
		var loader = document.getElementById("loader");
		window.addEventListener("load", function () {
			$("#loader").fadeOut();
		});
		var chkbxrmbrme = document.getElementById("chkbxrmbrme");
		chkbxrmbrme.checked = true;
		

		if ($("#show").text() == "0") {
			$("#signupbox").show();
		}
		else if ($("#show").text() == "1") {
			$("#signinbox").show();
		}
		else if ($("#show").text() == "2") {
			$("#otpbox").show();
		}
		else if ($("#show").text() == "3") {
			$("#formbox").show();
		}
		else if ($("#show").text() == "4") {
			$("#forgotbox").show();
		}
		else if ($("#show").text() == "5") {
			$("#forgototpbox").show();
		}
		else if ($("#show").text() == "6") {
			$("#resetpassbox").show();
		}

		if ($("#informer").text() == "AlreadyRegistered") {
			$(".alert-box").show();
		}
		else if ($("#informer").text() == "QueryNotSubmitted") {
			$(".alert-box").show();
		}
		else if ($("#informer").text() == "InvalidEmailid") {
			$(".alert-box").show();
		}
		else if ($("#informer").text() == "InvalidOTP") {
			$(".alert-box").show();
		}
		else if ($("#informer").text() == "InvalidAccess") {
			$(".alert-box").show();
		}
		else if ($("#informer").text() == "InvalidUseridorPassword") {
			$(".alert-box").show();
		}
		else if ($("#informer").text() == "VerifiedButNotFilled") {
			$(".alert-box").show();
		}
		else if ($("#informer").text() == "PasswordChanged") {
			$(".alert-box").show();
		}
		else if ($("#informer").text() == "SignUpFirst") {
			$(".alert-box").show();
		}

		if ($("#informer").text() == "AlreadyRegistered") {
			$(".alert-box").show();
		}
		else if ($("#informer").text() == "SuccessfullForNewsletter") {
			$(".alert-box").show();
		}
		else if ($("#informer").text() == "QueryNotSubmitted") {
			$(".alert-box").show();
		}
		else if ($("#informer").text() == "MustEnterYourEmail") {
			$(".alert-box").show();
		}
		else if ($("#informer").text() == "loggedout") {
			$(".alert-box").show();
		}
	</script>
	<script type="text/javascript">
		$(".close-alert-box").click(function () {
			$(".alert-box").fadeOut();
		});


		$("#signuppasstxt").attr("disabled", true);
		$("#signuprepasstxt").attr("disabled", true);

		$("#nametxt").attr("disabled", true);
		$("#addresstxt").attr("disabled", true);
		$("#pintxt").attr("disabled", true);

		$("#resetrepasstxt").attr("disabled", true);
		$("#resetpassbtn").attr("disabled", true);
		$("#resetpassbtn").val("Enter Details to Enable");


		$("#supbtn").attr("disabled", true);
		$("#supbtn").val("Enter Details to Enable");
		

		$("#loginbtn").attr("disabled", true);
		$("#loginbtn").val("Enter Details to Enable");

		$("#formbtn").attr("disabled", true);
		$("#formbtn").val("Fill form to enable");

		var resetpasstxt = document.getElementById("resetpasstxt");
		var resetrepasstxt = document.getElementById("resetrepasstxt");

		$("#resetpasstxt").focus(function () {
			$("#resetrepasstxt").attr("disabled", false);
		});
		$("#resetrepasstxt").focus(function () {
			if (resetpasstxt.value == "") {
				$("#alerttext").text("Please enter Password first.");
				$("#resetrepasstxt").attr("disabled", true);
				$(".alert-box").fadeIn();
			}
			else {
				$("#resetpassbtn").attr("disabled", false);
				$("#resetpassbtn").val("Reset Password");
			}
		});
		$("#resetpassbtn").click(function () {
			if (resetpasstxt.value != resetrepasstxt.value) {
				$("#resetpassbtn").attr("disabled", true);
				$("#resetpassbtn").val("Enter Details to Enable");
				$("#alerttext").text("Password not match.");
				resetrepasstxt.value = "";
				$(".alert-box").fadeIn();
			}
		});


		var signupidtxt = document.getElementById("signupidtxt");
		var signuppasstxt = document.getElementById("signuppasstxt");
		var signuprepasstxt = document.getElementById("signuprepasstxt");
		$("#signupidtxt").focus(function () {
			$("#signuppasstxt").attr("disabled", false);
		});
		$("#signuppasstxt").focus(function () {
			if (signupidtxt.value == "") {
				$("#alerttext").text("Please enter Email ID first.");
				$("#signuppasstxt").attr("disabled", true);
				$(".alert-box").fadeIn();
			}
			else
				$("#signuprepasstxt").attr("disabled", false);
		});
		$("#signuprepasstxt").focus(function () {
			if (signuppasstxt.value == "") {
				$("#alerttext").text("Please enter Password first.");
				$("#signuprepasstxt").attr("disabled", true);
				$(".alert-box").fadeIn();
			}
			else {
				$("#supbtn").attr("disabled", false);
				$("#supbtn").val("Sign Up");
			}
		});
		$("#supbtn").click(function () {
			if (signuppasstxt.value != signuprepasstxt.value) {
				$("#supbtn").attr("disabled", true);
				$("#supbtn").val("Enter Details to Enable");
				$("#alerttext").text("Password not match.");
				signuprepasstxt.value = "";
				$(".alert-box").fadeIn();
			}
		});

		var loginidtxt = document.getElementById("loginidtxt");
		var loginpasstxt = document.getElementById("loginpasstxt");
		$("#loginidtxt").focus(function () {
			$("#loginpasstxt").attr("disabled", false);
		});
		$("#loginpasstxt").focus(function () {
			if (loginidtxt.value == "") {
				$("#alerttext").text("Please enter Email ID first.");
				$("#loginpasstxt").attr("disabled", true);
				$(".alert-box").fadeIn();
			}
			else {
				$("#loginbtn").attr("disabled", false);
				$("#loginbtn").val("Sign In");
			}
		});

		var mobile = document.getElementById("mobiletxt");
		var nametxt = document.getElementById("nametxt");
		var addresstxt = document.getElementById("addresstxt");
		var pintxt = document.getElementById("pintxt");
		$("#mobiletxt").focus(function () {
			$("#nametxt").attr("disabled", false);
		});
		$("#mobiletxt").blur(function () {
			if (mobile.value == "") {

			}
			else if (mobile.value < 999999999 || mobile.value > 9999999999) {
				mobile.value = "";
				$("#nametxt").attr("disabled", true);
				$("#alerttext").text("Please enter only 10 Digit of Mobile Number.");
				$(".alert-box").fadeIn();
			}
		});
		$("#nametxt").focus(function () {
			if (mobile.value == "") {
				$("#alerttext").text("Please enter Mobile Number first.");
				$("#nametxt").attr("disabled", true);
				$(".alert-box").fadeIn();
			}
			else
				$("#addresstxt").attr("disabled", false);
		});
		$("#addresstxt").focus(function () {
			if (nametxt.value == "") {
				$("#alerttext").text("Please enter your Name first.");
				$("#addresstxt").attr("disabled", true);
				$(".alert-box").fadeIn();
			}
			else
				$("#pintxt").attr("disabled", false);
		});
		$("#pintxt").focus(function () {
			if (addresstxt.value == "") {
				$("#alerttext").text("Please enter Address first.");
				$("#pintxt").attr("disabled", true);
				$(".alert-box").fadeIn();
			}
			else {
				$("#formbtn").attr("disabled", false);
				$("#formbtn").val("Submit");
			}
		});
	</script>
	<!-- cart-js -->
	<script src="js/minicart.js"></script>
	<script>
		googles.render();

		googles.cart.on('googles_checkout', function (evt) {
			var items, len, i;

			if (this.subtotal() > 0) {
				items = this.items();

				for (i = 0, len = items.length; i < len; i++) { }
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
	<!-- Count-down -->
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
	<!--// Count-down -->
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
</body>
</html>
