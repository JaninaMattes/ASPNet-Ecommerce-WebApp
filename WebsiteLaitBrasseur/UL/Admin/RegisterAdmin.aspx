﻿<%@ Page Title="Admin Registration" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="RegisterAdmin.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Admin.RegisterAdmin" %>



<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--START UpdatePanel fEnables sections of a page to be partially rendered without a postback. -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <!--Page managing the registration of a new admin -->

            <h3>Create a new Admin account</h3>

            <!--Label result to inform the user that a confirmation email has been sent -->
            <div class="col-md-9">
                <asp:Label ID="lblRegResult" runat="server" CssClass="text-danger"></asp:Label>
            </div>


            <!--Label /TextBox / Validators for E-mail -->
            <div class="form-group">
                <label for="TextEmail" class="control-label col-md-3 text-info">E-mail</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextEmail" runat="server" CssClass="form-control" TextMode="Email"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailReqField" runat="server" ControlToValidate="TextEmail" Display="Dynamic" CssClass="text-danger" ErrorMessage="Email is required"></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="EmailRegValid" runat="server" ControlToValidate="TextEmail" ValidationExpression=".*@.*\.[a-z][a-z](m)?" ErrorMessage="Please, enter a correct email" CssClass="text-danger"></asp:RegularExpressionValidator>

                </div>
            </div>

            <!--Label /TextBox / Validator(compare with first email entry) for Confirm Email -->
            <div class="form-group">
                <label for="TextEmailConf" class="control-label col-md-3 text-info">Confirm E-mail</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextEmailConf" runat="server" CssClass="form-control" TextMode="Email"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailConfReqField" runat="server" ControlToValidate="TextEmailConf" Display="Dynamic" CssClass="text-danger" ErrorMessage="Confirm email is required"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="EmailCompValid" runat="server" ControlToCompare="TextEmail" ControlToValidate="TextEmailConf" Display="Dynamic" CssClass="text-danger" ErrorMessage="The email and confirmation email do not match."></asp:CompareValidator>
                </div>
            </div>


            <!--Label /TextBox / Validator for First Name -->
            <div class="form-group">
                <label for="TextFirstName" class="control-label col-md-3 text-info">First name</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextFirstName" runat="server" CssClass="form-control"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="FirstNameReqField" runat="server" ControlToValidate="TextFirstName" Display="Dynamic" CssClass="text-danger" ErrorMessage="First name is required"></asp:RequiredFieldValidator><br />
                </div>
            </div>

            <!--Label /TextBox / Validator for Last Name -->
            <div class="form-group">
                <label for="TextLastName" class="control-label col-md-3 text-info">Last name</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextLastName" runat="server" CssClass="form-control"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="LastNameReqField" runat="server" ControlToValidate="TextLastName" Display="Dynamic" CssClass="text-danger" ErrorMessage="Last name is required"></asp:RequiredFieldValidator><br />
                </div>
            </div>

            <!--Label /TextBox / Validator for BirthDay -->
            <div class="form-group">
                <label for="TextBirthday" class="control-label col-md-3 text-info">Birthdate</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextBirthday" runat="server" CssClass="form-control" TextMode="Date"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="BirthdayReqField" runat="server" ControlToValidate="TextBirthday" Display="Dynamic" CssClass="text-danger" ErrorMessage="Birthdate is required"></asp:RequiredFieldValidator><br />
                </div>
            </div>


            <!--Label /TextBox / Validator for Password -->
            <div class="form-group">
                <label for="TextPassword" class="control-label col-md-3 text-info">Password</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextPassword" runat="server" CssClass="form-control" TextMode="Password"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordField" runat="server" ControlToValidate="TextPassword" Display="Dynamic" CssClass="text-danger" ErrorMessage="Password is required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="PasswordReqValid" runat="server" ControlToValidate="TextPassword" ValidationExpression="^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9#?!@$%^&*-]).{8,}$" ErrorMessage="The password format does not meet the requirements." CssClass="text-danger"></asp:RegularExpressionValidator>
                    <br />
                    <asp:Label ID="lblRequirement" runat="server" CssClass="text-info" Text="(8 characters : at least 1 upper case, 1 lower case, one number or one special character)"></asp:Label>

                </div>
            </div>

            <!--Label /TextBox / Validator(compare with first password entry) for Confirm Password -->
            <div class="form-group">
                <label for="TextPasswordConf" class="control-label col-md-3 text-info">Confirm Password</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextPasswordConf" runat="server" CssClass="form-control" TextMode="Password"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="ConfirmPasswordField" runat="server" ControlToValidate="TextPasswordConf" Display="Dynamic" CssClass="text-danger" ErrorMessage="Confirm password is required"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="PasswordCompValid" runat="server" ControlToCompare="TextPassword" ControlToValidate="TextPasswordConf" Display="Dynamic" CssClass="text-danger" ErrorMessage="The password and confirmation password do not match."></asp:CompareValidator>
                </div>
            </div>

            <!--Label /TextBox /  Validator(+format phone number validator) for the Phone number-->
            <div class="form-group">
                <label for="TextPhone" class="control-label col-md-3 text-info">Phone Number</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextPhone" runat="server" CssClass="form-control" TextMode="Phone"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="PhoneReqField" runat="server" ErrorMessage="Phone is required" ControlToValidate="TextPhone" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="PhoneRegValid" runat="server" ErrorMessage="Should be 10 Digits or '+' and 11 Digits" ControlToValidate="TextPhone" Display="Dynamic" ValidationExpression="(\+\d{1})?\d{10}$" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                </div>
            </div>

            <!--"Create Account" button &  "Cancel" Button  -->
            <div class="col-md-offset-3 col-md-9">
                <asp:Button ID="CreateAccountButton" runat="server" Text="Create Account" CssClass="btn btn-primary" OnClick="CreateAccountButton_Click" />
                <asp:Button ID="CancelButton" runat="server" Text="Cancel" CssClass="btn btn-danger" CausesValidation="False" OnClick="CancelButton_Click" />
            </div>

            <!--END UpdatePanel Enables sections of a page to be partially rendered without a postback. -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
