<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterNorthwindUsers.aspx.cs" Inherits="WebApp.Admin.Security.RegisterNorthwindUsers" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Process Unregistered Employees and Customers</h1>

    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />

    <asp:ListView ID="UnregisteredUsersListView" runat="server"
         DataSourceID="UnregisteredUsersDataSource"
         OnItemCommand="UnregisteredUsersListView_ItemCommand">
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Button runat="server" CommandName="Add" Text="Add User" ID="InsertButton" />
                    <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                </td>
                <td>
                    <asp:HiddenField Value='<%# Bind("Id") %>' runat="server" ID="IdHiddenField" />
                    <asp:Label Text='<%# Eval("UserType") %>' runat="server" ID="UserTypeLabel" />
                </td>
                <td>
                    <asp:TextBox Text='<%# Bind("Name") %>' runat="server" ID="NameTextBox" />
                </td>
                <td>
                    <asp:TextBox Text='<%# Bind("OtherName") %>' runat="server" ID="OtherNameTextBox" />
                </td>
                <td>
                    <asp:TextBox Text='<%# Bind("AssignedUserName") %>' runat="server" ID="AssignedUserNameTextBox" />
                </td>
                <td>
                    <asp:TextBox Text='<%# Bind("AssignedEmail") %>' runat="server" ID="AssignedEmailTextBox" />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table runat="server" id="itemPlaceholderContainer" style="" border="0">
                            <tr runat="server" style="">
                                <th runat="server"></th>
                                <th runat="server">UserType</th>
                                <th runat="server">Name</th>
                                <th runat="server">OtherName</th>
                                <th runat="server">AssignedUserName</th>
                                <th runat="server">AssignedEmail</th>
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
    </asp:ListView>
    <asp:ObjectDataSource ID="UnregisteredUsersDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllUnregisteredUsers" TypeName="WebApp.Admin.Security.RegistrationController"></asp:ObjectDataSource>
</asp:Content>
