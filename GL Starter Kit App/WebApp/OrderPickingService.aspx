<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderPickingService.aspx.cs" Inherits="WebApp.OrderPickingService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">Order Picking Service</h1>

    <div class="row">
        <div class="col-md-8">
            <div>
                <asp:Label ID="Label1" runat="server"
                    AssociatedControlID="OrderNumberDropDown">Order Number</asp:Label>
                <asp:DropDownList ID="OrderNumberDropDown" runat="server">
                    <asp:ListItem Value="0">[Select an order]</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-md-4">
            <!-- Message User Control Here -->
        </div>
    </div>
    <asp:ObjectDataSource ID="OrderNumberDataSource" runat="server"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="PickerDataSource" runat="server"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OrderItemsDataSource" runat="server"></asp:ObjectDataSource>
</asp:Content>
