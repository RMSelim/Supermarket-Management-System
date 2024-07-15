<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="WebApplication1.products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Products:<br />
&nbsp;<asp:GridView
          id="GridView1"
          runat="server"
          DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="serial_no">
                <Columns>
                    <asp:BoundField DataField="serial_no" HeaderText="serial_no" InsertVisible="False" ReadOnly="True" SortExpression="serial_no" />
                    <asp:BoundField DataField="product_name" HeaderText="product_name" SortExpression="product_name" />
                    <asp:BoundField DataField="category" HeaderText="category" SortExpression="category" />
                    <asp:BoundField DataField="product_description" HeaderText="product_description" SortExpression="product_description" />
                    <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                    <asp:BoundField DataField="final_price" HeaderText="final_price" SortExpression="final_price" />
                    <asp:BoundField DataField="color" HeaderText="color" SortExpression="color" />
                </Columns>
      </asp:GridView>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:m2ConnectionString %>" SelectCommand="SELECT [serial_no], [product_name], [category], [product_description], [price], [final_price], [color] FROM [Product] ORDER BY [final_price]"></asp:SqlDataSource>
    </form>
</body>
</html>
