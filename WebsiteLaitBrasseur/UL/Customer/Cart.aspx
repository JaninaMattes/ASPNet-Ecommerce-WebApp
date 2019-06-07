<%@ Page Title="Cart" Language="C#" MasterPageFile="~/UL/Customer/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Cart.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Customer.Cart" %>


<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
<!--START UpdatePanel fEnables sections of a page to be partially rendered without a postback. -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<!--Page managing  a "fake" cart-->

    <div class="container-fluid ">
    
        <!--Global container with the differents Items and the Summary -->
        <div class="col-md-12 row text-center">

            <div class="col-md-6">
                <div id="CartTitle1" runat="server" class="ContentHead">
                    <h1>Shopping Cart</h1>
                </div>

                <asp:Label ID="lblResult" runat="server" Text="" CssClass="text-info" Style="font-size: 20px"></asp:Label>

                <asp:GridView ID="CartTable" runat="server"
                    GridLines="none"
                    AutoGenerateColumns="false"
                    class="table table-hover table-striped text-center"
                    OnRowDataBound="CartTable_RowDataBound"
                    OnRowDeleting="CartTable_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="ID" ReadOnly="true" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="Image" runat="server" ImageUrl='<%# Bind("Image") %>' Width="165px" Height="110px" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Product Name">
                            <ItemTemplate>
                                <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Size">
                            <ItemTemplate>
                                <asp:Label ID="lblSize" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Price">
                            <ItemTemplate>
                                <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:DropDownList ID="DDLQuantity" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DDLQuantity_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Total Price">
                            <ItemTemplate>
                                <asp:Label ID="lblTotalPrice" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField ButtonType="Button" DeleteText="Delete" ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" />
                    </Columns>
                </asp:GridView>

                <!--Sum prices of items -->
                <div id="AmountLabels" runat="server" class="text-right" style="font-size:18px">
                    <br />
                    <asp:Label ID="lblAmount" runat="server" CssClass="text-info" Text="Amount : "></asp:Label>
                    <asp:Label ID="lblAmountValue" runat="server" CssClass="text-body" Text=""></asp:Label>
                    <asp:Label runat="server" CssClass="text-body" Text="AUS$"></asp:Label><br />
                </div>
            </div> 

            <!--Summary : updated via the "update" button-->
            <div class="col-md-5 offset-1 text-center"  >
                 <div id="CartTitle2" runat="server" class="ContentHead"><h1>Summary</h1><br /></div>
                 <div style="font-size:18px">

                     <!-- Shipping cost will apply -->
                     <!--Label /DropDown List for the Postage Options-->
                     <asp:Label ID="lblPostage" runat="server" cssclass="text-info  " Text="Shipping cost : "></asp:Label>
                     <asp:Label ID="lblPostageValue" runat="server" cssclass=" text-body" Text=""></asp:Label>

                     <asp:Label  runat="server" cssclass="text-body" Text="AUS$"></asp:Label><br />

                    <asp:gridview id="PostagesTable" runat="server"
                    gridlines="none"
                    autogeneratecolumns="false"
                    OnSelectedIndexChanged="PostagesTable_SelectedIndexChanged"
                    class="table table-hover table-striped text-center"
                   >
                        <Columns>
                            <asp:BoundField DataField="PostageID" ReadOnly="true" />

                            <asp:templateField HeaderText="Company">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany" runat="server" Text='<%# Bind("Company") %>' ></asp:Label>
                                </ItemTemplate>
                            </asp:templateField>

                            <asp:templateField HeaderText="Delivery Days">
                                <ItemTemplate>
                                    <asp:Label ID="lblDeliveryTime" runat="server" Text='<%# Bind("DeliveryTime") %>' ></asp:Label>
                                </ItemTemplate>
                            </asp:templateField>

                            <asp:templateField HeaderText="Cost Per Unit">
                                <ItemTemplate>
                                    <asp:Label ID="lblCost" runat="server" Text='<%# Bind("Cost") %>' ></asp:Label>
                                </ItemTemplate>
                            </asp:templateField>

                            <asp:ButtonField Text="Select" CausesValidation="false" CommandName="Select" ControlStyle-CssClass="btn btn-primary" />
                        </Columns>
                    </asp:gridview>

                     <br />


                     <!-- Tax will apply -->
                     <asp:Label ID="lblTax" runat="server" cssclass="text-info " Text="Tax : "></asp:Label>
                     <asp:Label ID="lblTaxValue" runat="server" CssClass="text-body" Text="20"></asp:Label>%
                     <br /></br>

                     <!--Final cost including shipping cost and tax -->
                     <asp:Label ID="TotalCost" runat="server" cssclass="text-info " Text="Total Cost : "></asp:Label>
                     <asp:Label ID="TotalCostValue" runat="server" cssclass="text-body " Text=""></asp:Label>
                     <asp:Label  runat="server" cssclass="text-body" Text="AUS$"></asp:Label><br /><br /><br />


                     <!--"CreditCard" button to get to the credit card page" -->
                     <asp:button ID="CreditCardButton" runat="server" CssClass="btn btn-success" Text="Payment" ValidationGroup="CreateInvoice" OnClick="CreditCardButton_Click"/>

                     
                     <!--"Change Address" Button to get to the shipping address page -->
                     <br /><br />
                     <asp:button ID="ChangeAddressButton" runat="server" CssClass="btn btn-info" Text="Change Delivery Address" OnClick="ChangeAddressButton_Click" />

                     <br />
                      <asp:Label ID="lblValidation" runat="server" Text="" CssClass="text-danger" Style="font-size: 20px"></asp:Label>


                 </div>
            </div>
        </div>
    </div>

    <!--END UpdatePanel Enables sections of a page to be partially rendered without a postback. -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
