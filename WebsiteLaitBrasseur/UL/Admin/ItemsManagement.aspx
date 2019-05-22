<%@ Page Title="Items Management" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ItemsManagement.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Admin.ItemsManagement" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <!--START UpdatePanel fEnables sections of a page to be partially rendered without a postback. -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

    <div class="container-fluid">

<!--Page managing the items in the Admin side -->

            <h3 id="sheader">Manage Items</h3>
        
            <!--Information labels -->
            <asp:Label id="lblItemList" Text="The items list is empty." runat="server" /><br />
            <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger"></asp:Label><br />
            <asp:Label ID="lblInfo" runat="server" Text="" CssClass="text-info"></asp:Label>


            <div class="col-md-10">

               <!-- GridView with seven fields and three buttons for edit the line / delete the line / show detail of the product  -->
                <!--The gridview is built with this scheme :
                        TemplateField
                            ItemTemplate
                            EditItemTemplate
                -->

                <asp:gridview id="ItemListTable" runat="server"
                    gridlines="none"
                    autogeneratecolumns="false"
                    class="table table-hover table-striped text-center"
                    OnRowCancelingEdit="ItemListTable_RowCancelingEdit"
                    OnRowDeleting="ItemListTable_RowDeleting"
                    OnRowEditing="ItemListTable_RowEditing"
                    OnRowUpdating="ItemListTable_RowUpdating"
                    OnRowCommand="ItemListTable_RowCommand">


                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="true" />


                            <asp:templateField HeaderText="Product Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("Name") %>' ></asp:Label>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:TextBox ID="TextEditProductName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ProductEditNameReqField" runat="server" ControlToValidate="TextEditProductName" ErrorMessage="Product Name is required" ValidationGroup="Edit" CssClass="text-danger"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:templateField>


                           <asp:templateField HeaderText="Product Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductType" runat="server" Text='<%# Bind("Type") %>' ></asp:Label>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:DropDownList ID="DDLProductType" runat="server"  >
                                        <asp:ListItem Value="1" Selected="True" Text="Cheese"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Beer"></asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:templateField>


                            <asp:templateField HeaderText="Unit">
                                <ItemTemplate>
                                    <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Size") %>' ></asp:Label>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:TextBox ID="TextEditUnit" runat="server" text='<%# Bind("Size") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID=UnitReqField runat="server" ControlToValidate="TextEditUnit" ErrorMessage="Unit is required" ValidationGroup="Edit" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="UnitEditRegValid" runat="server" ControlToValidate="TextEditUnit"  ValidationExpression="[0-9]*" ErrorMessage="Please enter positive integer" ValidationGroup="Edit" CssClass="text-danger"></asp:RegularExpressionValidator><br />

                                </EditItemTemplate>
                            </asp:templateField>


                            <asp:templateField HeaderText="Stock">
                                <ItemTemplate>
                                    <asp:Label ID="lblStock" runat="server" Text='<%# Bind("Stock") %>' ></asp:Label> 
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:TextBox ID="TextEditStock" runat="server" text='<%# Bind("Stock") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="StockEditReqField" runat="server" ControlToValidate="TextEditStock" ErrorMessage="Stock is required" ValidationGroup="Edit" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="StockEditRegValid" runat="server" ControlToValidate="TextEditStock" ValidationExpression="[0-9]*" ErrorMessage="Please enter positive integer" ValidationGroup="Edit" CssClass="text-danger"></asp:RegularExpressionValidator><br />

                                </EditItemTemplate>
                            </asp:templateField>


                            <asp:templateField HeaderText="Price">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>' ></asp:Label>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:TextBox ID="TextEditPrice" runat="server" text='<%# Bind("Price") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PriceEditReqField" runat="server" ControlToValidate="TextEditPrice" ErrorMessage="Price is required" ValidationGroup="Edit" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="PriceEditRegValid" runat="server" ControlToValidate="TextEditPrice" ValidationExpression="([0-9]*\,)?[0-9]*" ErrorMessage="Please enter a valid number (decimal with coma)"  ValidationGroup="Edit" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                                </EditItemTemplate>
                            </asp:templateField>


                            <asp:templateField HeaderText="Available">
                                <ItemTemplate>
                                    <asp:Label ID="lblAvailable" runat="server" Text='<%# Bind("Status") %>' ></asp:Label>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:DropDownList ID="DDLAvailable" runat="server"  >
                                        <asp:ListItem Value="1" Selected="True" Text="Available"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Not available"></asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:templateField>


                            <asp:CommandField ShowEditButton="true" ButtonType="Button"  EditText="Edit" />
                            <asp:CommandField ShowDeleteButton="true"  ButtonType="Button"   DeleteText="Delete" />
                            <asp:ButtonField   ButtonType="Button" CommandName="Detail_click" Text="Show details" />
                        </Columns>
                    </asp:gridview>


                <!--Add a Product -->
                    <!--Row with TextBox/DropdownList for informations about the new product and "Add" button /Validators below -->

                <div class="row">

                        <asp:Button ID="AddButton" ToolTip="Add item."  runat="server" Text="Add" OnClick="AddButton_Click" CssClass="btn btn-success" ValidationGroup="Add" CausesValidation="true" />

                    <div class="offset-md-1 col-md-2">
                        <asp:TextBox ID="TextProductName" runat="server" text=""  ValidationGroup="Add" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class=" col-md-2" >
                        <asp:DropDownList ID="TypeList" runat="server"  ValidationGroup="Add" CssClass="form-control">
                            <asp:ListItem Value="1"  Selected="true" Text="Cheese"></asp:ListItem>
                            <asp:ListItem Value="2"   Text="Beer"></asp:ListItem>
                        </asp:DropDownList> 
                    </div>

                    <div class="col-md-1">
                        <asp:TextBox ID="TextUnit" runat="server" text=""  ValidationGroup="Add" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>

                    <div class="col-md-1">
                        <asp:TextBox ID="TextStock" runat="server" text=""  ValidationGroup="Add" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>

                    <div class="col-md-1">
                        <asp:TextBox ID="TextPrice" runat="server" text=""  ValidationGroup="Add" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <asp:DropDownList ID="AvailableList" runat="server"  ValidationGroup="Add" CssClass="form-control">
                            <asp:ListItem Value="1"  Selected="true" Text="Available"></asp:ListItem>
                            <asp:ListItem Value="2"   Text="Not Available"></asp:ListItem>
                        </asp:DropDownList> 
                    </div>

                </div>


                <!--Validators for the new product informations -->

                <div id="Validators">
                    <asp:RequiredFieldValidator ID="ProductNameReqField" runat="server"  ControlToValidate="TextProductName" ErrorMessage="Name is required" ValidationGroup="Add" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    <asp:RequiredFieldValidator ID="UnitReqField" runat="server"  ControlToValidate="TextUnit" ErrorMessage="Unit is required" ValidationGroup="Add" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="UnitRegValid" runat="server" ControlToValidate="TextUnit"  ValidationExpression="[0-9]*" ErrorMessage="Must be positive number" ValidationGroup="Add" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                    <asp:RequiredFieldValidator ID="StockReqField" runat="server"  ControlToValidate="TextStock" ErrorMessage="Stock amount is required" ValidationGroup="Add" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="StockRegValid" runat="server" ControlToValidate="TextStock" ValidationExpression="[0-9]*" ErrorMessage="Must be positive number" ValidationGroup="Add" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                    <asp:RequiredFieldValidator ID="PriceReqField" runat="server"  ControlToValidate="TextPrice" ErrorMessage="Price is required" ValidationGroup="Add" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="PriceRegValid" runat="server" ControlToValidate="TextPrice" ValidationExpression="([0-9]*\,)?[0-9]*" ErrorMessage="Please enter a valid number (decimal with coma)"  ValidationGroup="Add" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                </div>  




            </div>
    </div>

        <!--END UpdatePanel Enables sections of a page to be partially rendered without a postback. -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
