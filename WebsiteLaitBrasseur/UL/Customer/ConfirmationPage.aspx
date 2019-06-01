<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Customer/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmationPage.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Customer.ConfirmationPage" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--START UpdatePanel fEnables sections of a page to be partially rendered without a postback. -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

        <!--Page managing the email confirmation of new admin registered -->

        <div class="text-center text-info">
                <h3> <asp:Label ID="lblRegistrationResult" runat="server" Text="No Verif" CssClass="text-success"></asp:Label> </h3>
        </div>

        <!--END UpdatePanel Enables sections of a page to be partially rendered without a postback. -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>