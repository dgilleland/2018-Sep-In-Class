<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Service Areas</h3>
    <p>Northwind Traders provides your supply and service needs in the following regions.</p>

    <div class="row">
        <asp:Repeater ID="RegionRepeater" runat="server"
             DataSourceID="RegionsDataSource"
             ItemType="NorthwindTraders.Entities.Region">
            <ItemTemplate>
                <div class="col-md-3">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4><%# Item.RegionDescription %></h4>
                        </div>
                        <div class="panel-body">
                            <asp:Repeater ID="TerritoryRepeater" runat="server"
                                 DataSource="<%# Item.Territories %>"
                                 ItemType="NorthwindTraders.Entities.Territory">
                                <ItemTemplate><%# Item.TerritoryDescription.Trim() %></ItemTemplate>
                                <SeparatorTemplate>, </SeparatorTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <img src="Images/NorthwindLogoLarge.png" />

    <asp:ObjectDataSource ID="RegionsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllRegions" TypeName="NorthwindTraders.BLL.CRUD.RegionController"></asp:ObjectDataSource>
</asp:Content>
