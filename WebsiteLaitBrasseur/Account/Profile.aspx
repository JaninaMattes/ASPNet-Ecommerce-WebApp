<%@ Page Language="C#" Title="User Profile" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebsiteLaitBrasseur.Account.WebForm1" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <section>
        
        <div class="align-top">
            <div class="split left">
            <h1>Profile</h1>
            <div id="header" class="card-img">
            <img id="customerImg" alt="Customer Image" src="/Images/customerImg.jpg" style="width:150px;height:150px" class="img-rounded img-responsive" />
        </div>

        <div id="table" class="table-borderless">
        <asp:Table id="Table_UserProfile" runat="server"
                 CellPadding="10" 
                 GridLines="Both"
                 HorizontalAlign="Left">
          <asp:TableRow>
            <asp:TableCell>
                <label for="Firstname" class="control-label col-md-3">Firstname</label>
            </asp:TableCell>
            <asp:TableCell>
               <asp:TextBox ID="Firstname" Text="" runat="server" AutoPostBack="True" Cssclass="form-control"> </asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="FirstName" 
                    Display="Dynamic" 
                    ErrorMessage="Should not be blank."
                    CssClass="text-danger"> </asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <label for="Lastname" class="control-label col-md-3">Lastname</label>
            </asp:TableCell>
            <asp:TableCell>
               <asp:TextBox ID="Lastname" Text="" runat="server" AutoPostBack="True" Cssclass="form-control"> </asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="LastName" 
                    Display="Dynamic" 
                    ErrorMessage="Should not be blank."
                    CssClass="text-danger"> </asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <label for="Username" class="control-label col-md-3">Username</label>
            </asp:TableCell>
            <asp:TableCell>
               <asp:TextBox ID="Username" Text="" runat="server" AutoPostBack="True" Cssclass="form-control"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="FirstName" 
                    Display="Dynamic" 
                    ErrorMessage="Should not be blank."
                    CssClass="text-danger"> </asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <label for="Email" class="control-label col-md-3">Email</label>
            </asp:TableCell>
            <asp:TableCell>
               <asp:TextBox ID="Email" Text="" runat="server" AutoPostBack="True" Cssclass="form-control"> </asp:TextBox>
               <asp:RegularExpressionValidator ID="EmailValidator" runat="server" 
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ControlToValidate="Email" 
                    ErrorMessage="Invalid Email Format"
                    CssClass="text-danger"> </asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>

        </asp:Table>
        <div class="align-bottom">
            <asp:Table id="Table_ButtonContainer" runat="server"
                 CellPadding="10" 
                 GridLines="Both"
                 BottomAlign="Left" Height="35px" Width="96px">
            <asp:TableRow>
                <asp:TableCell>
                <label for="Label_Message" class="control-label col-md-3"></label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="SaveButton" runat="server" Text="Edit" OnClick="SaveButtonGo" CssClass="btn btn-default"/>
            </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        </div>    
        </div>
        </div>

        <div class="split right">
            <h2>Shopping History</h2>
        <div class="form-group">
            <asp:Table ID="myTable" runat="server" Width="100%"> 
                <asp:TableRow>
                    <asp:TableCell>Invoice Number</asp:TableCell>
                    <asp:TableCell>Total Amount</asp:TableCell>
                    <asp:TableCell>Date Ordered</asp:TableCell>
                    <asp:TableCell>Date Arrived</asp:TableCell>
                </asp:TableRow>
            </asp:Table>  
        </div>
        </div>
        </div>
    </section>
</asp:Content>

