using System;
using Microsoft.EntityFrameworkCore;
using Project_0;



namespace DataAccess
{
    class Program
    {
        static void Main()
        {
            #region Feilds and Properties
            /// Declare variables to use throughout main method
            AccessOrders orderAcc = new AccessOrders();
            AccessCustomer accessCus = new AccessCustomer();
            InventoryAccess invAcc = new InventoryAccess();
            #endregion
            // call the run application to start the program
            RunApplication.RunApp();
            #region Check whether to add customer to database or to lookup existing
            //chacks if the custumer exists if not add customer to database, if not add customer
            if (RunApplication.CusExists == false)
            {
                accessCus.AddCusToDataBase();

            }
            // if customer exists
            else if (RunApplication.CusExists ==true )
            {
                do
                {
                    /// set runs the look up customer from database until the 
                    /// customer is not null
                    GetCustLookupInfo.GetCustID();
                    Console.WriteLine("Looking for customer");
                    if (GetCustLookupInfo.CustIDHolder != null)
                    {
                        accessCus.LookUpCustFromDB();
                    }    
                }while (accessCus.ExistingCustomer == null);
            }
            #endregion
            #region new order
            /// checks if newOrder is set to true if so access the store inventory in order 
            /// to use that inventory in a new order, run a new order method to place a new order
            if (RunApplication.NOrder)
            {
                Console.WriteLine("Accessing store Inventory");
                invAcc.GetStoreInventory();
                NewOrder.NewOrderSetup();
                invAcc.ChangeStoreInventory();
                orderAcc.AddNewOrder();
              
            }
            #endregion
            /// if the cust is not trying to add a new order access previous orders 
            else
            {
                #region Access Previous Orders
                /// check if the user has requested to look up previous orders 
                /// access previous orders and run the get orders store/ or get orders customer depending on 
                /// which bools are true
                orderAcc.AccessPreviousOrders();
                if (RunApplication.Cust == true)
                {
                    orderAcc.cust.GetOrders();
                }
                else if (RunApplication.StoreInfo==true)
                {
                    orderAcc.store.GetOrders();
                }
               
            }
            #endregion
        }
    }
}
