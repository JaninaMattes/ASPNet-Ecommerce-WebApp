<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="WebsiteLaitBrasseur.ProductDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <div class="container-fluid" style="border:solid;border-color:blue">
        <div class="row" style="border:solid;border-color:yellow">

            <div class="col-md-4" style="border:solid;border-color:green">
               IMAGE
            </div>

            <div class=" offset-md-1 col-md-3" style="border:solid;border-color:red">
                label :
            </div>

            <div class=" offset-md-1 col-md-3" style="border:solid;border-color:red">
                "labelValue"
            </div>


        </div>


        <div class="col-md-5" style="border:solid;border-color:purple">
            Description
        </div>
    </div>


</asp:Content>
