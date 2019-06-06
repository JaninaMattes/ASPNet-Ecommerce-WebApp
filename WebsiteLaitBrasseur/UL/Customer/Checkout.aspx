<%@ Page Title="Checkout" Language="C#" MasterPageFile="~/UL/Customer/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Customer.Checkout" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <!--Page managing the checkout -->

    <!--Global container for the form -->
    <div class="container-fluid col-md-4"  >

            <asp:Label ID="lblResult" runat="server" Text="" CssClass="text-info" style="font-size:25px" ></asp:Label>
            <asp:Label ID="lblArrivalDate" runat="server" Text="" CssClass="text-info" style="font-size:25px" ></asp:Label>
    </div>
</asp:Content>
