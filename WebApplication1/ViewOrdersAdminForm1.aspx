<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewOrdersAdminForm1.aspx.cs" Inherits="WebApplication1.ViewOrdersAdminForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">        

      <asp:SqlDataSource
          id="SqlDataSource1"
          runat="server"
          DataSourceMode="DataReader"
          ConnectionString="<%$ ConnectionStrings:m2ConnectionString %>"
          SelectCommand="Execute reviewOrders">
      </asp:SqlDataSource>

      <asp:GridView
          id="GridView1"
          runat="server"
          DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="order_no">
          <Columns>
              <asp:BoundField DataField="order_no" HeaderText="order_no" InsertVisible="False" ReadOnly="True" SortExpression="order_no" />
              <asp:BoundField DataField="order_date" HeaderText="order_date" SortExpression="order_date" />
              <asp:BoundField DataField="total_amount" HeaderText="total_amount" SortExpression="total_amount" />
              <asp:BoundField DataField="cash_amount" HeaderText="cash_amount" SortExpression="cash_amount" />
              <asp:BoundField DataField="credit_amount" HeaderText="credit_amount" SortExpression="credit_amount" />
              <asp:BoundField DataField="payment_type" HeaderText="payment_type" SortExpression="payment_type" />
              <asp:BoundField DataField="order_status" HeaderText="order_status" SortExpression="order_status" />
              <asp:BoundField DataField="remaining_days" HeaderText="remaining_days" SortExpression="remaining_days" />
              <asp:BoundField DataField="time_limit" HeaderText="time_limit" SortExpression="time_limit" />
              <asp:BoundField DataField="GiftCard_code_used" HeaderText="GiftCard_code_used" SortExpression="GiftCard_code_used" />
              <asp:BoundField DataField="customer_name" HeaderText="customer_name" SortExpression="customer_name" />
              <asp:BoundField DataField="delivery_id" HeaderText="delivery_id" SortExpression="delivery_id" />
              <asp:BoundField DataField="creditcard_number" HeaderText="creditcard_number" SortExpression="creditcard_number" />
          </Columns>
      </asp:GridView>


        <div>
                        <asp:Label ID="Label1" runat="server" Text="Order ID to update:"></asp:Label>
        <asp:TextBox ID="idTxtBox" runat="server" Height="16px"></asp:TextBox>
        <asp:Button ID="update" runat="server" OnClick="update_Click" Text="Update Status of Order" />

        </div>
                <p>
            <asp:Label ID="errorBox" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Visible="False"></asp:Label>
        </p>
        

    </form>
</body>
</html>
