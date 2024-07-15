<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="WebApplication1.cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            My Cart:<br />
&nbsp;<asp:GridView
          id="GridView1"
          runat="server"
          DataSourceID="SqlDataSource1" Width="210px" AutoGenerateColumns="False" DataKeyNames="serial_no">
                <Columns>
                    <asp:BoundField DataField="serial_no" HeaderText="serial_no" InsertVisible="False" ReadOnly="True" SortExpression="serial_no" />
                    <asp:BoundField DataField="product_name" HeaderText="product_name" SortExpression="product_name" />
                    <asp:BoundField DataField="product_description" HeaderText="product_description" SortExpression="product_description" />
                    <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                    <asp:BoundField DataField="final_price" HeaderText="final_price" SortExpression="final_price" />
                    <asp:BoundField DataField="color" HeaderText="color" SortExpression="color" />
                </Columns>
      </asp:GridView>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:m2ConnectionString %>" SelectCommand="viewMyCart" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="customer" SessionField="username" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        Available Products:<br />
        <asp:GridView
          id="GridView2"
          runat="server"
          DataSourceID="SqlDataSource2" Width="210px">
      </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:m2ConnectionString %>" SelectCommand="SELECT [serial_no], [product_name], [category], [product_description], [price], [final_price], [color] FROM [Product] where available=1"></asp:SqlDataSource>
        <br />
            To add to your cart, put Serial Number here:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="AddProduct" Text="Add Product" />
            <asp:Label ID="errorBox" runat="server"></asp:Label>
            <br />
        <br />
            To remove a product from your cart, put Serial Number here:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="Remove Product" OnClick="RemoveProduct" />
        <asp:Label ID="errorBox0" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Checkout" />
    </form>
</body>
</html>
