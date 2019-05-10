<%@ Page Title="Verification Page" Language="C#" MasterPageFile="/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="VerificationPage.aspx.cs" Inherits="WebsiteLaitBrasseur.Admin.VerificationPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<!--Page managing the email confirmation of new admin registered -->

    <div class="text-center text-info">
            <h3> <asp:Label ID="lblRegistrationResult" runat="server" Text="No Verif" CssClass="text-success"></asp:Label> </h3>
    </div>


</asp:Content>
