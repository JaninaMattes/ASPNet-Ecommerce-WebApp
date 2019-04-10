<%@ Page Language="C#" Title="Customer Profile" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailPage.aspx.cs" Inherits="WebsiteLaitBrasseur.Account.DetailPage" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<!-- Content of detail view page-->
<div class="container-fluid">

        <div class="row" style="border: solid; border-color: lightseagreen">
            <div class="col-md-12" style="text-align: center;">
                <h2><asp:Label ID="headerTitle" runat="server" Text="Label"></asp:Label></h2>
                <p><asp:Label ID="headerSubtitle" runat="server"></asp:Label></p>
            </div> 
        </div>
        
        <div class="row">
                <!--Split view distribution of gui with product Image / Label Title / Label Description -->
                <div class="col-md-8" style="border: solid; border-color: dodgerblue">
                    <div id="image" class ="col-md-6" style="crop">
                        <asp:Image ID="destinationImg" runat="server" Width="450px" Height="300px"/>     
                    </div>  
                    <div class ="col-md-6" style="border: solid; border-color: lightcoral">                                              
                    <h2><asp:Label ID="nameLabel" runat="server" Text="Label"></asp:Label></h2>
                <p><asp:Label ID="descriptionLabel" runat="server"></asp:Label></p>
             </div>
           </div>

                <div class="col-md-5" style="border: solid; border-color: fuchsia">
                    <h2><asp:Label ID="LabelDetail" runat="server" Text="Product Detail Overview"></asp:Label></h2>
                    <!--Further product information about Price/ Total Amount / Product Quantity-->
                    Product: <p><asp:Label ID="labelProduct" runat="server" Text=""></asp:Label></p><br />
                    Producer: <p><asp:Label ID="labelProducer" runat="server" Text=""></asp:Label></p><br />
                    Price: <p><asp:Label ID="labelPrice" runat="server" Text=""></asp:Label></p><br/>
                    <!--Dropdown list with different sizes for the product to be selected-->
                    Unit Size:
                    <asp:DropDownList ID="unitDropDownList" runat="server" Cssclass="form-control">
                               <asp:ListItem Value="1" Selected="true">250 gr</asp:ListItem>
                               <asp:ListItem Value="2">500 gr</asp:ListItem>
                               <asp:ListItem Value="3">750 gr</asp:ListItem>
                               <asp:ListItem Value="4">1000 gr</asp:ListItem>
                    </asp:DropDownList><b/>
                    <asp:RequiredFieldValidator InitialValue="-1" ID="Req_ID" Display="Dynamic" 
                         ValidationGroup="g1" runat="server" ControlToValidate="unitDropDownList"
                         Text="*" ErrorMessage="ErrorMessage" CssClass="text-danger">
                    </asp:RequiredFieldValidator>
                    <!--Dropdown list with max 10 entries selectable-->
                    Quantity:
                    <asp:DropDownList ID="quantityDropDownList" runat="server" Cssclass="form-control">
                               <asp:ListItem Value="0" Selected="true">0</asp:ListItem>
                               <asp:ListItem Value="1">1</asp:ListItem>
                               <asp:ListItem Value="2">2</asp:ListItem>
                               <asp:ListItem Value="3">3</asp:ListItem>
                               <asp:ListItem Value="4">4</asp:ListItem>
                               <asp:ListItem Value="5">5</asp:ListItem>
                               <asp:ListItem Value="6">6</asp:ListItem>
                               <asp:ListItem Value="7">7</asp:ListItem>
                               <asp:ListItem Value="8">8</asp:ListItem>
                               <asp:ListItem Value="9">9</asp:ListItem>
                               <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList><b/>
                    <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator1" Display="Dynamic" 
                         ValidationGroup="g1" runat="server" ControlToValidate="quantityDropDownList"
                         Text="*" ErrorMessage="ErrorMessage" CssClass="text-danger">
                    </asp:RequiredFieldValidator>
              
                    <hr />
                    Total Amount: <p><asp:Label ID="totalAmount" runat="server" Text=""></asp:Label></p><br />
                </div>
                <!--Button to add products to shopping list-->
                <div id="addButton" style="bottom">
        
                </div>
            
        </div>
    </div>

</asp:Content>