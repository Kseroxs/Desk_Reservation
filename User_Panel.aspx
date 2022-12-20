<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Panel.aspx.cs" Inherits="Desk_Reservation.User_Panel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
        <asp:Panel runat="server" ID="AuthenticatedMessagePanel">
        <asp:Label runat="server" ID="WelcomeMessage"></asp:Label>
        </asp:Panel>
    <form id="form1" runat="server">
        <asp:Button ID="MakeReservationButton" runat="server" Text="Make a reservation" OnClick="MakeReservationButton_Click" />
    </form>
    
</body>
</html>
