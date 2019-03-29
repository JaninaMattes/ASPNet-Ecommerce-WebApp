<%@ Page Title="Accueil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebsiteLaitBrasseur.Default" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <div class="text-center">
        <img id="Img_prez" alt="LaitBrasseur_Prez" src="/Images/beers_prez.jpg"  style="width:auto;height:auto" />
    </div>

    <div class="container">
        <img id="Beer_prez" alt="LaitBrasseur_Beers" src="/Images/beer_button.jpg"  style="float:left;width:25%;height:25%"  />
        <asp:Button ID="BeerButton" runat="server" Text="Beers" OnClick="BeerButton_Click" CssClass="btn btn-primary"/>

        <img id="Cheese_prez" alt="LaitBrasseur_Cheese" src="/Images/cheese_carre.jpg"  style="float:right;width:25%;height:25%"/>
        <asp:Button ID="ChesseButton" runat="server" Text="Chesse" OnClick="CheeseButton_Click" CssClass="btn btn-primary"/>
    </div>
    





</asp:Content>
