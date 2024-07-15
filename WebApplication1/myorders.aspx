<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myorders.aspx.cs" Inherits="WebApplication1.myorders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<asp:GridView
          id="GridView1"
          runat="server"
          DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="Order Number">
    <Columns>
        <asp:BoundField DataField="Order Number" HeaderText="Order Number" InsertVisible="False" ReadOnly="True" SortExpression="Order Number" />
        <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
        <asp:BoundField DataField="Total Amount" HeaderText="Total Amount" SortExpression="Total Amount" />
        <asp:BoundField DataField="Order Status" HeaderText="Order Status" SortExpression="Order Status" />
    </Columns>
      </asp:GridView>
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=DESKTOP-NM2FONB\SQLEXPRESS;Initial Catalog=m2;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [order_no] as [Order Number], [order_date] as [Date], [total_amount] as [Total Amount], [order_status] as [Order Status] FROM [Orders] WHERE ([customer_name] = @customer_name)">
                <SelectParameters>
                    <asp:SessionParameter Name="customer_name" SessionField="username" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <p>
            To cancel an order, please enter the order number:&nbsp; <asp:TextBox ID="TextBox1" runat="server" Width="62px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Cancel Order" OnClick="cancelorder" />
        </p>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Home" />
    </form>
</body>
</html>
