<%@ Page Title="Cart" Language="C#" MasterPageFile="~/UL/Customer/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Cart.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Customer.Cart" %>


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
                
                <asp:Label ID="lblResult" runat="server" Text="" CssClass="text-info" style="font-size:20px"></asp:Label>

                <asp:gridview id="CartTable" runat="server"
                    gridlines="none"
                    autogeneratecolumns="false"
                    class="table table-hover table-striped text-center"
                    OnRowDataBound="CartTable_RowDataBound"
                    OnRowCancelingEdit="CartTable_RowCancelingEdit"
                    OnRowDeleting="CartTable_RowDeleting"
                    OnRowUpdating="CartTable_RowUpdating"
                    >


                        <Columns>
                            <asp:BoundField DataField="ID" ReadOnly="true" />

                            <asp:templateField >
                                <ItemTemplate>
                                    <asp:Image ID="Image" runat="server"  ImageUrl='<%# Bind("Image") %>' Width="165px" Height="110px"/>  
                                </ItemTemplate>
                            </asp:templateField>

                            <asp:templateField HeaderText="Product Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("Name") %>' ></asp:Label>
                                </ItemTemplate>
                            </asp:templateField>

                            <asp:templateField HeaderText="Size">
                                <ItemTemplate>
                                    <asp:Label ID="lblSize" runat="server" Text='<%# Bind("Size") %>' ></asp:Label>
                                </ItemTemplate>
                            </asp:templateField>

                            <asp:templateField HeaderText="Price">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>' ></asp:Label>
                                </ItemTemplate>
                            </asp:templateField>

                            <asp:templateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:DropDownList ID="DDLQuantity" runat="server" Cssclass="form-control" AutoPostBack="true"  OnSelectedIndexChanged="DDLQuantity_SelectedIndexChanged">
                                        
                                    </asp:DropDownList>
                                </ItemTemplate>                           
                            </asp:templateField>

                            <asp:templateField HeaderText="Total Price">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalPrice" runat="server" Text="" ></asp:Label>
                                </ItemTemplate>
                            </asp:templateField>

                        </Columns>
            </asp:gridview>

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
