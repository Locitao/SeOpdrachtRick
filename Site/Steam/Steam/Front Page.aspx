<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Front Page.aspx.cs" Inherits="Steam.Front_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>S26 Rick van Duijnhoven</title>
    <link rel="stylesheet" href="style2.css" />
</head>
<body>
    
    <form id="form1" runat="server">
        <h1>Steam</h1>
        <a href="Signup.aspx" id="logsign">Log in/sign up</a><br/>
        <asp:Button CssClass="button" ID="btnTestConnection" runat="server" Text="Test database connection" OnClick="btnTestConnection_Click" />
        <asp:Label ID="lblTest" runat="server" Text="Komt hier shit?"></asp:Label>
        
    </form>
    
</body>
</html>
