<%@ Page Title="Billing" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="WebsiteLaitBrasseur.Billing" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<!--Page managing the collection of shipping informations -->

    <!-- Global container-->
    <div class="container-fluid col-md-12 row">
 
            <!-- First Big container : form fot informations about shipping adress-->
            <div class="col-md-3"  >
                <h1>Shipping Adress</h1>

                <!--Label /TextBox / Validator for the Country-->
                <div class="form-group">
                    <div >
                            <label for="TextCountry" class="control-label">Country</label>
                            <asp:TextBox ID="TextCountry" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="CountryReqField" runat="server" ErrorMessage="Country is required" ControlToValidate="TextCountry" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    </div>
                </div>

                <!--Label /TextBox / Validator for the Name-->
                <div class="form-group">
                    <div>
                            <label for="TextName" class="control-label">Full Name</label>
                            <asp:TextBox ID="TextName" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="NameReqField" runat="server" ErrorMessage="Name is required" ControlToValidate="TextName" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    </div>
                </div>

                <!--Label /Double TextBox / Single Validator for the Adress-->
                <div class="form-group">
                    <div>
                            <label for="TextAdress" class="control-label">Adress</label>
                            <asp:TextBox ID="TextAdress1" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="AdressReqField" runat="server" ErrorMessage="Adress is required" ControlToValidate="TextAdress1" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                            <asp:TextBox ID="TextAdress2" runat="server" Cssclass="form-control"> </asp:TextBox>
                    </div>
                </div>

                <!--Label /TextBox /  Validator for the City-->
                <div class="form-group">
                    <div>
                            <label for="TextCity" class="control-label">City</label>
                            <asp:TextBox ID="TextCity" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="CityReqField" runat="server" ErrorMessage="City is required" ControlToValidate="TextCity" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    </div>
                </div>

                <!--Label /TextBox /  Validator for the State-->
                <div class="form-group">
                    <div >
                            <label for="TextState" class="control-label">State / Province / Region</label>
                            <asp:TextBox ID="TextState" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="StatereqField" runat="server" ErrorMessage="This field is required" ControlToValidate="TextState" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    </div>
                </div>

                <!--Label /TextBox /  Validator(+format zipcode validator) for the ZipCode-->
                <div class="form-group">
                    <div>
                            <label for="TextZip" class="control-label">Zip Code</label>
                            <asp:TextBox ID="TextZip" runat="server" Cssclass="form-control" TextMode="Number"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ZipReqField" runat="server" ErrorMessage="Zip is required" ControlToValidate="TextZip" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                            <asp:regularExpressionValidator ID="ZipRegExpValid" runat="server" ErrorMessage="Should be 5 or 9 Digits" ControlToValidate="TextZip" Display="Dynamic"  ValidationExpression="\d{5}-?(\d{4})?$" CssClass="text-danger"></asp:RegularExpressionValidator>                   
                    </div>
                </div>

                <!--Label /TextBox /  Validator(+format phone number validator) for the Phone number-->
                <div class="form-group">
                    <div>
                            <label for="TextPhone" class="control-label ">Phone Number</label>
                            <asp:TextBox ID="TextPhone" runat="server" Cssclass="form-control" TextMode="Phone"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="PhoneReqField" runat="server" ErrorMessage="Phone is required" ControlToValidate="TextPhone" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                            <asp:regularExpressionValidator ID="PhoneRegValid" runat="server" ErrorMessage="Should be 10 Digits or '+' and 11 Digits" ControlToValidate="TextPhone" Display="Dynamic"  ValidationExpression="(\+\d{1})?\d{10}$" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                    </div>
                </div>
            </div>

            <!--Button for Save the adress information / access to credit Card payment or Paypal payment-->
            <div class="col-md-4 text-center" >
                <br /><br /><br /><br />
                <asp:Button ID="SaveAdress" runat="server" CssClass="btn btn-primary" text="Save adress changes"/><br /><br /><br /><br />
                <asp:Button ID="CreditCard" runat="server" CssClass="btn btn-success" OnClick="CreditCardButton_Click" text="Credit Card"/><br /><br /><br /><br />
                <asp:Button ID="Paypal" runat="server" CssClass="btn btn-success" text="PayPal"/><br /><br /><br /><br />
            </div>

    </div>



</asp:Content>

