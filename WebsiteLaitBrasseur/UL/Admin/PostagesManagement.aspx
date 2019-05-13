<%@ Page Title="PostagesOptions" Language="C#" MasterPageFile="/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PostagesManagement.aspx.cs" Inherits="WebsiteLaitBrasseur.Admin.PostagesOptions" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!--START UpdatePanel fEnables sections of a page to be partially rendered without a postback. -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

<!--Page managing the different postage options -->

    <div class="container-fluid">
        <h3>Shipping Options Overview</h3>

            <!--Information label about List of postage options -->
            <asp:Label id="lblPostageList" Text="The postage list is empty." runat="server" />
            <!--Label about error during events execution -->
            <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger"></asp:Label><br />
            <asp:Label ID="lblInfo" runat="server" Text="" CssClass="text-info"></asp:Label>

            <!-- GridView conatiner-->
            <div class="offset-md-2 col-md-8" style="font-size:20px">

                <!-- GridView with 2 field (ProviderName + CostPerUnit) and button for edition/deletion
                    Field build with this scheme :
                        TemplateField
                            ItemTemplate
                            EditItemField
                -->
                <asp:GridView id="PostageTable" runat="server"  
                    GridLines="None" 
                    AutoGenerateColumns="false" 
                    class="table table-hover table-striped text-center" 
                    OnRowDeleting="PostageTable_RowDeleting"
                    OnRowEditing="PostageTable_RowEditing"
                    OnRowUpdating="PostageTable_RowUpdating"
                    OnRowCancelingEdit="PostageTable_RowCancelingEdit">

                        <Columns >
                            <asp:BoundField DataField="ProviderID" HeaderText="Provider ID" ReadOnly="True" /> 

                            <asp:TemplateField HeaderText="Provider Name" >

                                <ItemTemplate>
                                    <asp:Label ID="lblProviderName" runat="server" Text='<%# Bind("ProviderName") %>' ></asp:Label>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:TextBox id="TextProviderName" runat="server" Text='<%# Bind("ProviderName") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ProviderNameReqField" runat="server" ControlToValidate="TextProviderName" ValidationGroup="edit" ErrorMessage="Provider name is required" CssClass="text-danger"></asp:RequiredFieldValidator>
                                </EditItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cost per unit(€)" >

                                <ItemTemplate>
                                    <asp:Label ID="lblCost" runat="server" Text='<%# Bind("CostPerUnit") %>'></asp:Label>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:TextBox id="TextCost" runat="server" Text='<%# Bind("CostPerUnit") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CostNameReqField" runat="server" ControlToValidate="TextCost" ValidationGroup="edit" ErrorMessage="Cost is required" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="CostRegValid" runat="server" ControlToValidate="TextCost" ValidationExpression="([0-9]*\,)?[0-9]*" ErrorMessage="Please enter a valid number(decimal with coma)"  ValidationGroup="edit" CssClass="text-danger" ></asp:RegularExpressionValidator><br />

                                </EditItemTemplate>

                            </asp:TemplateField>
                                                     
                            <asp:CommandField ShowEditButton="true" CausesValidation="true"  ButtonType="Button" ValidationGroup="edit"  ItemStyle-CssClass="col-sm-1 "  />
                            <asp:CommandField ShowDeleteButton="true" CausesValidation="false"  ButtonType="Button"  ItemStyle-CssClass=" col-sm-1" /> 

                        </Columns>
                    </asp:GridView>



                <!--Add a Postage option -->
                    <!--Row with TextBox for informations about the new Postage option and "Add" button /Validators below -->
                <div class="row">
                    <div class="col-md-3">
                        <asp:Button ID="AddButton" ToolTip="Add Shippment."  runat="server" Text="Add" OnClick="AddButton_Click" CssClass="btn btn-success" CausesValidation="true" ValidationGroup="Add"/>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="TextAddProvider" runat="server" Text="Provider name" ValidationGroup="Add" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="TextAddCost" runat="server" Text="Cost" ValidationGroup="Add" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <!--Validators for the new postage option informations -->
                <div id="Validators">
                    <asp:RequiredFieldValidator ID="AddProviderNameReqField" runat="server" ControlToValidate="TextAddProvider" ValidationGroup="Add" ErrorMessage="Provider Name is required" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    <asp:RequiredFieldValidator ID="AddCostReqField" runat="server" ControlToValidate="TextAddCost" ValidationGroup="Add" ErrorMessage="Cost field is required" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="AddCostRegValid" runat="server" ControlToValidate="TextAddCost" ValidationExpression="([0-9]*\,)?[0-9]*" ErrorMessage="Please enter a valid number (decimal with coma)"  ValidationGroup="Add" CssClass="text-danger" ></asp:RegularExpressionValidator><br />
                </div>
            </div>

    </div>

    <!--END UpdatePanel Enables sections of a page to be partially rendered without a postback. -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
