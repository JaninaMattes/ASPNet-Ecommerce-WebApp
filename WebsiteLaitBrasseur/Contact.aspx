<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebsiteLaitBrasseur.Contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Contact</title>

    <meta name="viewport"  content="width=device-width; initial-scale=1"/>
    <link href="/Content/bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <link href="/Content/site.css" rel="stylesheet" />
    <script src="/Scripts/jquery-3.3.1.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>

</head>
<body>
    <header class="jumbotron">
        <h1>You try to reach us ?</h1>
        <img id="logoLB" alt="LaitBrasseur_Logo" src="/Images/laitBrasseurmin.jpg" class="img-rounded img-responsive" />
    </header>

        <div>
            <h4>You can see us in the shop : </h4>
            <address > 
                <strong>Lait Brasseur<br /></strong>
                Le Champ Paveau <br />
                Tinqueux, 51430 <br />
                France <br />
                Mail: contact@laitbrasseur.com<br />
                <abbr title="Phone">Mobile:</abbr> 06-60-02-62-58
            </address>
        </div>
        <form id="ContactForm" runat="server" class="form-horizontal">
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
        </form>
<!--To the shop / adress
Let us a message : nom () / mail / message
    -->
</body>
</html>
