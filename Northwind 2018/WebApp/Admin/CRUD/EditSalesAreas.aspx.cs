using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Admin.Security;

public partial class Admin_CRUD_EditSalesAreas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Secure access to this page
        if (!Request.IsAuthenticated || User.IsInRole(Settings.EmployeeRole))
            Response.Redirect("~", true);
    }

    protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
    {
        MessageUserControl.HandleDataBoundException(e);
    }
}