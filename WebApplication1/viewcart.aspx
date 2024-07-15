<%@ Page Language="C#" AutoEventWireup="true" Codefile="viewcart.aspx.cs" Inherits="WebApplication1.viewcart" %>

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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=DESKTOP-NM2FONB\SQLEXPRESS;Initial Catalog=m2;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="viewMyCart" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="customer" SessionField="username" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Button ID="Button1" runat="server" OnClick="makeorder" Text="Confirm Purchase" />
    &nbsp;&nbsp;&nbsp;&nbsp;
        </form>
</body>
</html>
