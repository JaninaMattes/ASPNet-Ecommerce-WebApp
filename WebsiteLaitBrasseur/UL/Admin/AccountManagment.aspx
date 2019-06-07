<%@ Page Title="Accounts Managment" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AccountManagment.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Admin.AccountManagment" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--Page managing  "fake" user accounts-->

    <div class="container-fluid ">

        <!--START Header / Label / GridView-->
        <div id="tableCustomer clearfix">
            <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger"></asp:Label>
            <h3 id="sheader">Manage Customer Accounts</h3>
            <asp:Label ID="lblUserList" Text="The customer list is empty." runat="server" />
            <div class=" offset-md-1 col-md-10">

                <!-- GridView with  7 fields / a button for change Suspended Statut / a button for show transaction-->
                <asp:GridView ID="UserListTable" runat="server"
                    GridLines="none"
                    AutoGenerateColumns="false"
                    OnRowCommand="UserListTable_RowCommand"
                    OnRowEditing="UserListTable_RowEditing"
                    OnRowUpdating="UserListTable_RowUpdating"
                    class="table table-hover table-striped text-center">

                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="Id Number" />
                        <asp:BoundField DataField="Firstname" HeaderText="Firstname" />
                        <asp:BoundField DataField="Lastname" HeaderText="Lastname" />
                        <asp:BoundField DataField="Email" HeaderText="E-mail" />
                        <asp:BoundField DataField="PhoneNo" HeaderText="PhoneNo" />
                        <asp:BoundField DataField="IsConfirmed" HeaderText="IsConfirmed" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="ShowButton" runat="server" CommandName="Edit" Text="Show Transactions" CommandArgument="Show" CssClass="btn btn-primary"></asp:LinkButton>
                                <asp:LinkButton ID="ChangeStatusButton" runat="server" CommandName="Update" Text="Suspend / Activate" CommandArgument="Change" CssClass="btn btn-danger"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>


            </div>

            <br />
            <br />
            <h3 id="sheaderAdmin">Manage Admin Accounts</h3>
            <asp:Label ID="lblAdminList" Text="The Admin list is empty." runat="server" />
            <div class=" offset-md-1 col-md-10">

                <!-- GridView with  7 fields -->
                <asp:GridView ID="AdminListTable" runat="server"
                    GridLines="none"
                    AutoGenerateColumns="false"
                    class="table table-hover table-striped text-center">

                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="Id Number" />
                        <asp:BoundField DataField="Firstname" HeaderText="Firstname" />
                        <asp:BoundField DataField="Lastname" HeaderText="Lastname" />
                        <asp:BoundField DataField="Email" HeaderText="E-mail" />
                        <asp:BoundField DataField="PhoneNo" HeaderText="PhoneNo" />
                        <asp:BoundField DataField="IsConfirmed" HeaderText="IsConfirmed" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />

                    </Columns>
                </asp:GridView>

            </div>

        </div>
        <!--END Container Content-->
    </div>
</asp:Content>
