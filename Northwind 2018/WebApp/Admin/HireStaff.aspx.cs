using NorthwindTraders.BLL;
using NorthwindTraders.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_HireStaff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void AddStaff_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            DateTime parsedDate;
            int parsedId;
            var hire = new NewEmployeeProfile();
            hire.Title = JobTitle.Text;
            hire.Notes = Notes.Text;
            if (DateTime.TryParse(HireDate.Text, out parsedDate))
                hire.StartDate = parsedDate;
            if (int.TryParse(SupervisorList.SelectedValue, out parsedId))
                hire.Supervisor = parsedId;
            hire.Extension = Extension.Text;
            hire.FirstName = FirstName.Text;
            hire.LastName = LastName.Text;
            hire.TitleOfCourtesy = CourtesyTitle.Text;
            if (DateTime.TryParse(BirthDate.Text, out parsedDate))
                hire.BirthDate = parsedDate;
            if (Photo.HasFile)
                hire.RawPhoto = Photo.FileBytes;
            hire.Address = Address.Text;
            hire.City = City.Text;
            hire.Region = Region.Text;
            hire.Country = Country.Text;
            hire.PostalCode = PostalCode.Text;
            hire.HomePhone = Phone.Text;

            var controller = new HumanResourcesController();
            try
            {
                controller.HireEmployee(hire);
                MessageLabel.Text = "Employee Added";
                MessagePanel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
                MessagePanel.Visible = true;
            }
        }
    }
}