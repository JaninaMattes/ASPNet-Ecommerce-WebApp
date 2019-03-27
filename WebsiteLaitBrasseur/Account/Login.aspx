<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebsiteLaitBrasseur.Account.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <meta name="viewport"  content="width=device-width; initial-scale=1"/>
    <link href="/Content/bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <link href="/Content/site.css" rel="stylesheet" />
    <script src="/Scripts/jquery-3.3.1.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>

    
</head>

<body> 
    <header class="jumbotron">
        <h1>Welcome on Lait Brasseur's website</h1>
        <img id="logoLB" alt="LaitBrasseur_Logo" src="/Images/laitBrasseurmin.jpg" class="img-rounded img-responsive" />
    </header>

    <main class="container">
        <form id="LoginForm" runat="server" class="form-horizontal">
            <div class="form-group">
                <label for="TextLogin" class="control-label col-md-3">Login</label>
                <div class="col-md-3">
                    <asp:TextBox ID="TextLogin" runat="server" Cssclass="form-control"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="LoginReqField" runat="server" ErrorMessage="Login is required" ControlToValidate="TextLogin" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                </div>
            </div>

            <div class="form-group">
                <label for="TextPassword" class="control-label col-md-3">Password</label>
                <div class="col-md-3">
                    <asp:TextBox ID="TextPassword" runat="server" Cssclass="form-control" TextMode="Password"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordReqField" runat="server" ErrorMessage="Password is required" ControlToValidate="TextPassword" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>


            <div class="form-group">
                <div class="col-md-offset-3 col-md-9">
                    <div class="checkbox">
                        <asp:CheckBox ID="RememberMeBox" runat="server" />
                        <label for="RememberMeBox" >Remember me ?</label>
                    </div>
                </div> 
            </div>


            <div class="col-md-offset-3 col-md-9">
                <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" CssClass="btn btn-primary"/>
                <a href='/Account/Logout.aspx'>Forgot password ?</a><br />
                <a href='/Account/Register.aspx'>Register</a>
            </div>


            <div class="col-md-offset-3 col-md-9">
                <asp:Label ID="Label1" runat="server" CssClass="text-info"></asp:Label>
            </div>

        </form>
    </main>
    <footer>
        <p> &copy; <%: DateTime.Now.Year %>  - <a runat="server" href="~/">About us</a> - <a runat="server" href="~/">Facebook</a> </p>
    </footer>
</body>
</html>