<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bksmhl1601.aspx.cs" Inherits="bksmhl1601" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Restricted Page | BooksMahal</title>
	<meta name="theme-color" content="#ffffff" />
	<meta name="msApplication-navbutton-color" content="#ffffff" />
	<meta name="apple-mobile-web-app-status-bar-style" content="#ffffff" />
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link id="Link1" runat="server" rel="Shortcut Icon" href="Images/fi.png" type="image/x-icon"/>
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
	<link href="css/ACSS.css" rel="stylesheet" />
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
	<script src="js/AJS.js"></script>
	<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
	<link href="https://fonts.googleapis.com/css?family=Inconsolata|Poppins|Karma|Muli|Yantramanav|Kalam|Pacifico|Quicksand|Sedgwick+Ave" rel="stylesheet"/>
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
			<div class="col-sm-4"></div>
			<div class="col-sm-4">
				<div style="padding-top:100px;width:100%;">
					<asp:TextBox runat="server" ID="aidtxt" TextMode="Email" CssClass="form-control" style="border-radius:0;text-transform:lowercase;margin-bottom:10px;"></asp:TextBox>
					<asp:TextBox runat="server" ID="apastxt" TextMode="Password" CssClass="form-control" style="border-radius:0;margin-bottom:10px;"></asp:TextBox>
					<asp:Button runat="server" ID="loginbtn" CssClass="btn btn-danger" Text="Go"  style="border-radius:0;margin-bottom:10px;" OnClick="loginbtn_Click"/>
				</div>
			</div>
			<div class="col-sm-4"></div>
        </div>
    </form>
</body>
</html>
