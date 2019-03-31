<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="WebsiteLaitBrasseur.Billing" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid ">

        <div class="col-md-12 row"   >

            <div class="col-md-3"  >
                <h1>Shipping Adress</h1>
                <div class="form-group">
                    <div >
                            <label for="TextCountry" class="control-label">Country</label>
                            <asp:TextBox ID="TextCountry" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="CountryReqField" runat="server" ErrorMessage="Country is required" ControlToValidate="TextCountry" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    </div>
                </div>

                <div class="form-group">
                    <div>
                            <label for="TextName" class="control-label">Name</label>
                            <asp:TextBox ID="TextName" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="NameReqField" runat="server" ErrorMessage="Name is required" ControlToValidate="TextName" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    </div>
                </div>

                <div class="form-group">
                    <div>
                            <label for="TextAdress" class="control-label">Adress</label>
                            <asp:TextBox ID="TextAdress1" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="AdressReqField" runat="server" ErrorMessage="Adress is required" ControlToValidate="TextAdress1" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                            <asp:TextBox ID="TextAdress2" runat="server" Cssclass="form-control"> </asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div>
                            <label for="TextCity" class="control-label">City</label>
                            <asp:TextBox ID="TextCity" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="CityReqField" runat="server" ErrorMessage="City is required" ControlToValidate="TextCity" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    </div>
                </div>

                <div class="form-group">
                    <div >
                            <label for="TextState" class="control-label">State / Province / Region</label>
                            <asp:TextBox ID="TextState" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="StatereqField" runat="server" ErrorMessage="This field is required" ControlToValidate="TextState" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    </div>
                </div>

                <div class="form-group">
                    <div>
                            <label for="TextZip" class="control-label">Zip Code</label>
                            <asp:TextBox ID="TextZip" runat="server" Cssclass="form-control" TextMode="Number"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ZipreqField" runat="server" ErrorMessage="Zip is required" ControlToValidate="TextZip" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    </div>
                </div>

                <div class="form-group">
                    <div>
                            <label for="TextPhone" class="control-label ">Phone Number</label>
                            <asp:TextBox ID="TextPhone" runat="server" Cssclass="form-control" TextMode="Phone"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="PhoneReqField" runat="server" ErrorMessage="Phone is required" ControlToValidate="TextPhone" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    </div>
                </div>
            </div>

            <div class="col-md-4 text-center" >
                <br /><br /><br /><br />
                <asp:Button ID="SaveAdress" runat="server" CssClass="btn btn-primary" text="Save adress changes"/><br /><br /><br /><br />
                <asp:Button ID="CreditCard" runat="server" CssClass="btn btn-success" OnClick="CreditCardButton_Click" text="Credit Card"/><br /><br /><br /><br />
                <asp:Button ID="Paypal" runat="server" CssClass="btn btn-success" text="PayPal"/><br /><br /><br /><br />
            </div>


        </div>

    </div>



</asp:Content>

