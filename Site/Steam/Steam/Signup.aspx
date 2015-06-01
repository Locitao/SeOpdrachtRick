<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Steam.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="style2.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="signup">
        <h1>Create account.</h1>
        <div id="text">
            <p class="lblText">Name:</p><br/>
            <p class="lblText">E-mail address:</p><br/>
            <p class="lblText">Username:</p><br/>
            <p class="lblText">Password:</p><br/>
            

        </div>
        <div id="textBoxes">
            <asp:TextBox ID="tbSignupName" CssClass="textbox" runat="server"></asp:TextBox><br/>
            <asp:TextBox ID="tbSignupEmail" CssClass="textbox" runat="server"></asp:TextBox><br/>
            <asp:Textbox ID="tbSignUpUsername" CssClass="textbox" runat="server"></asp:Textbox><br/>
            <asp:Textbox ID="tbSignupPassword" CssClass="textbox" runat="server" TextMode="Password"></asp:Textbox>
        </div>
        

        <br/><asp:Button CssClass="button" ID="btnCreate" runat="server" Text="Create account" OnClick="btnCreate_Click" />
    </div>
        

        
        

    </form>
</body>
</html>
