<%@ Page Title="Password Change" Language="C#" MasterPageFile="~/UL/Customer/Site.Master" AutoEventWireup="true" CodeBehind="PasswordChanging.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Customer.PasswordChanging" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--Page managing the modification of a password-->

    <div class="container-fluid">
        <h3>Password Modification </h3>
        <asp:Label ID="lblResult" runat="server" Text="" CssClass="text-success"></asp:Label> 

        
        <!--Label /TextBox / Validator for Old Password -->
        <div class="form-group">
                <label for="TextOldPassword" class="control-label col-md-3 text-info">Old Password</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextOldPassword" runat="server" Cssclass="form-control" TextMode="Password"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="OldPasswordReqField" runat="server"  ControlToValidate="TextOldPassword" Display="Dynamic" CssClass="text-danger" ErrorMessage="Old Password is required"></asp:RequiredFieldValidator><br />
                </div>
         </div>
        

        <!--Label /TextBox / Validator for New Password -->
        <div class="form-group">
                <label for="TextPassword" class="control-label col-md-3 text-info">New Password</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextPassword" runat="server" Cssclass="form-control" TextMode="Password"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordField" runat="server"  ControlToValidate="TextPassword" Display="Dynamic" CssClass="text-danger" ErrorMessage="Password is required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="PasswordReqValid" runat="server" ControlToValidate="TextPassword" ValidationExpression="^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9#?!@$%^&*-]).{8,}$" ErrorMessage="The password format does not meet the requirements." CssClass="text-danger" ></asp:RegularExpressionValidator>
                    <br /><asp:Label ID="lblRequirement" runat="server" CssClass="text-info" Text="(8 characters : at least 1 upper case, 1 lower case, one number or one special character)"></asp:Label>                                  

                </div>
         </div>

         <!--Label /TextBox / Validator(compare with New password entry) for Confirm Password -->
         <div class="form-group">
                <label for="TextPasswordConf" class="control-label col-md-3 text-info">Confirm New Password</label>
                <div class="col-md-5">
                    <asp:TextBox ID="TextPasswordConf" runat="server" Cssclass="form-control" TextMode="Password" > </asp:TextBox>
                    <asp:RequiredFieldValidator ID="ConfirmPasswordField" runat="server"  ControlToValidate="TextPasswordConf" Display="Dynamic" CssClass="text-danger" ErrorMessage="Confirm password is required"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="PasswordCompValid" runat="server"  ControlToCompare="TextPassword" ControlToValidate="TextPasswordConf" Display="Dynamic" CssClass="text-danger" ErrorMessage="The password and confirmation password do not match."></asp:CompareValidator>       
                </div>
         </div>

        <!--"Change Password" button -->
         <div class="col-md-offset-3 col-md-9">
                <asp:Button ID="ChangeButton" runat="server" Text="Change Password" CssClass="btn btn-primary" OnClick="ChangeButton_Click"/>
         </div>
    </div>

</asp:Content>
