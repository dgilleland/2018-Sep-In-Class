using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Admin.Security;

namespace WebApp.Admin.CRUD
{
    public partial class EditInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Secure access to this page
            if (!Request.IsAuthenticated || User.IsInRole(Settings.EmployeeRole))
                Response.Redirect("~", true);
        }

        protected void CheckForExceptions(object sender, ObjectDataSourceStatusEventArgs e)
        {
            MessageUserControl.HandleDataBoundException(e);
        }
    }
}