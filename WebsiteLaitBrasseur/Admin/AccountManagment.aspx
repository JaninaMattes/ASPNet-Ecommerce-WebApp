<%@ Page Title="Accounts Managment" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AccountManagment.aspx.cs" Inherits="WebsiteLaitBrasseur.Admin.AccountManagment" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--Page managing  "fake" user accounts-->

    <div class="container-fluid ">
        
        <div id="BodyTitle" runat="server" class="ContentHead"><h1>Manage User Accounts</h1></div>
        <!--Global container with the List of Users -->
        <div class="col-md-10 row rounded text-center"  style="border:solid;border-color:grey;"   >

                <!--Legend-->
                   <div class="col-md-2" >
                       <asp:Label ID="LegendFirstName" runat="server" cssclass="text-info" Text="First Name"></asp:Label>                 
                   </div>

                   <div class="col-md-2" >
                       <asp:Label ID="LegendLastName" runat="server" cssclass="text-info" Text="Last Name"></asp:Label>                 
                   </div>

                   <div class="col-md-2" >
                       <asp:Label ID="LegendUsername" runat="server" cssclass="text-info" Text="Username"></asp:Label>                 
                   </div>

                   <div class="col-md-2" >
                       <asp:Label ID="LegendDue" runat="server" cssclass="text-info" Text="Due"></asp:Label>                 
                   </div>

                   <div class="col-md-1" >
                       <asp:Label ID="LegendSuspend" runat="server" cssclass="text-info" Text="Suspend"></asp:Label>                 
                   </div>

                    <div class="col-md-1">
                        <asp:Label ID="LegendSelected" runat="server" cssclass="text-info" Text="Selected User"></asp:Label> 
                    </div>
        </div>

        <div class="col-md-10 row rounded text-center"  style="border:solid;border-color:grey;height:40px"    >
            <!--First User-->
            <div class="col-md-2" >
                <asp:Label ID="FirstUserFirstName" runat="server" Text="James"></asp:Label>                 
            </div>

            <div class="col-md-2" >
                <asp:Label ID="FirstUserLastName" runat="server"  Text="Miller"></asp:Label>                 
            </div>

            <div class="col-md-2" >
                <asp:Label ID="FirstUserUsername" runat="server"  Text="JMiller51"></asp:Label>                 
            </div>

            <div class="col-md-2" >
                <asp:Label ID="FirstUserDue" runat="server"  Text="Yes"></asp:Label>                 
            </div>

            <div class="col-md-1" >
                <asp:checkBox ID="FirstUserSuspend" runat="server"  ></asp:checkBox>                 
            </div>

            <div class="col-md-1" >
                <asp:radioButton ID="FirstUserSelected" groupname="UserSelection"  runat="server" ></asp:radioButton>                 
            </div>
        </div>

        <!--Second User-->
        <div class="col-md-10 row rounded text-center"  style="border:solid;border-color:grey;height:40px"   >

            <div class="col-md-2" >
                <asp:Label ID="SecondUserFirstName" runat="server" Text="Maria"></asp:Label>                 
            </div>

            <div class="col-md-2" >
                <asp:Label ID="SecondUserLastName" runat="server"  Text="Doberthy"></asp:Label>                 
            </div>

            <div class="col-md-2" >
                <asp:Label ID="SecondUserUsername" runat="server"  Text="MariaDB"></asp:Label>                 
            </div>

            <div class="col-md-2" >
                <asp:Label ID="SecondUserDue" runat="server"  Text="No"></asp:Label>                 
            </div>

            <div class="col-md-1" >
                <asp:checkBox ID="SecondUserSuspend" runat="server"  ></asp:checkBox>                 
            </div>

            <div class="col-md-1" >
                <asp:radioButton ID="SecondUserSelected" groupname="UserSelection" runat="server" ></asp:radioButton>                 
            </div>
        </div>


        <!--Third User-->
        <div class="col-md-10 row rounded text-center"  style="border:solid;border-color:grey;height:40px"   >

            <div class="col-md-2" >
                <asp:Label ID="ThirdUserFirstName" runat="server" Text="Saul"></asp:Label>                 
            </div>

            <div class="col-md-2" >
                <asp:Label ID="ThirdUserLastName" runat="server"  Text="Goodman"></asp:Label>                 
            </div>

            <div class="col-md-2" >
                <asp:Label ID="ThirdUserUsername" runat="server"  Text="BCS66"></asp:Label>                 
            </div>

            <div class="col-md-2" >
                <asp:Label ID="ThirdUserDue" runat="server"  Text="No"></asp:Label>                 
            </div>

            <div class="col-md-1" >
                <asp:checkBox ID="ThirdUserSuspend" runat="server"  ></asp:checkBox>                 
            </div>

            <div class="col-md-1" >
                <asp:radioButton ID="ThirdUserSelected" groupname="UserSelection"  runat="server" ></asp:radioButton>                 
            </div>
        </div>

        <br />
        <div class="col-md-10 text-right">
            <asp:Button ID="TransactionsButton" runat="server" CssClass="btn btn-primary"  Text="Show Transactions" />
            <asp:Button ID="SaveButton" runat="server" CssClass="btn btn-success" OnClick="SaveButton_Click" Text="Save" />
        </div>


        <div class="col-md-10 text-right text-success">
            <asp:label id="ResultSave" runat="server"  Text=""></asp:label>
        </div>
   </div>

</asp:Content>
