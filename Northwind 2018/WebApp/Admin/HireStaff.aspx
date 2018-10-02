<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Admin_HireStaff" Codebehind="HireStaff.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1 class="page-header">New Staff Hires</h1>
    <div class="row">
        <div class="col-md-6 grid-form">
            <fieldset>
                <legend>Job Position</legend>
                
                <asp:Label ID="Label1" runat="server" Text="Job Title" AssociatedControlID="JobTitle" />
                <asp:TextBox ID="JobTitle" runat="server"></asp:TextBox>

                <asp:Label ID="Label2" runat="server" Text="Biography/Qualifications" AssociatedControlID="Notes" />
                <asp:TextBox ID="Notes" runat="server" TextMode="MultiLine"></asp:TextBox>

                <asp:Label ID="Label3" runat="server" Text="Hire Date" AssociatedControlID="HireDate" />
                <asp:TextBox ID="HireDate" runat="server" TextMode="Date"></asp:TextBox>

                <asp:Label ID="Label4" runat="server" Text="Supervisor" AssociatedControlID="SupervisorList" />
                <asp:DropDownList ID="SupervisorList" runat="server" AppendDataBoundItems="true" DataSourceID="SupervisorDataSource" DataTextField="Text" DataValueField="Key">
                    <asp:ListItem Value="">[Select a supervisor]</asp:ListItem>
                </asp:DropDownList>
                <asp:ObjectDataSource runat="server" ID="SupervisorDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListStaffNames" TypeName="NorthwindTraders.BLL.HumanResourcesController"></asp:ObjectDataSource>

                <asp:Label ID="Label5" runat="server" Text="Work Phone Extension" AssociatedControlID="Extension" />
                <asp:TextBox ID="Extension" runat="server"></asp:TextBox>
            </fieldset>
            <div>
                <asp:LinkButton ID="AddStaff" runat="server" CssClass="btn btn-primary" OnClick="AddStaff_Click">Add New Staff</asp:LinkButton>
            </div>
                    
            <br />
            <asp:Panel ID="MessagePanel" runat="server" role="alert" Visible="false">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <asp:Label ID="MessageLabel" runat="server"></asp:Label>
            </asp:Panel>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-info"
                 HeaderText="Please note the following problems with your form. Correct these before hiring the new staff member." />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                 ControlToValidate="FirstName" ErrorMessage="First Name is required"
                 Display="None"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                 ControlToValidate="LastName" ErrorMessage="Last Name is required"
                 Display="None"/>
        </div>

        <div class="col-md-6 grid-form">
            <fieldset>
                <legend>Personal Information</legend>
                
                <asp:Label ID="Label6" runat="server" Text="First Name" AssociatedControlID="FirstName" />
                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>

                
                <asp:Label ID="Label7" runat="server" Text="Last Name" AssociatedControlID="LastName" />
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>

                
                <asp:Label ID="Label8" runat="server" Text="Title of Courtesy" AssociatedControlID="CourtesyTitle" />
                <asp:TextBox ID="CourtesyTitle" runat="server" list="titles"></asp:TextBox>
                <datalist id="titles">
                    <option>Dr.</option>
                    <option>Mr.</option>
                    <option>Mrs.</option>
                    <option>Ms.</option>
                </datalist>

                
                <asp:Label ID="Label9" runat="server" Text="Birth Date" AssociatedControlID="BirthDate" />
                <asp:TextBox ID="BirthDate" runat="server" TextMode="Date"></asp:TextBox>

                
                <asp:Label ID="Label10" runat="server" Text="Photo (upload)" AssociatedControlID="Photo" />
                <asp:FileUpload ID="Photo" runat="server"></asp:FileUpload>
            </fieldset>

            <fieldset>
                <legend>Contact Information</legend>
                
                <asp:Label ID="Label11" runat="server" Text="Address" AssociatedControlID="Address" />
                <asp:TextBox ID="Address" runat="server"></asp:TextBox>

                
                <asp:Label ID="Label12" runat="server" Text="City" AssociatedControlID="City" />
                <asp:TextBox ID="City" runat="server"></asp:TextBox>

                
                <asp:Label ID="Label13" runat="server" Text="Region" AssociatedControlID="Region" />
                <asp:TextBox ID="Region" runat="server"></asp:TextBox>

                
                <asp:Label ID="Label14" runat="server" Text="Country" AssociatedControlID="Country" />
                <asp:TextBox ID="Country" runat="server"></asp:TextBox>

                
                <asp:Label ID="Label15" runat="server" Text="Postal Code" AssociatedControlID="PostalCode" />
                <asp:TextBox ID="PostalCode" runat="server"></asp:TextBox>

                
                <asp:Label ID="Label16" runat="server" Text="Phone" AssociatedControlID="Phone" />
                <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
            </fieldset>
        </div>
    </div>
    <link href="/Content/GridFormLayout.css" rel="stylesheet" />
</asp:Content>

