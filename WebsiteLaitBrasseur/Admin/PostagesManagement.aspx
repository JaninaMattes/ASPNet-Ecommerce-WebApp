﻿<%@ Page Title="PostagesOptions" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PostagesManagement.aspx.cs" Inherits="WebsiteLaitBrasseur.Admin.PostagesOptions" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<!--Page managing the different postage options -->

    <div class="container-fluid">
        <h3>Shipping Options Overview</h3>

            <!--Information label about List of postage options -->
            <asp:Label id="lblPostageList" Text="The postage list is empty." runat="server" />

            <!-- GridView conatiner-->
            <div class="offset-md-2 col-md-8" style="font-size:20px">

                <!-- GridView with 2 field (ProviderName + CostPerUnit) and button for edition/deletion
                    Field build with this scheme :
                        TemplateField
                            EditItemField
                            ItemTemplate
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


                            <asp:TemplateField HeaderText="ProviderName" >

                                <EditItemTemplate>
                                    <div >
                                        <asp:TextBox ID="TextProviderName" runat="server" CssClass="form-control"  Text='<%# Bind("ProviderName") %>' ></asp:TextBox>
                                    </div>

                                    <asp:RequiredFieldValidator id="ProviderNameReqField" runat="server" ControlToValidate="TextProviderName" ValidationGroup="Edit" ErrorMessage="Name is required" CssClass="text-danger"  ></asp:RequiredFieldValidator>
                                </EditItemTemplate>

                                <ItemTemplate>
                                    <asp:Label ID="lblProviderName" runat="server" text='<%# Bind("ProviderName") %>'></asp:Label>
                                </ItemTemplate>

                                
                                </asp:TemplateField>


                            <asp:TemplateField HeaderText="Cost per unit(€)">

                                <EditItemTemplate>
                                    <div >
                                        <asp:TextBox ID="TextCostPerUnit" runat="server" CssClass="form-control" text='<%# Bind("CostPerUnit") %>'></asp:TextBox>
                                    </div>
                                    <asp:RequiredFieldValidator id="CostReqField" runat="server" ControlToValidate="TextCostPerUnit" ValidationGroup="Edit" ErrorMessage="Cost is required" CssClass="text-danger"  ></asp:RequiredFieldValidator>
                                    <asp:regularExpressionValidator ID="CostRegValid" runat="server" ErrorMessage="Should be number (make decimal with coma)" ControlToValidate="TextCostPerUnit" Display="Dynamic"  ValidationExpression="([0-9]*\,)?[0-9]*$" CssClass="text-danger"></asp:RegularExpressionValidator>
                                </EditItemTemplate>

                                <ItemTemplate>
                                    <asp:Label ID="lblCostPerUnit" runat="server" text='<%# Bind("CostPerUnit") %>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>


                            <asp:CommandField ShowEditButton="true" CausesValidation="true"  ButtonType="Button" ValidationGroup="Edit"  ItemStyle-CssClass="col-sm-1 "  />
                            <asp:CommandField ShowDeleteButton="true" CausesValidation="false"  ButtonType="Button"  ItemStyle-CssClass=" col-sm-1" /> 

                        </Columns>
                    </asp:GridView>

                <!--Label about error during events execution -->
                <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger"></asp:Label><br />
                <asp:Label ID="lblInfo" runat="server" Text="" CssClass="text-info"></asp:Label>

                <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_Click" CssClass="btn btn-success" />
            </div>

    </div>

</asp:Content>