<%@ Page Language="C#" AutoEventWireup="true" Codefile="registercustomer.aspx.cs" Inherits="WebApplication1.registercustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Firstname:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Lastname:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <br />
            Username: <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            Password:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            Email:
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
