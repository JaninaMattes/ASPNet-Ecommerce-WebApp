<%@ Page Title="Default" Language="C#" MasterPageFile="~/UL/Customer/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Customer.Default" %>


<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">

    <!--Home Page Content-->
    <div class="container-fluid text-center">
        <br />

        <!--Welcoming picture -->


        <asp:Label ID="lblWelcome" Text="" runat="server" CssClass="center text-black-50 text-center" Font-Size="35px">WelcomeBienvenue</asp:Label><br />

        <div class="row">
            <!--Cheese products Picture with possiblity to navigate to product overview -->
            <div class="col-md-6 img-responsive text-center">
                <div class="col-md-3" style="margin-left: 30%">

                    <!--START Product CardView-->
                    <div id="cardView0" class="card">
                        <div id="img-cardview0">
                            <asp:ImageButton ID="img1" Width="340px" Heigth="100px" ToolTip="Select category." runat="server" ImageUrl="/UL/Images/cheese13.jpg" OnCommand="imgCommand" CommandArgument="Cheese" />
                        </div>
                        <div id="container0" class="container clearfix">
                            <div class="profile-usertitle">
                                <div id="information0" class="label label-default-large">
                                    <h4><b>
                                        <asp:Label ID="Title0" Text="" runat="server" />Lá Cheese</b></h4>
                                    <p><b>
                                        <asp:Label ID="Subtitle0" Text="" runat="server" />Collection of all products.</b></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
            </div>

            <!--Beer products Picture with possiblity to navigate to product overview -->
            <div class="col-md-6 img-responsive text-center">
                <div class="col-md-3 float-md-left">

                    <!--START Product CardView-->
                    <div id="cardView1" class="card">
                        <div id="img-cardview1">
                            <asp:ImageButton ID="img2" Width="340px" Heigth="100px" ToolTip="Select category." runat="server" ImageUrl="/UL/Images/beer1.jpg" OnCommand="imgCommand" CommandArgument="Beer" />
                        </div>
                        <div id="container1" class="container clearfix">
                            <div class="profile-usertitle">
                                <div id="information1" class="label label-default-large">
                                    <h4><b>
                                        <asp:Label ID="Title1" Text="" runat="server" />Lé Beer</b></h4>
                                    <p><b>
                                        <asp:Label ID="Subtitle1" Text="" runat="server" />Selected seasonal products.</b></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
