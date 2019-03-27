<%@ Page Language="C#" Title="Profile" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerProfile.aspx.cs" Inherits="WebsiteLaitBrasseur.Account.WebForm1" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
        <h1>Profile</h1>
          
    <div class="form-group">
        <div style="width:48%; float: left;">
             <img id="customerImg" alt="Customer Image" src="/Images/customerImg.jpg" class="img-rounded img-responsive" />
        
        <% Textfield: Firstname %> 
        <div class="form-group">
            <label for="Firstname" class="control-label col-md-3">Firstname</label>
            <div class="col-md-3">
                <asp:TextBox ID="FirstName" Text="0" runat="server" AutoPostBack="True">
                </asp:TextBox>
                <% Field validator to check empty user input %>
                <asp:RequiredFieldValidator ID="FirstNameRequired" runat="server" 
                    ControlToValidate="FirstName" 
                    Display="Dynamic" 
                    ErrorMessage="Should not be blank."
                    CssClass="text-danger">
                </asp:RequiredFieldValidator>
                <br/>
            </div>
        </div>
        

        <% Textfield: Lastname %> 
        <div class="form-group">
            <label for="Lastname" class="control-label col-md-3">Lastname</label>
            <div class="col-md-3">
                <asp:TextBox ID="LastName" Text="0" runat="server" AutoPostBack="True">
                </asp:TextBox>
                <% Field validator to check empty user input %>
                <asp:RequiredFieldValidator ID="LastNameRequired"runat="server" 
                    ControlToValidate="Lastname" 
                    Display="Dynamic"              
                    ErrorMessage="Should not be blank."
                    CssClass="text-danger">
                </asp:RequiredFieldValidator>
                <br/>
            </div>
        </div>

        <% Textfield: Username %>
        <div class="form-group">
            <label for="Username" class="control-label col-md-3">Username</label>
            <div class="col-md-3">
                <asp:TextBox ID="Username" Text="0" runat="server" AutoPostBack="True">
                </asp:TextBox>
                <% Field validator to check empty user input %>
                <asp:RequiredFieldValidator ID="UserNameRequired"runat="server" 
                    ControlToValidate="Username" 
                    Display="Dynamic"
                    ErrorMessage="Should not be blank."
                    CssClass="text-danger">
                </asp:RequiredFieldValidator>
                <br/>
            </div>
        </div>

        <% Textfield: Email %>
        <div class="form-group">
            <label for="Email" class="control-label col-md-3">Email</label>
            <div class="col-md-3">
                <asp:TextBox ID="Email" Text="0" runat="server" AutoPostBack="True">
                </asp:TextBox>
                <% Field validator to check user input with regex%>
                <asp:RegularExpressionValidator ID="EmailRegexValidator" runat="server" 
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ControlToValidate="Email" 
                    ErrorMessage="Invalid Email Format"
                    CssClass="text-danger">
                </asp:RegularExpressionValidator>
                <br/>
            </div>
        </div>

        <% Textfield: Password %>
        <label for="Password" class="control-label col-md-3">Password</label>
        <div class="col-md-3">
            <asp:TextBox ID="Password" Text="0" runat="server" AutoPostBack="True">
            </asp:TextBox>
            <% Field validator to check empty user input %>
            <asp:RequiredFieldValidator ID="PasswordRegexValidator" runat="server" 
                ControlToValidate="TextBox1" 
                Display="Dynamic" 
                Forecolor="Red"
                ErrorMessage="Should not be blank.">
            </asp:RequiredFieldValidator>
             <br/>
            </div>
        </div>
    </div>

    <div style="width:48%; margin-left: 1%; float: right;">
        <h2>Shopping History</h2>
        <p>Select an item.</p>
    </div>
</asp:Content>
