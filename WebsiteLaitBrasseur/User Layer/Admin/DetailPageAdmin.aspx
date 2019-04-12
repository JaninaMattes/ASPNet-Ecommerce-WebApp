<%@ Page Title="Detail Page" Language="C#" MasterPageFile="/User Layer/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DetailPageAdmin.aspx.cs" Inherits="WebsiteLaitBrasseur.Admin.DetailPageAdmin" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<!--Page managing the detail of a product in the admin side -->

    <div class="container-fluid row">

        <!--Left part of the page -->
        <div class="col-md-6">

            <!--Image informations  -->
            <div class="col-md-6">
                <asp:Image ID="destinationImg" runat="server" ImageUrl="~/Images/photoIcon.png" ToolTip="Product Image." Width="350" Height="250px"/><br /><br />

                <!--TextBox for add a link to the new image + button to upload it -->
                <asp:TextBox ID="TextImageLink" runat="server" Text="Image link" CssClass="form-control"></asp:TextBox> <br />
                <asp:Button ID="UploadButton" ToolTip="Update image." runat="server"  Text="Upload Image" CssClass="btn btn-primary" /><br />
            </div>
            <br />
            
            <!--TextBox / label for Long description -->
            <label for="TextLongDescription" class="control-label col-md-3 text-info">Long Description</label><br />
            <asp:TextBox ID="TextLongDescription" ToolTip="Update description."  runat="server" Text="" CssClass="form-control" style="width:500px;height:200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="LongReqField" runat="server" ControlToValidate="TextLongDescription" ErrorMessage="Long description is required" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>


        <!--Right part of the page -->
        <div class="col-md-6">     
            <div class="col-md-6">
                <!--TextBox / label for Producer name -->
                <label for="TextProducer" class="control-label text-info">Producer Name</label><br />
                <asp:TextBox ID="TextProducer" runat="server" Text="" CssClass="form-control"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="ProducerReqField" runat="server" ControlToValidate="TextProducer" ErrorMessage="Producer Name is required" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>

            <br />
            <br />
            
            <div class="col-md-6">
                <!--TextBox / label for Producer name -->
                <label for="TextShortDescription" class="control-label  text-info">Short Description</label><br />
                <asp:TextBox ID="TextShortDescription" ToolTip="Update desription."  runat="server"  Text="" CssClass="form-control" style="width:400px;height:150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ShortReqField" runat="server" ControlToValidate="TextShortDescription" ErrorMessage="Short description is required" CssClass="text-danger"></asp:RequiredFieldValidator><br /><br/>
                <asp:Button ID="SaveButton" ToolTip="Save changes."  runat="server" Text="Save changes" CssClass="btn btn-success" /> 
            </div>
            <br />

        </div>
    </div>


</asp:Content>
