<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="Admin_Block_Invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BooksMahal | Invoice</title>
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
		#accshow{
			display:none;
		}
		.txt {
			border:none;
			height:initial;
			font-size:12px;
			background-color:transparent;
			border-radius:0;
			resize:none;
		}
		th, td{
			padding:3px 5px;
			font-family:muli;
			font-size:12px;
		}
		tr:hover{
			color:black;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">

        <div style="width:50%;height:auto;border:1px solid lightgray;padding:10px;font-size:10px;">
			<div class="row">
				<div class="col-xs-6 text-center">
					<img src="../images/logo_.png" style="width:100%;" />
						+91 9720410274
				</div>
				<div class="col-xs-6">
					<p>
						BooksMahal.com<br />
						New F-97 1st floor Raghubir Nagar, near Tagore Garden, New Delhi, Delhi 110027
					</p>
				</div>
			</div><hr style="margin:5px -5px;"/>
			<div class="row">
				<div class="col-xs-12 text-center">
					<b style="font-size:12px;">INVOICE</b><hr style="margin:5px -5px;"/>
				</div>
				<div class="col-xs-12">
					To,<br />
					<asp:Label runat="server" ID="namelbl"></asp:Label>,<br />
					<asp:Label runat="server" ID="addresslbl"></asp:Label>,<br />
					Mobile : <asp:Label runat="server" ID="contactlbl"></asp:Label><hr style="margin:5px -5px;"/>
				</div>
				<div class="col-xs-6" style="font-size:13px;">
					Order ID : <asp:Label runat="server" ID="oidlbl"></asp:Label><br />
					Amount : <asp:Label runat="server" ID="totamlbl"></asp:Label><br />
				</div>
				<div class="col-xs-6" style="border-left:0.1px solid lightgray;">
					<div class="row">
						<div class="col-xs-7 text-center">
							<span style="font-size:20px;">F</span>ast<br />
							<span>Delivery</span>
						</div>
						<div class="col-xs-5">
							<img src="../images/qr-code.png" style="width:100%;" />
						</div>
					</div>
				</div>
				<div class="col-xs-12"><hr style="margin:5px -5px;"/>
					<img src="../images/bar-code.png" style="width:100%;" />
				</div>
			</div>
		</div><br />



        <%--<div style="width:100%;height:auto;border:1px solid lightgray;padding:10px;font-size:10px;">
			<div class="row">
				<div class="col-xs-6">
					<img src="../images/logo_.png" style="width:50%;" />
				</div>
				<div class="col-xs-6">
					<p>

					</p>
				</div>
			</div><hr />
			<h6 style="text-align:center;font-weight:bold;">INVOICE</h6><hr />
			<table style="width:100%;">
				<tr><td>Product</td><td>Price</td><td>Discount</td><td>Dis. Price</td><td>Quantity</td><td>Total</td></tr>
				<asp:PlaceHolder runat="server" ID="invoiceph"></asp:PlaceHolder>
				<tr style="border-top:0.5px solid lightgray;"><td colspan="4"></td><td style="text-align:right;padding-top:12px;">Grand Total : </td><td style="padding-top:12px;">&#8377; <asp:Label runat="server" ID="gtlbl"></asp:Label></td></tr>

			</table>
        </div>--%>
    </form>
</body>
</html>
