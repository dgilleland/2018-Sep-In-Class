<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Admin_CRUD_EditSalesAreas" Codebehind="EditSalesAreas.aspx.cs" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="My" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="jumbotron">
        <h1>Sales Management Areas</h1>
        <p class="lead">Northwind Trader's employees are assigned to various sales areas, comprised of regions and territories. The initial set of areas focus on the continental US. This page provides <a href="#" data-placement="top" data-toggle="tooltip" title="Read, Edit, Add, Delete -- Cleaner than CRUD">R.E.A.D.</a> management of these areas.</p>
    </div>

    <div class="row">
        <div class="col-md-12">
            <My:MessageUserControl runat="server" ID="MessageUserControl" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <h1>Regions</h1>
            <asp:ListView ID="RegionListView" runat="server"
                DataSourceID="RegionsDataSource"

                InsertItemPosition="LastItem"
                DataKeyNames="RegionID">
                <AlternatingItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Eval("RegionID") %>' runat="server" ID="RegionIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("RegionDescription") %>' runat="server" ID="RegionDescriptionLabel" /></td>
                        
                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# Bind("RegionID") %>' runat="server" ID="RegionIDTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("RegionDescription") %>' runat="server" ID="RegionDescriptionTextBox" /></td>
                        
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# Bind("RegionID") %>' runat="server" ID="RegionIDTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("RegionDescription") %>' runat="server" ID="RegionDescriptionTextBox" /></td>
                        
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Eval("RegionID") %>' runat="server" ID="RegionIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("RegionDescription") %>' runat="server" ID="RegionDescriptionLabel" /></td>
                        
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="itemPlaceholderContainer" style="" border="0">
                                    <tr runat="server" style="">
                                        <th runat="server"></th>
                                        <th runat="server">RegionID</th>
                                        <th runat="server">RegionDescription</th>
                                        
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="">
                                <asp:DataPager runat="server" ID="DataPager1">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True"></asp:NextPreviousPagerField>
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Eval("RegionID") %>' runat="server" ID="RegionIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("RegionDescription") %>' runat="server" ID="RegionDescriptionLabel" /></td>
                        
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:ObjectDataSource runat="server" ID="RegionsDataSource" DataObjectTypeName="NorthwindTraders.Entities.Region" DeleteMethod="DeleteRegion" InsertMethod="AddRegion" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllRegions" TypeName="NorthwindTraders.BLL.CRUD.RegionController" UpdateMethod="UpdateRegion"
                OnDeleted="CheckForException"
                OnInserted="CheckForException"
                OnUpdated="CheckForException"
                ></asp:ObjectDataSource>
        </div>
        <div class="col-md-6">
            <h1>Territories</h1>
            <asp:ListView ID="TerritoryListView" runat="server"
                 DataSourceID="TerritoriesDataSource"
                 DataKeyNames="TerritoryID"
                 ItemType="NorthwindTraders.Entities.Territory"
                 InsertItemPosition="LastItem">
                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server">
                        <div id="itemPlaceholder" runat="server"></div>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div>
                        <asp:Button ID="EditButton" runat="server"
                             Text="Edit" CommandName="Edit" />
                        <asp:Button ID="DeleteButton" runat="server"
                             Text="Delete" CommandName="Delete" />
                        <asp:Label ID="TerritoryDescriptionLabel" runat="server"
                             Text='<%# Item.TerritoryDescription + " (" + Item.Region.RegionDescription + ")" %>' />
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <div>
                        <asp:Button ID="UpdateButton" runat="server"
                             Text="Update" CommandName="Update" />
                        <asp:Button ID="CancelButton" runat="server"
                             Text="Cancel" CommandName="Cancel" />
                        <asp:TextBox ID="TerritoryDescriptionTextBox" runat="server"
                             Text="<%# BindItem.TerritoryDescription %>" />
                        <asp:DropDownList ID="TerritoryRegionDropDown" runat="server"
                             DataSourceID="RegionsDataSource"
                             DataValueField="RegionID" DataTextField="RegionDescription"
                             SelectedValue="<%# BindItem.RegionID %>"
                             AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[Select a Region]</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <div>
                        <asp:Button ID="InsertButton" runat="server"
                             Text="Insert" CommandName="Insert" />
                        <asp:Button ID="CancelButton" runat="server"
                             Text="Cancel" CommandName="Cancel" />
                        <asp:TextBox ID="TerritoryDescriptionTextBox" runat="server"
                             Text="<%# BindItem.TerritoryDescription %>" />
                        <asp:DropDownList ID="TerritoryRegionDropDown" runat="server"
                             DataSourceID="CurrentRegionsDataSource"
                             DataValueField="RegionID" DataTextField="RegionDescription"
                             SelectedValue="<%# BindItem.RegionID %>"
                             AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[Select a Region]</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </InsertItemTemplate>
            </asp:ListView>

            <asp:ObjectDataSource ID="TerritoriesDataSource" runat="server" DataObjectTypeName="NorthwindTraders.Entities.Territory" DeleteMethod="DeleteTerritory" InsertMethod="AddTerritory" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllTerritories" TypeName="NorthwindTraders.BLL.CRUD.TerritoryController" UpdateMethod="UpdateTerritory"                
                 OnDeleted="CheckForException"
                 OnInserted="CheckForException"
                 OnUpdated="CheckForException"></asp:ObjectDataSource>
            <asp:ObjectDataSource runat="server" ID="CurrentRegionsDataSource" DataObjectTypeName="NorthwindTraders.Entities.Region" SelectMethod="ListAllRegions" TypeName="NorthwindTraders.BLL.CRUD.RegionController" ></asp:ObjectDataSource>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
</asp:Content>

