<%@ Page Title="Card Informations" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CardPayment.aspx.cs" Inherits="WebsiteLaitBrasseur.CardPayment" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<!--Page managing the payment via Credit Card -->

    <!--Global container for the form -->
    <div class="container-fluid col-md-4"  ">

            <h3>Enter your credit card informations</h3>

            <!--Label /TextBox / Validator for the Owner of the credit card-->
            <div class="form-group">
                <div>
                    <label for="TextName" class="control-label ">CardHolder Name</label>
                    <asp:TextBox ID="TextName" runat="server" Cssclass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="NameReqField" runat="server" ErrorMessage="Enter the name as it is on the credti card" ControlToValidate="TextName" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                </div>
            </div>

            <!--Label /Radio button / Validator for the Type of Card-->
            <div class="form-group">
                <div>
                     <label class="control-label "> Card Type :</label>
                     &nbsp;&nbsp;
                    <asp:RadioButtonList ID="CreditCardButton" runat="server">
                        <asp:ListItem Text="<img id='LogoVisa' alt='Visa' src='/Images/visa_logo.jpg' style='height:40px;width:40px'/>"  ></asp:ListItem>
                        <asp:ListItem Text="<img id='LogoMasterCard' alt='Mastercard' src='/Images/mastercard-logo-.png' style='height:50px;width:50px;' />"></asp:ListItem>
                    </asp:RadioButtonList>

                     <asp:RequiredFieldValidator ID="TypeCardReqField" runat="server" ErrorMessage="Choose a type of Credit Card" ControlToValidate="CreditCardButton" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />

                </div>

            </div>

            <!--Label /TextBox / Validators for the Type of Card-->
            <div class="form-group">
                    <div >
                            <label for="TextCardNumber" class="control-label">Card Number</label>
                            <asp:TextBox ID="TextCardNumber" runat="server" Cssclass="form-control" > </asp:TextBox>
                            <asp:RequiredFieldValidator ID="CardNumberReqFiled" runat="server" ErrorMessage="Card Number is required" ControlToValidate="TextCardNumber" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                            <asp:regularExpressionValidator ID="CardNumberRegValid" runat="server" ErrorMessage="Should be 20 Digits" ControlToValidate="TextCardNumber" Display="Dynamic"  ValidationExpression="\d{20}$" CssClass="text-danger"></asp:RegularExpressionValidator><br />

                    </div>
                </div>   

            <!--DropDown List for the month and the year expiration of the card-->
            <div class="form-group">
                <div>
                    <asp:label id="ExpirationLabel" runat="server" >Expiration Date :</asp:label>
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="MonthExpiration" runat="server" >
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
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="YearExpiration" runat="server" >
                         <asp:ListItem Selected="True" Value="2019"></asp:ListItem>
                         <asp:ListItem Value="2020"></asp:ListItem>
                         <asp:ListItem Value="2021"></asp:ListItem>
                         <asp:ListItem Value="2022"></asp:ListItem>
                         <asp:ListItem Value="2023"></asp:ListItem>
                         <asp:ListItem Value="2024"></asp:ListItem>
                         <asp:ListItem Value="2025"></asp:ListItem>                      
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <div>
                    <label for="TextCSC" class="control-label ">Security Code (CSC :)</label>
                    <asp:TextBox ID="TextCSC" runat="server" Cssclass="form-control" style="width:70px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="CSCReqField" runat="server" ErrorMessage="CSC is required" ControlToValidate="TextCSC" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:regularExpressionValidator ID="CSCRegValid" runat="server" ErrorMessage="Should be 3 Digits" ControlToValidate="TextCSC" Display="Dynamic"  ValidationExpression="\d{3}$" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                </div>
            </div>

            <!--Label /TextBox / Validator for the Country-->
            <div class="form-group">
                    <div>
                            <label for="TextCountry" class="control-label">Country</label>
                            <asp:TextBox ID="TextCountry" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="CountryReqField" runat="server" ErrorMessage="Country is required" ControlToValidate="TextCountry" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    </div>
                </div> 

            <!--Label /TextBoxs / Validator for the Adress-->
            <div class="form-group">
                    <div>
                            <label for="TextAdress" class="control-label">Billing Adress</label>
                            <asp:TextBox ID="TextAdress1" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="AdressReqField" runat="server" ErrorMessage="Adress is required" ControlToValidate="TextAdress1" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                            <asp:TextBox ID="TextAdress2" runat="server" Cssclass="form-control"> </asp:TextBox>
                    </div>
                </div>

            <!--Label /TextBox / Validator for the Citys-->
            <div class="form-group">
                    <div>
                            <label for="TextCity" class="control-label">City</label>
                            <asp:TextBox ID="TextCity" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="CityReqField" runat="server" ErrorMessage="City is required" ControlToValidate="TextCity" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    </div>
                </div>

            <!--Label /TextBox / Validator for the State-->
            <div class="form-group">
                    <div>
                            <label for="TextState" class="control-label">State / Province / Region</label>
                            <asp:TextBox ID="TextState" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="StatereqField" runat="server" ErrorMessage="This field is required" ControlToValidate="TextState" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    </div>
                </div>

            <!--Label /TextBox / Validator(+format zipcode validator) for the ZipCode-->
            <div class="form-group">
                    <div>
                            <label for="TextZip" class="control-label">Zip Code</label>
                            <asp:TextBox ID="TextZip" runat="server" Cssclass="form-control" TextMode="Number"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ZipReqField" runat="server" ErrorMessage="Zip is required" ControlToValidate="TextZip" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                            <asp:regularExpressionValidator ID="ZipRegExpValid" runat="server" ErrorMessage="Should be 5 or 9 Digits" ControlToValidate="TextZip" Display="Dynamic"  ValidationExpression="\d{5}-?(\d{4})?$" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                    </div>
           </div>
  
           <!--Button for Cancel or submit the payment-->        
           <div class="col-md-offset-3 col-md-9">
                <asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClick="CancelButton_Click" CausesValidation="false" CssClass="btn btn-danger"/>
                        &nbsp;
                <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" CssClass="btn btn-success"/>
           </div>


      </div>
</asp:Content>
