<%@ Page Language="C#" Title="Register" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebsiteLaitBrasseur.Account.Register" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

<!--Page managing the registration of a new user -->

    <h3>  Create a new account</h3>

        <!--Label /TextBox / Validator for E-mail -->
        <div class="form-group">
                <label for="TextEmail" class="control-label col-md-3">E-mail</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextEmail" runat="server" Cssclass="form-control" TextMode="Email"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailReqField" runat="server"  ControlToValidate="TextEmail" Display="Dynamic" CssClass="text-danger" ErrorMessage="Email is required"></asp:RequiredFieldValidator><br />
                </div>
        </div>

       <!--Label /TextBox / Validator for First Name -->
       <div class="form-group">
            <label for="TextFirstName" class="control-label col-md-3">First name</label>
            <div class="col-md-5">
                <asp:TextBox ID="TextFirstName" runat="server" Cssclass="form-control"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="FirstNameReqField" runat="server"  ControlToValidate="TextFirstName" Display="Dynamic" CssClass="text-danger" ErrorMessage="First name is required"></asp:RequiredFieldValidator><br />
            </div>
        </div>

       <!--Label /TextBox / Validator for Last Name -->
        <div class="form-group">
            <label for="TextLastName" class="control-label col-md-3">Last name</label>
            <div class="col-md-5">
                <asp:TextBox ID="TextLastName" runat="server" Cssclass="form-control"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="LastNameReqField" runat="server"  ControlToValidate="TextLastName" Display="Dynamic" CssClass="text-danger" ErrorMessage="Last name is required"></asp:RequiredFieldValidator><br />
            </div>
        </div>

       <!--Label /TextBox / Validator for BirthDay -->
        <div class="form-group">
            <label for="TextBirthday" class="control-label col-md-3">Birthdate</label>
            <div class="col-md-5">
                <asp:TextBox ID="TextBirthday" runat="server" Cssclass="form-control" TextMode="Date" > </asp:TextBox>
                <asp:RequiredFieldValidator ID="BirthdayReqField" runat="server"  ControlToValidate="TextBirthday" Display="Dynamic" CssClass="text-danger" ErrorMessage="Birthdate is required"></asp:RequiredFieldValidator><br />
            </div>
        </div>



        <!--Label /TextBox / Validator for Password -->
        <div class="form-group">
                <label for="TextPassword" class="control-label col-md-3">Password</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextPassword" runat="server" Cssclass="form-control" TextMode="Password"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordField" runat="server"  ControlToValidate="TextPassword" Display="Dynamic" CssClass="text-danger" ErrorMessage="Password is required"></asp:RequiredFieldValidator><br />
                </div>
         </div>

         <!--Label /TextBox / Validator(compare with first password entry) for Confirm Password -->
         <div class="form-group">
                <label for="TextPasswordConf" class="control-label col-md-3">Confirm Password</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextPasswordConf" runat="server" Cssclass="form-control" TextMode="Password" > </asp:TextBox>
                    <asp:RequiredFieldValidator ID="ConfirmPasswordField" runat="server"  ControlToValidate="TextPasswordConf" Display="Dynamic" CssClass="text-danger" ErrorMessage="Confirm password is required"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="PasswordCompValid" runat="server"  ControlToCompare="TextPassword" ControlToValidate="TextPasswordConf" Display="Dynamic" CssClass="text-danger" ErrorMessage="The password and confirmation password do not match."></asp:CompareValidator>       
                </div>
         </div>

         <!--Label /TextBox /  Validator(+format phone number validator) for the Phone number-->
         <div class="form-group">
            <label for="TextPhone" class="control-label col-md-3">Phone Number</label>
            <div class="col-md-5">
                <asp:TextBox ID="TextPhone" runat="server" Cssclass="form-control" TextMode="Phone"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="PhoneReqField" runat="server" ErrorMessage="Phone is required" ControlToValidate="TextPhone" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:regularExpressionValidator ID="PhoneRegValid" runat="server" ErrorMessage="Should be 10 Digits or '+' and 11 Digits" ControlToValidate="TextPhone" Display="Dynamic"  ValidationExpression="(\+\d{1})?\d{10}$" CssClass="text-danger"></asp:RegularExpressionValidator><br />
            </div>
        </div>

        <!--"Create Account" button &  "Cancel" Button => Back to Default.aspx -->
         <div class="col-md-offset-3 col-md-9">
                <asp:button ID="CancelButton" runat="server" Text="Cancel" CssClass="btn btn-primary" CausesValidation="False" OnClick="CancelButton_Click"/>
                <asp:Button ID="CreateAccountButton" runat="server" Text="Create Account" CssClass="btn btn-primary" OnClick="CreateAccountButton_Click"/>
         </div>
        
            <div class="col-md-9">
                <asp:Label ID="Label1" runat="server" CssClass="text-info"></asp:Label>
            </div>
</asp:Content>
