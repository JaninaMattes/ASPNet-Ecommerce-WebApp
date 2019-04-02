<%@ Page Title="LogIn" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" Inherits="WebsiteLaitBrasseur.Admin.LoginAdmin" %>




<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
  <!--Page managing the login of an Admin to his account -->

            <div class="container-fluid">

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


                    <!--Login/Register button -->
                    <div class="col-md-offset-3 col-md-9">
                        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" CssClass="btn btn-primary"/>
                        <asp:Button ID="Register" runat="server" Text="Register" OnClick="RegisterButton_Click" CausesValidation="False" CssClass="btn btn-info"/>

                    </div>


                    <div class="col-md-offset-3 col-md-9">
                        <asp:Label ID="Label1" runat="server" CssClass="text-info"></asp:Label>
                    </div>
            </div>


</asp:Content>
