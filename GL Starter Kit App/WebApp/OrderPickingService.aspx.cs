using GroceryStore.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class OrderPickingService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SavePickOrder_Click(object sender, EventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                // Get the data from the GridView & form,
                // then send to the BLL for processing

                // Update the form
                OrderNumberDropDown.Items.Clear(); // because of AppendDataBoundItems being true
                OrderNumberDropDown.DataBind(); // should cascade to include
                                                // the gridview's data,
                                                // because of the dependency
            }, "Order Picked", "Order Ready for Pickup by Customer");
        }

        protected void FetchOrder_Click(object sender, EventArgs e)
        {
            if(OrderNumberDropDown.SelectedIndex > 0)
            {
                // Populate the customer information from the BLL
                var controller = new OrderListsController();
                var customerInfo = controller.Customers_Get(int.Parse(OrderNumberDropDown.SelectedValue));
                CustomerName.Text = customerInfo.FirstName + " " + customerInfo.LastName;
                ContactNumber.Text = customerInfo.Phone;
            }
        }
    }
}