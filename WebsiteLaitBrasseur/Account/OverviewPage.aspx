<%@ Page Language="C#" Title="Log In" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login2.aspx.cs" Inherits="WebsiteLaitBrasseur.Account.WebForm1" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

        <h2>><%: Page.Title %></h2>
            
            <div id="gridcontainer">
                 <asp:GridView ID="grdProducts" runat="server" 
                     AllowPaging="False" 
                     AutoGenerateColumns="false" 
                     CssClass="align-self-md-center" 
                     EmptyDataText="No Result found. Please try search again." 
                     PageSize="1" Width="16px" Height="332px" OnSelectedIndexChanged="grdProducts_SelectedIndexChanged">

      <Columns>
          <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="ProductImage"  runat="server" onClick="ProductSelectionClick" 
                        ImageUrl="~/Images/cheese12.jpg" Height="250px" Width="100%" />
                    <divstyle="display:flex; flex-direction: row; justify-content: center; align-items: center">  
                        <div id="table" class="table-borderless">
                        <asp:Table id="Table_UserProfile" runat="server"
                            CellPadding="10"
                            HorizontalAlign="Left" 
                            CellSpacing="1" 
                            ToolTip="Select Product"></asp:Table>
                        <asp:Label ID="ProductTitle" runat="server">Product Title</asp:Label><br/>
                        <asp:Label ID="Price" runat="server">Price</asp:Label>
                    </divstyle="display:flex;>
                </ItemTemplate>
          </asp:TemplateField>
      </Columns>
    </asp:GridView>
  </div>
</asp:Content>