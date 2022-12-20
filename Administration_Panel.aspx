<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administration_Panel.aspx.cs" Inherits="Desk_Reservation.Administration_Panel" %>

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
    <asp:TextBox ID="LocationTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="AddLocationButton" runat="server" Text="Add Location" OnClick="AddLocationButton_Click" />
    <br />
    <br />
    <asp:DropDownList ID="LocationDropDownList" runat="server" DataSourceID="DeskDataSource1" DataTextField="Location" DataValueField="Location"></asp:DropDownList>
        <asp:SqlDataSource ID="DeskDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DeskReservationConnectionString %>" SelectCommand="SELECT [Location] FROM [Locations] ORDER BY [Location]"></asp:SqlDataSource>
    </form>
    <asp:TextBox ID="DeskTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="AddDeskButton" runat="server" Text="Add Desk" OnClick="AddDeskButton_Click" />
</body>
</html>
