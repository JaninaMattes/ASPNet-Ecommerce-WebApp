<%@ Page Title="Cart" Language="C#" MasterPageFile="~/UL/Customer/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Customer.Cart" %>


<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
<!--START UpdatePanel fEnables sections of a page to be partially rendered without a postback. -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<!--Page managing  a "fake" cart-->

    <div class="container-fluid ">
    
        <!--Global container with the differents Items and the Summary -->
        <div  class="col-md-12 row text-center"   >

            <div class="col-md-7"  >
                <div id="CartTitle1" runat="server" class="ContentHead">
                    <h1>Shopping Cart</h1>
                </div>

                <!--Shopping Card Legend-->
                <div class="col-md-12 row rounded justify-content-center"  style="border:solid;border-color:grey;">
                   <div class="col-md-3" >
                       <asp:Label ID="LegendImage" runat="server" cssclass="text-info" Text="Image"></asp:Label>                 
                   </div>

                   <div class="col-md-2" >
                       <asp:Label ID="LegendNamePrice" runat="server" cssclass="text-info" Text="Name/Price"></asp:Label>                 
                   </div>

                   <div class="col-md-2" >
                       <asp:Label ID="LegendQuantity" runat="server" cssclass="text-info" Text="Quantity"></asp:Label>                 
                   </div>

                   <div class="col-md-2" >
                       <asp:Label ID="LegendTotal" runat="server" cssclass="text-info" Text="Total Price"></asp:Label>                 
                   </div>

                    <div class="col-md-1">
                        <asp:Label ID="LegendRemove" runat="server" cssclass="text-info" Text="Remove Item"></asp:Label> 
                    </div>
                </div>


                <!--First Item : Image / Name + Price / Dropdown List for quantity / CheckBox to remove the Item-->
                <div class="col-md-12 row rounded justify-content-center"  style="border:solid;border-color:grey;height:160px;">
                   <div class="col-md-3" >
                       <img id="Brune" alt="Beer_Brown" src="https://images.pexels.com/photos/8812/food-wood-night-alcohol.jpg?auto=compress&cs=tinysrgb&dpr=1&w=500"  class="img-fluid rounded"/>                 
                   </div>

                   <div class="col-md-2  ">
                       <asp:Label ID="NameBrune" runat="server" cssclass="text-info " Text="Fleurac La Triple IPA"></asp:Label><br />
                       <asp:Label ID="PriceBrune" runat="server" cssclass="text-info" Text="14,95"></asp:Label>
                       <asp:Label  runat="server" cssclass="text-info" Text="€"></asp:Label>
                   </div>

                   <div class="col-md-2   ">
                   <!--Dropdown list to select the quantity of products-->
                   <asp:DropDownList ID="QuantityBrune" runat="server">
                       <asp:ListItem Selected="True" Value="1"></asp:ListItem>
                       <asp:ListItem  Value="2"></asp:ListItem>
                       <asp:ListItem  Value="4"></asp:ListItem>
                       <asp:ListItem  Value="5"></asp:ListItem>
                       <asp:ListItem  Value="6"></asp:ListItem>
                       <asp:ListItem  Value="7"></asp:ListItem>
                       <asp:ListItem  Value="8"></asp:ListItem>
                       <asp:ListItem  Value="9"></asp:ListItem>
                       <asp:ListItem  Value="10"></asp:ListItem>
                
                   </asp:DropDownList>

                   </div>

                   <!--Label for total price -->
                   <div class="col-md-2   ">
                      <asp:Label ID="TotalBrune" runat="server" cssclass="text-info " Text=""></asp:Label>
                       <asp:Label  runat="server" cssclass="text-info" Text="€"></asp:Label>
                   </div>


                   <div class="col-md-1">
                        <asp:checkbox ID="checkboxBrune" runat="server" />
                   </div>
                </div>

                <!--Second Item-->
                <div class="col-md-12 row rounded justify-content-center"  style="border:solid;border-color:grey;height:160px">
                   <div class="col-md-3" ">
                       <img id="Blonde" alt="Beer_Blonde" src="https://images.pexels.com/photos/1089930/pexels-photo-1089930.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500" class="img-fluid rounded" />                     
                   </div>

                   <div class="col-md-2">
                       <asp:Label ID="NameBlonde" runat="server" cssclass="text-info " Text="Pilsener de Rockefort"></asp:Label><br />
                       <asp:Label ID="PriceBlonde" runat="server" cssclass="text-info" Text="9,95"></asp:Label>
                       <asp:Label  runat="server" cssclass="text-info" Text="€"></asp:Label>
                   </div>

                   <div class="col-md-2 ">
                   <asp:DropDownList ID="QuantityBlonde" runat="server">
                       <asp:ListItem Selected="True" Value="1"></asp:ListItem>
                       <asp:ListItem  Value="2"></asp:ListItem>
                       <asp:ListItem  Value="3"></asp:ListItem>
                       <asp:ListItem  Value="4"></asp:ListItem>
                       <asp:ListItem  Value="5"></asp:ListItem>
                       <asp:ListItem  Value="6"></asp:ListItem>
                       <asp:ListItem  Value="7"></asp:ListItem>
                       <asp:ListItem  Value="8"></asp:ListItem>
                       <asp:ListItem  Value="9"></asp:ListItem>
                       <asp:ListItem  Value="10"></asp:ListItem>
                    
                   </asp:DropDownList>
                   </div>

                   <div class="col-md-2 ">
                      <asp:Label ID="TotalBlonde" runat="server" cssclass="text-info " Text=""></asp:Label>
                       <asp:Label  runat="server" cssclass="text-info" Text="€"></asp:Label>
                   </div>

                   <div class="col-md-1">
                        <asp:checkbox ID="checkBoxBlonde" runat="server" />
                   </div>
                </div>


                <!--Third Item-->
                <div class="col-md-12 row rounded justify-content-center"  style="border:solid;border-color:grey;height:160px">
                   <div class="col-md-3" ">
                       <img id="Blanche" alt="Beer_Blanche" src="https://images.pexels.com/photos/1727829/pexels-photo-1727829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500" class="img-fluid rounded"/>                  
                   </div>

                   <div class="col-md-2">
                       <asp:Label ID="NameBlanche" runat="server" cssclass="text-info " Text="La Choulette Blonde"></asp:Label><br />
                       <asp:Label ID="PriceBlanche" runat="server" cssclass="text-info" Text="10,95"></asp:Label>
                       <asp:Label  runat="server" cssclass="text-info" Text="€"></asp:Label>
                   </div>

                   <div class="col-md-2  ">
                   <asp:DropDownList ID="QuantityBlanche" runat="server">
                       <asp:ListItem Selected="True" Value="1"></asp:ListItem>
                       <asp:ListItem  Value="2"></asp:ListItem>
                       <asp:ListItem  Value="3"></asp:ListItem>
                       <asp:ListItem  Value="4"></asp:ListItem>
                       <asp:ListItem  Value="5"></asp:ListItem>
                       <asp:ListItem  Value="6"></asp:ListItem>
                       <asp:ListItem  Value="7"></asp:ListItem>
                       <asp:ListItem  Value="8"></asp:ListItem>
                       <asp:ListItem  Value="9"></asp:ListItem>
                       <asp:ListItem  Value="10"></asp:ListItem>
                     
                   </asp:DropDownList>
                   </div>

                   <div class="col-md-2 ">
                      <asp:Label ID="TotalBlanche" runat="server" cssclass="text-info " Text=""></asp:Label>
                       <asp:Label  runat="server" cssclass="text-info" Text="€"></asp:Label>
                   </div>

                   <div class="col-md-1">
                        <asp:checkbox ID="checkBoxBlanche" runat="server" />
                   </div>
                </div>

                <!--Fourth Item-->
                <div class="col-md-12 row rounded justify-content-center"  style="border:solid;border-color:grey;height:160px">
                   <div class="col-md-3" ">
                       <img id="Carre" alt="Cheese" src="https://cdn.pixabay.com/photo/2016/01/19/16/57/cheese-1149471__340.jpg" class="img-fluid rounded"/>                  
                   </div>

                   <div class="col-md-2 ">
                       <asp:Label ID="NameCheese" runat="server" cssclass="text-info " Text="Brie de Meaux"></asp:Label><br />
                       <asp:Label ID="PriceCheese" runat="server" cssclass="text-info" Text="11,95"></asp:Label>
                       <asp:Label  runat="server" cssclass="text-info" Text="€"></asp:Label>
                   </div>

                   <div class="col-md-2 ">
                   <asp:DropDownList ID="QuantityCheese" runat="server">
                       <asp:ListItem Selected="True" Value="1"></asp:ListItem>
                       <asp:ListItem  Value="2"></asp:ListItem>
                       <asp:ListItem  Value="4"></asp:ListItem>
                       <asp:ListItem  Value="5"></asp:ListItem>
                       <asp:ListItem  Value="6"></asp:ListItem>
                       <asp:ListItem  Value="7"></asp:ListItem>
                       <asp:ListItem  Value="8"></asp:ListItem>
                       <asp:ListItem  Value="9"></asp:ListItem>
                       <asp:ListItem  Value="10"></asp:ListItem>
           
                   </asp:DropDownList>
                   </div>
                   <div class="col-md-2 ">
                      <asp:Label ID="TotalCheese" runat="server" cssclass="text-info " Text=""></asp:Label>
                       <asp:Label  runat="server" cssclass="text-info" Text="€"></asp:Label>
                   </div>

                   <div class="col-md-1">
                        <asp:checkbox ID="checkBoxCheese" runat="server" />
                   </div>
                </div>


            </div> 

            <!--Summary : updated via the "update" button-->
            <div class="col-md-2 offset-1" >
                 <div id="CartTitle2" runat="server" class="ContentHead"><h1>Summary</h1><br /></div>
                 <div style="font-size:20px">

                     <!--Sum prices of items -->
                     <asp:Label ID="Amount" runat="server" cssclass="text-info  " Text="Amount : "></asp:Label>
                     <asp:Label ID="AmountValue" runat="server" cssclass="text-info" Text=""></asp:Label>
                     <asp:Label  runat="server" cssclass="text-info" Text="€"></asp:Label><br /> <br /><br />

                     <!-- Shipping cost will apply -->
                     <!--Label /DropDown List for the Postage Options-->
                      <label for="PostageDropDownList"  class="text-info">Postage</label>
                      <asp:DropDownList ID="PostageDropDownList" runat="server" Cssclass="form-control">
                          <asp:ListItem Value="1" Selected="true">Provider 1 : 2,95€</asp:ListItem>
                          <asp:ListItem Value="2">Provider 2 : 5,95€</asp:ListItem>
                          <asp:ListItem Value="3">Provider 3 : 7,95€</asp:ListItem>
                      </asp:DropDownList>
                     <br />



                     <!-- Tax will apply -->
                     <asp:Label ID="Tax" runat="server" cssclass="text-info " Text="Tax (%) : "></asp:Label>
                     <asp:Label ID="TaxValue" runat="server" cssclass="text-info" Text=" 20"></asp:Label><br /><br /><br />

                     <!--Final cost including shipping cost and tax -->
                     <asp:Label ID="TotalCost" runat="server" cssclass="text-info " Text="Total Cost : "></asp:Label>
                     <asp:Label ID="TotalCostValue" runat="server" cssclass="text-info " Text=""></asp:Label>
                     <asp:Label  runat="server" cssclass="text-info" Text="€"></asp:Label><br /><br /><br />

                     <!--"Update" button to actualize informations in Summary part" -->
                     <asp:Button ID="saveButton" runat="server" Text="Save Changes" OnClick="saveButton_Click" ValidationGroup="Quantity" CssClass="btn btn-primary"/><br /><br /><br />

                     <!--"CreditCard" button to get to the credit card page" -->
                     <asp:button ID="CreditCardButton" runat="server" CssClass="btn btn-success" Text="Credit Card" OnClick="CreditCardButton_Click"/>

                     <!--"PayPal" button Buy to get to the paypal page -->
                     <asp:button ID="PaypalButton" runat="server" CssClass="btn btn-success" Text="Paypal" OnClick="PaypalButton_Click"/>

                     <!--"Change Address" Button to get to the shipping address page -->
                     <br /><br />
                     <asp:button ID="ChangeAddressButton" runat="server" CssClass="btn btn-info" Text="Change Address" OnClick="ChangeAddressButton_Click" />

                 </div>
            </div>
        </div>
    </div>

    <!--END UpdatePanel Enables sections of a page to be partially rendered without a postback. -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
