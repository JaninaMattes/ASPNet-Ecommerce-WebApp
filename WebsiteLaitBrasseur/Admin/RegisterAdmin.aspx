<%@ Page Title="Admin Registration" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="RegisterAdmin.aspx.cs" Inherits="WebsiteLaitBrasseur.Admin.RegisterAdmin" %>



<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    
<!--Page managing the registration of a new admin -->

    <h3>  Create a new Admin account</h3>

        <!--Label /TextBox / Validator for the Username -->
        <div class="form-group">
            <label for="TextUsername" class="control-label col-md-3">Username</label>
            <div class="col-md-5">
                <asp:TextBox ID="TextUsername" runat="server" Cssclass="form-control"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="UsernameReqField" runat="server"  ControlToValidate="TextUsername" Display="Dynamic" CssClass="text-danger" ErrorMessage="Username is required"></asp:RequiredFieldValidator><br />

            </div>
        </div>

        <!--Label /TextBox / Validator for E-mail -->
        <div class="form-group">
                <label for="TextEmail" class="control-label col-md-3">E-mail</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextEmail" runat="server" Cssclass="form-control" TextMode="Email"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailReqField" runat="server"  ControlToValidate="TextEmail" Display="Dynamic" CssClass="text-danger" ErrorMessage="Email is required"></asp:RequiredFieldValidator><br />
                </div>
        </div>
   
         <!--Label /TextBox / Validator(compare with first email entry) for Confirm Email -->
         <div class="form-group">
                <label for="TextEmailConf" class="control-label col-md-3">Confirm E-mail</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextEmailConf" runat="server" Cssclass="form-control" TextMode="Email" > </asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailConfReqField" runat="server"  ControlToValidate="TextEmailConf" Display="Dynamic" CssClass="text-danger" ErrorMessage="Confirm email is required"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="EmailCompValid" runat="server"  ControlToCompare="TextEmail" ControlToValidate="TextEmailConf" Display="Dynamic" CssClass="text-danger" ErrorMessage="The email and confirmation email do not match."></asp:CompareValidator>       
                </div>
         </div>

       <!--Label /TextBox / Validator for First Name -->
       <div class="form-group">
            <label for="TextFirstName" class="control-label col-md-3">First name</label>
            <div class="col-md-5">
                <asp:TextBox ID="TextFirstName" runat="server" Cssclass="form-control"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="FirstNameReqField" runat="server"  ControlToValidate="TextFirstName" Display="Dynamic" CssClass="text-danger" ErrorMessage="First name is required"></asp:RequiredFieldValidator><br />
            </div>
        </div>

       <!--Label /TextBox / Validator for Last Name -->
        <div class="form-group">
            <label for="TextLastName" class="control-label col-md-3">Last name</label>
            <div class="col-md-5">
                <asp:TextBox ID="TextLastName" runat="server" Cssclass="form-control"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="LastNameReqField" runat="server"  ControlToValidate="TextLastName" Display="Dynamic" CssClass="text-danger" ErrorMessage="Last name is required"></asp:RequiredFieldValidator><br />
            </div>
        </div>

        <!--Label /DropDownList for Birth Date-->
        <div class="form-group">
               <div Class="col-md-3">
                <asp:label ID="BirthDateLabel" runat="server"  Text="Birth Date : "></asp:label>
                    &nbsp&nbsp
                    <asp:DropDownList ID="BirthDay" runat="server" >
                         <asp:ListItem Selected="True" Value="1"></asp:ListItem>
                         <asp:ListItem Value="2"></asp:ListItem>
                         <asp:ListItem Value="3"></asp:ListItem>
                         <asp:ListItem Value="4"></asp:ListItem>
                         <asp:ListItem Value="5"></asp:ListItem>
                         <asp:ListItem Value="6"></asp:ListItem>
                         <asp:ListItem Value="7"></asp:ListItem>
                         <asp:ListItem Value="8"></asp:ListItem>
                         <asp:ListItem Value="9"></asp:ListItem>
                         <asp:ListItem Value="10"></asp:ListItem>
                         <asp:ListItem Value="11"></asp:ListItem>
                         <asp:ListItem Value="12"></asp:ListItem>
                         <asp:ListItem Value="13"></asp:ListItem>
                         <asp:ListItem Value="14"></asp:ListItem>
                         <asp:ListItem Value="15"></asp:ListItem>
                         <asp:ListItem Value="16"></asp:ListItem>
                         <asp:ListItem Value="17"></asp:ListItem>
                         <asp:ListItem Value="18"></asp:ListItem>
                         <asp:ListItem Value="19"></asp:ListItem>
                         <asp:ListItem Value="20"></asp:ListItem>
                         <asp:ListItem Value="21"></asp:ListItem>
                         <asp:ListItem Value="22"></asp:ListItem>
                         <asp:ListItem Value="23"></asp:ListItem>
                         <asp:ListItem Value="24"></asp:ListItem>
                         <asp:ListItem Value="25"></asp:ListItem>
                         <asp:ListItem Value="26"></asp:ListItem>
                         <asp:ListItem Value="27"></asp:ListItem>
                         <asp:ListItem Value="28"></asp:ListItem>
                         <asp:ListItem Value="29"></asp:ListItem>
                         <asp:ListItem Value="30"></asp:ListItem>
                         <asp:ListItem Value="31"></asp:ListItem>
                    </asp:DropDownList>
                    &nbsp/&nbsp
                    <asp:DropDownList ID="BirthMonth" runat="server" >
                         <asp:ListItem Selected="True" Value="1"></asp:ListItem>
                         <asp:ListItem Value="2"></asp:ListItem>
                         <asp:ListItem Value="3"></asp:ListItem>
                         <asp:ListItem Value="4"></asp:ListItem>
                         <asp:ListItem Value="5"></asp:ListItem>
                         <asp:ListItem Value="6"></asp:ListItem>
                         <asp:ListItem Value="7"></asp:ListItem>
                         <asp:ListItem Value="8"></asp:ListItem>
                         <asp:ListItem Value="9"></asp:ListItem>
                         <asp:ListItem Value="10"></asp:ListItem>
                         <asp:ListItem Value="11"></asp:ListItem>
                         <asp:ListItem Value="12"></asp:ListItem>
                    </asp:DropDownList>
                    &nbsp/&nbsp
                    <asp:DropDownList ID="BirthYear" runat="server" >
                         <asp:ListItem  Value="1970"></asp:ListItem>
                         <asp:ListItem  Value="1971"></asp:ListItem>
                         <asp:ListItem  Value="1972"></asp:ListItem>
                         <asp:ListItem  Value="1973"></asp:ListItem>
                         <asp:ListItem  Value="1974"></asp:ListItem>
                         <asp:ListItem  Value="1975"></asp:ListItem>
                         <asp:ListItem  Value="1976"></asp:ListItem>
                         <asp:ListItem  Value="1977"></asp:ListItem>
                         <asp:ListItem  Value="1978"></asp:ListItem>
                         <asp:ListItem  Value="1979"></asp:ListItem>
                         <asp:ListItem  Value="1980"></asp:ListItem>
                         <asp:ListItem  Value="1981"></asp:ListItem>
                         <asp:ListItem  Value="1982"></asp:ListItem>
                         <asp:ListItem  Value="1983"></asp:ListItem>
                         <asp:ListItem  Value="1984"></asp:ListItem>
                         <asp:ListItem  Value="1985"></asp:ListItem>
                         <asp:ListItem  Value="1986"></asp:ListItem>
                         <asp:ListItem  Value="1987"></asp:ListItem>
                         <asp:ListItem  Value="1988"></asp:ListItem>
                         <asp:ListItem  Value="1989"></asp:ListItem>
                         <asp:ListItem  Value="1990"></asp:ListItem>
                         <asp:ListItem  Value="1991"></asp:ListItem>
                         <asp:ListItem  Value="1992"></asp:ListItem>
                         <asp:ListItem  Value="1993"></asp:ListItem>
                         <asp:ListItem  Value="1994"></asp:ListItem>
                         <asp:ListItem  Value="1995"></asp:ListItem>
                         <asp:ListItem  Value="1996"></asp:ListItem>
                         <asp:ListItem  Selected="True" Value="1997"></asp:ListItem>
                         <asp:ListItem  Value="1998"></asp:ListItem>
                         <asp:ListItem  Value="1999"></asp:ListItem>
                         <asp:ListItem  Value="2000"></asp:ListItem>
                         <asp:ListItem  Value="2001"></asp:ListItem>
         
                    </asp:DropDownList>
                </div>
         </div>

        <!--Label /TextBox / Validator for Password -->
        <div class="form-group">
                <label for="TextPassword" class="control-label col-md-3">Password</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextPassword" runat="server" Cssclass="form-control" TextMode="Password"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordField" runat="server"  ControlToValidate="TextPassword" Display="Dynamic" CssClass="text-danger" ErrorMessage="Password is required"></asp:RequiredFieldValidator><br />
                </div>
         </div>

         <!--Label /TextBox / Validator(compare with first password entry) for Confirm Password -->
         <div class="form-group">
                <label for="TextPasswordConf" class="control-label col-md-3">Confirm Password</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextPasswordConf" runat="server" Cssclass="form-control" TextMode="Password" > </asp:TextBox>
                    <asp:RequiredFieldValidator ID="ConfirmPasswordField" runat="server"  ControlToValidate="TextPasswordConf" Display="Dynamic" CssClass="text-danger" ErrorMessage="Confirm password is required"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="PasswordCompValid" runat="server"  ControlToCompare="TextPassword" ControlToValidate="TextPasswordConf" Display="Dynamic" CssClass="text-danger" ErrorMessage="The password and confirmation password do not match."></asp:CompareValidator>       
                </div>
         </div>

        <!--"Create Account" button &  "Cancel" Button => Back to DefaultAdmin.aspx -->
         <div class="col-md-offset-3 col-md-9">
                <asp:button ID="CancelButton" runat="server" Text="Cancel" CssClass="btn btn-primary" CausesValidation="False" OnClick="CancelButton_Click"/>
                <asp:Button ID="CreateAccountButton" runat="server" Text="Create Account" CssClass="btn btn-primary" OnClick="CreateAccountButton_Click"/>
         </div>
        
            <div class="col-md-9">
                <asp:Label ID="Label1" runat="server" CssClass="text-info"></asp:Label>
            </div>

</asp:Content>
