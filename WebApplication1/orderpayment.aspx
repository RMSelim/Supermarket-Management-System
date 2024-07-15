<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderpayment.aspx.cs" Inherits="WebApplication1.orderpayment" %>

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
                     <asp:BoundField DataField="Total Amount" HeaderText="Total Amount" SortExpression="Total Amount" />
                 </Columns>
      </asp:GridView>
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:m2ConnectionString %>" SelectCommand="SELECT order_no AS [Order Number], total_amount AS [Total Amount] FROM Orders
where order_no=( select max(order_no) from orders)"></asp:SqlDataSource>
            <br />
            Please choose your payment method (Only one):</div>
             <p>
                 <asp:CheckBox ID="cashcheck" runat="server" Text="Cash" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:CheckBox ID="creditcheck" runat="server" Text="Credit Card" />
             </p>
             <p>
                 Please specify amount being paid with money:&nbsp; <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
             </p>
             <p>
                 Please choose a Credit Card (Skip this step if you are paying with cash):&nbsp;
                 <asp:DropDownList ID="DropDownList1" runat="server" Width="119px" DataSourceID="SqlDataSource2" DataTextField="cc_number">
                 </asp:DropDownList>
             </p>
             <p>
                 <asp:Button ID="Button1" runat="server" OnClick="payfororder" Text="Confirm Payment" />
             </p>
    <p>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:m2ConnectionString %>" SelectCommand="SELECT [cc_number] FROM [Customer_CreditCard] WHERE ([customer_name] = @customer_name)">
            <SelectParameters>
                <asp:SessionParameter Name="customer_name" SessionField="username" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
             </p>
    </form>
    </body>
</html>
