using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project_0;
using Project_0.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess
{
    internal class AccessCustomer
    {
        /// <summary>
        /// Field and property declarations to be used. 
        /// Properties are listed so that they can be used in other classes. 
        /// private fields are here to be used during the modifications
        /// </summary>
        #region Fields and properties
        private static bool cusFound = false;
        public static bool CusFound { get => cusFound; set => cusFound = value; }
        private Customer existingCust;
        public Customer ExistingCustomer { get => existingCust; set => existingCust = value; }
        private int preferredStore;
        public int PreferredStore { get => preferredStore; set => preferredStore = value; }
        private Store store;
        #endregion
        #region Add Cust to Database
        /// <summary>
        /// Internal method to add the customer to the database
        /// </summary>
        internal void AddCusToDataBase()
        {
            // using to make sure that idisposable is properly utilized
            ///declare a new database context to manipulate the tables
            using (var db = new DataBaseContext())
            {
                ///Add the new customer to the database then save the changes
                db.Add(AddCustomer.nCust);
                db.SaveChanges();
                /// sets new order info that is used in the new order class to the info that has been obtained 
                /// from adding the user
                NewOrder.StoreID = AddCustomer.nCust.StoreID;
                NewOrder.custID = AddCustomer.nCust.CustomerID;
                /// sets the bool in run application to true, this enables it to automatically go to lookup orders or new orders when
                /// returning to the application
                RunApplication.StoreChosen = true;
                //return to main app
                RunApplication.RunApp();
            }
        }
        #endregion
        #region Look Up customer from database
        /// <summary>
        /// The Folowing method accesses customer data from the Database
        /// </summary>

        internal void LookUpCustFromDB()
        {
            {
                #region access user info 
                /// setting existingCust(which is basically cur user to the customer that correlates with the customer ID entered by the user)
                using (var db = new DataBaseContext())
                {

                    existingCust = db.Customers.Where(cust => cust.CustomerID == GetCustLookupInfo.CustIDHolder).FirstOrDefault();
                    if (existingCust != null)
                    {
                        store = db.Stores.Where(stores => stores.StoreID == existingCust.StoreID).FirstOrDefault();
                    }
                    

                    if (existingCust != null)
                    {
                        try
                        {
                            /// trys to write a greeting for the returning customer, if it is properly assigned
                            Console.WriteLine("Welcome Back " + existingCust.FirstName);
                            if (existingCust.StoreID != 0)
                            {
                                // show what the current preffered store is set to and ask if the user wants to change their preferred store
                                Console.WriteLine("Your current preferred store is " + store.StoreName + "Store Number " + existingCust.StoreID +
                                    "\n If you would like to change your prefered store type yes otherwise press enter");
                                if (Console.ReadLine().ToUpper() == "YES")
                                {
                                    // if the user wants to change their preferred store set the current store to 0 which will kick off the if 0 statment
                                    existingCust.StoreID = 0;
                                }
                                else
                                {
                                    // if the user chooses to keep their store as is store their information for new order, 
                                    // change store chosen then run application again
                                    NewOrder.StoreID = existingCust.StoreID;
                                    NewOrder.custID = existingCust.CustomerID;
                                    RunApplication.StoreChosen = true;
                                    RunApplication.RunApp();
                                }
                            }
                            #endregion
                            #region Change Preferred store
                            // alows user to change their preferred store setting. 
                            if (existingCust.StoreID <= 0 || existingCust.StoreID >= 4)
                            {
                                // runs the set default store method changing their results as necessary
                                GetCustLookupInfo.SetDefaultStore();
                                /// try catch block that will catch format exceptions for the input. 
                                try
                                {
                                    existingCust.StoreID = Convert.ToInt32(GetCustLookupInfo.StoreNumber);
                                    db.SaveChanges();
                                    NewOrder.StoreID = existingCust.StoreID;
                                    NewOrder.custID = existingCust.CustomerID;
                                    RunApplication.StoreChosen = true;
                                    RunApplication.RunApp();
                                }
                                catch (FormatException exception)
                                {
                                    Console.WriteLine("Please Format Store Identification as an Int", exception);
                                }
                            }
                        }
                        #endregion
                        // catch block for the wrapping try catch block it catches null reference exceptions when the user enters an 
                        //invalid customer 
                        catch (NullReferenceException exception)
                        {
                            Console.WriteLine("That customer was Not found", exception);
                            Console.Clear();
                        }

                    }
                    else 
                    {
                        Console.Clear();
                        Console.WriteLine("No such customer was found");
                        GetCustLookupInfo.GetCustID();
                    }
                }
            }
            #endregion
        }
    }
}


