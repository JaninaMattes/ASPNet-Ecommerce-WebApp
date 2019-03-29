<%@ Page Language="C#" Title="User Profile" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerProfile.aspx.cs" Inherits="WebsiteLaitBrasseur.Account.CustomerProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      
    <h3 id="Header User Profile">Profile</h3>
       
    <div class="form-group">
            
            <div class="split left" style="width:48%; float: left;">
          
            <div id="header" class="card-img">
            <img id="customerImg" alt="User Image" src="/Images/customerImg.jpg" style="width:150px;height:150px" class="img-presentation" />
            </div>

        <div id="table" class="table-borderless">
        <asp:Table id="Table_UserProfile" runat="server"
                 CellPadding="10"
                 HorizontalAlign="Left" CellSpacing="1" ToolTip="Edit Content">
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

            <asp:TableRow>
            <asp:TableCell>
                <label for="PhoneNo" class="control-label col-md-3">Phonenumber</label>
            </asp:TableCell>
            <asp:TableCell>
               <asp:TextBox ID="PhoneNo" Text="" runat="server" AutoPostBack="True" Cssclass="form-control"> </asp:TextBox>
               <asp:RegularExpressionValidator ID="PhoneNumberValidator" runat="server" 
                   ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"
                   ControlToValidate="PhoneNo" 
                   ErrorMessage="Phone number invalid." 
                   CssClass="text-danger">
               </asp:RegularExpressionValidator> 
            </asp:TableCell>
        </asp:TableRow>

             <asp:TableRow>
            <asp:TableCell>
                <label for="Country" class="control-label col-md-3">Country</label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList id="Country" runat="server" Cssclass="form-control">
                    <asp:ListItem Value="AU">Australia</asp:ListItem>
                    <asp:ListItem Value="AT">Austria</asp:ListItem>
                    <asp:ListItem Value="BE">Belgium</asp:ListItem>
                    <asp:ListItem Value="FR">France</asp:ListItem>
                    <asp:ListItem Value="DE">Germany</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow> 
            
            <asp:TableRow>
            <asp:TableCell>
                <label for="ZipCode" class="control-label col-md-3">Zip Code</label>
            </asp:TableCell>
            <asp:TableCell>
               <asp:TextBox ID="TextBox1" Text="" runat="server" AutoPostBack="True" Cssclass="form-control"> </asp:TextBox>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                   ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"
                   ControlToValidate="PhoneNo" 
                   ErrorMessage="Zip code is not valid." 
                   CssClass="text-danger">
               </asp:RegularExpressionValidator> 
            </asp:TableCell>
        </asp:TableRow>
        </asp:Table>

           <asp:Button ID="EditButton" runat="server" Text="Edit" OnClick="EditButton_Click" CssClass="btn btn-primary" Width="100px" BackColor="#CCCCCC" BorderColor="White"/>
           <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" CssClass="btn btn-primary" Width="100px" BorderColor="White"/>

          </div>
       </div>
    </div>

        <div class="split right" style="width: 48%; margin-left:1%; float: right; background-color: lightgrey">
        <h2>&nbsp;Shopping History</h2>
        <div class="form-group" id="shoppingOv">
              <asp:GridView ID="shoppingOverview" runat="server" AutoGenerateColumns="false" Width="767px">
        <Columns>
            <asp:BoundField DataField="InvoiceNumber" HeaderText="Invoice Number" />
            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
            <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
            <asp:BoundField DataField="Dispatched" HeaderText="Dispatched" />
        </Columns>
        </asp:GridView>
        </div>        
      </div>
        
</asp:Content>
