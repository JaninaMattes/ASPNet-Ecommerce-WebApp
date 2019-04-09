<%@ Page Title="Accueil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebsiteLaitBrasseur.Default"%>


<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
<<<<<<< HEAD

<!--Home Page Content-->
    <div class="container-fluid text-center" >
        <br />
=======
  
<!--Home Page -->

    <div class="container-fluid text-center" >
        <br />
       <h1> <asp:Label ID="lblWelcome" runat="server" style="font-family:cursive;color:yellowgreen;" ></asp:Label>  </h1>


>>>>>>> f3f42df0f11a9a8769d53d9df77f123322f9c69e
        <!--Welcoming picture -->
        <div class="col-md-12 text-center crop">
            <img id="ImgHome" alt="LaitBrasseur_Prez" src="/Images/brewery.jpg" style="width: 95%; height: 250px;"/>
            <div class="centered" style="width: 200px; height: 50px; background-color: white;">
                <asp:Label ID="lblWelcome" Text="" runat="server" CssClass="align-content-center text-black-50 text-center">Welcome & Bienvenue</asp:Label>
            </div>
        </div>

        <div class="row">
               <!--Cheese products Picture with possiblity to navigate to product overview -->
               <div class="col-md-6 img-responsive text-center" style="border:double; border-color: red">
                    <div class="col-md-3">
    
                <!--START Product CardView-->
                <div id="cardView0" class="card">
                <div id="img-cardview0" class="crop">
                    <asp:ImageButton id="img1" runat="server" ImageUrl="/Images/cheese11.jpg" OnCommand="imgCommand" CommandArgument="cheese"/>      
                </div>
                <div id="container0" class="container clearfix">
                    <div class="profile-usertitle">
				    <div id="information0" class="label label-default-large">
				        <h4><b><asp:Label id="Title0" Text="" runat="server" />Lá Cheese</b></h4>
                        <p><b><asp:Label id="Subtitle0" Text="" runat="server" />Collection of all products.</b></p>
			        </div>
                </div>
            </div>
        </div>
    </div><br />
 </div>

               <!--Beer products Picture with possiblity to navigate to product overview -->
               <div class="col-md-6 img-responsive text-center" style="border:double; border-color: red">
                    <div class="col-md-3">
    
                <!--START Product CardView-->
                <div id="cardView1" class="card">
                <div id="img-cardview1" class="crop">
                    <asp:ImageButton id="ImageButton1" runat="server" ImageUrl="/Images/beer1.jpg" OnCommand="imgCommand" CommandArgument="beer"/>      
                </div>
                <div id="container1" class="container clearfix">
                    <div class="profile-usertitle">
				    <div id="information1" class="label label-default-large">
				        <h4><b><asp:Label id="Title1" Text="" runat="server" />Lé Beer</b></h4>
                        <p><b><asp:Label id="Subtitle1" Text="" runat="server" />Selected seasonal products.</b></p>
			        </div>
                </div>
            </div>
        </div>
    </div><br />
 
        </div>
    </div>
 </div>
</asp:Content>
