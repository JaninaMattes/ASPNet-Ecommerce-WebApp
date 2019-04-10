<%@ Page Title="Default" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebsiteLaitBrasseur.Admin.Default" %>




<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!--Admin Home Page -->

    <div class="container-fluid " >
        <div class="row">

            <!--LinkButton to Product managment -->
            <div class="col-md-4 text-center">
                <a>
                    <asp:Button ID="Productbutton" runat="server" CssClass="btn btn-primary " style="font-size:30px;height:100px;width:200px" Text="Product" />
                </a>
            </div>


            <!--LinkButton to Customer managment -->
            <div class="col-md-4 text-center">
                    <asp:Button ID="Customerbutton" runat="server" OnClick="Customerbutton_Click" CssClass="btn btn-primary" style="font-size:30px;height:100px;width:200px" Text="Customer" />
            </div>


            <!--LinkButton to Shipping managment -->
            <div class="col-md-4 text-center">
                    <asp:Button ID="Shippingbutton" runat="server" OnClick="Shippingbutton_Click" CssClass="btn btn-primary" style="font-size:30px;height:100px;width:200px" Text="Shipping" />
            </div>

        </div>

    </div>

</asp:Content>
