<%@ Page Title="Accueil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebsiteLaitBrasseur.Default" %>


<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">

<!--Home Page -->

    <div class="container-fluid text-center" >
        <br />
       <h1> <asp:Label ID="lblWelcome" runat="server" style="font-family:cursive;color:yellowgreen;" Text="Welcome"></asp:Label>  </h1>


        <!--Welcoming picture -->
        <div class="col-md-12 text-center">
            <img id="Img_prez" alt="LaitBrasseur_Prez" src="/Images/beers_prez.jpg" class="img rounded img-fluid" style="width:auto;height:auto" />
        </div>

        <div class="row">
               <!--Beer Picture with Button to product overview -->
               <div class="col-md-6 img-responsive text-center">
                    <asp:button ID="beer_button" runat="server" Text="Beer" class="btn btn-primary" OnClick="BeerButton_Click"/>
                    <img id="Beer_prez" alt="LaitBrasseur_Beers" src="/Images/beer_button.jpg" class="rounded" style="width:150px;height:150px"/>
               </div>

               <!--Cheese Picture with Button to product overview -->
               <div class="col-md-6 img-responsive text-center">
                    <img id="Cheese_prez" alt="LaitBrasseur_Cheese" src="/Images/cheese_carre.jpg"  class="rounded" style="width:150px;height:150px"/>
                    <asp:button ID="Chesse_button" runat="server" Text="Cheese" class="btn btn-primary" OnClick="CheeseButton_Click"/>
               </div>
        </div>
    </div>

</asp:Content>
