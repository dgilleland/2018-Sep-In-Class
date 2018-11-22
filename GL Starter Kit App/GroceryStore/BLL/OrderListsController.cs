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
        public List<PickList> OrderLists_OrderPickList(int orderid)
        {
            // Retrieve the items on an order. Only unpicked orders are to be retrieved

            throw new NotImplementedException();
        }

        public Customer Customers_Get(int customerid)
        {
            throw new NotImplementedException();
        }

        public void OrderLists_Picking(int pickingid, int ordereid, List<PickList> picklist)
        {
            // Transaction!
            // Update order list item record(s), update order totals, picker and pick date
            // Tables: Orders (U), OrderLists (U)
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Order> Orders_UnDeliveredList()
        {
            throw new NotImplementedException();
        }

        public List<Picker> Pickers_List()
        {
            throw new NotImplementedException();
        }


    }
}
