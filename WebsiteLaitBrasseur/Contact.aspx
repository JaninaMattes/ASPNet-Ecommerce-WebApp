<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebsiteLaitBrasseur.Contact" %>


<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">



    <div class="container-fluid">
         <h1>You try to reach us ?</h1>
         <h4>You can see us in the shop : </h4>
            <address > 
                <strong>Lait Brasseur<br /></strong>
                Le Champ Paveau <br />
                Tinqueux, 51430 <br />
                France <br />
                Mail: contact@laitbrasseur.com<br />
                <abbr title="Phone">Mobile:</abbr> 06-60-02-62-58
            </address>

        <h4>Or you can let us a message :</h4>

            <div class="form-group">
                <label for="TextName" class="control-label col-md-3">Name (or Social Reason)*</label>
                <div class="col-md-3">
                    <asp:TextBox ID="TextName" runat="server" Cssclass="form-control"> </asp:TextBox>
                </div>

                <label for="TextEmail" class="control-label col-md-3">Email*</label>
                <div class="col-md-3">
                    <asp:TextBox ID="TextEmail" runat="server" Cssclass="form-control" TextMode="Email"> </asp:TextBox>
                </div>


                <label for="TextObject" class="control-label col-md-3">Object</label>
                <div class="col-md-3">
                    <asp:TextBox ID="TextObject" runat="server" Cssclass="form-control"> </asp:TextBox>
                </div>

                <label for="TextMessage" class="control-label col-md-3">Message</label>
                <div class="col-md-3">
                    <asp:TextBox ID="TextMessage" runat="server" Cssclass="form-control"> </asp:TextBox>
                </div>
            </div>
    </div>


</asp:Content>
