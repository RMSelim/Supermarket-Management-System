<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMainPage.aspx.cs" Inherits="WebApplication1.AdminMainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
             <asp:Button ID="Button1" runat="server" Text="Review and Update Orders" Width="261px" OnClick="Button1_Click" />
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Activate Vendors" Width="263px" />
        </p>
        <p>
            <asp:Button ID="Button3" runat="server" Text="Add and Remove Today's Deal" OnClick="Button3_Click" />
        </p>
        <p>
            &nbsp;</p>
    <p>
        Mobile Number:
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Add Mobile Number" />
    </p>
        <p>
            &nbsp;</p>
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Logout" />
    </form>
</body>
</html>
