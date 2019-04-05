<%@ Page Language="C#" Title="Product Overview" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OverviewPage.aspx.cs" Inherits="WebsiteLaitBrasseur.Account.WebForm1" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

<div class="container-fluid" style="width: 100%;">
    
    <h1>.</h1>
    <!-- set a dynamically exchangeable title--> <h2><%: Page.Title %></h2>

  <div class="row">
  
    <asp:Repeater ID="ImageRepeater" runat="server">
     <ItemTemplate>

      <div class="col-md-4">
        <!--1 Col Product card nested in repeater control-->
        <!--START Product CardView-->
            <div id="cardView" class="card">
            <div id="img-cardview" class="crop">
        
                <asp:ImageButton id="img1" runat="server" ImageUrl='<%# Eval("ImagePath") %>'  OnCommand="img1_Command" CommandArgument='<%# Eval("Id") %>'/>
                <asp:Image id="Image1" runat="server" AlternateText="Product Image" ImageUrl="/Images/cheese15.jpg" Width="100%" />
                
            </div>
            <div id="container1" class="container clearfix">
            <div class="profile-usertitle">
				<div id="information1" class="label label-default-large">
				    <h4><b><asp:Label id="Title" Text="Product Title" runat="server" /></b></h4>
                    <p><b><asp:Label id="Subtitle" Text="Product Subtitle" runat="server" /></b></p>
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

 </ItemTemplate>
</asp:Repeater>
</div>

</div>

</asp:Content>