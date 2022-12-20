<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Desk_Reservation.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        Username
    <br />
    <asp:TextBox ID="LoginTextBox" runat="server"></asp:TextBox>
    <br />
    E-mail
    <br />

    <asp:TextBox ID="EmailTextBox" Type="email" runat="server"></asp:TextBox>
        <br />
    Password
    <br />

    <asp:TextBox ID="PasswordTextBox" Type="password" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="RegistrationButton" runat="server" Text="Sign Up" OnClick="RegistrationButton_Click" />
        <br />
        <asp:HyperLink ID="LoginHyperLink" runat="server" NavigateUrl="~/Login.aspx">Sign In</asp:HyperLink>
    </form>
</body>
</html>
