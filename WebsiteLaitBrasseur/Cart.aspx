<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebsiteLaitBrasseur.Cart" %>



<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid ">


        <div class="col-md-12 row text-center" "  >

            <div class="col-md-7 "  >
                <div id="CartTitle1" runat="server" class="ContentHead"><h1>Shopping Cart</h1></div>
                <!--Legend-->
                <div class="col-md-12 row rounded"  style="border:solid;border-color:grey;">
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


                <!--First Item-->
                <div class="col-md-12 row rounded"  style="border:solid;border-color:grey;height:150px">
                   <div class="col-md-3" >
                       <img id="Brune" alt="Beer_Brown" src="/Images/Brune.jpg" />                 
                   </div>

                   <div class="col-md-2  ">
                       <asp:Label ID="NameBrune" runat="server" cssclass="text-info " Text="Roubingole"></asp:Label><br />
                       <asp:Label ID="PriceBrune" runat="server" cssclass="text-info" Text="7.5€"></asp:Label>
                   </div>

                   <div class="col-md-2   ">
                      <asp:textbox id="QuantityBrune" runat="server" Cssclass="form-control" TextMode="Number"></asp:textbox>
                   </div>

                   <div class="col-md-2   ">
                      <asp:Label ID="TotalBrune" runat="server" cssclass="text-info " Text=""></asp:Label>
                   </div>

                   <div class="col-md-1">
                        <asp:checkbox ID="checkboxBrune" runat="server" />
                   </div>
                </div>

                <!--Second Item-->
                <div class="col-md-12 row rounded"  style="border:solid;border-color:grey;height:150px">
                   <div class="col-md-3" ">
                       <img id="Blonde" alt="Beer_Blonde" src="/Images/blond.jpg" />                     
                   </div>

                   <div class="col-md-2">
                       <asp:Label ID="NameBlonde" runat="server" cssclass="text-info " Text="LaBlonde"></asp:Label><br />
                       <asp:Label ID="PriceBlonde" runat="server" cssclass="text-info" Text="5.5€"></asp:Label>
                   </div>

                   <div class="col-md-2 ">
                      <asp:textbox id="QuantityBlonde" runat="server" Cssclass="form-control" TextMode="Number"></asp:textbox>
                   </div>

                   <div class="col-md-2 ">
                      <asp:Label ID="TotalBlonde" runat="server" cssclass="text-info " Text=""></asp:Label>
                   </div>

                   <div class="col-md-1">
                        <asp:checkbox ID="checkBoxBlonde" runat="server" />
                   </div>
                </div>


                <!--Third Item-->
                <div class="col-md-12 row rounded"  style="border:solid;border-color:grey;height:150px">
                   <div class="col-md-3" ">
                       <img id="Blanche" alt="Beer_Blanche" src="/Images/blanche.jpg" />                  
                   </div>

                   <div class="col-md-2">
                       <asp:Label ID="NameBlanche" runat="server" cssclass="text-info " Text="Blanchette"></asp:Label><br />
                       <asp:Label ID="PriceBlanche" runat="server" cssclass="text-info" Text="6€"></asp:Label>
                   </div>

                   <div class="col-md-2  ">
                      <asp:textbox id="QuantityBlanche" runat="server" Cssclass="form-control" TextMode="Number"></asp:textbox>
                   </div>

                   <div class="col-md-2 ">
                      <asp:Label ID="TotalBlanche" runat="server" cssclass="text-info " Text=""></asp:Label>
                   </div>

                   <div class="col-md-1">
                        <asp:checkbox ID="checkBoxBlanche" runat="server" />
                   </div>
                </div>

                <!--Fourth Item-->
                <div class="col-md-12 row rounded"  style="border:solid;border-color:grey;height:150px">
                   <div class="col-md-3" ">
                       <img id="Carre" alt="Cheese" src="/Images/cheese_carre_est.jpg" />                  
                   </div>

                   <div class="col-md-3 ">
                       <asp:Label ID="NameCheese" runat="server" cssclass="text-info " Text="Le carré Rémois"></asp:Label><br />
                       <asp:Label ID="PriceCheese" runat="server" cssclass="text-info" Text="8€"></asp:Label>
                   </div>

                   <div class="col-md-2 ">
                      <asp:textbox id="QuantityCheese" runat="server" Cssclass="form-control" TextMode="Number"></asp:textbox>
                   </div>
                   <div class="col-md-2 ">
                      <asp:Label ID="TotalCheese" runat="server" cssclass="text-info " Text=""></asp:Label>
                   </div>

                   <div class="col-md-1">
                        <asp:checkbox ID="checkBoxCheese" runat="server" />
                   </div>

                </div>


            </div> 

            <!--Summary-->
            <div class="col-md-2 offset-1" >
                 <div id="CartTitle2" runat="server" class="ContentHead"><h1>Summary</h1></div>

                 <div >
                     <asp:Label ID="Amount" runat="server" cssclass="text-info  " Text="Amount :"></asp:Label><br /> <br />
                     <asp:Label ID="Tax" runat="server" cssclass="text-info " Text="Tax :"></asp:Label><br /><br />
                     <asp:Label ID="ShippingCost" runat="server" cssclass="text-info " Text="Shipping Cost :"></asp:Label><br /><br />
                     <asp:Label ID="TotalCost" runat="server" cssclass="text-info " Text="Total Cost :"></asp:Label><br /><br />

                 </div>

            </div>


        </div>
        <br />
        <div class="container">
            <asp:Button ID="updateButton" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="updateButton_Click" />
        </div>

    </div>


</asp:Content>
