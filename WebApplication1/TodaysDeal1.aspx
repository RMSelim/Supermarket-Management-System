<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TodaysDeal1.aspx.cs" Inherits="WebApplication1.TodaysDeal1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                        <asp:Label ID="Label1" runat="server" Text="Create Today's Deal"></asp:Label>

        </div>
                <p>
            <asp:Label ID="Label2" runat="server" Text="Amount:"></asp:Label>
            <asp:TextBox ID="amountTxt" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Expiry Date(YYYY-MM-DD):"></asp:Label>
            <asp:TextBox ID="dateTxt" runat="server" style="margin-top: 0px"></asp:TextBox>
            <asp:Label ID="Label7" runat="server" Text="Time(HH:MM)"></asp:Label>
            <asp:TextBox ID="timeTxt0" runat="server" style="margin-top: 0px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Product ID:"></asp:Label>
            <asp:TextBox ID="productTxt" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="errorBox" runat="server"></asp:Label>
        <p>
            <asp:Button ID="createBut" runat="server" OnClick="createBut_Click" Text="Create Deal" />
        </p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="Delete Deal"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Deal ID:"></asp:Label>
            <asp:TextBox ID="deleteTxt" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="errorBox0" runat="server"></asp:Label>
        <p>
            <asp:Button ID="dltBut" runat="server" OnClick="Button2_Click" Text="Delete Deal" />
        </p>

    </form>
</body>
</html>
