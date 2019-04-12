<%@ Page Title="Accounts Managment" Language="C#" MasterPageFile="/User Layer/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AccountManagment.aspx.cs" Inherits="WebsiteLaitBrasseur.Admin.AccountManagment" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--Page managing  "fake" user accounts-->

    <div class="container-fluid ">
        
    <!--START Header / Label / GridView--> 
        <div id="tableCustomer clearfix" >
            <h3 id="sheader">Manage Customer Accounts</h3>
            <asp:Label id="lblUserList" Text="The customer list is empty." runat="server" />
            <div class=" offset-md-2 col-md-7">

               <!-- GridView with  6 fields / a button for change Suspended Statut / a button for show transaction-->
                <asp:GridView id="UserListTable" runat="server" 
                    GridLines="none"
                    AutoGenerateColumns="false"
                    OnRowEditing="UserListTable_RowEditing"
                    OnRowDeleting="UserListTable_RowDeleting"
                    class="table table-hover table-striped text-center">

                        <Columns>
                            <asp:BoundField DataField="userId" HeaderText="Id Number" />
                            <asp:BoundField DataField="firstname" HeaderText="Firstname" /> 
                            <asp:BoundField DataField="lastname" HeaderText="Lastname" />
                            <asp:BoundField DataField="email" HeaderText="E-mail" />
                            <asp:BoundField DataField="phoneNo" HeaderText="PhoneNo" />
                            <asp:BoundField DataField="isSuspended" HeaderText="Suspended User" />

                            <asp:CommandField ShowEditButton="true" ButtonType="Button"  EditText="Show Transactions" />
                            <asp:CommandField ShowDeleteButton="true"  ButtonType="Button"   DeleteText="Suspend/Activate" />
                        </Columns>
                    </asp:GridView>

                    <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger"></asp:Label>
            </div>

        </div>
    <!--END Container Content-->
  </div>
</asp:Content>
