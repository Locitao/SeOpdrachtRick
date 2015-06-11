<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Steam.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout</title>
    <link rel="stylesheet" href="style.css"/>

</head>
<body>
    <form id="checkout" runat="server">
        <asp:Button runat="server" ID="btnLogin" CssClass="button" Text="Log in/Sign up" OnClick="btnLogin_Click"/>
        <asp:Button runat="server" ID="toFrontPage" Text="Front Page" CssClass="button" OnClick="toFrontPage_Click"/>
    <h1 class="steam">Steam</h1><br/>
    <p>This is your shopping cart. If you want to purchase the games displayed; click the "buy" button.</p><br/>


        <div class="listboxes">
            <asp:ListBox ID="lbCheckout" CssClass="listbox" runat="server" Height="200px" Width="400px"></asp:ListBox>
        </div>
        <asp:RadioButton ID="rdPayPal" runat="server" Text="PayPal" GroupName="payment" />
        <asp:RadioButton ID="rdIdeal" runat="server" Text="iDeal" GroupName="payment" />
        <asp:RadioButton ID="rdWallet" runat="server" Text="Steam Wallet" GroupName="payment" />
        <asp:Button runat="server" CssClass="button" ID="buy" Text="Buy these games." OnClick="buy_Click"/><br />
        
        <asp:DropDownList ID="dropDownWallet" runat="server"></asp:DropDownList><br/>
        <asp:Button runat="server" CssClass="button" Text="Add funds to wallet." ID="btnAddFunds" OnClick="btnAddFunds_Click"/>

    </form>
</body>
</html>
