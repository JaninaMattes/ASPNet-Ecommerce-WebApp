<%@ Page Language="C#" Title="Product Overview" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OverviewPage.aspx.cs" Inherits="WebsiteLaitBrasseur.Account.WebForm1" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

<div class="container-fluid" style="width: 100%;">
    
    <h1>.</h1>
    <!-- set a dynamically exchangeable title--> <h2><%: Page.Title %></h2>

  <div class="row">
  
      <div class="col-md-3">
        <!--1 Col Product card nested later in gridview to show latest collection of aviable products-->
        <!--START Product CardView-->
            <div id="cardView1" class="card">
            <div id="img-cardview1" class="crop">
                 <a href="ProductDetails.aspx">
                <asp:Image id="Image1" runat="server" AlternateText="Product Image" ImageUrl="/Images/cheese15.jpg" Width="100%" />
                </a>
            </div>
            <div id="container1" class="container clearfix">
            <div class="profile-usertitle">
				<div id="information1" class="label label-default-large">
				    <h4><b><asp:Label id="Title1" Text="Blue Cheese de Avignón" runat="server" /></b></h4>
                    <p><b><asp:Label id="Subtitle1" Text="Special Product Choice" runat="server" /></b></p>
			    </div>
                <div id="card-footer1" class="card-footer">
                    <hr/>
                    <!--START Footer CardView-->
                    <table style="width:94%; margin-left: 0px; background-color: white">
                        <tr>
                            <th><p>Price</p></th>
                            <th><asp:Label id="Price1" Text="14.99€" runat="server"/></th>
                            <th><asp:Label id="Amount1" Text="259gr" runat="server"/></th>
                            <th><asp:Label id="Available1" Text="Available" runat="server" style="color:aquamarine; margin: 5%"/></th> 
                        </tr>
                    </table>
                    <!--END Footer CardView-->
                </div>
            </div>
        </div>
     </div>
  </div>

    <div class="col-md-3">
    <!--1 Col Product card nested later in gridview to show latest collection of aviable products-->
    <!--START Product CardView-->
    <div id="cardView2" class="card">
        <div id="img-cardview2" class="crop">
            <a href="ProductDetails.aspx">
            <asp:Image id="Image2" runat="server" AlternateText="Product Image" ImageUrl="/Images/cheese11.jpg" Width="100%" />
            </a>
        </div>
        <div id="container2" class="container clearfix">
            <div class="profile-usertitle">
				<div id="information2" class="label label-default-large">
				    <h4><b><asp:Label id="Title2" Text="Fourmet dé Ambert" runat="server" /></b></h4>
                    <p><b><asp:Label id="Subtitle2" Text="Special Product Choice" runat="server" /></b></p>
			    </div>
                <div id="card-footer2" class="card-footer">
                    <hr/>
                    <!--START Footer CardView-->
                    <table style="width:94%; margin-left: 0px; background-color: white">
                        <tr>
                            <th><p>Price</p></th>
                            <th><asp:Label id="Price2" Text="25.99€" runat="server"/></th>
                            <th><asp:Label id="Amount2" Text="239gr" runat="server"/></th>
                            <th><asp:Label id="Available2" Text="Available" runat="server" style="color:aquamarine; margin: 5%"/></th> 
                        </tr>
                    </table>
                    <!--END Footer CardView-->
                </div>
             </div>
          </div>
       </div>
     </div>

      <div class="col-md-3">
        <!--1 Col Product card nested later in gridview to show latest collection of aviable products-->
        <!--START Product CardView-->
            <div id="cardView3" class="card">
            <div id="img-cardview3" class="crop">
                <a href="ProductDetails.aspx">
                <asp:Image id="Image3" runat="server" AlternateText="Product Image" ImageUrl="/Images/cheese12.jpg" Width="100%" />
                </a>
            </div>
            <div id="container3" class="container clearfix">
            <div class="profile-usertitle">
				<div id="information3" class="label label-default-large">
				    <h4><b><asp:Label id="Title3" Text="Roquefort Golden" runat="server" /></b></h4>
                    <p><b><asp:Label id="Subtitle3" Text="Special Product Choice" runat="server" /></b></p>
			    </div>
                <div id="card-footer3" class="card-footer">
                    <hr/>
                    <!--START Footer CardView-->
                    <table style="width:94%; margin-left: 0px; background-color: white">
                        <tr>
                            <th><p>Price</p></th>
                            <th><asp:Label id="Price3" Text="11.99€" runat="server"/></th>
                            <th><asp:Label id="Amount3" Text="239gr" runat="server"/></th>
                            <th><asp:Label id="Availble3" Text="Available" runat="server" style="color:aquamarine; margin: 5%"/></th> 
                        </tr>
                    </table>
                    <!--END Footer CardView-->
                </div>
          </div>
        </div>
     </div>
  </div>


   <div class="col-md-3"    >
   <!--1 Col Product card nested later in gridview to show latest collection of aviable products-->
   <!--START Product CardView-->
    <div id="cardView4" class="card">
        <div id="img-cardview4" class="crop">
            <a href="ProductDetails.aspx">
            <asp:Image id="Image4" runat="server" AlternateText="Product Image" ImageUrl="/Images/cheese10.jpg" Width="100%" />
            </a>
        </div>
        <div id="container4" class="container clearfix">
            <div class="profile-usertitle">
				<div id="information4" class="label label-default-large">
				    <h4><b><asp:Label id="Title4" Text="Brie dé Meaux" runat="server" /></b></h4>
                    <p><b><asp:Label id="Subtitle4" Text="Special Product Choice" runat="server" /></b></p>
			    </div>
                <div id="card-footer4" class="card-footer">
                    <hr/>
                    <!--START Footer CardView-->
                    <table style="width:94%; margin-left: 0px;">
                        <tr>
                            <th><p>Price</p></th>
                            <th><asp:Label id="Price4" Text="18.99€" runat="server"/></th>
                            <th><asp:Label id="Amount4" Text="239gr" runat="server"/></th>
                            <th><asp:Label id="Available4" Text="Available" runat="server" style="color:aquamarine; margin: 5%"/></th> 
                        </tr>
                    </table>
                    <!--END Footer CardView-->
                </div>
            </div>
        </div>
        </div>
        </div>

    </div>

    <div class="row">
  
      <div class="col-md-3">
        <!--1 Col Product card nested later in gridview to show latest collection of aviable products-->
        <!--START Product CardView-->
            <div id="cardView5" class="card">
            <div id="img-cardview5" class="crop">
                 <a href="ProductDetails.aspx">
                <asp:Image id="Image5" runat="server" AlternateText="Product Image" ImageUrl="/Images/cheese16.jpg" Width="100%" />
                </a>
            </div>
            <div id="container5" class="container clearfix">
            <div class="profile-usertitle">
				<div id="information5" class="label label-default-large">
				    <h4><b><asp:Label id="Label" Text="Blue Cheese de Avignón" runat="server" /></b></h4>
                    <p><b><asp:Label id="Label2" Text="Special Product Choice" runat="server" /></b></p>
			    </div>
                <div id="card-footer5" class="card-footer">
                    <hr/>
                    <!--START Footer CardView-->
                    <table style="width:94%; margin-left: 0px; background-color: white">
                        <tr>
                            <th><p>Price</p></th>
                            <th><asp:Label id="Label3" Text="14.99€" runat="server"/></th>
                            <th><asp:Label id="Label4" Text="259gr" runat="server"/></th>
                            <th><asp:Label id="Label5" Text="Available" runat="server" style="color:aquamarine; margin: 5%"/></th> 
                        </tr>
                    </table>
                    <!--END Footer CardView-->
                </div>
            </div>
        </div>
     </div>
  </div>

    <div class="col-md-3">
    <!--1 Col Product card nested later in gridview to show latest collection of aviable products-->
    <!--START Product CardView-->
    <div id="cardView6" class="card">
        <div id="img-cardview6" class="crop">
            <a href="ProductDetails.aspx">
            <asp:Image id="Image6" runat="server" AlternateText="Product Image" ImageUrl="/Images/cheese17.jpg" Width="100%" />
            </a>
        </div>
        <div id="container6" class="container clearfix">
            <div class="profile-usertitle">
				<div id="information6" class="label label-default-large">
				    <h4><b><asp:Label id="Label6" Text="Fourmet dé Ambert" runat="server" /></b></h4>
                    <p><b><asp:Label id="Label7" Text="Special Product Choice" runat="server" /></b></p>
			    </div>
                <div id="card-footer6" class="card-footer">
                    <hr/>
                    <!--START Footer CardView-->
                    <table style="width:94%; margin-left: 0px; background-color: white">
                        <tr>
                            <th><p>Price</p></th>
                            <th><asp:Label id="Label8" Text="25.99€" runat="server"/></th>
                            <th><asp:Label id="Label9" Text="239gr" runat="server"/></th>
                            <th><asp:Label id="Label10" Text="Available" runat="server" style="color:aquamarine; margin: 5%"/></th> 
                        </tr>
                    </table>
                    <!--END Footer CardView-->
                </div>
             </div>
          </div>
       </div>
     </div>

      <div class="col-md-3">
        <!--1 Col Product card nested later in gridview to show latest collection of aviable products-->
        <!--START Product CardView-->
            <div id="cardView7" class="card">
            <div id="img-cardview7" class="crop">
                <a href="ProductDetails.aspx">
                <asp:Image id="Image7" runat="server" AlternateText="Product Image" ImageUrl="/Images/cheese18.jpg" Width="100%" />
                </a>
            </div>
            <div id="container7" class="container clearfix">
            <div class="profile-usertitle">
				<div id="information7" class="label label-default-large">
				    <h4><b><asp:Label id="Label11" Text="Roquefort Golden" runat="server" /></b></h4>
                    <p><b><asp:Label id="Label12" Text="Special Product Choice" runat="server" /></b></p>
			    </div>
                <div id="card-footer7" class="card-footer">
                    <hr/>
                    <!--START Footer CardView-->
                    <table style="width:94%; margin-left: 0px; background-color: white">
                        <tr>
                            <th><p>Price</p></th>
                            <th><asp:Label id="Label13" Text="11.99€" runat="server"/></th>
                            <th><asp:Label id="Label14" Text="239gr" runat="server"/></th>
                            <th><asp:Label id="Label15" Text="Available" runat="server" style="color:aquamarine; margin: 5%"/></th> 
                        </tr>
                    </table>
                    <!--END Footer CardView-->
                </div>
          </div>
        </div>
     </div>
  </div>


   <div class="col-md-3"    >
   <!--1 Col Product card nested later in gridview to show latest collection of aviable products-->
   <!--START Product CardView-->
    <div id="cardView8" class="card">
        <div id="img-cardview8" class="crop">
            <a href="ProductDetails.aspx">
            <asp:Image id="Image8" runat="server" AlternateText="Product Image" ImageUrl="/Images/cheese19.jpg" Width="100%" />
            </a>
        </div>
        <div id="container8" class="container clearfix">
            <div class="profile-usertitle">
				<div id="information8" class="label label-default-large">
				    <h4><b><asp:Label id="Label16" Text="Brie dé Meaux" runat="server" /></b></h4>
                    <p><b><asp:Label id="Label17" Text="Special Product Choice" runat="server" /></b></p>
			    </div>
                <div id="card-footer8" class="card-footer">
                    <hr/>
                    <!--START Footer CardView-->
                    <table style="width:94%; margin-left: 0px;">
                        <tr>
                            <th><p>Price</p></th>
                            <th><asp:Label id="Label18" Text="18.99€" runat="server"/></th>
                            <th><asp:Label id="Label19" Text="239gr" runat="server"/></th>
                            <th><asp:Label id="Label20" Text="Available" runat="server" style="color:aquamarine; margin: 5%"/></th> 
                        </tr>
                    </table>
                    <!--END Footer CardView-->
                </div>
            </div>
        </div>
        </div>
        </div>

    </div>
   </div>

</asp:Content>