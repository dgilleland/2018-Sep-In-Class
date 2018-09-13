<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_MessageUserControl" Codebehind="MessageUserControl.ascx.cs" %>
<asp:Panel ID="MessagePanel" runat="server">
    <div class="panel-heading">
        <asp:Label ID="MessageTitleIcon" runat="server"> </asp:Label>
        <asp:Label ID="MessageTitle" runat="server" />
    </div>
    <div class="panel-body">
        <asp:Label ID="MessageLabel" runat="server" />
        <asp:Repeater ID="MessageDetailsRepeater" runat="server" EnableViewState="false">
            <headertemplate>
                <ul>
            </headertemplate>
            <footertemplate>
                </ul>
            </footertemplate>
            <itemtemplate>
                <li><%# Eval("Error") %></li>
            </itemtemplate>
        </asp:Repeater>
    </div>
</asp:Panel>