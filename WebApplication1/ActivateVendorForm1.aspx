<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivateVendorForm1.aspx.cs" Inherits="WebApplication1.ActivateVendorForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
                <asp:Label ID="Label1" runat="server" Text="Vendor Username:"></asp:Label>
        <asp:TextBox ID="vendoruser" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Height="20px" OnClick="Button1_Click" Text="Activate" Width="69px" />
        <p>
            <asp:Label ID="errorBox" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Visible="False"></asp:Label>

    </form>
</body>
</html>
