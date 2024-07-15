<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wishlists.aspx.cs" Inherits="WebApplication1.Wishlists" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
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
        <div>
            To add to a Wishlist, put Serial Number here:
            &nbsp;<asp:TextBox ID="addTxt" runat="server"></asp:TextBox>
            and Wishlist name here:&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Width="105px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="AddProduct" Text="Add to Wishlist" />
            <br />
            <br />
            To remove from a Wishlist, put Serial Number here:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;and Wishlist name here:&nbsp;
            <asp:TextBox ID="TextBox3" runat="server" Width="83px"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Remove from Wishlist" Width="154px" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="View my Wishlists" />
            <br />
        </div>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Home" />
    </form>
</body>
</html>
