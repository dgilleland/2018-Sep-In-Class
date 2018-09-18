<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Admin_CRUD_EditShippers" Codebehind="EditShippers.aspx.cs" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="My" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="jumbotron">
        <h1>Manage Shippers</h1>
        <My:MessageUserControl runat="server" ID="MessageUserControl" />
    </div>

    <div class="row">
        <div class="col-md-8">
            <h2>Shippers for Northwind Traders</h2>
            <asp:ListView ID="ShippersListView" runat="server" DataKeyNames="ShipperID"
                 DataSourceID="ShippersDataSource" InsertItemPosition="LastItem"
                 ItemType="NorthwindTraders.Entities.Shipper">
                <EditItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.ShipperID %>' runat="server" ID="ShipperIDTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.CompanyName %>' runat="server" ID="CompanyNameTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.Phone %>' runat="server" ID="PhoneTextBox" /></td>
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
                            <asp:TextBox Text='<%# BindItem.ShipperID %>' runat="server" ID="ShipperIDTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.CompanyName %>' runat="server" ID="CompanyNameTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.Phone %>' runat="server" ID="PhoneTextBox" /></td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                            <asp:Button runat="server" CommandName="Select" Text="!" ID="SelectButton" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Item.ShipperID %>' runat="server" ID="ShipperIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Item.CompanyName %>' runat="server" ID="CompanyNameLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Item.Phone %>' runat="server" ID="PhoneLabel" /></td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table class="table table-hover" runat="server" id="itemPlaceholderContainer" style="" border="0">
                                    <tr runat="server" style="">
                                        <th runat="server"></th>
                                        <th runat="server">ShipperID</th>
                                        <th runat="server">CompanyName</th>
                                        <th runat="server">Phone</th>
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
                    <tr style="background-color:yellow;">
                        <td>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Item.ShipperID %>' runat="server" ID="ShipperIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Item.CompanyName %>' runat="server" ID="CompanyNameLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Item.Phone %>' runat="server" ID="PhoneLabel" /></td>
                    </tr>
                    <tr style="background-color:yellow;">
                        <td colspan="2"></td>
                        <td colspan="2"><i><b><%# Item.Orders.Count %></b> orders shipped via <%# Item.CompanyName %></i></td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:ObjectDataSource ID="ShippersDataSource" runat="server" DataObjectTypeName="NorthwindTraders.Entities.Shipper" DeleteMethod="RemoveShipper" InsertMethod="AddShipper" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllShippers" TypeName="NorthwindTraders.BLL.CRUD.ShipperController" UpdateMethod="UpdateShipper"
              OnUpdated="CheckForExceptions"
              OnDeleted="CheckForExceptions"
              OnInserted="CheckForExceptions"  >
            </asp:ObjectDataSource>
        </div>
        <div class="col-md-4">
            <h2>About Managing Shippers</h2>
        </div>
    </div>
</asp:Content>

