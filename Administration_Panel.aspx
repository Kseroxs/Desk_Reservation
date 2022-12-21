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
        <asp:GridView ID="LocationsGridView" runat="server" OnRowCommand="LocationsGridView_RowCommand">
            <Columns>  
                    <asp:TemplateField><ItemTemplate>  
                        <asp:LinkButton ID = "LinkButton2" runat="server"   Text="Delete" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" CommandName="DeleteButton"></asp:LinkButton>  
                                       </ItemTemplate>

                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
    <asp:TextBox ID="LocationTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="AddLocationButton" runat="server" Text="Add Location" OnClick="AddLocationButton_Click" />
    <br />
    <br />
    <asp:DropDownList ID="LocationDropDownList" runat="server" DataSourceID="DeskDataSource1" DataTextField="Location" DataValueField="Location" AutoPostBack="True"></asp:DropDownList>
        <asp:SqlDataSource ID="DeskDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DeskReservationConnectionString %>" SelectCommand="SELECT [Location] FROM [Locations] ORDER BY [Location]"></asp:SqlDataSource>
        <asp:GridView ID="DesksGridView" runat="server" OnRowCommand="DesksGridView_RowCommand">
            <Columns>  
                    <asp:TemplateField><ItemTemplate>  
                        <asp:LinkButton ID = "LinkButton2" runat="server"   Text="Delete" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" CommandName="DeleteButton"></asp:LinkButton>  
                                       </ItemTemplate>

                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
    </form>
    <asp:TextBox ID="DeskTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="AddDeskButton" runat="server" Text="Add Desk" OnClick="AddDeskButton_Click" />
</body>
</html>
