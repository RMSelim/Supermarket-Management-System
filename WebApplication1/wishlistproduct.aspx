<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wishlistproduct.aspx.cs" Inherits="WebApplication1.wishlistproduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:GridView
          id="GridView1"
          runat="server"
          DataSourceID="SqlDataSource1">
      </asp:GridView>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:m2ConnectionString %>" SelectCommand="showWishlistProduct" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="customername" SessionField="username" Type="String" />
                <asp:SessionParameter Name="name" SessionField="wishname" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back to Wishlist page" />
    </form>
</body>
</html>
