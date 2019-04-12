<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebsiteLaitBrasseur.Contact" %>


<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">

<!--Page managing the way to contact directly the company -->


    <div class="container-fluid">
        <!--Informations for physical Contact-->
         <h1 class="text-info">You try to reach us ?</h1>
         <h4 class="text-info">You can see us in the shop : </h4>
            <address > 
                <strong>Lait Brasseur<br /></strong>
                Le Champ Paveau <br />
                Tinqueux, 51430 <br />
                France <br />
                Mail: contact@laitbrasseur.com<br />
                <abbr title="Phone">Mobile:</abbr> 06-60-02-62-58
            </address>


        <h4 class="text-info">Or you can let us a message :</h4>

            <!--Contact From to let a message -->
            <div class="form-group">

                <!--Label / TextBox / Validator  for Name -->
                <label for="TextName" class="control-label col-md-3">Name (or Social Reason)*</label>
                <div class="col-md-4">
                    <asp:TextBox ID="TextName" runat="server" ToolTip="Add name." Cssclass="form-control"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="NameReqField" runat="server" ErrorMessage="Name is required" ControlToValidate="TextName" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>

                <!--Label / TextBox / Validator  for E-mail-->
                <label for="TextEmail" class="control-label col-md-3">Email*</label>
                <div class="col-md-4">
                    <asp:TextBox ID="TextEmail" runat="server" ToolTip="Add email." Cssclass="form-control" TextMode="Email"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailReqField" runat="server" ErrorMessage="E-mail is required" ControlToValidate="TextEmail" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>

                <!--Label / TextBox for Object-->
                <label for="TextObject" class="control-label col-md-3">Object</label>
                <div class="col-md-4">
                    <asp:TextBox ID="TextObject" runat="server" Cssclass="form-control"> </asp:TextBox>
                </div>

                <!--Label / TextBox / Validator for Message-->
                <label for="TextMessage" class="control-label col-md-3" >Message</label>
                <div class="col-md-4">
                    <asp:TextBox ID="TextMessage" runat="server" ToolTip="Leave a message." Cssclass="form-control" Height="120px"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="MessageReqField" runat="server" ErrorMessage="Message is required" ControlToValidate="TextMessage" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>

                <!--Button submit + confimation Label -->
                <div class="col-md-offset-3 col-md-4">
                    <asp:Button ID="SubmitButton" runat="server" Text="Submit" ToolTip="Submit" OnClick="SubmitButton_Click" CssClass="btn btn-success"/>
                    <asp:Label ID="ResultLabel" runat="server" Text="" CssClass=" text-success"></asp:Label>
                </div>
            </div>
    </div>


</asp:Content>
