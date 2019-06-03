<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Customer/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Customer.Checkout" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <!--Page managing the checkout -->

    <!--Global container for the form -->
    <div class="container-fluid col-md-4"  ">

            <h3>Result</h3>

            <asp:Label ID="lblResult" runat="server" Text="" CssClass="text-info"></asp:Label>
    </div>
</asp:Content>
