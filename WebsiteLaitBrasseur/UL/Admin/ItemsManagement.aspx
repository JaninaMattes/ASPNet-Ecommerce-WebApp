<%@ Page Title="Items Management" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ItemsManagement.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Admin.ItemsManagement" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <!--START UpdatePanel fEnables sections of a page to be partially rendered without a postback. -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

    <div class="container-fluid">

<!--Page managing the items in the Admin side -->

            <h3 id="sheader">Manage Items</h3>
        
            <!--Information labels -->
            <asp:Label id="lblItemList" Text="The items list is empty." runat="server"/><br />
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
                            <asp:BoundField DataField="SizeID" ReadOnly="true" />

                            <asp:BoundField DataField="ProductID" HeaderText="ID" ReadOnly="true" />

                            <asp:templateField HeaderText="Product Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("Name") %>' ></asp:Label>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:TextBox ID="TextEditProductName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ProductEditNameReqField" runat="server" ControlToValidate="TextEditProductName" ErrorMessage="Product Name is required" ValidationGroup="Edit" CssClass="text-danger"></asp:RequiredFieldValidator>

                                </EditItemTemplate>

                                <FooterTemplate>
                                    <asp:TextBox id="TextAddName" runat="server" Text="Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="NameReqField" runat="server" ControlToValidate="TextAddName" ValidationGroup="add" ErrorMessage="Name is required" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                                </FooterTemplate>

                            </asp:templateField>


                           <asp:templateField HeaderText="Product Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductType" runat="server" Text='<%# Bind("Type") %>' ></asp:Label>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:DropDownList ID="DDLProductType" runat="server"  >
                                        <asp:ListItem Value="Cheese"  Text="Cheese"></asp:ListItem>
                                        <asp:ListItem Value="Beer" Text="Beer"></asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                           
                                <FooterTemplate>
                                    <asp:DropDownList ID="DDLProductAddType" runat="server"  >
                                        <asp:ListItem Value="Cheese" Text="Cheese"></asp:ListItem>
                                        <asp:ListItem Value="Beer" Text="Beer"></asp:ListItem>
                                    </asp:DropDownList>
                                </FooterTemplate>
                            </asp:templateField>


                            <asp:templateField HeaderText="Size">
                                <ItemTemplate>
                                    <asp:Label ID="lblSize" runat="server" Text='<%# Bind("Size") %>' ></asp:Label>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:TextBox ID="TextEditSize" runat="server" text='<%# Bind("Size") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID=SizeReqField runat="server" ControlToValidate="TextEditSize" ErrorMessage="Size is required" ValidationGroup="Edit" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="SizeEditRegValid" runat="server" ControlToValidate="TextEditSize"  ValidationExpression="[0-9]*" ErrorMessage="Please enter positive integer" ValidationGroup="Edit" CssClass="text-danger"></asp:RegularExpressionValidator><br />


                                </EditItemTemplate>

                                <FooterTemplate>
                                    <asp:TextBox id="TextAddSize" runat="server" Text="Size"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AddSizeNameReqField" runat="server" ControlToValidate="TextAddSize" ValidationGroup="add" ErrorMessage="Size is required" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                                </FooterTemplate>

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


                                <FooterTemplate>
                                    <asp:TextBox id="TextAddPrice" runat="server" Text="Price"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PriceReqField" runat="server" ControlToValidate="TextAddPrice" ValidationGroup="add" ErrorMessage="Price is required" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="PriceRegValid" runat="server" ControlToValidate="TextAddPrice" ValidationExpression="([0-9]*\,)?[0-9]*" ErrorMessage="Please enter a valid number (decimal with coma)"  ValidationGroup="add" CssClass="text-danger" ></asp:RegularExpressionValidator><br />
                                </FooterTemplate>
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

                                <FooterTemplate>
                                    <asp:TextBox id="TextAddStock" runat="server" Text="Stock"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="StockReqField" runat="server" ControlToValidate="TextAddStock" ValidationGroup="add" ErrorMessage="Stock is required" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="StockRegValid" runat="server" ControlToValidate="TextAddStock" ValidationExpression="[0-9]*" ErrorMessage="Please enter a valid number"  ValidationGroup="add" CssClass="text-danger" ></asp:RegularExpressionValidator><br />
                                </FooterTemplate>
                            </asp:templateField>


                            <asp:templateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>' ></asp:Label>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:DropDownList ID="DDLStatus" runat="server"  >
                                        <asp:ListItem Value="1"  Text="Available"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="Not Available"></asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>

                                <FooterTemplate>
                                    <asp:DropDownList ID="DDLAddStatus" runat="server"  >
                                        <asp:ListItem Value="1" Text="Available"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="Not Available"></asp:ListItem>
                                    </asp:DropDownList>
                                </FooterTemplate>
                            </asp:templateField>

                            <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:LinkButton ID="DetailButton" runat="server" CommandName="FakeDelete" Text="Delete" CssClass="btn btn-danger" ></asp:LinkButton>
                                    <asp:LinkButton ID="editButton" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-primary" CausesValidation="true" ValidationGroup="edit"></asp:LinkButton>
                                    <asp:LinkButton ID="deleteButton" runat="server" CommandName="Delete" Text="Details" CssClass="btn btn-primary" ></asp:LinkButton>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:LinkButton ID="updateButton" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-primary" CausesValidation="true" ValidationGroup="edit"></asp:LinkButton>
                                    <asp:LinkButton ID="cancelButton" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-danger" CausesValidation="true" ValidationGroup="edit"></asp:LinkButton>

                                </EditItemTemplate>
                                
                                <FooterTemplate>
                                    <asp:LinkButton ID="insertButton" runat="server" CommandArgument="Insert" Text="Insert" CssClass="btn btn-success" CausesValidation="true" ValidationGroup="add"></asp:LinkButton>
                                    <asp:Button ID="cancelInsertButton" runat="server" Text="Cancel" OnClick="CancelInsertButton_Click" CssClass="btn btn-danger"/>

                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:gridview>


                <!--Add a Product -->
                    <!--Row with TextBox/DropdownList for informations about the new product and "Add" button /Validators below -->

                <div class="col-md-3 row">
                        <asp:Button ID="AddButton" ToolTip="Add item."  runat="server" Text="Add" OnClick="AddButton_Click" CssClass="btn btn-success" ValidationGroup="add" CausesValidation="true" />
                </div>


                <!--Validators for the new product informations -->

                <div id="Validators">
                </div>  
            </div>
    </div>

        <!--END UpdatePanel Enables sections of a page to be partially rendered without a postback. -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
