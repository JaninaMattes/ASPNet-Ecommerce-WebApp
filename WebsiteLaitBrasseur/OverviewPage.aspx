<%@ Page Language="C#" Title="Product Overview" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OverviewPage.aspx.cs" Inherits="WebsiteLaitBrasseur.Account.OverviewPage" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

<div class="container-fluid">

  <h1>Product Overview</h1>
  <p><b><asp:Label id="Subtitle_Warn" Text="" runat="server" /></b></p>

  <div class="row">
  
    <asp:Repeater ID="ImageRepeater" runat="server" OnItemCommand="ImageRepeater_ItemCommand">
     <ItemTemplate>

      <div class="col-md-3">
        <!--1 Col Product card nested in repeater control-->
        <!--START Product CardView-->
            <div id="cardView" class="card">
            <div id="img-cardview" class="crop text-center" style="crop:rect(0, 340px, 220px, 0);">
                <asp:ImageButton id="img1" runat="server" ImageUrl='<%# Eval("ImagePath") %>'  OnCommand="imgCommand" CommandArgument='<%# Eval("Id") %>'/>      
            </div>
            <div id="container1" class="container clearfix">
            <div class="profile-usertitle">
				<div id="information1" class="label label-default-large">
				    <h4><b><asp:Label id="Title" Text="" runat="server" /><%# Eval("ProductName")%></b></h4>
                    <p><b><asp:Label id="Subtitle" Text="" runat="server" /><%# Eval("ShortDescription")%></b></p>
			    </div>
                <div id="card-footer1" class="card-footer">
                    <hr/>
                    <!--START Footer CardView-->
                    <table style="width:94%; margin-left: 0px; background-color: white">
                        <tr>
                            <th><p>Price</p></th>
                            <td><asp:Label id="LabelPrice" Text="" runat="server"/><%# Eval("Price")%> €</td>
                            <th><p>Size</p></th>
                            <td><asp:Label id="LabelAmount" Text="" runat="server"/><%# Eval("Unit")%> </td>
                            <th><p>Status</p></th>
                            <td><asp:Label id="LabelAvailable" Text="" runat="server" style="color:aquamarine; margin: 5%"/><%# Eval("Available")%></td> 
                        </tr>
                    </table>
                    <!--END Footer CardView-->
                </div>
            </div>
        </div>
     </div>
  </div><br />

 </ItemTemplate>
</asp:Repeater>
</div>

</div>

</asp:Content>