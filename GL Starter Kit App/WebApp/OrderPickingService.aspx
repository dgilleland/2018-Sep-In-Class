<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderPickingService.aspx.cs" Inherits="WebApp.OrderPickingService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">Order Picking Service</h1>

    <div class="row">
        <div class="col-md-8">
            <div>
                <asp:Label ID="Label1" runat="server"
                    AssociatedControlID="OrderNumberDropDown">Order Number</asp:Label>
                <asp:DropDownList ID="OrderNumberDropDown" runat="server" 
                    DataSourceID="OrderNumberDataSource"
                    AppendDataBoundItems="true"
                    DataTextField="OrderID" DataValueField="OrderID">
                    <asp:ListItem Value="0">[Select an order]</asp:ListItem>
                </asp:DropDownList>
                <asp:LinkButton ID="FetchOrder" runat="server"
                     CssClass="btn btn-default">Fetch</asp:LinkButton>
                <asp:Label ID="Label2" runat="server">Customer</asp:Label>
                <asp:Label ID="CustomerName" runat="server" />
                <asp:Label ID="Label3" runat="server">Contact</asp:Label>
                <asp:Label ID="ContactNumber" runat="server" />
                <asp:Label ID="Label4" runat="server"
                    AssociatedControlID="PickerDropDown">Picker</asp:Label>
                <asp:DropDownList ID="PickerDropDown" runat="server"
                    DataSourceID="PickerDataSource"
                    AppendDataBoundItems="true"
                    DataTextField="FullName" DataValueField="PickerID">
                    <asp:ListItem Value="0">[Select a picker]</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-md-4">
            <!-- Message User Control Here -->
        </div>
    </div>
    <asp:ObjectDataSource ID="OrderNumberDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Orders_UnDeliveredList" TypeName="GroceryStore.BLL.OrderListsController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="PickerDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Pickers_List" TypeName="GroceryStore.BLL.OrderListsController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OrderItemsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="OrderLists_OrderPickList" TypeName="GroceryStore.BLL.OrderListsController">
        <SelectParameters>
            <asp:ControlParameter ControlID="OrderNumberDropDown" PropertyName="SelectedValue" Name="orderid" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
