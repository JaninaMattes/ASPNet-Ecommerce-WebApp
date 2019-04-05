<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebsiteLaitBrasseur.Cart" %>


<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">

<!--Page managing  a "fake" cart-->

    <div class="container-fluid ">

        <!--Global container with the differents Items and the Summary -->
        <div class="col-md-12 row text-center" "  >

            <div class="col-md-7"  >
                <div id="CartTitle1" runat="server" class="ContentHead"><h1>Shopping Cart</h1></div>
                <!--Legend-->
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
                <div class="col-md-12 row rounded justify-content-center"  style="border:solid;border-color:grey;height:150px;">
                   <div class="col-md-3" >
                       <img id="Brune" alt="Beer_Brown" src="/Images/Brune.jpg"  class="img-fluid"/>                 
                   </div>

                   <div class="col-md-2  ">
                       <asp:Label ID="NameBrune" runat="server" cssclass="text-info " Text="Blackaty"></asp:Label><br />
                       <asp:Label ID="PriceBrune" runat="server" cssclass="text-info" Text="3"></asp:Label>
                       <asp:Label  runat="server" cssclass="text-info" Text="€"></asp:Label>
                   </div>

                   <div class="col-md-2   ">
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
                       <asp:ListItem  Value="11"></asp:ListItem>
                       <asp:ListItem  Value="12"></asp:ListItem>
                       <asp:ListItem  Value="13"></asp:ListItem>
                       <asp:ListItem  Value="14"></asp:ListItem>
                       <asp:ListItem  Value="15"></asp:ListItem>
                       <asp:ListItem  Value="16"></asp:ListItem>
                       <asp:ListItem  Value="17"></asp:ListItem>
                       <asp:ListItem  Value="18"></asp:ListItem>
                       <asp:ListItem  Value="19"></asp:ListItem>
                       <asp:ListItem  Value="20"></asp:ListItem>
                   </asp:DropDownList>


                   </div>

                   <div class="col-md-2   ">
                      <asp:Label ID="TotalBrune" runat="server" cssclass="text-info " Text=""></asp:Label>
                       <asp:Label  runat="server" cssclass="text-info" Text="€"></asp:Label>
                   </div>

                   <div class="col-md-1">
                        <asp:checkbox ID="checkboxBrune" runat="server" />
                   </div>
                </div>

                <!--Second Item-->
                <div class="col-md-12 row rounded justify-content-center"  style="border:solid;border-color:grey;height:150px">
                   <div class="col-md-3" ">
                       <img id="Blonde" alt="Beer_Blonde" src="/Images/blond.jpg" class="img-fluid" />                     
                   </div>

                   <div class="col-md-2">
                       <asp:Label ID="NameBlonde" runat="server" cssclass="text-info " Text="LaBlonde"></asp:Label><br />
                       <asp:Label ID="PriceBlonde" runat="server" cssclass="text-info" Text="2"></asp:Label>
                       <asp:Label  runat="server" cssclass="text-info" Text="€"></asp:Label>
                   </div>

                   <div class="col-md-2 ">
                   <asp:DropDownList ID="QuantityBlonde" runat="server">
                       <asp:ListItem Selected="True" Value="1"></asp:ListItem>
                       <asp:ListItem  Value="2"></asp:ListItem>
                       <asp:ListItem  Value="4"></asp:ListItem>
                       <asp:ListItem  Value="5"></asp:ListItem>
                       <asp:ListItem  Value="6"></asp:ListItem>
                       <asp:ListItem  Value="7"></asp:ListItem>
                       <asp:ListItem  Value="8"></asp:ListItem>
                       <asp:ListItem  Value="9"></asp:ListItem>
                       <asp:ListItem  Value="10"></asp:ListItem>
                       <asp:ListItem  Value="11"></asp:ListItem>
                       <asp:ListItem  Value="12"></asp:ListItem>
                       <asp:ListItem  Value="13"></asp:ListItem>
                       <asp:ListItem  Value="14"></asp:ListItem>
                       <asp:ListItem  Value="15"></asp:ListItem>
                       <asp:ListItem  Value="16"></asp:ListItem>
                       <asp:ListItem  Value="17"></asp:ListItem>
                       <asp:ListItem  Value="18"></asp:ListItem>
                       <asp:ListItem  Value="19"></asp:ListItem>
                       <asp:ListItem  Value="20"></asp:ListItem>
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
                <div class="col-md-12 row rounded justify-content-center"  style="border:solid;border-color:grey;height:150px">
                   <div class="col-md-3" ">
                       <img id="Blanche" alt="Beer_Blanche" src="/Images/blanche.jpg" class="img-fluid"/>                  
                   </div>

                   <div class="col-md-2">
                       <asp:Label ID="NameBlanche" runat="server" cssclass="text-info " Text="Blanchette"></asp:Label><br />
                       <asp:Label ID="PriceBlanche" runat="server" cssclass="text-info" Text="1,5"></asp:Label>
                       <asp:Label  runat="server" cssclass="text-info" Text="€"></asp:Label>
                   </div>

                   <div class="col-md-2  ">
                   <asp:DropDownList ID="QuantityBlanche" runat="server">
                       <asp:ListItem Selected="True" Value="1"></asp:ListItem>
                       <asp:ListItem  Value="2"></asp:ListItem>
                       <asp:ListItem  Value="4"></asp:ListItem>
                       <asp:ListItem  Value="5"></asp:ListItem>
                       <asp:ListItem  Value="6"></asp:ListItem>
                       <asp:ListItem  Value="7"></asp:ListItem>
                       <asp:ListItem  Value="8"></asp:ListItem>
                       <asp:ListItem  Value="9"></asp:ListItem>
                       <asp:ListItem  Value="10"></asp:ListItem>
                       <asp:ListItem  Value="11"></asp:ListItem>
                       <asp:ListItem  Value="12"></asp:ListItem>
                       <asp:ListItem  Value="13"></asp:ListItem>
                       <asp:ListItem  Value="14"></asp:ListItem>
                       <asp:ListItem  Value="15"></asp:ListItem>
                       <asp:ListItem  Value="16"></asp:ListItem>
                       <asp:ListItem  Value="17"></asp:ListItem>
                       <asp:ListItem  Value="18"></asp:ListItem>
                       <asp:ListItem  Value="19"></asp:ListItem>
                       <asp:ListItem  Value="20"></asp:ListItem>
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
                <div class="col-md-12 row rounded justify-content-center"  style="border:solid;border-color:grey;height:150px">
                   <div class="col-md-3" ">
                       <img id="Carre" alt="Cheese" src="/Images/cheese_carre_est.jpg" class="img-fluid"/>                  
                   </div>

                   <div class="col-md-3 ">
                       <asp:Label ID="NameCheese" runat="server" cssclass="text-info " Text="Le carré de l'Est"></asp:Label><br />
                       <asp:Label ID="PriceCheese" runat="server" cssclass="text-info" Text="8"></asp:Label>
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
                       <asp:ListItem  Value="11"></asp:ListItem>
                       <asp:ListItem  Value="12"></asp:ListItem>
                       <asp:ListItem  Value="13"></asp:ListItem>
                       <asp:ListItem  Value="14"></asp:ListItem>
                       <asp:ListItem  Value="15"></asp:ListItem>
                       <asp:ListItem  Value="16"></asp:ListItem>
                       <asp:ListItem  Value="17"></asp:ListItem>
                       <asp:ListItem  Value="18"></asp:ListItem>
                       <asp:ListItem  Value="19"></asp:ListItem>
                       <asp:ListItem  Value="20"></asp:ListItem>
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
                     <asp:Label ID="ShippingCost" runat="server" cssclass="text-info " Text="Shipping Cost : "></asp:Label>
                     <asp:Label ID="ShippingCostValue" runat="server" cssclass="text-info " Text="4"></asp:Label>
                     <asp:Label  runat="server" cssclass="text-info" Text="€"></asp:Label><br /><br /><br />

                     <!-- Tax will apply -->
                     <asp:Label ID="Tax" runat="server" cssclass="text-info " Text="Tax (%) : "></asp:Label>
                     <asp:Label ID="TaxValue" runat="server" cssclass="text-info" Text=" 20"></asp:Label><br /><br /><br />

                     <!--Final cost including shipping cost and tax -->
                     <asp:Label ID="TotalCost" runat="server" cssclass="text-info " Text="Total Cost : "></asp:Label>
                     <asp:Label ID="TotalCostValue" runat="server" cssclass="text-info " Text=""></asp:Label>
                     <asp:Label  runat="server" cssclass="text-info" Text="€"></asp:Label><br /><br /><br />

                     <!--"Update" button to actualize informations in Summary part" -->
                     <asp:Button ID="updateButton" runat="server" Text="Update" OnClick="updateButton_Click" ValidationGroup="Quantity" CssClass="btn btn-primary"/><br /><br /><br />

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


</asp:Content>
