﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Admin.Security
{
    public partial class RegisterNorthwindUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Secure access to this page
            if (!Request.IsAuthenticated || !User.IsInRole(Settings.AdminRole))
                Response.Redirect("~", true);
        }
    }
}