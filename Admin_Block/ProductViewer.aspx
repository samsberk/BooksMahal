<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductViewer.aspx.cs" Inherits="Admin_Block_ProductViewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BooksMahal | Product Viewer</title>
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
			margin-bottom:10px;
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
					<h3 style="text-align:center;"><i class="fa fa-bullseye"></i> Product Viewer</h3><hr />
					<ul class="breadcrumb">
						<li><a href="Administrator_Home" class="link">Administrator Home</a></li>
						<li><a href="Administrator_Product_Manager" class="link">Product Manager</a></li>
						<li>Product Viewer</li>
					</ul>
					<div class="row">
						<div class="col-sm-2"></div>
						<div class="col-sm-8">
							<h4><i class="fa fa-align-justify"></i> Product Data</h4><hr />
							<div class="row">
								<div class="col-xs-6 text-center">
									<span>Cover <i class="fa fa-chevron-down"></i></span><br /><br />
									<asp:Image runat="server" ID="coverpic" AlternateText="&ensp;Cover Picture not uploaded" style="width:75%;"/>
								</div>
								<div class="col-xs-6 text-center">
									<span>Syllabus <i class="fa fa-chevron-down"></i></span><br /><br />
									<asp:Image runat="server" ID="syllpic" AlternateText="&ensp;Syllabus Picture not uploaded" style="width:75%;"/>
								</div>
							</div><br />
							<table border="1" style="width:100%;">
								<tr><th>Attributes</th><th>Values</th></tr>
								<tr><td>Product ID</td><td><asp:Label runat="server" ID="pidlbl"></asp:Label></td></tr>
								<tr><td>Name</td><td><asp:Label runat="server" ID="namelbl"></asp:Label></td></tr>
								<tr><td>Category</td><td><asp:Label runat="server" ID="categlbl"></asp:Label></td></tr>
								<tr><td>Stock</td><td><asp:Label runat="server" ID="stocklbl"></asp:Label></td></tr>
								<tr><td>Strike Price</td><td><asp:Label runat="server" ID="strikeplbl"></asp:Label></td></tr>
								<tr><td>Sell Price</td><td><asp:Label runat="server" ID="sellplbl"></asp:Label></td></tr>
								<tr><td>Discount</td><td><asp:Label runat="server" ID="discountlbl"></asp:Label></td></tr>
								<tr><td>Description</td><td><asp:Label runat="server" ID="desclbl"></asp:Label></td></tr>
								<tr><td>Information</td><td><asp:Label runat="server" ID="infolbl"></asp:Label></td></tr>
								<tr><td>State</td><td><asp:Label runat="server" ID="statelbl"></asp:Label></td></tr>
								<tr><td>Review</td><td><asp:Label runat="server" ID="reviewlinklbl"></asp:Label></td></tr>
							</table><br />
							<asp:Button runat="server" ID="prodelete" CssClass="btn btn-danger" Text="Delete Product" OnClick="prodelete_Click"/>
							<hr /><br />

							<h4><i class="fa fa-edit"></i> Update Product Details :</h4><hr />
							<label for="pidtxt">Product ID :</label>
							<asp:TextBox runat="server" ID="pidtxt" TextMode="Number" CssClass="form-control txt" placeholder="Product ID"></asp:TextBox>
							<label for="txtname">Product Name :</label>
							<asp:TextBox runat="server" ID="txtname" CssClass="form-control txt" placeholder="Product Name (Max. 200 Char)" MaxLength="200"></asp:TextBox>
							<label for="txtcateg">Product Category :</label>
							<asp:DropDownList runat="server" ID="txtcateg" CssClass="form-control txt"></asp:DropDownList>
							<label for="txtstock">Total Stock :</label>
							<asp:TextBox runat="server" ID="txtstock" TextMode="Number" CssClass="form-control txt" placeholder="In Stock"></asp:TextBox>
							<label for="txtstrikep">Strike Price :</label>
							<asp:TextBox runat="server" ID="txtstrikep" TextMode="Number" CssClass="form-control txt" placeholder="Strike Price"></asp:TextBox>
							<label for="txtsellp">Sell Price :</label>
							<asp:TextBox runat="server" ID="txtsellp" TextMode="Number" CssClass="form-control txt" placeholder="Sell Price"></asp:TextBox> 
							<label for="txtdiscount">Discount (%) :</label>
							<asp:TextBox runat="server" ID="txtdiscount" TextMode="Number" CssClass="form-control txt" placeholder="Discount on Product in Percent"></asp:TextBox>
							<label for="txtdesc">Product Description :</label>
							<asp:TextBox runat="server" ID="txtdesc" TextMode="MultiLine" Rows="3" CssClass="form-control txt" placeholder="Description (Max. 1000 Char)" MaxLength="1000"></asp:TextBox>
							<label for="txtinfo">Product Information :</label>
							<asp:TextBox runat="server" ID="txtinfo" TextMode="MultiLine" Rows="3" CssClass="form-control txt" placeholder="Information (Max. 1000 Char)" MaxLength="1000"></asp:TextBox>
							<label for="txtstate">State :</label>
							<asp:DropDownList runat="server" ID="txtstate" CssClass="form-control txt">
								<asp:ListItem Text="SELECT STATE" Value="SELECT STATE"></asp:ListItem>
								<asp:ListItem Text="NEW" Value="NEW"></asp:ListItem>
								<asp:ListItem Text="FEATURED" Value="FEATURED"></asp:ListItem>
								<asp:ListItem Text="OLD" Value="OLD"></asp:ListItem>
							</asp:DropDownList>
							<asp:Button runat="server" ID="proupdate" CssClass="btn btn-warning" Text="Update Product" OnClick="proupdate_Click" />
							<br /><hr />
						</div>
						<div class="col-sm-2"></div>
					</div>
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

		$("#pidtxt").attr("disabled", true);
		var t0 = document.getElementById("pidtxt");
		var t1 = document.getElementById("txtname");
		var t2 = document.getElementById("txtcateg");
		var t3 = document.getElementById("txtstock");
		var t4 = document.getElementById("txtsellp");
		var t5 = document.getElementById("txtstrikep");
		var t6 = document.getElementById("txtdiscount");
		var t7 = document.getElementById("txtdesc");
		var t8 = document.getElementById("txtinfo");
		var t9 = document.getElementById("txtstate");
		t0.value = $("#pidlbl").text();
		t1.value = $("#namelbl").text();
		t2.value = $("#categlbl").text();
		t3.value = $("#stocklbl").text();
		t4.value = $("#sellplbl").text();
		t5.value = $("#strikeplbl").text();
		t6.value = $("#discountlbl").text();
		t7.value = $("#desclbl").text();
		t8.value = $("#infolbl").text();
		t9.value = $("#statelbl").text();

		
		//$("#txtsellp").blur(function () {
		//	var st = document.getElementById("txtstrikep");
		//	var sl = document.getElementById("txtsellp");
		//	var dis = document.getElementById("txtdiscount");
		//	var vst = parseInt(st.value, 10);
		//	var vsl = parseInt(sl.value, 10);
		//	var vdis = 100 - ((vsl * 100) / vst);
		//	dis.value = vdis;
		//});
		$("#txtdiscount").blur(function () {
			var st = document.getElementById("txtstrikep");
			var sl = document.getElementById("txtsellp");
			var dis = document.getElementById("txtdiscount");
			var vst = parseInt(st.value, 10);
			var vdis = parseInt(dis.value, 10);
			var vsl = vst - ((vst * vdis) / 100);
			sl.value = vsl;
		});
	</script>
</body>
</html>
