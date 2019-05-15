﻿<%@ Page Title="Shopping History" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="WebsiteLaitBrasseur.UL.Admin.Transactions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!--START UpdatePanel fEnables sections of a page to be partially rendered without a postback. -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

<!--Page managing the display of the transactions history of an user-->

                <div id="tableShoppingHistory clearfix" class="offset-md-2 col-md-7">

                    <h3 id="sheader">Shopping History</h3><br />

                    <asp:Label id="tableShoppingHistoryLabel" Text="Shopping history empty." runat="server" />
                        
                        <!--Gridview displaying transactions history -->
                        <asp:GridView id="ShoppingTable" runat="server" class="table table-hover table-striped text-center" GridLines="None" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="InvoiceNumber" HeaderText="Invoice Number" />
                                    <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount(€)" />
                                    <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                                    <asp:BoundField DataField="ArrivalDate" HeaderText="Arrival Date" />
                                </Columns>
                            </asp:GridView>
                </div>
    <!--END UpdatePanel Enables sections of a page to be partially rendered without a postback. -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
