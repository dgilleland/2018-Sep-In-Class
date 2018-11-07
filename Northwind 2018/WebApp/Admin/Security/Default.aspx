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
            <h2>
                Users
                <a href="~/Admin/Security/RegisterNorthwindUsers.aspx" runat="server" class="btn btn-default">Northwind User Registrations &rarr;</a>
            </h2>
            <asp:ListView ID="UsersListView" runat="server"
                DataSourceID="UsersDataSource" DataKeyNames="UserId"
                InsertItemPosition="FirstItem"
                OnItemInserting="UsersListView_ItemInserting"
                OnItemUpdating="UsersListView_ItemUpdating"
                ItemType="WebApp.Admin.Security.DTOs.RegisteredUser">
                <EditItemTemplate>
                    <tr style="">
                        <td style="white-space:nowrap;">
                            <asp:Button runat="server" CommandName="Update" Text="Update" CssClass="btn btn-default" ID="UpdateButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-default" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.UserName %>' runat="server" ID="UserNameTextBox" CssClass="form-control" />
                        </td>
                        <td>
                            <asp:CheckBoxList ID="AssignedUserRoles" runat="server" DataSourceID="RolesDataSource" DataTextField="Name" DataValueField="Id">
                            </asp:CheckBoxList>
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.Email %>' runat="server" ID="EmailTextBox" CssClass="form-control" />
                            <asp:TextBox Text='<%# BindItem.PhoneNumber %>' runat="server" ID="PhoneNumberTextBox" CssClass="form-control" />

                        </td>
                    </tr>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <tr class="bg-info">
                        <td style="white-space:nowrap;">
                            <asp:Button runat="server" CommandName="Insert" Text="Insert" CssClass="btn btn-default" ID="InsertButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Clear" CssClass="btn btn-default" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.UserName %>' runat="server" ID="UserNameTextBox" CssClass="form-control" />
                        </td>
                        <td>
                            <asp:CheckBoxList ID="AssignedUserRoles" runat="server" DataSourceID="RolesDataSource" DataTextField="Name" DataValueField="Id">
                            </asp:CheckBoxList>
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.Email %>' runat="server" ID="EmailTextBox" CssClass="form-control" />
                            <asp:TextBox Text='<%# BindItem.PhoneNumber %>' runat="server" ID="PhoneNumberTextBox" CssClass="form-control" />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td style="white-space:nowrap;">
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-default" ID="DeleteButton" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-default" ID="EditButton" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Item.UserName %>' runat="server" ID="UserNameLabel" />
                            <br />
                            <small>(<asp:Label Text='<%# Item.UserId %>' runat="server" ID="IdLabel" />)</small>
                        </td>
                        <td>
                            <asp:Repeater ID="UserRoleRepeater" runat="server"
                                 DataSource="<%# Item.UserRoles %>"
                                 
                ItemType="WebApp.Admin.Security.DTOs.RegisteredUser.UserRole">
                                <ItemTemplate><%# Item.RoleName %></ItemTemplate>
                                <SeparatorTemplate>,</SeparatorTemplate>
                            </asp:Repeater>
                        </td>
                        <td>
                            <asp:Label Text='<%# Item.Email %>' runat="server" ID="EmailLabel" />
                            <br />
                            <asp:Label Text='<%# Item.PhoneNumber %>' runat="server" ID="PhoneNumberLabel" />
                        </td>
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
                                        <th runat="server">User Roles</th>
                                        <th runat="server">Email / Phone Number</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="">
                                <asp:DataPager runat="server" ID="DataPager1">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" ButtonCssClass="btn btn-default"></asp:NextPreviousPagerField>
                                        <asp:NumericPagerField NumericButtonCssClass="btn btn-default"></asp:NumericPagerField>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" ButtonCssClass="btn btn-default"></asp:NextPreviousPagerField>
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
                <LayoutTemplate>
                    <div id="itemPlaceholder" runat="server"></div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div>
                        <asp:LinkButton runat="server" CommandName="Delete" ID="DeleteButton"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Edit" ID="EditButton"><i class="glyphicon glyphicon-pencil"></i></asp:LinkButton>
                        <%# Item.Name %>
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <div>
                        <asp:LinkButton runat="server" CommandName="Update" ID="UpdateButton"><i class="glyphicon glyphicon-ok"></i></asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Cancel" ID="CancelButton"><i class="glyphicon glyphicon-arrow-left"></i></asp:LinkButton>
                        <asp:TextBox ID="RoleName" runat="server" Text="<%# BindItem.Name %>"></asp:TextBox>
                    </div>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <div class="bg-info">
                        <asp:LinkButton runat="server" CommandName="Insert" ID="InsertButton"><i class="glyphicon glyphicon-plus"></i></asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Cancel" ID="CancelButton"><i class="glyphicon glyphicon-ban-circle"></i></asp:LinkButton>
                        <asp:TextBox ID="RoleName" runat="server" Text="<%# BindItem.Name %>"></asp:TextBox>
                    </div>
                </InsertItemTemplate>
            </asp:ListView>
        </div>
    </div>

    <asp:ObjectDataSource ID="UsersDataSource" runat="server"
        DataObjectTypeName="WebApp.Admin.Security.DTOs.RegisteredUser"
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
