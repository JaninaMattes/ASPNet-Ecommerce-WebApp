<%@ Page Title="PostagesOptions" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PostagesOptions.aspx.cs" Inherits="WebsiteLaitBrasseur.Admin.PostagesOptions" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <h3>Shipping Options Overview</h3>

            <asp:Label id="tablePostageList" Text="The postage list is empty." runat="server" />
            <div class="table-dark">
                <asp:GridView id="PostageTable" runat="server">
                        <Columns>
                            <asp:BoundField DataField="ProviderID" HeaderText="Provider ID" />
                            <asp:BoundField DataField="ProviderName" HeaderText="Provider Name" />
                            <asp:BoundField DataField="CostsPerUnit" HeaderText="Costs per Unit" /> 
                            <asp:BoundField DataField="Select" HeaderText="Select" />
                        </Columns>
                    </asp:GridView>
            </div>

    </div>

</asp:Content>
