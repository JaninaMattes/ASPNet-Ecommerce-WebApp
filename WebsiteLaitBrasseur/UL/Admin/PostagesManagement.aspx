﻿<%@ Page Title="PostagesOptions" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PostagesManagement.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Admin.PostagesOptions" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!--START UpdatePanel fEnables sections of a page to be partially rendered without a postback. -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <!--Page managing the different postage options -->

            <div class="container-fluid">
                <h3>Shipping Options Overview</h3>

                <!--Information label about List of postage options -->
                <asp:Label ID="lblPostageList" Text="The postage list is empty." runat="server" />

                <!--Labels about error/info during events execution -->
                <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger"></asp:Label><br />
                <asp:Label ID="lblInfo" runat="server" Text="" CssClass="text-info"></asp:Label>


                <!-- GridView container-->
                <div class="offset-md-1 col-md-8" style="font-size: 20px">

                    <!-- GridView with 7 fields  and button for edition/deletion/Update and Insertin footer
                    Field build with this scheme :
                        TemplateField
                            ItemTemplate
                            EditItemField
                            FooterTemplate
                -->
                    <asp:GridView ID="PostageTable" runat="server"
                        GridLines="None"
                        AutoGenerateColumns="false"
                        class="table table-hover table-striped text-center"
                        OnRowDeleting="PostageTable_RowDeleting"
                        OnRowEditing="PostageTable_RowEditing"
                        OnRowUpdating="PostageTable_RowUpdating"
                        OnRowCancelingEdit="PostageTable_RowCancelingEdit"
                        OnRowCommand="PostageTable_RowCommand">

                        <Columns>

                            <asp:BoundField HeaderText="ID" ReadOnly="true" DataField="ID" />


                            <asp:TemplateField HeaderText="Company">

                                <ItemTemplate>
                                    <asp:Label ID="lblCompanyName" runat="server" Text='<%# Bind("Company") %>'></asp:Label>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:TextBox ID="TextCompanyName" runat="server" Text='<%# Bind("Company") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CompanyNameReqField" runat="server" ControlToValidate="TextCompanyName" ValidationGroup="edit" ErrorMessage="Company name is required" CssClass="text-danger"></asp:RequiredFieldValidator>
                                </EditItemTemplate>

                                <FooterTemplate>
                                    <asp:TextBox ID="TextAddCompany" runat="server" Text="CompanyName"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AddCompanyNameReqField" runat="server" ControlToValidate="TextAddCompany" ValidationGroup="add" ErrorMessage="Company Name is required" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                                </FooterTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Type">

                                <ItemTemplate>
                                    <asp:Label ID="lblType" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:TextBox ID="TextType" runat="server" Text='<%# Bind("Type") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="TypeNameReqField" runat="server" ControlToValidate="TextType" ValidationGroup="edit" ErrorMessage="Type is required" CssClass="text-danger"></asp:RequiredFieldValidator><br />

                                </EditItemTemplate>

                                <FooterTemplate>
                                    <asp:TextBox ID="TextAddType" runat="server" Text="Type"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="TypeNameReqField" runat="server" ControlToValidate="TextAddType" ValidationGroup="add" ErrorMessage="Type is required" CssClass="text-danger"></asp:RequiredFieldValidator><br />

                                </FooterTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Delivery Time (days)">

                                <ItemTemplate>
                                    <asp:Label ID="lblDeliveryTime" runat="server" Text='<%# Bind("DeliveryTime") %>'></asp:Label>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:TextBox ID="TextDeliveryTime" runat="server" Text='<%# Bind("DeliveryTime") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="DeliveryTimeReqField" runat="server" ControlToValidate="TextDeliveryTime" ValidationGroup="edit" ErrorMessage="DeliveryTime is required" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="DeliveryTimeRegValid" runat="server" ControlToValidate="TextDeliveryTime" ValidationExpression="[0-9]*" ErrorMessage="Please enter a valid number" ValidationGroup="edit" CssClass="text-danger"></asp:RegularExpressionValidator><br />

                                </EditItemTemplate>

                                <FooterTemplate>
                                    <asp:TextBox ID="TextAddDeliveryTime" runat="server" Text="DeliveryTime"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="DeliveryTimeReqField" runat="server" ControlToValidate="TextAddDeliveryTime" ValidationGroup="add" ErrorMessage="DeliveryTime is required" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="DeliveryTimeRegValid" runat="server" ControlToValidate="TextAddDeliveryTime" ValidationExpression="[0-9]*" ErrorMessage="Please enter a valid number" ValidationGroup="add" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                                </FooterTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cost per unit(€)">

                                <ItemTemplate>
                                    <asp:Label ID="lblCost" runat="server" Text='<%# Bind("Cost") %>'></asp:Label>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:TextBox ID="TextCost" runat="server" Text='<%# Bind("Cost") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CostNameReqField" runat="server" ControlToValidate="TextCost" ValidationGroup="edit" ErrorMessage="Cost is required" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="CostRegValid" runat="server" ControlToValidate="TextCost" ValidationExpression="([0-9]*\.)?[0-9]*" ErrorMessage="Please enter a valid number(decimal with dot)" ValidationGroup="edit" CssClass="text-danger"></asp:RegularExpressionValidator><br />

                                </EditItemTemplate>

                                <FooterTemplate>
                                    <asp:TextBox ID="TextAddCost" runat="server" Text="Cost"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AddCostReqField" runat="server" ControlToValidate="TextAddCost" ValidationGroup="add" ErrorMessage="Cost field is required" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="AddCostRegValid" runat="server" ControlToValidate="TextAddCost" ValidationExpression="([0-9]*\.)?[0-9]*" ErrorMessage="Please enter a valid number (decimal with dot)" ValidationGroup="add" CssClass="text-danger"></asp:RegularExpressionValidator><br />

                                </FooterTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Status">

                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:TextBox ID="TextStatus" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="StatusNameReqField" runat="server" ControlToValidate="TextStatus" ValidationGroup="edit" ErrorMessage="Status is required" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="StatusRegValid" runat="server" ControlToValidate="TextStatus" ValidationExpression="1|0" ErrorMessage="Please enter a valid number(0 or 1)" ValidationGroup="edit" CssClass="text-danger"></asp:RegularExpressionValidator><br />

                                </EditItemTemplate>

                                <FooterTemplate>
                                    <asp:TextBox ID="TextAddStatus" runat="server" Text="Status"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="StatusNameReqField" runat="server" ControlToValidate="TextAddStatus" ValidationGroup="add" ErrorMessage="Status is required" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="StatusRegValid" runat="server" ControlToValidate="TextAddStatus" ValidationExpression="1|0" ErrorMessage="Please enter a valid number(0 or 1)" ValidationGroup="add" CssClass="text-danger"></asp:RegularExpressionValidator><br />

                                </FooterTemplate>

                            </asp:TemplateField>


                            <asp:TemplateField>

                                <ItemTemplate>

                                    <asp:LinkButton ID="editButton" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-primary" CausesValidation="true" ValidationGroup="edit"></asp:LinkButton>
                                    <asp:LinkButton ID="deleteButton" runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-danger"></asp:LinkButton>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:LinkButton ID="updateButton" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-primary" CausesValidation="true" ValidationGroup="edit"></asp:LinkButton>
                                    <asp:LinkButton ID="cancelButton" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-danger" CausesValidation="true" ValidationGroup="edit"></asp:LinkButton>

                                </EditItemTemplate>

                                <FooterTemplate>
                                    <asp:LinkButton ID="insertButton" runat="server" CommandArgument="Insert" Text="Insert" CssClass="btn btn-success" CausesValidation="true" ValidationGroup="add"></asp:LinkButton>
                                    <asp:Button ID="cancelInsertButton" runat="server" Text="Cancel" OnClick="CancelInsertButton_Click" CssClass="btn btn-danger" />

                                </FooterTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>



                    <!--Add a Postage option -->
                    <div class=" col-md-3 row">
                        <asp:Button ID="AddButton" ToolTip="Add Shippment." runat="server" Text="Add" OnClick="AddButton_Click" CssClass="btn btn-success" />
                    </div>
                </div>

            <!--END UpdatePanel Enables sections of a page to be partially rendered without a postback. -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
