<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="ProductCatalog" Codebehind="ProductCatalog.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <h1 class="page-header">Product Catalog</h1>

    <div class="row">
        <div class="col-md-12">
            <asp:Repeater ID="CategoryRepeater" runat="server"
                DataSourceID="CatalogDataSource"
                ItemType="NorthwindTraders.Entities.DTOs.ProductCategory">
                <ItemTemplate>
                    <div>
                        <img style="float:left;height:30px; margin-right:7px;"
                            src="data:image/png;base64,<%# Convert.ToBase64String(Item.Picture) %>" />
                        <h3><%# Item.Name %></h3>
                        <p><%# Item.Description %></p>
                        <blockquote>
                            <asp:Repeater ID="ProductRepeater" runat="server"
                                 DataSource="<%# Item.Products %>"
                                 ItemType="NorthwindTraders.Entities.POCOs.ProductInfo">
                                <HeaderTemplate>
                                    <table class="table table-hover table-condensed">
                                </HeaderTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <th class="col-md-4"><%# Item.Name %></th>
                                        <th class="col-md-2" style="text-align:right"><%# $"{Item.Price:C}" %></th>
                                        <td class="col-md-3">@ <%# Item.QuantityPerUnit %> each</td>
                                        <td class="col-md-3"><%# Item.InStock %> In stock </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </blockquote>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <asp:ObjectDataSource ID="CatalogDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="AllProductsByCategory" TypeName="NorthwindTraders.BLL.ProductCatalogueController"></asp:ObjectDataSource>
</asp:Content>

