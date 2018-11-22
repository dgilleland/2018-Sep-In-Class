using GroceryStore.Entities;
using GroceryStore.Entities.POCOsDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.BLL
{
    [DataObject]
    public class OrderListsController
    {
        #region Query Methods
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<OrderItem> OrderLists_OrderPickList(int orderid)
        {
            // Retrieve the items on an order. Only unpicked orders are to be retrieved

            throw new NotImplementedException();
        }

        public Customer Customers_Get(int customerid)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Command Methods
        public void OrderLists_Picking(int pickingid, int ordereid, List<PickListItem> picklist)
        {
            // Transaction!
            // Update order list item record(s), update order totals, picker and pick date
            // Tables: Orders (U), OrderLists (U)
        }
        #endregion

        #region Exposes Database Entities (bit extreme for what's needed)
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Order> Orders_UnDeliveredList()
        {
            throw new NotImplementedException();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Picker> Pickers_List()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
