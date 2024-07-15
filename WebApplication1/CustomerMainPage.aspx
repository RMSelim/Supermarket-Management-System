<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerMainPage.aspx.cs" Inherits="WebApplication1.CustomerMainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
</body>
</html>
<asp:Button runat="server" Text="View All Products" OnClick="goproducts" />
<asp:Button runat="server" Text="Wishlists" OnClick="gowishlists" />
<asp:Button runat="server" Text="View My Cart" OnClick="gocart" />
    <br />
    <p>
        cc number:
        <asp:TextBox ID="TextBox1" runat="server" Width="237px"></asp:TextBox>
        </p>
    cvc:
    <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
    <br />
    expiry date (YYYY-MM-DD):
    <asp:TextBox ID="TextBox3" runat="server" Width="121px"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Add Credit Card" OnClick="addcredit" Width="137px" />
    <br />
    <br />
    wishlist name:
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    &nbsp;<p>
        <asp:Button ID="Button2" runat="server" Text="Create Wishlist" OnClick="createwishlist" />
    </p>
    <p>
        Mobile Number:
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Add Mobile Number" />
    </p>
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Logout" />
    </form>

