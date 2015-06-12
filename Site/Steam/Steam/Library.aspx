<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Library.aspx.cs" Inherits="Steam.Library" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Library</title>
    <link rel="stylesheet" href="style.css"/>
</head>
<body>
<form id="formLibrary" runat="server">
    <div>
        <asp:Button runat="server" ID="btnLogin" CssClass="button" Text="Log in/Sign up"/>
        <asp:Button runat="server" ID="toFrontPage" Text="Front Page" CssClass="button" OnClick="toFrontPage_Click"/>
        <asp:Button runat="server" ID="toCheckOut" Text="Check out" CssClass="button" OnClick="toCheckOut_Click"/>
        <h1 class="steam">Steam</h1><br/>

        <p>Here are all your games. Enjoy.</p><br/>
        <asp:ListBox ID="lbGames" CssClass="listbox" runat="server" Height="200px" Width="400px"></asp:ListBox><br/>
        <asp:Button runat="server" CssClass="button" ID="btnInstall" Text="Install selected game." OnClick="btnInstall_Click"/>
    </div>
</form>
</body>
</html>