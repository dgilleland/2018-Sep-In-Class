using NorthwindTraders.BLL;
using NorthwindTraders.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_FireStaff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int employeeId;
            if (int.TryParse(Request.QueryString["eid"], out employeeId))
            {
                EmployeeId.Value = employeeId.ToString();
                PopulatePage(employeeId);
            }
            else
                Response.Redirect("~/Default.aspx", true);
        }
    }

    private void PopulatePage(int Id)
    {
        var manager = new HumanResourcesController();
        var employee = manager.GetStaffProfile(Id);
        if(employee == null)
            Response.Redirect("~/Default.aspx", true);

        FullName.Text = employee.Name;
        JobTitle.Text = employee.JobTitle;
        HireDate.Text = employee.HireDate.Value.ToShortDateString();
        Photo.ImageUrl = @"data:image/gif;base64," + Convert.ToBase64String(employee.Photo.ToArray());

        TerritoryReassignmentRepeater.DataSource = employee.Territories;
        TerritoryReassignmentRepeater.DataBind();


    }

    private List<KeyValueOption> _OtherEmployees = null;
    public List<KeyValueOption> ListOtherEmployees()
    {
        if (_OtherEmployees == null)
        {
            var controller = new HumanResourcesController();
            _OtherEmployees = controller.ListStaffNames().Where(x => x.Key != EmployeeId.Value).ToList();
        }
        return _OtherEmployees;
    }

    protected void Terminate_Click(object sender, EventArgs e)
    {
        //if (IsValid)
        {
            int employeeId = int.Parse(EmployeeId.Value);
            List<TerritoryAssignment> reassignedTerritories = new List<TerritoryAssignment>();
            DateTime firedOn = DateTime.Parse(TerminationDate.Text);

            foreach (RepeaterItem item in TerritoryReassignmentRepeater.Items)
            {
                var tidControl = item.FindControl("TerritoryId") as HiddenField;
                var sidControl = item.FindControl("EmployeeDropDown") as DropDownList;
                int sid;

                if (int.TryParse(sidControl.SelectedValue, out sid))
                {
                    TerritoryAssignment reassignment = new TerritoryAssignment()
                    {
                        EmployeeId = sid,
                        TerritoryId = tidControl.Value
                    };
                    reassignedTerritories.Add(reassignment);
                }
            }

            HumanResourcesController controller = new HumanResourcesController();
            controller.FireEmployee(employeeId, reassignedTerritories, firedOn);
        }
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}