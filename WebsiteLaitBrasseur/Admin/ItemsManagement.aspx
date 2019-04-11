<%@ Page Title="Items Management" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ItemsManagement.aspx.cs" Inherits="WebsiteLaitBrasseur.Admin.ItemsManagement" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="container-fluid">

            <h3 id="sheader">Manage Items</h3>
            <asp:Label id="lblItemList" Text="The items list is empty." runat="server" /><br />
            <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger"></asp:Label><br />
            <asp:Label ID="lblInfo" runat="server" Text="" CssClass="text-info"></asp:Label>
            <div class="col-md-10">

               <!-- GridView with  -->
                <asp:gridview id="ItemListTable" runat="server"
                    gridlines="none"
                    autogeneratecolumns="false"
                    class="table table-hover table-striped text-center"
                    OnRowCancelingEdit="ItemListTable_RowCancelingEdit"
                    OnRowDeleting="ItemListTable_RowDeleting"
                    OnRowEditing="ItemListTable_RowEditing"
                    OnRowUpdating="ItemListTable_RowUpdating">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="Id Number" ReadOnly="true" />
                            <asp:BoundField DataField="productName" HeaderText="Product Name" /> 
                            <asp:BoundField DataField="productType" HeaderText="Product Type" />
                            <asp:BoundField DataField="unit" HeaderText="Unit" />
                            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="price" HeaderText="Price" />
                            <asp:BoundField DataField="available" HeaderText="Available" />

                            <asp:CommandField ShowEditButton="true" ButtonType="Button"  EditText="Edit" />
                            <asp:CommandField ShowDeleteButton="true"  ButtonType="Button"   DeleteText="Delete" />
                        </Columns>
                    </asp:gridview>


                <div class="row">

                        <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_Click" CssClass="btn btn-success" ValidationGroup="Add" CausesValidation="true" />

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
                        <asp:TextBox ID="TextQuantity" runat="server" text=""  ValidationGroup="Add" CssClass="form-control" TextMode="Number"></asp:TextBox>
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


                <div id="Validators">
                    <asp:RequiredFieldValidator ID="ProductNameReqField" runat="server"  ControlToValidate="TextProductName" ErrorMessage="Name is required" ValidationGroup="Add" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    <asp:RequiredFieldValidator ID="UnitReqField" runat="server"  ControlToValidate="TextUnit" ErrorMessage="Unit is required" ValidationGroup="Add" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="UnitRegValid" runat="server" ControlToValidate="TextUnit"  ValidationExpression="[0-9]*" ErrorMessage="Must be positive number" ValidationGroup="Add" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                    <asp:RequiredFieldValidator ID="QuantityReqField" runat="server"  ControlToValidate="TextQuantity" ErrorMessage="Quantity is required" ValidationGroup="Add" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="QuantityRegValid" runat="server" ControlToValidate="TextQuantity" ValidationExpression="[0-9]*" ErrorMessage="Must be positive number" ValidationGroup="Add" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                    <asp:RequiredFieldValidator ID="PriceReqField" runat="server"  ControlToValidate="TextPrice" ErrorMessage="Price is required" ValidationGroup="Add" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="PriceRegValid" runat="server" ControlToValidate="TextPrice" ValidationExpression="([0-9]*\,)?[0-9]*" ErrorMessage="Please enter a valid number (decimal with coma)"  ValidationGroup="Add" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                </div>  




            </div>
</div>
</asp:Content>
