using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Admin.Security.DTOs;

namespace WebApp.Admin.Security
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Secure access to this page
            if (!Request.IsAuthenticated || !User.IsInRole(Settings.AdminRole))
                Response.Redirect("~", true);

            CurrentUserFeedback();
        }

        private void CurrentUserFeedback()
        {
            CurrentUserName.Text = User.Identity.Name;
            List<string> roleChecks = new List<string>();
            if (User.IsInRole(Settings.AdminRole)) roleChecks.Add(Settings.AdminRole);
            if (User.IsInRole(Settings.CustomerRole)) roleChecks.Add(Settings.CustomerRole);
            if (User.IsInRole(Settings.EmployeeRole)) roleChecks.Add(Settings.EmployeeRole);
            CurrentUserRoles.Text = string.Join(", ", roleChecks);
        }

        protected void CheckForExceptions(object sender, ObjectDataSourceStatusEventArgs e)
        {
            MessageUserControl.HandleDataBoundException(e);
        }

        protected void UsersListView_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            var addToRoles = new List<RegisteredUser.UserRole>();
            var roles = e.Item.FindControl("AssignedUserRoles") as CheckBoxList;
            if (roles != null)
                foreach (ListItem item in roles.Items)
                    if (item.Selected)
                        addToRoles.Add(new RegisteredUser.UserRole { RoleId = item.Value });
            e.Values[nameof(RegisteredUser.UserRoles)] = addToRoles;
        }

        protected void UsersListView_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            var addToRoles = new List<RegisteredUser.UserRole>();
            var roles = UsersListView.Items[e.ItemIndex].FindControl("AssignedUserRoles") as CheckBoxList;
            if (roles != null)
                foreach (ListItem item in roles.Items)
                    if (item.Selected)
                        addToRoles.Add(new RegisteredUser.UserRole { RoleId = item.Value });
            e.NewValues[nameof(RegisteredUser.UserRoles)] = addToRoles;
        }

        protected void AssignedUserRoles_DataBound(object sender, EventArgs e)
        {
            var control = sender as CheckBoxList;
            if( control != null )
            {
                var parent = (sender as Control).Parent as ListViewDataItem;
                if (parent != null)
                {
                    var data = parent.DataItem as RegisteredUser;
                    if(data != null)
                    {
                        foreach(ListItem item in control.Items)
                        {
                            item.Selected = data.UserRoles.Any(x => x.RoleId == item.Value);
                        }
                    }
                }
            }
        }
    }
}