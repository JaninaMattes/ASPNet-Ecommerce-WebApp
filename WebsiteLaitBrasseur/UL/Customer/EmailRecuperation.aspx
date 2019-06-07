<%@ Page Title="Recuperation Email" Language="C#" MasterPageFile="~/UL/Customer/Site.Master" AutoEventWireup="true" CodeBehind="EmailRecuperation.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Customer.EmailRecuperation" %>



<asp:Content ID="EmailRecuperation" ContentPlaceHolderID="MainContent" runat="server">

    <!--Page where the user give his email to get a password reinitialization link-->

    <div class="container-fluid col-md-6 text-center">
        <h3>Password Recuperation </h3>
        <br />

        <asp:Label ID="lblResult" runat="server" Text="" CssClass="text-success"></asp:Label><br />
        <br />

        <label for="TextEmail" class="control-label text-info" style="font-size: 20px">Please enter your email address :</label>

        <div class="container-fluid col-md-6">
            <!--Label /TExtBox /Validator for email Recuperation -->
            <asp:TextBox ID="TextEmail" runat="server" ToolTip="Enter email." CssClass=" text-center form-control" TextMode="Email"> </asp:TextBox>
            <asp:RequiredFieldValidator ID="EmailReqField" runat="server" ErrorMessage="Email is required" ControlToValidate="TextEmail" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="EmailRegValid" runat="server" ControlToValidate="TextEmail" ValidationExpression=".*@.*\.[a-z][a-z](m)?" ErrorMessage="Please, enter a correct email" CssClass="text-danger"></asp:RegularExpressionValidator>
            <asp:Button ID="ValidationButton" runat="server" Text="Send Email" OnClick="ValidationButton_Click" CausesValidation="true" CssClass="btn btn-primary" />
        </div>

    </div>
</asp:Content>
