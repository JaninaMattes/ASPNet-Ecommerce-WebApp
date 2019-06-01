<%@ Page Title="Billing" Language="C#" MasterPageFile="~/UL/Customer/Site.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Customer.Billing" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<!--START UpdatePanel fEnables sections of a page to be partially rendered without a postback. -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

<!--Page managing the collection of shipping informations -->

    <!-- Global container-->
    <div class="container-fluid col-md-12 row">
 
            <!-- First Big container : form fot informations about shipping adress-->
            <div class="col-md-3"  >
                <h1>Shipping Adress</h1>
                <asp:Label ID="lblResultNamePhone" runat="server" Text="" CssClass="text-info"></asp:Label><br />
                <asp:Label ID="lblResultAddress" runat="server" Text="" CssClass="text-info"></asp:Label>

                <!--Label /DropDown List for the Country-->
                <div class="form-group">
                            <label for="CountryDropDownList"  class="text-info">Country</label>
                            <asp:DropDownList ID="CountryDropDownList" runat="server" Cssclass="form-control">
                               <asp:ListItem Value="1" Selected="true">Australia</asp:ListItem>
                               <asp:ListItem Value="2">New Zealand</asp:ListItem>
                               <asp:ListItem Value="3">Belgium</asp:ListItem>
                               <asp:ListItem Value="4">France</asp:ListItem>
                               <asp:ListItem Value="5">Germany</asp:ListItem>
                            </asp:DropDownList>
                </div>  
                <!--Label /TextBox / Validator for the Name-->
                    <!--FirstName + Last Name -->
                    <div class="form-group row ">
                        <!--Label / TextBox / Validator for First Name-->
                        <div class="col-md-6">
                                <br />
                                <label for="TextFirstname" class="control-label  text-info">First name</label>
                                <asp:TextBox id="TextFirstname" Text="Please add firstname." ToolTip="Edit firstname." runat="server" AutoPostBack="True" Cssclass="form-control"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="FirstnameReqField" runat="server" ControlToValidate="TextFirstname" Display="Dynamic" ErrorMessage="Firstname is required" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>

                        <!--Label / TextBox / Validator for Last Name-->
                        <div class="col-md-6">
                                <br /> 
                                <label for="TextLastname" class="control-label  text-info">Last name</label>
                                <asp:TextBox id="TextLastname" Text="Please add lastname." ToolTip="Edit lastname." runat="server" AutoPostBack="True" Cssclass="form-control"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="LastNameReqField" runat="server" ControlToValidate="TextLastname" Display="Dynamic" ErrorMessage="Lastname is required" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>     
                   </div>

                <!--Label /Double TextBox / Single Validator for the Adress-->
                <div class="form-group row">
                    <div class="col-md-4">
                            <label for="TextAddressnumber" class="control-label text-info">Adress N°</label>
                            <asp:TextBox ID="TextAddressnumber" runat="server" Cssclass="form-control" TextMode="number"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="AddressnumberReqField" runat="server" ErrorMessage="Address number is required" ControlToValidate="TextAddressnumber" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-md-8">
                            <label for="TextAddress" class="control-label text-info">Adress</label>
                            <asp:TextBox ID="TextAddress" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="AddressReqField" runat="server" ErrorMessage="Address is required" ControlToValidate="TextAddress" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />

                    </div>
                </div>

                <!--Label /TextBox /  Validator for the City-->
                <div class="form-group">
                    <div>
                            <label for="TextCity" class="control-label text-info">City</label>
                            <asp:TextBox ID="TextCity" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="CityReqField" runat="server" ErrorMessage="City is required" ControlToValidate="TextCity" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    </div>
                </div>

                <!--Label /TextBox /  Validator(+format zipcode validator) for the ZipCode-->
                <div class="form-group">
                    <div>
                            <label for="TextZip" class="control-label text-info">Zip Code</label>
                            <asp:TextBox ID="TextZip" runat="server" Cssclass="form-control" TextMode="Number"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ZipReqField" runat="server" ErrorMessage="Zip is required" ControlToValidate="TextZip" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                            <asp:regularExpressionValidator ID="ZipRegExpValid" runat="server" ErrorMessage="Should be 4" ControlToValidate="TextZip" Display="Dynamic"  ValidationExpression="\d{4}$" CssClass="text-danger"></asp:RegularExpressionValidator>                   
                    </div>
                </div>

                <!--Label /TextBox /  Validator(+format phone number validator) for the Phone number-->
                <div class="form-group">
                    <div>
                            <label for="TextPhone" class="control-label text-info ">Phone Number</label>
                            <asp:TextBox ID="TextPhone" runat="server" Cssclass="form-control" TextMode="Phone"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="PhoneReqField" runat="server" ErrorMessage="Phone is required" ControlToValidate="TextPhone" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                            <asp:regularExpressionValidator ID="PhoneRegValid" runat="server" ErrorMessage="Should be 10 Digits or '+' and 11 Digits" ControlToValidate="TextPhone" Display="Dynamic"  ValidationExpression="(\+\d{1})?\d{10}$" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                    </div>
                </div>
            </div>

            <!--Button for Save the adress information / access to credit Card payment or Paypal payment-->
            <div class="col-md-4 text-center" >
                <br /><br /><br /><br />
                <asp:Button ID="SaveAddress" runat="server" CssClass="btn btn-primary" text="Save address changes" OnClick="SaveButton_Click"/><br /><br /><br /><br />
                <asp:Button ID="CreditCard" runat="server" CssClass="btn btn-success" OnClick="CreditCardButton_Click" text="Credit Card"/><br /><br /><br /><br />
                <asp:Button ID="Paypal" runat="server" CssClass="btn btn-success" text="PayPal"/><br /><br /><br /><br />
            </div>

    </div>

<!--END UpdatePanel Enables sections of a page to be partially rendered without a postback. -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

