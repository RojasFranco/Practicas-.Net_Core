<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="curso.ui.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Test</title>
	<link href="css/Style.css?v12" rel="stylesheet" />
	<script src="js/JavaScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    	<p>
		<input class="default default-2" id ="Button1" type="button" value="button" onclick="onClick(this);" /></p>
		<asp:Button ID="btnLogin" runat="server" Text="Button" OnClick="Button2_Click"  class="default default-2"/>
    	<p>
			<asp:TextBox ID="txtUsuario" runat="server" class="default default-2" Width="222px" ReadOnly="True"></asp:TextBox>
		</p>
    </form>
</body>
</html>
