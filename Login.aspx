<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Desk_Reservation.Login" %>

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
    Login
    <br />
    <asp:TextBox ID="LoginTextBox" runat="server"></asp:TextBox>
    <br />
    Password
    <br />
    <asp:TextBox ID="PasswordTextBox" Type="password" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
    </form>

    <asp:Label ID="InvalidCredentialsMessage" runat="server" ForeColor="Red" Text="Niepoprawny login lub hasło." Font-Size="Large"
            Visible="False"></asp:Label> 
    
</body>
</html>
