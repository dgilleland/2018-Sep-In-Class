<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Battle Stations</h1>
    </div>

    <div class="row">
        <div class="col-md-3">
            <h2 class="text-center">Good Fleet</h2>
            <asp:GridView ID="GoodFleet" runat="server" AutoGenerateColumns="false"
                CssClass="table table-hover table-condensed"
                ItemType="SpaceBattleEngine.Ship"
                OnRowCommand="GoodFleet_RowCommand"
                ViewStateMode="Enabled">
                <Columns>
                    <asp:TemplateField HeaderText="Registry" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("Registry") %>' ID="RegistryNumber"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Power" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("Power") %>' ID="PowerReserve"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField CommandName="Remove" Text="Delete" />
                    <asp:ButtonField CommandName="Add" Text="Deploy ==&amp;gt;" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-md-6">
            <h2 class="text-center">Battle Zone</h2>
            <div class="row">
                <div class="col-md-6">
                    <h2 class="text-center">Federation</h2>
                    <asp:GridView ID="Federation" runat="server"
                        CssClass="table table-hover table-condensed"
                        ItemType="SpaceBattleEngine.Ship" AutoGenerateColumns="False" Caption="Green Battle Group">
                        <Columns>
                            <asp:BoundField DataField="Registry" HeaderText="Id"></asp:BoundField>
                            <asp:BoundField DataField="Power" HeaderText="Power"></asp:BoundField>
                            <asp:BoundField DataField="Shields" HeaderText="Shields"></asp:BoundField>
                            <asp:CheckBoxField DataField="Disabled" HeaderText="!!"></asp:CheckBoxField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-md-6">
                    <h2 class="text-center">Clingons</h2>
                    <asp:GridView ID="Clingons" runat="server"
                        CssClass="table table-hover table-condensed" ItemType="SpaceBattleEngine.Ship" AutoGenerateColumns="False" Caption="Red Battle Group">
                        <Columns>
                            <asp:BoundField DataField="Registry" HeaderText="Id"></asp:BoundField>
                            <asp:BoundField DataField="Power" HeaderText="Power"></asp:BoundField>
                            <asp:BoundField DataField="Shields" HeaderText="Shields"></asp:BoundField>
                            <asp:CheckBoxField DataField="Disabled" HeaderText="!!"></asp:CheckBoxField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <h2 class="text-center">Bad Fleet</h2>
            <asp:GridView ID="BadFleet" runat="server" AutoGenerateColumns="false"
                CssClass="table table-hover table-condensed"
                ItemType="SpaceBattleEngine.Ship"
                OnRowCommand="BadFleet_RowCommand"
                ViewStateMode="Enabled">
                <Columns>
                    <asp:TemplateField HeaderText="Registry" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("Registry") %>' ID="RegistryNumber"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Power" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("Power") %>' ID="PowerReserve"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField CommandName="Remove" Text="Delete" />
                    <asp:ButtonField CommandName="Add" Text="&amp;lt;== Deploy" />

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
