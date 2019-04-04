<%@ Page Language="C#" Title="User Profile" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerProfile.aspx.cs" Inherits="WebsiteLaitBrasseur.Account.CustomerProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<!--Page managing informations about an user -->

    <div class="container-fluid row">

            <div class="col-md-7">
            <h3 id="HeaderUserProfile">Profile</h3>
                <div class="col-md-4">
                    <img id="customerImg" alt="User Image" src="/Images/customerImg.jpg" class="card-img img-fluid" />
                </div>

                <div class="row" style="font-size:15px">

                    <div class="col-md-6">
                        <asp:Label ID="lblUsername" runat="server" Text="Username :" CssClass="text-info"></asp:Label><br />
                        <asp:Label ID="lblUsernameValue" runat="server" Text="JMiller51"></asp:Label>
                    </div>

                    <div class="col-md-6">
                        <asp:Label ID="lblEmail" runat="server" Text="E-mail :" CssClass="text-info"></asp:Label><br />
                        <asp:Label ID="lblEmailValue" runat="server" Text="jmiller@outlook.com"></asp:Label><br /><br />
                    </div>


                    <div class="col-md-6">
                        <asp:Label ID="lblFirstName" runat="server" Text="First name :" CssClass="text-info"></asp:Label><br />
                        <asp:Label ID="lblFirstNameValue" runat="server" Text="James"></asp:Label>
                    </div>

                    <div class="col-md-6">
                        <asp:Label ID="lblLastName" runat="server" Text="Last name :" CssClass="text-info"></asp:Label><br />
                        <asp:Label ID="lblLastNameValue" runat="server" Text="Miller"></asp:Label><br /><br />
                    </div>

                    <div>
                        <asp:Button ID="PasswordChange" runat="server" Text="Change Password" CssClass="btn btn-primary" />
                    </div>

                </div>
            </div>


            <div class="col-md-4" style="font-size:15px">
                <h3>Shopping History</h3><br />
                
                <div id="order1" class="col-md-7 rounded" style="border:solid">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:label ID="DateOrder1" runat="server" CssClass="text-info" Text="21/03/2019"></asp:label>
                        </div>
                        <div class="col-md-6 text-right">
                            <asp:label ID="PriceOrder1" runat="server" cssclass="text-info" Text="43.2€"></asp:label>
                        </div>
 
                    </div>
                    <div>
                        <br />
                        <asp:label ID="Order1Product1" runat="server" Text="- 4 Blackaty 33cl"></asp:label><br />
                        <asp:label ID="Order1Product2" runat="server" Text="- 10 LaBLonde 33cl"></asp:label>
                    </div>
                </div>


                <br />
                <div id="order2" class="col-md-7 rounded" style="border:solid">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:label ID="DateOrder2" runat="server" CssClass="text-info" Text="10/03/2019"></asp:label>
                        </div>

                        <div class="col-md-6 text-right">
                            <asp:label ID="PriceOrder2" runat="server" cssclass="text-info" Text="28.8€"></asp:label>
                        </div>

                    </div>
                    <div>
                        <br />
                        <asp:label ID="Order2Product1" runat="server" Text="- 3 Blackaty 33cl"></asp:label><br />
                        <asp:label ID="Order2Product2" runat="server" Text="- 1 Carre de l'Est 33cl"></asp:label>
                        <br />
                    </div>
                </div>
            </div>


    </div>

</asp:Content>
