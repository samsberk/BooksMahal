<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsletterMessage.aspx.cs" Inherits="Admin_Block_NewsletterMessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BooksMahal | Newsletter Email Manager</title>
	<meta name="theme-color" content="#ffffff" />
	<meta name="msApplication-navbutton-color" content="#ffffff" />
	<meta name="apple-mobile-web-app-status-bar-style" content="#ffffff" />
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link id="Link1" runat="server" rel="Shortcut Icon" href="Images/fi.png" type="image/x-icon"/>
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
	<link href="../css/ACSS.css" rel="stylesheet" />
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
	<script src="../js/AJS.js"></script>
	<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
	<link href="https://fonts.googleapis.com/css?family=Inconsolata|Poppins|Karma|Muli|Yantramanav|Kalam|Pacifico|Quicksand|Sedgwick+Ave" rel="stylesheet"/>
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
	<style type="text/css">
		.txt {
			margin-bottom: 10px;
			border-radius:0;
			resize:none;
		}
		th, td{
			padding:3px 5px;
			font-family:muli;
			font-size:14px;
			text-align:center;
			border:0.5px solid lightgray;
		}
		tr:hover{
			background:lightgray;
			color:black;
			font-weight:bold;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
		<!--------------------------------------------------------------- Loader ----------------------------------------------------------------->
		<div id="loader">
			<div class="row loader-footer">
				<div class="col-sm-6 text-center"><span class="link stop-loading" style="cursor:alias;">STOP LOADING <i class="fa fa-hand-paper-o"></i></span></div>
				<div class="col-sm-6 text-center"><span>Designed with <i class="fa fa-heartbeat"></i> By : <a href="http://www.linkedin.com/in/samsberk" target="_blank" class="link">samsberk</a></span></div>
			</div>
        </div>
        <div class="after-click">
			<div class="row loader-footer">
				<div class="col-sm-6 text-center"><span class="link stop-loading" style="cursor:alias;">STOP LOADING <i class="fa fa-hand-paper-o"></i></span></div>
				<div class="col-sm-6 text-center"><span>Designed with <i class="fa fa-heartbeat"></i> By : <a href="http://www.linkedin.com/in/samsberk" target="_blank" class="link">samsberk</a></span></div>
			</div>
        </div>
		
		<!--------------------------------------------------------------- Nav bar ----------------------------------------------------------------->
        <nav class="nav navbar-fixed-top mymnav">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navmenu"><i class="fa fa-align-justify"></i></button>
                    <a href="Administrator_Home" class="navbar-brand mybrand click-on"> BooksMahal</a>
                </div>
                <div id="navmenu" class="collapse navbar-collapse">
                    <ul class="nav navbar-nav navbar-right mynavmenu">
                        <li><a href="Administrator_Home" class="click-on"><i class="fa fa-home"></i> HOME</a></li>
                        <li><a href="Administrator_Logout" class="click-on"><i class="fa fa-power-off"></i> LOGOUT</a></li>
                    </ul>
                </div>
            </div>
        </nav>
		<!--------------------------------------------------------------- Body ----------------------------------------------------------------->
		<div class="panel-body" style="min-height:100vh;padding:0px;border:none;">
			<!--------------------------------- Side Menu --------------------------------->
			<div class="side-menu">
				<a href="Administrator_Home" class="click-on"><span class="glyphicon glyphicon-th" style="border-top:0.5px solid gray;padding-left:20%;" data-toggle="tooltip" data-placement="right" title="DASHBOARD"></span></a>
				<a href="Administrator_Product_Manager" class="click-on"><span class="glyphicon glyphicon-book" data-toggle="tooltip" data-placement="right" title="PRODUCT MANAGER"></span></a>
				<a href="Administrator_Customer_Manager" class="click-on"><span class="glyphicon glyphicon-user" data-toggle="tooltip" data-placement="right" title="CUSTOMER MANAGER"></span></a>
				<a href="Administrator_Order_Manager" class="click-on"><span class="glyphicon glyphicon-shopping-cart" data-toggle="tooltip" data-placement="right" title="ORDER MANAGER"></span></a>
				<a href="Administrator_Growth_Manager" class="click-on"><span class="glyphicon glyphicon-signal" data-toggle="tooltip" data-placement="right" title="GROWTH MANAGER"></span></a>
				<a href="Administrator_Review_Manager" class="click-on"><span class="glyphicon glyphicon-comment" data-toggle="tooltip" data-placement="right" title="REVIEW MANAGER"></span></a>
				<a href="Administrator_Password" class="click-on"><span class="glyphicon glyphicon-lock" data-toggle="tooltip" data-placement="right" title="RESET PASSWORD"></span></a>
				<a href="Home" target="_blank"><span class="glyphicon glyphicon-home" data-toggle="tooltip" data-placement="right" title="Go to BooksMahal Home in New Tab"></span></a>
			</div>
			<div class="side-menu-box">
				<!--------------------------------- Side content --------------------------------->
				<div class="panel-body"><br />
					<h3 style="text-align:center;"><i class="fa fa-cog"></i> Newsletter Email Manager </h3><hr />
					<div class="row">
						<div class="col-sm-3"></div>
						<div class="col-sm-6">
							<h4>Send Message to All Registered Customer <i class="fa fa-caret-down"></i></h4><hr />
							<label for="msgtxt">Enter Message</label>
							<asp:TextBox runat="server" ID="msgtxt" TextMode="MultiLine" Rows="6" CssClass="form-control txt" placeholder="Enter Message"></asp:TextBox>
							<asp:Button runat="server" ID="msgbtn" CssClass="btn click-on btn-success" Text="Send Message" OnClick="msgbtn_Click" />
						</div>
						<div class="col-sm-3"></div>
					</div><hr /><br />
				</div>
			</div>
		</div>
		<!--------------------------------------------------------------- Footer ----------------------------------------------------------------->
		<footer >
			&copy; BooksMahal.com | All Rights Reserved<br />
			Designed & Developed By : <a href="http://www.linkedin.com/in/samsberk" target="_blank" class="link-footer" data-toggle="tooltip" data-placement="top" title="LinkedIN Profile">samsberk</a><br />
		</footer>
		<!--------------------------------------------------------------- Notification ----------------------------------------------------------------->
		<asp:Label runat="server" ID="informer"></asp:Label>
		<asp:Label runat="server" ID="show"></asp:Label>
		<div class="alert-box">
			<div class="alert-dialog text-center">
				<h4><i class="fa fa-bullhorn"></i> ALERT</h4><hr />
				<asp:Label runat="server" ID="alerttext" style="font-size:17px;"></asp:Label><hr />
				<button type="button" class="btn btn-default close-alert-box">Done</button>
			</div>
		</div>
    </form>
	<!--------------------------------------------------------------- Scripting ----------------------------------------------------------------->
	<script src="../js/Footer.js"></script>
	<script type="text/javascript">
		$(".close-alert-box").click(function () {
			$(".alert-box").fadeOut();
		});
	</script>
</body>
</html>
