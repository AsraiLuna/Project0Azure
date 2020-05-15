using System;
using System.Collections.Generic;
using System.Text;



namespace Project_0
{
    public static class RunApplication
    {
        #region Variable Declarations
        /// <summary>
        /// Variable declarations, declare a set of variables to be assigned and used later
        /// </summary>
        private static string add;
        private static string existing;
        private static string customer;
        private static string store;
        private static string custInput;
        private static bool storeChosen = false;
        private static string newOrder;
        private static string lookUpOrders;
        public static bool StoreChosen { get => storeChosen; set => storeChosen = value; }
        private static bool nOrder;
        public static bool NOrder { get=>nOrder; set => nOrder = value; }
        private static bool cusExists;
        public static bool CusExists { get => cusExists; set => cusExists = value; }
        private static bool cust;
        public static bool Cust { get=>cust; set=>cust=value; }
        private static bool storeInfo;
        public static bool StoreInfo { get => storeInfo; set=>storeInfo=value; }
        #endregion
        /// <summary>
        /// Run App Method checks Input criteria in order to 
        /// determine which methods to run
        /// </summary>
        public static void RunApp()
        {
            //Console.Clear();
            #region Basic Set and checks
            // set inputs to null at the beginning of the app to prevent abnormal 
           custInput = null;
           storeInfo = false;

            cust = false;
            cusExists = false;
            nOrder = false;
           // after selecting customer info, it returns back here, this bool ensures
           // that the user isn't asked redundant questions
            if (storeChosen == true)
            {
                NewOrderOrLookUP();
            
            }
            else GetCustStatus();
            #endregion
            //Switch statement that determines the "State of the application"
            #region Switch Statment
            switch (custInput)
            {
                case "ADD":
                    Console.Clear();
                    Console.WriteLine("You have entered ADD");
                    AddCustomer.NewCustomer();
                    cusExists = false;
                    Console.Clear();
                    break;
                case "EXISTING":
                    Console.Clear();
                    Console.WriteLine("You Have entered EXISTING");
                    cusExists = true;
                    Console.Clear();
                    break;
                case "NEW":
                    Console.Clear();
                    nOrder = true;
                    break;
                case "LOOKUP":
                    Console.Clear();
                    nOrder = false;
                    break;
                case "CUSTOMER":
                   Console.Clear();
                    cust = true;
                    break;
                case "STORE":
                   Console.Clear();
                    Console.WriteLine(storeInfo);
                    storeInfo = true;
                    break;
                default:
                    Console.WriteLine("You have not entered one of the options please enter again");
                    RunApp();
                    break;
            }
            #endregion
        }
        /// <summary>
        /// Asks the user to input add or existing
        /// sets the customer input to what ever the user inputs
        /// </summary>
        #region Get Cust Status Method 
        static void  GetCustStatus()
        {
            add = "ADD";
            existing = "EXISTING";
            Console.WriteLine("Type " + add + " if you are a new customer");
            Console.WriteLine("Type " + existing + " if you are an existing customer");
            custInput = Console.ReadLine().ToUpper();
        }
        #endregion
        /// <summary>
        /// Asks the user to input New order or look up previous orders
        /// Sets the customer input to what ever the user inputs
        /// </summary>
#region New Order method
        static void NewOrderOrLookUP()
        {
            newOrder = "NEW";
            lookUpOrders = "LOOKUP";
            Console.WriteLine("Type " + newOrder + " If you are wanting to place a new order with this store");
            Console.WriteLine("Type " + lookUpOrders + " If you are wanting to look up previous orders");
            custInput = Console.ReadLine().ToUpper();
            if (custInput == lookUpOrders)
            {
                StoreOrdersOrCustomerOrders();
            }
        }
        #endregion
        /// <summary>
        /// Asks the user if they are looking up customer orders or store orders
        /// sets the user input to what ever the user enters
        /// </summary>
#region Store/Orders method
        static void StoreOrdersOrCustomerOrders()
        {
            customer = "CUSTOMER";
            store = "STORE";
            Console.WriteLine("Type " + customer + "If you wish to access all of your orders from this location\n " +
                "Type " + store + " If you wish to lookup all orders from this store");
            custInput = Console.ReadLine().ToUpper();
        }
        #endregion
    }
}
