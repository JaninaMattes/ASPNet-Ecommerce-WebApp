<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductOverview.aspx.cs" Inherits="WebsiteLaitBrasseur.ProductOverview" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid" >
        <div class="row text-center" >

            <div class="col-md-4" >
                <div>
                    <img id="Brune" alt="Beer_Brown" src="/Images/Brune.jpg"  class="img-fluid rounded-circle"/> 
                </div>
                <div>
                    <asp:Label ID="NameBrune" runat="server" CssClass="text-left" Text="Roubignole"></asp:Label>
                    <asp:Label ID="PriceBrune" runat="server" CssClass="text-right" Text="7.5€"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="StockBrune" runat="server" CssClass="text-success" Text="In-stock"></asp:Label>
                </div>
            </div> 

            <div class="col-md-4" >
                <div>
                    <img id="Blonde" alt="Beer_Blonde" src="/Images/blond.jpg" class="img-fluid rounded-circle" /> 
                </div>
                <div>
                    <asp:Label ID="NameBlonde" runat="server" CssClass="text-left" Text="LaBlonde"></asp:Label>
                    <asp:Label ID="priceBlonde" runat="server" CssClass="text-right" Text="5.5€"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="StockBlonde" runat="server" CssClass="text-success" Text="In-stock"></asp:Label>
                </div>
                <br /><br />
            </div>
            

            <div class="col-md-4" >
                <div>
                    <img id="Blanche" alt="Beer_Blanche" src="/Images/blanche.jpg" class="img-fluid rounded-circle" />
                </div>
                <div>
                    <asp:Label ID="NameBlanche" runat="server" CssClass="text-left" Text="Blanchette"></asp:Label>
                    <asp:Label ID="PriceBlanche" runat="server" CssClass="text-right" Text="6€"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="StockBlanche" runat="server" CssClass="text-success" Text="In-stock"></asp:Label>
                </div>
            </div>


            <div class="col-md-4" >
                <div>
                    <img id="Carre" alt="Cheese" src="/Images/cheese_carre_est.jpg" class="img-fluid rounded-circle"/> 
                </div>
                <div>
                    <asp:Label ID="NameCarreEst" runat="server" CssClass="text-left" Text="Carre de l'Est"></asp:Label>
                    <asp:Label ID="PriceCarreEst" runat="server" CssClass="text-right" Text="8€"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="StockCarreEst" runat="server" CssClass="text-success" Text="In-stock"></asp:Label>
                </div>
            </div>


            <div class="col-md-4" >
                <div>
                    <img id="Raclette" alt="Cheese_Raclette" src="/Images/cheese_raclette.jpg"  class="img-fluid rounded-circle"/> 
                </div>
                <div>
                    <asp:Label ID="NameRaclette" runat="server" CssClass="text-left" Text="Raclette"></asp:Label>
                    <asp:Label ID="PriceRaclette" runat="server" CssClass="text-right" Text="12€"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="StockRaclette" runat="server" CssClass="text-success" Text="In-stock"></asp:Label>
                </div>
            </div>

            <div class="col-md-4" >
                <div>
                    <img id="Spice" alt="Cheese-spice" src="/Images/cheese_spice.jpg"  class="img-fluid rounded-circle"/>
                </div>
                <div>
                    <asp:Label ID="NameSpice" runat="server" CssClass="text-left" Text="Spicy cheese"></asp:Label>
                    <asp:Label ID="PriceSpice" runat="server" CssClass="text-right" Text="2€"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="StockSpice" runat="server" CssClass=" text-warning" Text="Low Stock"></asp:Label>
                </div>
            </div>

        </div>

    </div>
</asp:Content>
