<%@ Page Title="Accueil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebsiteLaitBrasseur.Default" %>






<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
            <img id="Img_prez" alt="LaitBrasseur_Prez" src="/Images/beers_prez.jpg" Class="offset-2" style="width:auto;height:auto" />

    </div>

<div class="container-fluid">
    <div class="row">
            <div class="col-md-6 img-responsive">
                <asp:button ID="beer_button" runat="server" Text="Beer" class="btn btn-primary" />
                <img id="Beer_prez" alt="LaitBrasseur_Beers" src="/Images/beer_button.jpg"  />
            </div>
           <div class="col-md-6 img-responsive">
                <img id="Cheese_prez" alt="LaitBrasseur_Cheese" src="/Images/cheese_carre.jpg"  class="offset-6"/>
                <asp:button ID="Chesse_button" runat="server" Text="Cheese" class="btn btn-primary"/>
           </div>
    </div>
</div>



</asp:Content>
