<%@ Page Language="C#" Title="Log In" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login2.aspx.cs" Inherits="WebsiteLaitBrasseur.Account.WebForm1" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

<!--Page managing the login of an user to his account -->
    <a href="CustomerProfile.aspx">CustomerProfile.aspx</a>
            <div class="container-fluid " >
                    <!--Title of the form -->
                    <h1>Welcome on Lait Brasseur's website</h1>
                <a href="CustomerProfile.aspx">CustomerProfile.aspx</a>
                    <!--Label /TextBox / Validator for the login -->
                    <div class="form-group">
                        <label for="TextLogin" class="control-label col-md-3">Login</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="TextLogin" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="LoginReqField" runat="server" ErrorMessage="Login is required" ControlToValidate="TextLogin" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                        </div>
                    </div>

                    <!--Label /TextBox / Validator for the password -->
                    <div class="form-group">
                        <label for="TextPassword" class="control-label col-md-3">Password</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="TextPassword" runat="server" Cssclass="form-control" TextMode="Password"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordReqField" runat="server" ErrorMessage="Password is required" ControlToValidate="TextPassword" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <!--Remerber Me checkBox-->
                    <div class="form-group">
                        <div class="col-md-offset-3 col-md-9">
                            <div class="checkbox">
                                <asp:CheckBox ID="RememberMeBox" runat="server" />
                                <label for="RememberMeBox" >Remember me ?</label>
                            </div>
                        </div> 
                    </div>

                    <!--Login/Register button & Forgot Password link -->
                    <div class="col-md-offset-3 col-md-9">
                        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" CssClass="btn btn-primary"/>
                        <a href='/Account/Logout.aspx'>Forgot password ?</a><br />
                        <asp:Button ID="Register" runat="server" Text="Register" OnClick="RegisterButton_Click" CausesValidation="False" CssClass="btn btn-info"/>

                    </div>


                    <div class="col-md-offset-3 col-md-9">
                        <asp:Label ID="Label1" runat="server" CssClass="text-info"></asp:Label>
                    </div>
            </div>
</asp:Content>