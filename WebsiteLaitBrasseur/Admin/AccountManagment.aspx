<%@ Page Title="Accounts Managment" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AccountManagment.aspx.cs" Inherits="WebsiteLaitBrasseur.Admin.AccountManagment" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--Page managing  "fake" user accounts-->

    <div class="container-fluid ">
        
    <!--START Header / Label / GridView--> 
        <div id="tableCustomer clearfix" style="float:left; margin:1%; width: 60%">
            <h3 id="sheader">Manage Customer Accounts</h3>
            <asp:Label id="tableUserList" Text="The customer list is empty." runat="server" />
            <div class="table-dark">
                <asp:GridView id="UserListTable" runat="server" style="table-grid;">
                        <Columns>
                            <asp:BoundField DataField="UserId" HeaderText="Id Number" />
                            <asp:BoundField DataField="Firstname" HeaderText="Firstname" /> 
                            <asp:BoundField DataField="Lastname" HeaderText="Lastname" />
                            <asp:BoundField DataField="PaymentDue" HeaderText="Payment Due" />
                            <asp:BoundField DataField="SuspendedUser" HeaderText="Suspended User" />
                            <asp:BoundField DataField="Select" HeaderText="Select" />
                        </Columns>
                    </asp:GridView>
            </div>
        <!-- START user buttons to select transaction for profile -->
        <div class="profile-userbuttons" style="bottom; float: right">
			<asp:Button id="transactionBtn" runat="server" Text="Show Transactions" OnClick="TransactionButton_Click" CssClass="btn-primary btn" />
            <asp:Button id="saveBtn" runat="server" Text="Save" OnClick="SaveButton_Click" CssClass="btn-primary btn" />
		<!-- END user buttons to delete the profile -->
        </div>
        </div>
    <!--END Container Content-->
  </div>
</asp:Content>
