<%@ Page Language="C#" Title="Log In" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login2.aspx.cs" Inherits="WebsiteLaitBrasseur.Account.WebForm1" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
        <h1>Welcome on Lait Brasseur's website</h1>

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

</asp:Content>