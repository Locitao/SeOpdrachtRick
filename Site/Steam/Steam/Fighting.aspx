<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fighting.aspx.cs" Inherits="Steam.Fighting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fighting games</title>
    <link rel="stylesheet" href="style.css"/>
</head>
<body>
<form id="formFighting" runat="server">
    <asp:Button runat="server" ID="btnLogin" CssClass="button" Text="Log in/Sign up"/>
    <asp:Button runat="server" ID="toFrontPage" Text="Front Page" CssClass="button" OnClick="toFrontPage_Click"/>
    <asp:Button runat="server" ID="toCheckOut" Text="Check out" CssClass="button" OnClick="toCheckOut_Click"/>
    <h1 class="steam">Steam</h1><br/>

    <p>On this page you'll find all games that are considered MMORPG's.</p><br/>
    <div class="buttons">
        <asp:Button runat="server" ID="mmo" CssClass="button" Text="MMORPG"/><br/>
        <asp:Button runat="server" ID="racing" CssClass="button" Text="Racing"/><br/>
        <asp:Button runat="server" ID="fights" CssClass="button" Text="Fighting"/>
    </div>
    <div class="listboxes">
        <asp:ListBox ID="lbFighting" CssClass="listbox" runat="server" Height="200px" Width="400px"></asp:ListBox>
    </div>
    <asp:Button runat="server" ID="buy" CssClass="button" Text="Buy this game!"/>
    <asp:Button runat="server" ID="reviews" CssClass="button" Text="Find reviews for selected game." OnClick="reviews_Click"/>
    <asp:Label ID="lblReviews" runat="server" Text=""></asp:Label>
</form>
</body>
</html>