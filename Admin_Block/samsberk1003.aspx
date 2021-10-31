<%@ Page Language="C#" AutoEventWireup="true" CodeFile="samsberk1003.aspx.cs" Inherits="Admin_Block_samsberk1003" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>4</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox runat="server" ID="aidtxt" placeholder="aid"></asp:TextBox><input type="button" /><br />
        <asp:TextBox runat="server" ID="mobiletxt" placeholder="mble"></asp:TextBox><input type="button" /><br />
        <asp:TextBox runat="server" ID="nametxt" placeholder="nmae"></asp:TextBox><input type="button" /><br />
        <asp:TextBox runat="server" ID="passtxt" placeholder="pas"></asp:TextBox><asp:Button runat="server" ID="genbtn" OnClick="genbtn_Click" Text="go" /><br />
		<input type="text" placeholder="dum_show"/><input type="button" /><br />
		<input type="text" placeholder="aid"/><input type="button" /><br />
		<input type="text" placeholder="aid"/><input type="button" /><br />
		<input type="text" placeholder="aid"/><input type="button" /><br />
		<input type="text" placeholder="aid"/><input type="button" /><br />
		<input type="text" placeholder="aid"/><input type="button" /><br />
		<input type="text" placeholder="aid"/><input type="button" /><br />
    </form>
</body>
</html>
