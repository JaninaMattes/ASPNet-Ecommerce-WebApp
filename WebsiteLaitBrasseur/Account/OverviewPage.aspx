<%@ Page Language="C#" Title="Product Overview" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OverviewPage.aspx.cs" Inherits="WebsiteLaitBrasseur.Account.WebForm1" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="container-fluid">
 <div class="row-fluid">
  <div class="col-md-12">
    
    <h1>Product Overview</h1>
    <!-- set a dynamically exchangeable title--> <h2><%: Page.Title %></h2>

  <div class="col-md-6">
    <div class="row-fluid">
      <div class="col-md-3">
        <!--1 Col Product card nested later in gridview to show latest collection of aviable products-->
        <!--START Product CardView-->
            <div id="cardView1" class="card">
            <div id="img-cardview1" class="img-cardview">
                <asp:Image id="Image1" runat="server" AlternateText="Product Image" ImageUrl="/Images/cheese15.jpg" Width="100%" />
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
                    <table style="width:94%; margin-left: 0px;">
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
        <div id="img-cardview2" class="img-cardview">
            <asp:Image id="Image2" runat="server" AlternateText="Product Image" ImageUrl="/Images/cheese15.jpg" Width="100%" />
        </div>
        <div id="container2" class="container clearfix">
            <div class="profile-usertitle">
				<div id="information2" class="label label-default-large">
				    <h4><b><asp:Label id="Title2" Text="Blue Cheese de Avignón" runat="server" /></b></h4>
                    <p><b><asp:Label id="Subtitle2" Text="Special Product Choice" runat="server" /></b></p>
			    </div>
                <div id="card-footer2" class="card-footer">
                    <hr/>
                    <!--START Footer CardView-->
                    <table style="width:94%; margin-left: 0px;">
                        <tr>
                            <th><p>Price</p></th>
                            <th><asp:Label id="Price2" Text="14.99€" runat="server"/></th>
                            <th><asp:Label id="Amount2" Text="259gr" runat="server"/></th>
                            <th><asp:Label id="Available2" Text="Available" runat="server" style="color:aquamarine; margin: 5%"/></th> 
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
      
 <div class="col-md-6">
    <div class="row-fluid">
      <div class="col-md-3">
        <!--1 Col Product card nested later in gridview to show latest collection of aviable products-->
        <!--START Product CardView-->
            <div id="cardView3" class="card">
            <div id="img-cardview3" class="img-cardview">
                <asp:Image id="Image3" runat="server" AlternateText="Product Image" ImageUrl="/Images/cheese15.jpg" Width="100%" />
            </div>
            <div id="container3" class="container clearfix">
            <div class="profile-usertitle">
				<div id="information3" class="label label-default-large">
				    <h4><b><asp:Label id="Title3" Text="Blue Cheese de Avignón" runat="server" /></b></h4>
                    <p><b><asp:Label id="Subtitle3" Text="Special Product Choice" runat="server" /></b></p>
			    </div>
                <div id="card-footer3" class="card-footer">
                    <hr/>
                    <!--START Footer CardView-->
                    <table style="width:94%; margin-left: 0px;">
                        <tr>
                            <th><p>Price</p></th>
                            <th><asp:Label id="Price3" Text="14.99€" runat="server"/></th>
                            <th><asp:Label id="Amount3" Text="259gr" runat="server"/></th>
                            <th><asp:Label id="Availble3" Text="Available" runat="server" style="color:aquamarine; margin: 5%"/></th> 
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
    <div id="cardView4" class="card">
        <div id="img-cardview4" class="img-cardview">
            <asp:Image id="Image4" runat="server" AlternateText="Product Image" ImageUrl="/Images/cheese15.jpg" Width="100%" />
        </div>
        <div id="container4" class="container clearfix">
            <div class="profile-usertitle">
				<div id="information4" class="label label-default-large">
				    <h4><b><asp:Label id="Title4" Text="Blue Cheese de Avignón" runat="server" /></b></h4>
                    <p><b><asp:Label id="Subtitle4" Text="Special Product Choice" runat="server" /></b></p>
			    </div>
                <div id="card-footer4" class="card-footer">
                    <hr/>
                    <!--START Footer CardView-->
                    <table style="width:94%; margin-left: 0px;">
                        <tr>
                            <th><p>Price</p></th>
                            <th><asp:Label id="Price4" Text="14.99€" runat="server"/></th>
                            <th><asp:Label id="Amount4" Text="259gr" runat="server"/></th>
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
 </div>
</div>
</div>
</div>
</asp:Content>