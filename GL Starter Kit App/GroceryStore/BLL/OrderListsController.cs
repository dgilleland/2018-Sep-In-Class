using GroceryStore.DAL;
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
        /// <summary>
        /// Used to get a list of all the order items for a given order.
        /// </summary>
        /// <param name="orderid">The primary key ID of the order</param>
        /// <returns>List of <see cref="OrderItem"/> objects on the given order.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<OrderItem> OrderLists_OrderPickList(int orderid)
        {
            // Retrieve the items on an order.
            // Only unpicked orders are to be retrieved
            // TODO: Student work - Query to get the data.
            return new List<OrderItem>(); // empty list - TEMP
            //throw new NotImplementedException();
        }

        // NOTE: From the order, I can get the customer :)
        /// <summary>
        /// Gets the customer details for a specific order
        /// </summary>
        /// <param name="orderId">An order Id related to the customer</param>
        /// <returns>Customer (entity) object</returns>
        public Customer Customers_Get(int orderId)
        {
            using (var context = new GroceryListContext())
            {
                return context.Orders
                       .Single(x => x.OrderID == orderId)
                       ?.Customer; // ?. -- If the result of the
                                   // .Single() is null, return null,
                                   // otherwise, return the .Customer
                                   // ?. is called the
                                   // null conditional operator
            }
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
            using (var context = new GroceryListContext())
            {
                var results = from data in context.Orders
                              where !data.PickedDate.HasValue // Not picked
                                 && !data.PickerID.HasValue // "can" be assumed, kinda
                              select data;
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Picker> Pickers_List()
        {
            using (var context = new GroceryListContext())
            {
                return context.Pickers.ToList();
            }
        }
        #endregion
    }
}
