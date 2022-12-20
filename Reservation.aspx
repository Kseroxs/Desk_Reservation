﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="Desk_Reservation.Reservation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                <TodayDayStyle BackColor="#CCCCCC" />
            </asp:Calendar>
            Location
            <br />
            
            <asp:DropDownList ID="LocationDropDownList" runat="server" DataSourceID="DeskDataSource" DataTextField="Location" DataValueField="Location"></asp:DropDownList>
            <asp:SqlDataSource ID="DeskDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DeskReservationConnectionString %>" SelectCommand="SELECT [Location] FROM [Locations] ORDER BY [Location]"></asp:SqlDataSource>
            <br />
            Desk Number
            <br />
            <asp:DropDownList ID="DeskNumberDropDownList" runat="server" DataSourceID="DeskDataSource2" DataTextField="DeskNumber" DataValueField="DeskNumber"></asp:DropDownList>
            <asp:SqlDataSource ID="DeskDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DeskReservationConnectionString %>" SelectCommand="SELECT [DeskNumber] FROM [Desk] ORDER BY [DeskNumber]"></asp:SqlDataSource>
            <br />
            <br />
            <asp:Button ID="Book" runat="server" Text="Book Desk" OnClick="Book_Click" />
        </div>
    </form>
</body>
</html>
