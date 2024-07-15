<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mywishlists.aspx.cs" Inherits="WebApplication1.mywishlists" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:m2ConnectionString %>" SelectCommand="viewwishlist" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:SessionParameter Name="customername" SessionField="username" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            My Wishlists:<br />
        </div>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Show Products" />
        <br />
    </form>
</body>
</html>
