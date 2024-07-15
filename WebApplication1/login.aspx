<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            Login</p>
        <p>
            Username:
            <asp:TextBox ID="TextBox1" runat="server" style="height: 22px"></asp:TextBox>
        </p>
        <p>
            Password:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="loginbutton" Text="Login" />
    </form>
</body>
</html>
