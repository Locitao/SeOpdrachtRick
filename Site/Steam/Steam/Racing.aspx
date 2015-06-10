<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Racing.aspx.cs" Inherits="Steam.Racing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Racing</title>
    <link rel="stylesheet" href="style.css"/>
</head>
<body>
    <form id="formRacing" runat="server">
    <asp:Button runat="server" ID="btnLogin" CssClass="button" Text="Log in/Sign up" />
        <h1 class="steam">Steam</h1><br/>
        
        <p>On this page you'll find all games that are considered MMORPG's.</p><br/>
        <div class="buttons">
        <asp:Button runat="server" ID="mmo" CssClass="button" Text="MMORPG" OnClick="mmo_Click" /><br/>
        <asp:Button runat="server" ID="races" CssClass="button" Text="Racing" OnClick="races_Click" /><br/>
        <asp:Button runat="server" ID="fighting" CssClass="button" Text="Fighting" OnClick="fighting_Click"/>
        </div>
        <div class="listboxes">
        <asp:ListBox ID="lbRacing" CssClass="listbox" runat="server" Height="200px" Width="400px"></asp:ListBox>
        </div>
        <asp:Button runat="server" ID="buy" CssClass="button" Text="Buy this game!"/>
    </form>
</body>
</html>
