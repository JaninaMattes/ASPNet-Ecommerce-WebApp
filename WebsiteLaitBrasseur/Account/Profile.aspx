<%@ Page Language="C#" Title="Customer Profile" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebsiteLaitBrasseur.Account.Profile" %>

<asp:Content id="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!--Page in split-view layout to allow user manage his profile information and review his past shopping history-->
    <!--START Container-->
    <div class="container-fluid"> <!--container-fluid allows responsive behaviour-->
        <!--START Container Content-->
        <!--START Part1: Split Screen Layout-->
        <div style="float:left; width: 15%">
            <!--START sidebar user image-->
            <div class="profile-userpic">
                <img class="img-responsive" alt="User Image" src="/Images/customerImg.jpg">
		    </div>
            <!-- END sidebar user image -->
            <div class="profile-usertitle">
                <div class="profile-usertitle">
				    <div class="profile-usertitle-name">
				        <asp:Label id="ProfileCustomerName" AssociatedControlId="FirstnameTextbox" Text="" runat="server" />
					</div>
				    <div class="profile-username">
				        <asp:Label id="ProfileUserName" AssociatedControlId="FirstnameTextbox" Text="" runat="server" />
					</div>
                    <!-- START user buttons to delete the profile -->
                    <div class="profile-userbuttons" style="bottom">
					<asp:Button id="deleteBtn" runat="server" Text="Delete Profile" OnClick="DeleteButton_Click" CssClass="btn-danger" />
					<!-- END user buttons to delete the profile -->
                </div>
            </div>
		</div>
      </div>
        <!--END Part1: Split Screen Layout-->
        <!--START Part2: Split Screen Layout-->
        <div style="float:none; width: 40%">
            <h3 id="header">Profile Details</h3>
            <div>
                <!--Part2.1: START user information-->
                <div class="clearfix" style="float:left; width: 40%; margin=1%">
                <!--Firstname Label /TextBox / Validator-->
                <div class="form-group">
                    <asp:Label id="Firstname" AssociatedControlId="FirstnameTextbox" Text="Firstname:" runat="server" />
                    <asp:TextBox id="FirstnameTextbox" Text="Please add firstname." runat="server" AutoPostBack="True" Cssclass="form-control"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="FirstnameReqField" runat="server" 
                                    ControlToValidate="FirstnameTextbox" 
                                    Display="Dynamic" 
                                    ErrorMessage="Field should not be blank."
                                    CssClass="text-danger">
                                </asp:RequiredFieldValidator>
                </div>
                <!--Username Label /TextBox / Validator-->
                <div class="form-group" style="text-align">
                    <asp:Label id="Username" AssociatedControlId="UsernameTextbox" Text="Username:" runat="server" />
                    <asp:TextBox id="UsernameTextBox" Text="Please add username." runat="server" AutoPostBack="True" Cssclass="form-control"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="UsernameReqField" runat="server" 
                                    ControlToValidate="UsernameTextBox" 
                                    Display="Dynamic" 
                                    ErrorMessage="Field should not be blank."
                                    CssClass="text-danger">
                                </asp:RequiredFieldValidator>
                </div>
                <!--Phonenumber Label /TextBox / Validator-->
                <div class="form-group" style="text-align">
                   <asp:Label id="Phonenumber" AssociatedControlId="PhoneNoTextbox" Text="Phonenumber:" runat="server" />
                   <asp:TextBox id="PhoneNoTextBox" Text="Please add valid phone number." runat="server" AutoPostBack="True" Cssclass="form-control"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="PhoneNoReqField" runat="server" 
                                    ControlToValidate="PhoneNoTextBox" 
                                    Display="Dynamic" 
                                    ErrorMessage="Field should not be blank."
                                    CssClass="text-danger">
                                </asp:RequiredFieldValidator>
                </div>
         </div>
            <!--Part2.2: START user information-->
            <div class="clearfix" style="float:right; width: 40%; margin=1%">
                <!--Lastname Label /TextBox / Validator-->
                <div class="form-group">
                    <asp:Label id="Lastname" AssociatedControlId="LastnameTextbox" Text="Lastname:" runat="server" />
                    <asp:TextBox id="LastnameTextBox" Text="Please add lastname." runat="server" AutoPostBack="True" Cssclass="form-control"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="LastNameReqField" runat="server" 
                                    ControlToValidate="LastnameTextBox" 
                                    Display="Dynamic" 
                                    ErrorMessage="Field should not be blank."
                                    CssClass="text-danger">
                                </asp:RequiredFieldValidator>
                </div>
                <!--Email Label /TextBox / Validator-->
                <div class="form-group" style="text-align">
                    <asp:Label id="Email" AssociatedControlId="EmailTextbox" Text="Email:" runat="server" />
                    <asp:TextBox id="EmailTextBox" Text="Please add email address." runat="server" AutoPostBack="True" Cssclass="form-control"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailReqField" runat="server" 
                                    ControlToValidate="EmailTextBox" 
                                    Display="Dynamic" 
                                    ErrorMessage="Field should not be blank."
                                    CssClass="text-danger">
                                </asp:RequiredFieldValidator>
                </div>
                 <!--Birthday information to later check if customer has reached the legal age to buy alcohol-->
                 <div class="form-group" style="text-align">
                    <asp:Label id="Birthday" AssociatedControlId="BirthdayTextbox" Text="Birthdate:" runat="server" />
                    <asp:TextBox id="BirthdayTextBox" Text="Please select birthday date." textmode="Date" runat="server" AutoPostBack="True" Cssclass="form-control"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="BirthdayReqField" runat="server" 
                                    ControlToValidate="BirthdayTextBox" 
                                    Display="Dynamic" 
                                    ErrorMessage="Field should not be blank."
                                    CssClass="text-danger">
                                </asp:RequiredFieldValidator>
                </div>
              </div>
            <!--Part2.2: END user information-->
            </div>
            <hr/>
            <p id="paragraph">Address Details</p>
            <!--Part2.3: START address information-->
            <div>
            <div>
                <!--Part2.4: START address information-->
                <div style="float:left; width: 50%; margin=1%">
                <!--Street Label /TextBox / Validator-->
                <div class="form-group">
                    <asp:Label id="Streetname" AssociatedControlId="StreetTextbox" Text="Streetname:" runat="server" />
                    <asp:TextBox id="StreetTextbox" Text="Please add streetname." runat="server" AutoPostBack="True" Cssclass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="StreetReqVal" runat="server" 
                                    ControlToValidate="StreetTextbox" 
                                    Display="Dynamic" 
                                    ErrorMessage="Field should not be blank."
                                    CssClass="text-danger">
                                </asp:RequiredFieldValidator>
                </div>
                <!--City Label /TextBox / Validator-->
                <div class="form-group" style="text-align">
                    <asp:Label id="City" AssociatedControlId="CityTextbox" Text="City:" runat="server" />
                    <asp:TextBox ID="CityTextBox" Text="Please add cityname." runat="server" AutoPostBack="True" Cssclass="form-control"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="CityReqVal" runat="server" 
                                    ControlToValidate="CityTextBox" 
                                    Display="Dynamic" 
                                    ErrorMessage="Field should not be blank."
                                    CssClass="text-danger">
                                </asp:RequiredFieldValidator>
                </div>
                <!--Country Label / Dropdownlist / Validator-->
                <div class="col">
                    <asp:Label id="Country" AssociatedControlId="CountryDropDownList" Text="Country:" runat="server" />
                    <asp:DropDownList ID="CountryDropDownList" runat="server" Cssclass="form-control">
                               <asp:ListItem Value="1" Selected="true">Australia</asp:ListItem>
                               <asp:ListItem Value="2">New Zealand</asp:ListItem>
                               <asp:ListItem Value="3">Belgium</asp:ListItem>
                               <asp:ListItem Value="4">France</asp:ListItem>
                               <asp:ListItem Value="5">Germany</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator InitialValue="-1" ID="Req_ID" Display="Dynamic" 
                         ValidationGroup="g1" runat="server" ControlToValidate="CountryDropDownList"
                         Text="*" ErrorMessage="ErrorMessage" CssClass="text-danger">
                    </asp:RequiredFieldValidator>
                </div>
                <!--START user buttons to save the profile -->
            <div class="profile-userbuttons" style="bottom">
                <asp:Button id="cancelBtn" runat="server" Text="Cancel" OnClick="CancelButton_Click" CssClass="btn btn-primary" />
                <asp:Button id="saveBtn" runat="server" Text="Save" OnClick="SaveButton_Click" CssClass="btn btn-primary" />
	        <!--END user buttons to save the profile -->
     </div>
         </div>
            <!--Part2.4: END address information-->
            <!--Part2.5: START address information-->
            <div style="float:right; width: 50%; margin=1%">
                <!--Streetnumber Label /TextBox / Validator-->
                <div class="form-group" style="text-align">
                    <asp:Label id="StreetNo" AssociatedControlId="StreetNoTextBox" Text="Streetnumber:" runat="server" />
                    <asp:TextBox id="StreetNoTextBox" Text="Please add streetnumber." runat="server" AutoPostBack="True" Cssclass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="StreetNoTextBox" 
                                    Display="Dynamic" 
                                    ErrorMessage="Field should not be blank."
                                    CssClass="text-danger">
                                </asp:RequiredFieldValidator>
                </div>
                <!--ZipCode Label /TextBox / Validator-->
                <div class="form-group" style="text-align">
                    <asp:Label id="PostCode" AssociatedControlId="PostCodeTextBox" Text="Postcode:" runat="server" />
                    <asp:TextBox id="PostCodeTextBox" Text="Please add postcode." runat="server" AutoPostBack="True" Cssclass="form-control"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="PostCodeReqValator5" runat="server" 
                                    ControlToValidate="PostCodeTextBox" 
                                    Display="Dynamic" 
                                    ErrorMessage="Field should not be blank."
                                    CssClass="text-danger">
                                </asp:RequiredFieldValidator>
                </div>
              </div>
            </div>
        </div>
        <!--Part2.2: END address information-->
        <!--END Part2: Split Screen Layout-->
      </div>
        <!--START Part3: Split Screen Layout-->
        <!--START Header / Label / GridView--> 
        <div id="tableShoppingHistory clearfix" style="float:right; margin-left:1%; width: 45%">
            <h3 id="sheader">Shopping History</h3>
            <asp:Label id="tableShoppingHistoryLabel" Text="Your shopping history is empty." runat="server" />
            <div class="table-dark">
                <asp:GridView id="ShoppingTable" runat="server">
                        <Columns>
                            <asp:BoundField DataField="InvoiceNumber" HeaderText="Invoice Number" />
                            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
                            <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                            <asp:BoundField DataField="ArrivalDate" HeaderText="Arrival Date" />
                        </Columns>
                    </asp:GridView>
            </div>
        </div>
        <!--END Part3: Split Screen Layout-->
    <!--END Container Content-->
<!--END Container-->
 </div>
</asp:Content>
