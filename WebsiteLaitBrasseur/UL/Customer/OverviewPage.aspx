﻿<%@ Page Language="C#" Title="Product Overview" MasterPageFile="~/UL/Customer/Site.Master" AutoEventWireup="true" CodeBehind="OverviewPage.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Customer.OverviewPage" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
 <!--START UpdatePanel fEnables sections of a page to be partially rendered without a postback. -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

<div class="container-fluid">

  <h1>Product Overview</h1>
  <p><b><asp:Label id="Subtitle_Warn" Text="" runat="server" /></b></p>

    <div class="row">
  
    <asp:Repeater ID="ImageRepeater" runat="server" >
     <ItemTemplate>

      <div class="col-md-3">
        <!--1 Col Product card nested in repeater control-->
        <!--START Product CardView-->
            <div id="cardView" >
            <div id="img-cardview"  >
                <asp:ImageButton id="img1" runat="server" class="img-fluid justify-content-center"  ToolTip="Select a product" ImageUrl='<%# Eval("imgPath") %>'   CommandArgument='<%# Eval("ID") %>'  OnCommand="imgCommand"/> 
            </div>
            <div id="container1" class="container clearfix">
            <div class="profile-usertitle">
				<div id="information1" class="label label-default-large">
				    <h4><b><asp:Label id="Title" Text="" runat="server" /><%# Eval("Name")%></b></h4>
                    <p><b><asp:Label id="Subtitle" Text="" runat="server" /><%# Eval("ShortInfo")%></b></p>
			    </div>
                <div id="card-footer1" class="card-footer">
                    <hr/>
                    <!--START Footer CardView-->
                    <table style="width:100%; margin-left: 0px; background-color: white">
                        <tr>
                            <th><p>Status</p></th>
                            <td><asp:Label id="LabelAvailable" Text="" runat="server" style="color:aquamarine"/><%# Eval("Status")%></td> 
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

    <!--END UpdatePanel Enables sections of a page to be partially rendered without a postback. -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>