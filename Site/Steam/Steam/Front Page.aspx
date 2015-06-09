<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Front Page.aspx.cs" Inherits="Steam.Front_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>S26 Rick van Duijnhoven</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    
    <form id="mainForm" runat="server">
        <asp:Button runat="server" ID="btnLogin" CssClass="button" Text="Log in/Sign up" OnClick="btnLogin_Click"/>
        <h1 class="steam">Steam</h1><br/>
        <!--<asp:Button CssClass="button" ID="btnTestConnection" runat="server" Text="Test database connection" OnClick="btnTestConnection_Click" />
        <asp:Label ID="lblTest" runat="server" Text="Komt hier shit?"></asp:Label>-->
        <p>Welcome to Steam, the biggest digital retailer of games in the world! Browse our selection of games by clicking on one of the links in the sidebar!</p><br/>
        <div class="buttons">
        <asp:Button runat="server" ID="mmorpg" CssClass="button" Text="MMORPG" OnClick="mmorpg_Click"/><br/>
        <asp:Button runat="server" ID="racing" CssClass="button" Text="Racing"/><br/>
        <asp:Button runat="server" ID="fighting" CssClass="button" Text="Fighting"/>
        </div>
    </form>
    
</body>
</html>
