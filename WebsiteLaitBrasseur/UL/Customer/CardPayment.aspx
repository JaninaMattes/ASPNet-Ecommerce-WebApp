<%@ Page Title="Card Informations" Language="C#" MasterPageFile="~/UL/Customer/Site.Master" AutoEventWireup="true" CodeBehind="CardPayment.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Customer.CardPayment" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--START UpdatePanel fEnables sections of a page to be partially rendered without a postback. -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <!--Page managing the payment via Credit Card -->

            <!--Global container for the form -->
            <div class="container-fluid col-md-4">

                <!-- Title and feedback labels-->
                <h3>Enter your credit card informations</h3>
                <asp:Label ID="lblWait" runat="server" Text="Please Wait..." CssClass="text-info" Visible="false"></asp:Label><br />
                <asp:Label ID="lblResult" runat="server" Text="" CssClass="text-info"></asp:Label>

                <!--Label /TextBox / Validator for the Owner of the credit card-->
                <div class="form-group">
                    <div>
                        <label for="TextName" class="control-label ">CardHolder Name</label>
                        <asp:TextBox ID="TextName" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NameReqField" runat="server" ErrorMessage="Enter the name as it is on the credti card" ControlToValidate="TextName" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                    </div>
                </div>

                <!--Label /TextBox / Validators for the Number of the Card-->
                <div class="form-group">
                    <div>
                        <label for="TextCardNumber" class="control-label">Card Number</label>
                        <asp:TextBox ID="TextCardNumber" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="CardNumberReqFiled" runat="server" ErrorMessage="Card Number is required" ControlToValidate="TextCardNumber" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="CardNumberRegValid" runat="server" ErrorMessage="Should be 16 Digits" ControlToValidate="TextCardNumber" Display="Dynamic" ValidationExpression="\d{16}$" CssClass="text-danger"></asp:RegularExpressionValidator><br />

                    </div>
                </div>

                <!--DropDown List for the month and the year expiration of the card-->
                <div class="form-group">
                    <div>
                        <asp:Label ID="ExpirationLabel" runat="server">Expiration Date :</asp:Label>
                        &nbsp;&nbsp;
                    <asp:DropDownList ID="MonthExpiration" runat="server">
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
                    <asp:DropDownList ID="YearExpiration" runat="server">
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
                        <asp:TextBox ID="TextCSC" runat="server" CssClass="form-control" Style="width: 70px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CSCReqField" runat="server" ErrorMessage="CSC is required" ControlToValidate="TextCSC" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="CSCRegValid" runat="server" ErrorMessage="Should be 3 Digits" ControlToValidate="TextCSC" Display="Dynamic" ValidationExpression="\d{3}$" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                    </div>
                </div>



                <!--Button for Cancel or submit the payment -->
                <div class="col-md-offset-3 col-md-9">
                    <asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClick="CancelButton_Click" CausesValidation="false" CssClass="btn btn-danger" />
                    &nbsp;

                    <!--2Buttons for submit : they take 2 different set of Data to make the payment  -->
                        <!--Sumit Real : take data enter by user => will not work because, payment data not in the dummyAccount -->
                        <!--Submit : take data from dummyAccount =>will work-->
                    <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" CausesValidation="true" CssClass="btn btn-success" />
                    <asp:Button ID="SubmitButtonReal" runat="server" Text="Submit (Real)" OnClick="SubmitButtonReal_Click" CausesValidation="true" CssClass="btn btn-success" />
                    <asp:Label ID="lblDetails1" runat="server" Text="Submit(Real) uses the information enter by the user in the page to make the payment, so it won't work."></asp:Label><br />
                    <asp:Label ID="lblDetails2" runat="server" Text="Submit uses the information in the DummyAccount of the Payment System to make it work."></asp:Label>
                </div>
            </div>

            <!--END UpdatePanel Enables sections of a page to be partially rendered without a postback. -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
