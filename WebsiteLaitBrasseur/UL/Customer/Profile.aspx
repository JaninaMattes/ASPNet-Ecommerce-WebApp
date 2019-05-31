<%@ Page Language="C#" Title="Customer Profile" MasterPageFile="~/UL/Customer/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Customer.Profile" %>

<asp:Content id="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <!--START UpdatePanel fEnables sections of a page to be partially rendered without a postback. -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

<!--Page managing an user profile-->

    <div class="container-fluid">
        <div class="row" >

            <!--First column : User picture and "Save"/"Delete" button-->
            <div class="col-md-2" >
                <div class="text-center">
                    <!--Image informations  -->
                    <asp:ImageButton ID="ProfilePicture" runat="server" ToolTip="Profile Image" DataImageUrlField="Path"  AlternateText="Format issue"  CssClass="img-thumbnail"/>                   
                    <!--TextBox for add a link to the new image + button to upload it -->
                    <asp:TextBox ID="TextImageLink" runat="server" Text="Image link" CssClass="form-control"></asp:TextBox><br />
                    <asp:Button ID="UploadButton" ToolTip="Update image." runat="server"  Text="Upload Image" OnClick="UploadButton_Click" CausesValidation="false"  CssClass="btn btn-primary" /><br />
 
		        </div>
                <div class="text-center">
                    <br /><br /><br />
                    <asp:button ID="DeleteButton" runat="server" ToolTip="Delete profile." Text="Delete Profile" class="btn btn-danger" OnClick="DeleteButton_Click"/><br /><br /><br />
                    <asp:button ID="SaveButton" runat="server" Text="Save Changes" class="btn btn-success" OnClick="SaveButton_Click"/><br /><br /><br />
                    
                </div>
            </div>

            <div class="col-md-5">
                <div id="UserInformation">
                    <h3 >Your informations</h3>

                    <!--FirstName + Last Name -->
                    <div class="row ">
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

                    <!--Email + Phone -->
                    <div class="row">
                        <!--Label / TextBox / Validator for Email-->
                        <div class="col-md-6">
                                <br />
                                <label for="TextEmail" class="control-label  text-info">E-mail</label>
                                <asp:TextBox id="TextEmail" Text="Please add email" ToolTip="Email address." runat="server" AutoPostBack="True" Cssclass="form-control" TextMode="email"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailReqField" runat="server" ControlToValidate="TextEmail" Display="Dynamic" ErrorMessage="Email is required" CssClass="text-danger"></asp:RequiredFieldValidator>

                        </div>

                        <!--Label / TextBox / Validators(Required + regular expression) for Phone number-->
                        <div class="col-md-6">
                                <br />
                                <label for="TextPhone" class="control-label  text-info">Phone Number</label>
                                <asp:TextBox id="TextPhone" Text="Please add phone number" ToolTip="Edit phonenumber." runat="server" AutoPostBack="True" Cssclass="form-control" TextMode="Phone"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="PhoneNumberReqField" runat="server" ControlToValidate="TextPhone" Display="Dynamic" ErrorMessage="Phone number is required" CssClass="text-danger"></asp:RequiredFieldValidator>
                                <asp:regularExpressionValidator ID="PhoneRegValid" runat="server" ErrorMessage="Should be 10 Digits or '+' and 11 Digits" ControlToValidate="TextPhone" Display="Dynamic"  ValidationExpression="(\+\d{1})?\d{10}$" CssClass="text-danger"></asp:RegularExpressionValidator>
                     
                        </div>   
                    </div>

                    <!--Birthday + passwordchange button  -->
                    <div class="row">
                        <!--Label /TextBox / Validator for BirthDay -->
                        <div class="col-md-6">
                            <br />
                            <label for="TextBirthday" class="control-label  text-info">Birthdate</label>
                            <asp:TextBox ID="TextBirthday" ToolTip="Edit birthdate." runat="server" Cssclass="form-control" TextMode="Date" > </asp:TextBox>
                            <asp:RequiredFieldValidator ID="BirthdayReqField" runat="server"  ControlToValidate="TextBirthday" Display="Dynamic" CssClass="text-danger" ErrorMessage="Birthdate is required"></asp:RequiredFieldValidator>
                        </div>

                        <!--Password change button -->
                        <div class="col-md-6 text-center">
                            <br /><br />
                            <asp:Button ID="ChangePasswordButton" runat="server" Text="Change Password" class="btn btn-primary" />
                        </div>


                    </div>
                </div>
                <br /> <hr />
                <!--User Address information -->
                <div id="userAddress">

                    <!--Address 1/2 -->
                    <div class="row">
                        <!--Label / TextBox / Validator for  Address number -->
                        <div class="col-md-2">
                            <br />
                            <label for="TextAdressnumber" class="control-label text-info">Address n°</label>
                            <asp:TextBox ID="TextAddressnumber" ToolTip="Edit address number." runat="server" Cssclass="form-control" TextMode="Number"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="AdressnumberReqField" runat="server" ErrorMessage="Adress number is required" ControlToValidate="TextAddressnumber" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>                           
                        </div>

                        <!--Label / TextBox / Validator for Street Name -->
                        <div class="col-md-10">
                            <br />
                            <label for="TextAddress " class="control-label text-info">Street Name</label>
                            <asp:TextBox ID="TextAddress1" ToolTip="Edit address." runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="AddressReqField" runat="server" ErrorMessage="Address is required" ControlToValidate="TextAddress1" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>                           
                        </div>         
                    </div>


                    <!--Zip Code + City -->
                    <div class="row">
                        <!--Label / TextBox / Validators(required + regular expression) for Zip code -->
                        <div class="col-md-6">
                            <br />
                            <label for="TextZip" class="control-label text-info">Zip Code</label>
                            <asp:TextBox ID="TextZip" ToolTip="Edit postcode." runat="server" Cssclass="form-control" TextMode="Number"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ZipReqField" runat="server" ErrorMessage="Zip is required" ControlToValidate="TextZip" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                            <asp:regularExpressionValidator ID="ZipRegExpValid" runat="server" ErrorMessage="Should be 4 digits" ControlToValidate="TextZip" Display="Dynamic"  ValidationExpression="\d{4}$" CssClass="text-danger"></asp:RegularExpressionValidator>                      
                        </div>    

                        <!--Label / TextBox / Validator for City-->
                        <div class="col-md-6">
                            <br />
                            <label for="TextCity" class="control-label text-info">City</label>
                            <asp:TextBox ID="TextCity" ToolTip="Edit city." runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="CityReqField" runat="server" ErrorMessage="City is required" ControlToValidate="TextCity" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>         
                    </div>


                    <!--Name + Country -->
                    <div class="row">
                        <!--Label / TextBox / Validator for Name -->
                        <div class="col-md-6">
                            <br />
                            <label for="TextName" class="control-label text-info">Full Name</label>
                            <asp:TextBox ID="TextName" runat="server" Cssclass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="NameReqField" runat="server" ErrorMessage="Name is required" ControlToValidate="TextName" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>

                        <!--DropDownList for Country-->
                        <div class="col-md-6">
                            <br />
                            <label for="CountryDropDownList"  class="text-info">Country</label>
                            <asp:DropDownList ID="CountryDropDownList" runat="server" Cssclass="form-control">
                               <asp:ListItem Value="1" Selected="true">Australia</asp:ListItem>
                               <asp:ListItem Value="2">New Zealand</asp:ListItem>
                               <asp:ListItem Value="3">Belgium</asp:ListItem>
                               <asp:ListItem Value="4">France</asp:ListItem>
                               <asp:ListItem Value="5">Germany</asp:ListItem>
                            </asp:DropDownList>
                        </div>  
                    </div>

                </div>
            </div>


            <!--User shopping history -->
            <div class="col-md-5">
                <div id="tableShoppingHistory clearfix">

                    <h3 id="sheader">Shopping History</h3>

                    <asp:Label id="tableShoppingHistoryLabel" Text="Your shopping history is empty." runat="server" />

                        <!--GridView with dummy data for shopping history -->
                        <asp:GridView id="ShoppingTable" runat="server"
                            class="table table-hover table-striped text-center"
                            GridLines="None"
                            emptydatatext="No data available." 
                            AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="InvoiceNumber" HeaderText="Invoice Number" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                    <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount(€)" />
                                    <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                                    <asp:BoundField DataField="ArrivalDate" HeaderText="Arrival Date" />
                                    <asp:BoundField DataField="PaymentDate" HeaderText="Payment Date" />
                                    <asp:BoundField DataField="PaymentStatus" HeaderText="Payment Status" />
                                </Columns>
                            </asp:GridView>
                </div>
            </div>
        </div>
    </div>

         <!--END UpdatePanel Enables sections of a page to be partially rendered without a postback. -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
