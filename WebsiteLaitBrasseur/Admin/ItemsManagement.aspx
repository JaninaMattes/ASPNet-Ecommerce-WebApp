<%@ Page Title="Items Management" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ItemsManagement.aspx.cs" Inherits="WebsiteLaitBrasseur.Admin.ItemsManagement" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="container-fluid">

            <h3 id="sheader">Manage Items</h3>
            <asp:Label id="lblItemList" Text="The items list is empty." runat="server" />
            <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger"></asp:Label><br />
            <asp:Label ID="lblInfo" runat="server" Text="" CssClass="text-info"></asp:Label>
            <div class=" offset-md-1 col-md-10">

               <!-- GridView with  -->
                <asp:gridview id="ItemListTable" runat="server"
                    gridlines="none"
                    autogeneratecolumns="false"
                    class="table table-hover table-striped text-center"
                    OnRowCancelingEdit="ItemListTable_RowCancelingEdit"
                    OnRowDeleting="PostageTable_RowDeleting"
                    OnRowEditing="PostageTable_RowEditing">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="Id Number" />
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
                <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_Click" CssClass="btn btn-success" />
            </div>
</div>
</asp:Content>
