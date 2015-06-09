<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mmorpg.aspx.cs" Inherits="Steam.Mmorpg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MMORPG's</title>
    <link rel="stylesheet" href="style.css"/>
</head>
<body>
    <form id="mmorpg" runat="server">
    <asp:Button runat="server" ID="btnLogin" CssClass="button" Text="Log in/Sign up" OnClick="btnLogin_Click"/>
        <h1 class="steam">Steam</h1><br/>
        
        <p>On this page you'll find all games that are considered MMORPG's.</p><br/>
        <div class="buttons">
        <asp:Button runat="server" ID="Button1" CssClass="button" Text="MMORPG"/><br/>
        <asp:Button runat="server" ID="racing" CssClass="button" Text="Racing"/><br/>
        <asp:Button runat="server" ID="fighting" CssClass="button" Text="Fighting"/>
        </div>
        <asp:ListBox ID="lbMmorpg" CssClass="listbox" runat="server" Height="400px" Width="400px"></asp:ListBox>

    </form>
</body>
</html>
