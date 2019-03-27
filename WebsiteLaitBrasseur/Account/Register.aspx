<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebsiteLaitBrasseur.Account.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Registration</title>

    <meta name="viewport"  content="width=device-width; initial-scale=1"/>
    <link href="/Content/bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <link href="/Content/site.css" rel="stylesheet" />
    <script src="/Scripts/jquery-3.3.1.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>

</head>
<body>
    <header class="jumbotron">
        <h1>Registration</h1>
    </header>

    <form id="RegistrationForm" runat="server">
    <h4>  Create a new account</h4>
        <div class="form-group">
            <label for="TextUsername" class="control-label col-md-3">Username</label>
            <div class="col-md-5">
                <asp:TextBox ID="TextUsername" runat="server" Cssclass="form-control"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="UsernameReqField" runat="server"  ControlToValidate="TextUsername" Display="Dynamic" CssClass="text-danger" ErrorMessage="Username is required"></asp:RequiredFieldValidator><br />

            </div>
        </div>

        <div class="form-group">
                <label for="TextEmail" class="control-label col-md-3">E-mail</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextEmail" runat="server" Cssclass="form-control" TextMode="Email"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailReqField" runat="server"  ControlToValidate="TextEmail" Display="Dynamic" CssClass="text-danger" ErrorMessage="Email is required"></asp:RequiredFieldValidator><br />
                </div>
        </div>

       <div class="form-group">
            <label for="TextFirstName" class="control-label col-md-3">First name</label>
            <div class="col-md-5">
                <asp:TextBox ID="TextFirstName" runat="server" Cssclass="form-control"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="FirstNameReqField" runat="server"  ControlToValidate="TextFirstName" Display="Dynamic" CssClass="text-danger" ErrorMessage="First name is required"></asp:RequiredFieldValidator><br />
            </div>
        </div>

        <div class="form-group">
            <label for="TextLastName" class="control-label col-md-3">Last name</label>
            <div class="col-md-5">
                <asp:TextBox ID="TextLastName" runat="server" Cssclass="form-control"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="LastNameReqField" runat="server"  ControlToValidate="TextLastName" Display="Dynamic" CssClass="text-danger" ErrorMessage="Last name is required"></asp:RequiredFieldValidator><br />
            </div>
        </div>

        <div class="form-group">
                <label for="TextPassword" class="control-label col-md-3">Password</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextPassword" runat="server" Cssclass="form-control" TextMode="Password"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordField" runat="server"  ControlToValidate="TextPassword" Display="Dynamic" CssClass="text-danger" ErrorMessage="Password is required"></asp:RequiredFieldValidator><br />
                </div>
         </div>

         <div class="form-group">
                <label for="TextPasswordConf" class="control-label col-md-3">Confirm Password</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextPasswordConf" runat="server" Cssclass="form-control" TextMode="Password" > </asp:TextBox>
                    <asp:RequiredFieldValidator ID="ConfirmPasswordField" runat="server"  ControlToValidate="TextPasswordConf" Display="Dynamic" CssClass="text-danger" ErrorMessage="Confirm password is required"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="ConfirmReqField" runat="server"  ControlToCompare="TextPassword" ControlToValidate="TextPasswordConf" Display="Dynamic" CssClass="text-danger" ErrorMessage="The password and confirmation password do not match."></asp:CompareValidator>       
                </div>
         </div>

         <div class="col-md-offset-3 col-md-9">
                <asp:button ID="CancelButton" runat="server" Text="Cancel" CssClass="btn btn-primary" CausesValidation="False" OnClick="CancelButton_Click"/>
                <asp:Button ID="CreateAccountButton" runat="server" Text="Create Account" CssClass="btn btn-primary" OnClick="CreateAccountButton_Click"/>
         </div>
        
            <div class="col-md-9">
                <asp:Label ID="Label1" runat="server" CssClass="text-info"></asp:Label>
            </div>
    </form>
</body>
</html>
