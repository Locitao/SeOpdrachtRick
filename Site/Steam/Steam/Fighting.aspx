<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fighting.aspx.cs" Inherits="Steam.Fighting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fighting games</title>
    <link rel="stylesheet" href="style.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Button runat="server" ID="btnLogin" CssClass="button" Text="Log in/Sign up" OnClick="btnLogin_Click"/>
        <h1 class="steam">Steam</h1><br/>
        
        <p>On this page you'll find all games that are considered MMORPG's.</p><br/>
        <div class="buttons">
        <asp:Button runat="server" ID="mmo" CssClass="button" Text="MMORPG" OnClick="mmo_Click"/><br/>
        <asp:Button runat="server" ID="racing" CssClass="button" Text="Racing" OnClick="racing_Click"/><br/>
        <asp:Button runat="server" ID="fights" CssClass="button" Text="Fighting"/>
        </div>
        <div class="listboxes">
        <asp:ListBox ID="lbMmorpg" CssClass="listbox" runat="server" Height="200px" Width="400px"></asp:ListBox>
        </div>
        <asp:Button runat="server" ID="buy" CssClass="button" Text="Buy this game!"/>
    </form>
</body>
</html>
