<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Admin_FireStaff" Codebehind="FireStaff.aspx.cs" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <h1 class="page-header">Staff Termination</h1>

    <div class="row">
        <div class="col-md-4 bg-info">
            <br />
            <div class="panel panel-default">
                <div class="panel-heading">
                    Employee Details
                    <small class="pull-right">Since
                        <asp:Label ID="HireDate" runat="server"></asp:Label></small>
                </div>
                <div class="panel-body">
                    <asp:HiddenField ID="EmployeeId" runat="server" />
                    <asp:Image ID="Photo" runat="server" Width="48" Height="56" CssClass="img-thumbnail pull-right" />
                    <asp:Label ID="FullName" runat="server" CssClass="lead"></asp:Label>
                    <asp:Label ID="JobTitle" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="TerminationDate">Termination Date:</asp:Label>
                    <asp:TextBox ID="TerminationDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="panel-footer">
                    <asp:LinkButton ID="Terminate" runat="server" CssClass="btn btn-danger" OnClick="Terminate_Click">Terminate Employment</asp:LinkButton>
                    <asp:LinkButton ID="Cancel" runat="server" CssClass="btn btn-default" OnClick="Cancel_Click">Cancel</asp:LinkButton>
                </div>
            </div>
            <p>Employees must be given appropriate notice of termination according to their contract agreement. Any sales territories assigned to the employee can be re-distributed to other employees at this time.</p>
            <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
        </div>


        <asp:Repeater ID="TerritoryReassignmentRepeater" runat="server" ItemType="NorthwindTraders.Entities.POCOs.StaffTerritory">
            <ItemTemplate>
                <div class="col-md-4">
                    <div class="well">
                        <asp:HiddenField ID="TerritoryId" runat="server" Value="<%# Item.TerritoryId %>" />
                        <asp:Label ID="TerritoryTitle" runat="server" AssociatedControlID="EmployeeDropDown"><%# Item.TerritoryName %></asp:Label>
                        <asp:DropDownList ID="EmployeeDropDown" runat="server" CssClass="form-control"
                            DataSource="<%# ListOtherEmployees() %>" AppendDataBoundItems="true"
                            DataTextField="DataText" DataValueField="DataValue">
                            <asp:ListItem Value="">[Select an employee]</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>

