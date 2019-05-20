<%@ Page Language="C#" Title="Customer Profile" MasterPageFile="~/UL/Customer/Site.Master" AutoEventWireup="true" CodeBehind="DetailPageCustomer.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Customer.DetailPage" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<!--START UpdatePanel fEnables sections of a page to be partially rendered without a postback. -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

<!-- Content of detail view page-->
<div class="container-fluid">

        <div class="row">
            <div class="col-md-12" style="text-align: center;">
                <h1><asp:Label ID="headerTitle" runat="server" Text="Label"></asp:Label></h1>
                <p><asp:Label ID="headerSubtitle" runat="server"></asp:Label></p>
            </div> 
        </div>
        
        <div class="row">
                <!--Split view distribution of gui with product Image / Label Title / Label Description -->
                <div class="col-md-7">
                    <div id="image" class ="col-md-6" style="crop:insert-rect(0, 450, 350, 0)">
                        <asp:Image ID="destinationImg" runat="server" Width="450px" Height="300px"/>     
                    </div>  
                    <div class ="col-md-7" style="margin-top:10px; margin-bottom: 25px;">                                              
                    <h2><asp:Label ID="nameLabel" runat="server" style="text-align: left"></asp:Label></h2>
                <p><asp:Label ID="descriptionLabel" runat="server" style="text-align: left"></asp:Label></p>
             </div>
           </div>

                <div class="col-md-5">
                    <h3><asp:Label ID="LabelDetail" runat="server" Text="Product Detail Overview"></asp:Label></h3>

                    <!--Further product information about Price/ Total Amount / Product Quantity-->
                    <p>Product:</p><p><asp:Label ID="labelProduct" runat="server" Text="" CssClass="text-info"></asp:Label></p><br />
                    <p>Producer:</p><p><asp:Label ID="labelProducer" runat="server" Text="" CssClass="text-info"></asp:Label></p><br />
                    <p>Price:</p><p class="text-info"><asp:Label ID="labelPrice" runat="server" Text="" CssClass="text-info"></asp:Label> €</p><br/>

                    <!--Dropdown list with different sizes for the product to be selected-->
                    <p>Unit Size (gr):</p>
                    <asp:DropDownList ID="unitDropDownList" runat="server" Cssclass="form-control" AutoPostBack="true" >
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator InitialValue="-1" ID="Req_ID" Display="Dynamic" 
                         ValidationGroup="g1" runat="server" ControlToValidate="unitDropDownList"
                         Text="*" ErrorMessage="ErrorMessage" CssClass="text-danger">
                    </asp:RequiredFieldValidator>
                    </br>

                    <!--Dropdown list with max 10 entries selectable-->
                    <p>Quantity:</p>
                    <asp:DropDownList ID="quantityDropDownList" runat="server" Cssclass="form-control"  AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator1" Display="Dynamic" 
                         ValidationGroup="g1" runat="server" ControlToValidate="quantityDropDownList"
                         Text="*" ErrorMessage="ErrorMessage" CssClass="text-danger">
                    </asp:RequiredFieldValidator>
                    </br>

                    <p>Total Amount:</p><p><asp:Label ID="totalAmount" runat="server" Text="" CssClass="text-info"></asp:Label></p><br />
                    <div class ="col-md-6">                                              
                    <!--Button to add products to shopping list-->
                    Add a product to the shopping cart.<br />                   
                   <asp:button ID="AddProduct" ToolTip="Add product."  runat="server" Text="Add Product" class="btn btn-info"/><br />
             </div>
           </div>
                          
        </div>
    </div>

        <!--END UpdatePanel Enables sections of a page to be partially rendered without a postback. -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>