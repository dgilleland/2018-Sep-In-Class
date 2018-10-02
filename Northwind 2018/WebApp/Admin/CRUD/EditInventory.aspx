<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditInventory.aspx.cs" Inherits="WebApp.Admin.CRUD.EditInventory" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Manage Inventory</h1>
        <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
    </div>

    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="Label1" runat="server" AssociatedControlID="PartialName">Partial Product Name</asp:Label>
            <asp:TextBox ID="PartialName" runat="server" CssClass="form-control" style="display:inline-block" placeholder="e.g.: Chef" />
            <asp:LinkButton ID="Filter" runat="server" CssClass="btn btn-default">Filter by Partial Product Name</asp:LinkButton>
            <hr />
            <h2>Products</h2>
            <script>
                function ConfirmDelete() {
                    return confirm("Are you sure you want to permanently delete this product?");
                }
            </script>
            <asp:ListView ID="ProductsListView" runat="server"
                DataSourceID="ProductsDataSource"
                DataKeyNames="ProductID"
                InsertItemPosition="LastItem"
                ItemType="NorthwindTraders.Entities.Product">
                <EditItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.ProductName %>' runat="server" ID="ProductNameTextBox" placeholder="Product Name" />
                            <asp:CheckBox ID="DiscontinuedCheckBox" runat="server" Checked='<%# BindItem.Discontinued %>' Text="Discontinued" />
                            <br />
                            <asp:DropDownList ID="SupplierDropDown" runat="server"
                                SelectedValue="<%# BindItem.SupplierID %>"
                                DataSourceID="SuppliersDataSource"
                                AppendDataBoundItems="true"
                                DataTextField="CompanyName"
                                DataValueField="SupplierID">
                                <asp:ListItem Value="">[No Supplier]</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <asp:DropDownList ID="CategoryDropDown" runat="server"
                                SelectedValue="<%# BindItem.CategoryID %>"
                                DataSourceID="CategoriesDataSource"
                                AppendDataBoundItems="true"
                                DataTextField="CategoryName"
                                DataValueField="CategoryID">
                                <asp:ListItem Value="">[No Category]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.UnitPrice %>' runat="server" ID="UnitPriceTextBox" placeholder="Unit Price" />
                            <br />
                            <asp:TextBox Text='<%# BindItem.QuantityPerUnit %>' runat="server" ID="QuantityPerUnitTextBox" placeholder="Qty/Unit" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.UnitsInStock %>' runat="server" ID="UnitsInStockTextBox" placeholder="In-Stock" />
                            <br />
                            <asp:TextBox Text='<%# BindItem.UnitsOnOrder %>' runat="server" ID="UnitsOnOrderTextBox" placeholder="On-Order" />
                            <br />
                            <asp:TextBox Text='<%# BindItem.ReorderLevel %>' runat="server" ID="ReorderLevelTextBox" placeholder="Reorder Level" />
                        </td>
                        <td></td>
                    </tr>
                </EditItemTemplate>
                <%-- The EmptyDataTemplate is not used when we display the InsertItemTemplate
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                --%>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.ProductName %>' runat="server" ID="ProductNameTextBox" placeholder="Product Name" />
                            <br />
                            <asp:DropDownList ID="SupplierDropDown" runat="server"
                                SelectedValue="<%# BindItem.SupplierID %>"
                                DataSourceID="SuppliersDataSource"
                                AppendDataBoundItems="true"
                                DataTextField="CompanyName"
                                DataValueField="SupplierID">
                                <asp:ListItem Value="">[No Supplier]</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <asp:DropDownList ID="CategoryDropDown" runat="server"
                                SelectedValue="<%# BindItem.CategoryID %>"
                                DataSourceID="CategoriesDataSource"
                                AppendDataBoundItems="true"
                                DataTextField="CategoryName"
                                DataValueField="CategoryID">
                                <asp:ListItem Value="">[No Category]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.UnitPrice %>' runat="server" ID="UnitPriceTextBox" placeholder="Unit Price" />
                            <br />
                            <asp:TextBox Text='<%# BindItem.QuantityPerUnit %>' runat="server" ID="QuantityPerUnitTextBox" placeholder="Qty/Unit" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.UnitsInStock %>' runat="server" ID="UnitsInStockTextBox" placeholder="In-Stock" />
                            <br />
                            <asp:TextBox Text='<%# BindItem.UnitsOnOrder %>' runat="server" ID="UnitsOnOrderTextBox" placeholder="On-Order" />
                            <br />
                            <asp:TextBox Text='<%# BindItem.ReorderLevel %>' runat="server" ID="ReorderLevelTextBox" placeholder="Reorder Level" />
                        </td>
                        <td></td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" OnClientClick="return ConfirmDelete()" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                        </td>
                        <td>
                            <b><asp:Label Text='<%# Item.ProductName %>' runat="server" ID="ProductNameLabel" /></b>
                            <asp:CheckBox Checked='<%# Item.Discontinued %>' runat="server" ID="DiscontinuedCheckBox" Enabled="false" Text="Discontinued" CssClass="pull-right" Visible='<%# Item.Discontinued %>' />
                            <br />
                            <i>Supplier: <asp:Label Text='<%# Item.Supplier?.CompanyName %>' runat="server" ID="SupplierIDLabel" /></i>
                            <i>Category: </i><asp:Label Text='<%# Item.Category?.CategoryName %>' runat="server" ID="CategoryIDLabel" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Item.UnitPrice.HasValue?Item.UnitPrice.Value.ToString("C"):"" %>' runat="server" ID="UnitPriceLabel" />
                            (for
                            <asp:Label Text='<%# Item.QuantityPerUnit %>' runat="server" ID="QuantityPerUnitLabel" />)
                        </td>
                        <td>
                            <b><asp:Label Text='<%# Item.UnitsInStock %>' runat="server" ID="UnitsInStockLabel" /></b>
                            (<asp:Label Text='<%# Item.UnitsOnOrder %>' runat="server" ID="UnitsOnOrderLabel" /> on order)
                            <br />
                            Reorder at: <asp:Label Text='<%# Item.ReorderLevel %>' runat="server" ID="ReorderLevelLabel" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Item.LastModified %>' runat="server" ID="LastModifiedLabel" />
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
                                        <th runat="server">
                                            Name / Discontinued / Supplier / Category
                                        </th>
                                        <th runat="server">Unit Price / Qty per Unit</th>
                                        <th runat="server">In Stock / On Order / Reorder Level</th>
                                        <th runat="server">Last Modified</th>
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

            <asp:ObjectDataSource ID="ProductsDataSource" runat="server" 
                OldValuesParameterFormatString="original_{0}" 
                SelectMethod="GetProductsByPartialProductName" 
                TypeName="NorthwindTraders.BLL.CRUD.ProductController" 
                DataObjectTypeName="NorthwindTraders.Entities.Product" 
                DeleteMethod="DeleteProduct"
                InsertMethod="AddProduct"
                UpdateMethod="UpdateProduct"
                OnUpdated="CheckForExceptions"
                OnInserted="CheckForExceptions"
                OnDeleted="CheckForExceptions">
                <SelectParameters>
                    <asp:ControlParameter ControlID="PartialName" PropertyName="Text" Name="partialName" Type="String"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>

            <asp:ObjectDataSource ID="CategoriesDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllCategories" TypeName="NorthwindTraders.BLL.CRUD.CategoryController"></asp:ObjectDataSource>

            <asp:ObjectDataSource ID="SuppliersDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllSuppliers" TypeName="NorthwindTraders.BLL.CRUD.SupplierController"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
