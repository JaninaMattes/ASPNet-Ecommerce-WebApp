<%@ Page Title="Detail Page" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DetailPageAdmin.aspx.cs" Inherits="WebsiteLaitBrasseur.Admin.DetailPageAdmin" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid row">
        <div class="col-md-6">
            <div class="col-md-6">
                <asp:Image ID="destinationImg" runat="server" ImageUrl="~/Images/photoIcon.png" ToolTip="Product Image." Width="350" Height="250px"/><br /><br />
                <asp:TextBox ID="TextImageLink" runat="server" Text="Image link" CssClass="form-control"></asp:TextBox> <br />
                <asp:Button ID="UploadButton" ToolTip="Update image." runat="server"  Text="Upload Image" CssClass="btn btn-primary" /><br />
            </div>

            <br />


            <label for="TextLongDescription" class="control-label col-md-3 text-info">Long Description</label><br />
            <asp:TextBox ID="TextLongDescription" ToolTip="Update description."  runat="server" Text="" CssClass="form-control" style="width:500px;height:200px"></asp:TextBox>

        </div>


        <div class="col-md-6">     
            <div class="col-md-6">
                <label for="TextProducer" class="control-label text-info">Producer Name</label><br />
                <asp:TextBox ID="TextProducer" runat="server" Text="" CssClass="form-control"></asp:TextBox> 
            </div>

            <br />
            <br />
            <div class="col-md-6">
                <label for="TextShortDescription" class="control-label  text-info">Short Description</label><br />
                <asp:TextBox ID="TextShortDescription" ToolTip="Update desription."  runat="server"  Text="" CssClass="form-control" style="width:400px;height:150px"></asp:TextBox><br /><br />
                <asp:Button ID="SaveButton" ToolTip="Save changes."  runat="server" Text="Save changes" CssClass="btn btn-success" />            
            </div>
            <br />

            
            
            <!--Producer
                Short description
                -->
        </div>
    </div>


</asp:Content>
