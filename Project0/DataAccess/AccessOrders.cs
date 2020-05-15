using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project_0;
using Project_0.Models;
using System.Linq;


namespace DataAccess
{
    class AccessOrders
    {
        #region Feilds and Properties
        /// <summary>
        /// Feilds and Properties 
        /// </summary>
        internal GetCustomerOrdersInfo cust;
        internal GetStoreOrders store;
        Customer curCust;
        #endregion
        #region AccessPreviousOrder
        /// <summary>
        /// Looks up the previous orders in the database
        /// </summary>
        internal void AccessPreviousOrders()
        {
            /// using calls the idisposable properly, declaring a local variable db to use to access the database
            using (var db = new DataBaseContext())
            {
                // sets the curCust to customers where the customer ID is the same as the cust ID holder in Get customer lookup
                curCust = db.Customers.Where(cust => cust.CustomerID == GetCustLookupInfo.CustIDHolder).FirstOrDefault();
                // instansiates a get customer orders info and get store orders in order to set info to them
                cust = new GetCustomerOrdersInfo();
                store = new GetStoreOrders();
                /// sets the customer orders and the store orders to the ones located in the database
                cust.CusOrders = db.Orders.Where(order => order.CustomerID == curCust.CustomerID).ToList();
                store.StoreOrders = db.Orders.Where(order => order.StoreID == curCust.StoreID).ToList();
            }
        }
        #endregion
        #region AddNewOrder
        /// <summary>
        /// Adds a new order to the database
        /// </summary>
        internal void AddNewOrder()
        {
            /// using block to call idisposable properly
            using (var db = new DataBaseContext())
            {
                try
                {/// adds new order to the database then saves the changes tells the user that the order has been placed
                    db.Add(NewOrder.CurOrder);
                    db.SaveChanges();
                    Console.WriteLine("Your Order has been placed, please pick up at your preferred store");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong with placing the order",e);
                }  
            }
            // runs the app again
            RunApplication.RunApp();
        }
        #endregion
    }
}
