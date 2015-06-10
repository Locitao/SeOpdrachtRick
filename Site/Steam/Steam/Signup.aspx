<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Steam.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signup/log in</title>
    <link rel="stylesheet" href="style.css"/>
</head>
<body>
    <form id="signUp" runat="server">
    <div id="signup">
        <h1>Create account.</h1>
        <div id="text">
            <p class="lblText">Full name:</p><br/>
            <p class="lblText">E-mail address:</p><br/>
            <p class="lblText">Birthdate(format: day/month/year):</p><br/>
            <p class="lblText">Password:</p><br/>
            

        </div>
        <div id="textBoxes">
            <asp:TextBox ID="tbSignupName" CssClass="textbox" runat="server"></asp:TextBox><br/>
            <asp:TextBox ID="tbSignupEmail" CssClass="textbox" runat="server"></asp:TextBox><br/>
            <asp:Textbox ID="tbBirthdate" CssClass="textbox" runat="server"></asp:Textbox><br/>
            <asp:Textbox ID="tbSignupPassword" CssClass="textbox" runat="server" TextMode="Password"></asp:Textbox>
        </div>
        <div id="loginstuff">
            <div id ="login">
                <p class="lblText">E-mail address:</p><br/>
                <p class="lblText">Password:</p><br/>
            </div>
            <div id="tbForLogin">
                <asp:TextBox ID="tbLoginEmail" CssClass="textbox" runat="server"></asp:TextBox><br/>
                <asp:TextBox ID="tbLoginPassword" CssClass="textbox" runat="server" TextMode="Password"></asp:TextBox><br/>
            </div>
            <br/><asp:Button runat="server" CssClass="button" ID="btnLogin" Text="Log in" OnClick="btnLogin_Click"/>
            
        </div>

        <br/><asp:Button CssClass="button" ID="btnCreate" runat="server" Text="Create account" OnClick="btnCreate_Click" />
    </div>
        

        
        

    </form>
</body>
</html>
