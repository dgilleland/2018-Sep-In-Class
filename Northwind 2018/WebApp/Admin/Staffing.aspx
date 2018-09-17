<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Admin_Staffing" Codebehind="Staffing.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1 class="page-header">
        Staffing
        <small>
            <asp:Label ID="MessageBox" runat="server"></asp:Label>
        </small>
    </h1>
    <div class="row">
        <div class="col-md-12">
            <asp:Repeater ID="UnassignedTerritoriesRepeater" runat="server" DataSourceID="UnassignedDataSource"
                 ItemType="NorthwindTraders.Entities.Territory">
                <HeaderTemplate><h4>Unassigned Territories</h4></HeaderTemplate>
                <ItemTemplate><%# Item.TerritoryDescription %></ItemTemplate>
                <SeparatorTemplate>, </SeparatorTemplate>
            </asp:Repeater>
            <hr />
        </div>
    </div>
    <div class="row">
        <asp:ListView ID="StaffListView" runat="server" DataSourceID="StaffDataSource"
             ItemType="NorthwindTraders.Entities.DTOs.StaffProfile"
             OnItemCommand="StaffListView_ItemCommand">
            <LayoutTemplate>
                <div runat="server" id="itemPlaceholder" />
            </LayoutTemplate>
            <ItemTemplate>
                <div class="col-md-3 col-lg-4 col-sm-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title"><%# Item.JobTitle %><small class="pull-right"><%# $"Since <b>{Item.HireDate:MMM yyyy}</b>" %></small></h3>
                        </div>
                        <div class="panel-body" style="min-height: 175px;">
                            <!-- Image Hack -->
                            <img src='<%# @"data:image/gif;base64," + Convert.ToBase64String(Item.Photo.ToArray()) %>'
                                    width="48" height="56" class="img-thumbnail pull-right" />
                            <p class="lead"><%# Item.Name %> <asp:LinkButton ID="FireEmployee" runat="server" CommandName="FireEmployee" CommandArgument="<%# Item.Id %>" CssClass="glyphicon glyphicon-ban-circle" title="Fire Employee"></asp:LinkButton></p>
                            <b>Service Territories:</b><br />
                            <asp:ListView ID="StaffTerritoryId" runat="server" DataSource="<%# Item.Territories %>"
                                    ItemType="NorthwindTraders.Entities.POCOs.StaffTerritory"
                                    DataKeyNames="StaffId,TerritoryId"
                                    OnItemDeleting="StaffTerritoryId_ItemDeleting">
                                <ItemTemplate>
                                    <span class="hovershow label label-default" data-toggle="modal">
                                        <%# Item.TerritoryName %>
                                        <asp:LinkButton ID="Remove" runat="server" CssClass="badge badge-error" CommandName="Delete"><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                                    </span>&nbsp;&nbsp;
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <div runat="server" id="itemPlaceholderContainer"><span runat="server" id="itemPlaceholder"></span></div>
                                </LayoutTemplate>
                            </asp:ListView>
                        </div>
                        <div class="panel-footer">
                            <div class="input-group">
                                <asp:TextBox ID="TerritoryToAdd" runat="server" CssClass="form-control"
                                    list="territoryList" placeholder="Add Territory..."></asp:TextBox>
                                <span class="input-group-btn">
                                <asp:LinkButton runat="server" ID="AddTerritory" CommandName="AddTerritory" CommandArgument="<%# Item.Id %>" CssClass="btn btn-default" type="button">Add</asp:LinkButton>
                                </span>
                            </div>
                            <asp:Repeater ID="AllTerritories" runat="server"
                                ItemType="NorthwindTraders.Entities.Territory" DataSourceID="AllTerritoriesDataSource">
                                <HeaderTemplate>
                                    <datalist id="territoryList"></HeaderTemplate>
                                <ItemTemplate>
                                    <option><%# Item.TerritoryDescription %> (<%# Item.TerritoryID %>)</option>
                                </ItemTemplate>
                                <FooterTemplate></datalist></FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <asp:ObjectDataSource runat="server" ID="StaffDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListStaff" TypeName="NorthwindTraders.BLL.HumanResourcesController"></asp:ObjectDataSource>
    <asp:ObjectDataSource runat="server" ID="AllTerritoriesDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllTerritories" TypeName="NorthwindTraders.BLL.HumanResourcesController"></asp:ObjectDataSource>
    <asp:ObjectDataSource runat="server" ID="UnassignedDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListUnassignedTerritories" TypeName="NorthwindTraders.BLL.HumanResourcesController"></asp:ObjectDataSource>

    <style type="text/css">
        .lead .glyphicon {
            color: darkred;
            display: none;
        }

        .lead:hover .glyphicon {
            display: inline;
        }

        .hovershow .badge {
            display: none;
        }
        .hovershow:hover .badge {
            display: inherit;
        }
        .badge {
          padding: 1px 9px 2px;
          font-size: 12.025px;
          font-weight: bold;
          white-space: nowrap;
          color: #ffffff;
          background-color: #999999;
          -webkit-border-radius: 9px;
          -moz-border-radius: 9px;
          border-radius: 9px;
        }
        .badge:hover {
          color: #ffffff;
          text-decoration: none;
          cursor: pointer;
        }
        .badge-error {
          background-color: #b94a48;
        }
        .badge-error:hover {
          background-color: #953b39;
        }
        .badge-warning {
          background-color: #f89406;
        }
        .badge-warning:hover {
          background-color: #c67605;
        }
        .badge-success {
          background-color: #468847;
        }
        .badge-success:hover {
          background-color: #356635;
        }
        .badge-info {
          background-color: #3a87ad;
        }
        .badge-info:hover {
          background-color: #2d6987;
        }
        .badge-inverse {
          background-color: #333333;
        }
        .badge-inverse:hover {
          background-color: #1a1a1a;
        }
    </style>
</asp:Content>

