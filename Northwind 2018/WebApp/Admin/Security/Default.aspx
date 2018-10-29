<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Admin.Security.Default" %>
<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">Website Security - Users and Roles</h1>
    <div class="row">
        <div class="col-md-12">
            <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-9">
            <h2>Users</h2>
            <asp:ListView ID="UsersListView" runat="server"
                DataSourceID="UsersDataSource" DataKeyNames="Id"
                InsertItemPosition="FirstItem"
                ItemType="WebApp.Models.ApplicationUser">
                <EditItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.UserName %>' runat="server" ID="UserNameTextBox" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.EmployeeId %>' runat="server" ID="EmployeeIdTextBox" />
                            <asp:TextBox Text='<%# BindItem.CustomerId %>' runat="server" ID="CustomerIdTextBox" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.Email %>' runat="server" ID="EmailTextBox" />
                            <asp:TextBox Text='<%# BindItem.PhoneNumber %>' runat="server" ID="PhoneNumberTextBox" />

                        </td>
                        <td>
                        </td>
                    </tr>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.UserName %>' runat="server" ID="UserNameTextBox" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.EmployeeId %>' runat="server" ID="EmployeeIdTextBox" />
                            <asp:TextBox Text='<%# BindItem.CustomerId %>' runat="server" ID="CustomerIdTextBox" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.Email %>' runat="server" ID="EmailTextBox" />
                            <asp:TextBox Text='<%# BindItem.PhoneNumber %>' runat="server" ID="PhoneNumberTextBox" /></td>
                        <td></td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Item.UserName %>' runat="server" ID="UserNameLabel" />
                            <br />
                            <small>(<asp:Label Text='<%# Item.Id %>' runat="server" ID="IdLabel" />)</small>
                        </td>
                        <td>
                            <asp:Label Text='<%# Item.EmployeeId %>' runat="server" ID="EmployeeIdLabel" />
                            <asp:Label Text='<%# Item.CustomerId %>' runat="server" ID="CustomerIdLabel" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Item.Email %>' runat="server" ID="EmailLabel" />
                            <asp:Label Text='<%# Item.PhoneNumber %>' runat="server" ID="PhoneNumberLabel" /></td>
                        <td>
                            <asp:Label Text='<%# string.Join(", ", Item.Roles.Select(x => x.RoleId)) %>' runat="server" ID="RolesLabel" /></td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="itemPlaceholderContainer" class="table table-condensed table-hover">
                                    <tr runat="server" style="">
                                        <th runat="server"></th>
                                        <th runat="server">UserName (Id)</th>
                                        <th runat="server">Employee / Customer</th>
                                        <th runat="server">Email / PhoneNumber</th>
                                        <th runat="server">Roles</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="">
                                <asp:DataPager runat="server" ID="DataPager1">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                        <asp:NumericPagerField></asp:NumericPagerField>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
        <div class="col-md-3">
            <h2>Roles</h2>
            <asp:ListView ID="RolesListView" runat="server"
                 DataSourceID="RolesDataSource" DataKeyNames="Id" InsertItemPosition="FirstItem"
                 ItemType="Microsoft.AspNet.Identity.EntityFramework.IdentityRole">
                <LayoutTemplate><div id="itemPlaceholder" runat="server"></div></LayoutTemplate>
                <ItemTemplate>
                    <div><%# Item.Name %></div>
                </ItemTemplate>
                <EditItemTemplate>
                    <div></div>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <div></div>
                </InsertItemTemplate>
            </asp:ListView>
        </div>
    </div>

    <asp:ObjectDataSource ID="UsersDataSource" runat="server"
        DataObjectTypeName="WebApp.Models.ApplicationUser"
        DeleteMethod="DeleteUser"
        InsertMethod="AddUser"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="ListUsers"
        TypeName="WebApp.Admin.Security.SecurityController"
        UpdateMethod="UpdateUser"
        OnUpdated="CheckForExceptions"
        OnInserted="CheckForExceptions"
        OnDeleted="CheckForExceptions"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="RolesDataSource" runat="server"
        DataObjectTypeName="Microsoft.AspNet.Identity.EntityFramework.IdentityRole"
        DeleteMethod="DeleteRole"
        InsertMethod="AddRole"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="ListRoles"
        TypeName="WebApp.Admin.Security.SecurityController"
        UpdateMethod="UpdateRole"
        OnUpdated="CheckForExceptions"
        OnInserted="CheckForExceptions"
        OnDeleted="CheckForExceptions"></asp:ObjectDataSource>
</asp:Content>
