<%@ Page Title="Detail Spicy cheese" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetailSpice.aspx.cs" Inherits="WebsiteLaitBrasseur.ProductDetailSpice" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid" >
        <div class="row">

            <div class="col-md-4 text-center">
                    <img id="Spice" alt="Cheese-spice" src="/Images/cheese_spice.jpg"  class="img-fluid" style="height:200px;width:200px"/>
            </div>

            <div class=" offset-md-1 col-md-5 text-center" >
                 <div style="font-size:15px">
                     <asp:Label ID="Price" runat="server" cssclass="text-info  " Text="Product Price :"></asp:Label>
                     <asp:Label ID="PriceValue" runat="server" cssclass="text-dark" Text="2 €"></asp:Label><br /><br />

                     <asp:Label ID="Size" runat="server" cssclass="text-info " Text="Product Size : "></asp:Label>
                     <asp:Label ID="SizeValue" runat="server" cssclass="text-dark" Text=""></asp:Label><br /><br />

                     <asp:Label ID="Producer" runat="server" cssclass="text-info " Text="Producer :"></asp:Label>
                     <asp:Label ID="ProducerName" runat="server" cssclass="text-dark" Text="LaitBrasseur"></asp:Label><br /><br />

                     <asp:Label ID="Quantity" runat="server" cssclass="text-info " Text="Quantity :"></asp:Label> 
                      <asp:DropDownList ID="QuantityChosen" runat="server" >
                         <asp:ListItem Selected="True" Value="1"></asp:ListItem>
                         <asp:ListItem Value="2"></asp:ListItem>
                         <asp:ListItem Value="3"></asp:ListItem>
                         <asp:ListItem Value="4"></asp:ListItem>
                         <asp:ListItem Value="5"></asp:ListItem>
                         <asp:ListItem Value="6"></asp:ListItem>
                         <asp:ListItem Value="7"></asp:ListItem>
                         <asp:ListItem Value="8"></asp:ListItem>
                         <asp:ListItem Value="9"></asp:ListItem>
                         <asp:ListItem Value="10"></asp:ListItem>
                         <asp:ListItem Value="11"></asp:ListItem>
                         <asp:ListItem Value="12"></asp:ListItem>
                         <asp:ListItem Value="13"></asp:ListItem>
                         <asp:ListItem Value="14"></asp:ListItem>
                         <asp:ListItem Value="15"></asp:ListItem>
                         <asp:ListItem Value="16"></asp:ListItem>
                         <asp:ListItem Value="17"></asp:ListItem>
                         <asp:ListItem Value="18"></asp:ListItem>
                         <asp:ListItem Value="19"></asp:ListItem>
                         <asp:ListItem Value="20"></asp:ListItem>
                    </asp:DropDownList><br /><br /><br />

                     <asp:button ID="AddToCartButton" runat="server" CssClass="btn btn-success" Text="Add To Cart"  />

                 </div>

           </div>
        </div>


        <div class="col-md-5 text-info text-justify" style="font-size:15px">
            <b>Spicy cheese</b><br />
        </div>

    </div>

</asp:Content>
