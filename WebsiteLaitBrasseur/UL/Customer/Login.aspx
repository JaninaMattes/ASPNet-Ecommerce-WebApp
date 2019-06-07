<%@ Page Language="C#" Title="Login" MasterPageFile="~/UL/Customer/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Customer.LoginWebForm" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <!--Page managing the login of an user to his account -->
    <div class="container-fluid ">
        <!--Title of the form -->
        <h1>Welcome on Lait Brasseur's website</h1>

        <!--Label /TextBox / Validator for the Email -->
        <div class="form-group">
            <label for="TextEmail" class="control-label col-md-3">E-mail</label>
            <div class="col-md-3">
                <asp:TextBox ID="TextEmail" runat="server" ToolTip="Enter email." CssClass="form-control" TextMode="Email"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="EmailReqField" runat="server" ErrorMessage="Email is required" ControlToValidate="TextEmail" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="EmailRegValid" runat="server" ControlToValidate="TextEmail" ValidationExpression=".*@.*\.[a-z][a-z](m)?" ErrorMessage="Please, enter a correct email" CssClass="text-danger"></asp:RegularExpressionValidator>
            </div>
        </div>

        <!--Label /TextBox / Validator for the password -->
        <div class="form-group">
            <label for="TextPassword" class="control-label col-md-3">Password</label>
            <div class="col-md-3">
                <asp:TextBox ID="TextPassword" runat="server" ToolTip="Enter password." CssClass="form-control" TextMode="Password"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordReqField" runat="server" ErrorMessage="Password is required" ControlToValidate="TextPassword" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
        </div>

        <!--Login/Register button & Forgot Password link -->
        <div class="col-md-offset-3 col-md-9">
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" CssClass="btn btn-primary" />
            <a href='/UL/Customer/EmailRecuperation.aspx'>Forgot password ?</a>
            <br />
            <asp:Button ID="Register" runat="server" Text="Register" OnClick="RegisterButton_Click" CausesValidation="False" CssClass="btn btn-info" />

        </div>


        <div class="col-md-offset-3 col-md-9">
            <asp:Label ID="LblErrorMessage" runat="server" CssClass="text-info"></asp:Label>
        </div>
    </div>
</asp:Content>
