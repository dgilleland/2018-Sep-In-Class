using NorthwindTraders.BLL;
using NorthwindTraders.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Staffing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MessageBox.Text = "";
        // TODO: Make sure the only one to manage this page is the VP Sales "Vice President, Sales"
    }

    protected void StaffTerritoryId_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        var controller = new HumanResourcesController();
        var assignment = new TerritoryAssignment()
        {
            EmployeeId = int.Parse( e.Keys["StaffId"].ToString()),
            TerritoryId = e.Keys["TerritoryId"].ToString()
        };
        controller.RemoveTerritoryAssignment(assignment);
        DataBind(); // Force all child controls to bind
    }

    protected void StaffListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "AddTerritory")
        {
            var territoryToAdd = e.Item.FindControl("TerritoryToAdd") as TextBox;
            if (territoryToAdd != null)
            {
                string addId = territoryToAdd.Text;
                addId = addId.Substring(addId.IndexOf("(") + 1, addId.IndexOf(")") - addId.IndexOf("(") - 1);
                string territoryName = territoryToAdd.Text.Replace(addId, "").Replace("()", "");
                var assignment = new TerritoryAssignment()
                {
                    EmployeeId = int.Parse(e.CommandArgument.ToString()),
                    TerritoryId = addId
                };
                var controller = new HumanResourcesController();
                controller.AssignEmployeeTerritory(assignment);

                territoryToAdd.Text = "";
                DataBind(); // Force all child controls to bind
                MessageBox.Text = $"Assigned {territoryName}";
                e.Handled = true; // Only really required for built-in supported commands like "Update"
            }
        }

        if (e.CommandName.Equals("FireEmployee"))
        {
            string targetUrl = $"~/Admin/FireStaff.aspx?eid={e.CommandArgument}";
            Response.Redirect(targetUrl, true);
        }
    }
}