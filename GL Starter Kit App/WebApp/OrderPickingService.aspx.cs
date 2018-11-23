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
                OrderNumberDropDown.Items.Insert(0, new ListItem("[Select a picker]", "0"));

            }, "Order Picked", "Order Ready for Pickup by Customer");
        }

        protected void FetchOrder_Click(object sender, EventArgs e)
        {
            if(OrderNumberDropDown.SelectedIndex > 0)
            {
                // Populate the customer information from the BLL
                var controller = new OrderListsController();
                int orderId = int.Parse(OrderNumberDropDown.SelectedValue);
                                
                var customerInfo = controller.Customers_Get(orderId);

                /* NOTE:
                 * If you were going to have a customerId to send into the BLL method,
                 * then you could have gotten that using the following code:

                var orders = controller.Orders_UnDeliveredList();
                int customerId = orders.Single(x => x.OrderID == orderId).CustomerID;
                var customerInfo = controller.Customers_Get(customerId);

                var pickListData = controller.OrderLists_OrderPickList(orderId);
                OrderItemGridView.DataSource = pickListData;
                OrderItemGridView.DataBind();

                 */

                // Populate the data
                CustomerName.Text = customerInfo.FirstName + " " + customerInfo.LastName;
                ContactNumber.Text = customerInfo.Phone;
            }
        }
    }
}