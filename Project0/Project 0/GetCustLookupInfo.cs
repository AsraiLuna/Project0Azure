using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public static class GetCustLookupInfo
    {
        /// <summary>
        /// Variables declared for use in cust look up
        /// Some are set as properties so they can be accessed by the
        /// data access layer
        /// </summary>
        #region Field and Properties
        private static string storeNumber;
        private static string firstName;
        private static string lastName;
        public static string StoreNumber { get=>storeNumber; set=>storeNumber = value; }
        private static string custIDHolder;
        public static string CustIDHolder { get => custIDHolder; set => custIDHolder = value; }
        #endregion
        #region Get CustID method
        public static void GetCustID()
        {
            // sets cust ID holder to null
            custIDHolder = null;
            /// while cust id holder is null, empty or whitespace ask the user 
            /// for their name and put it in the temp holders
            while (string.IsNullOrWhiteSpace(custIDHolder))
            {
                Console.WriteLine("Please Enter your First Name");
                firstName = Console.ReadLine().ToUpper();
                Console.WriteLine("Please Enter your Last Name");
                lastName = Console.ReadLine().ToUpper();
                // set custIDholder to the first name + the last name
                custIDHolder = firstName + lastName;
            }
        }
        #endregion
        #region SetDefault store
        /// <summary>
        /// Method for asking the user for their preffereed store
        /// while the storeNumber is null ask the player for their store number
        /// then set the storeNumber to the console.readline, if null it will try again
        /// </summary>
        public static void SetDefaultStore()
        {
            storeNumber = null;
            while (string.IsNullOrWhiteSpace(storeNumber) )
            {
                Console.WriteLine("You do not currently have a preferred store, " +
                    "Please choose a store from the following options \n  type 1 for the primary location \n " +
                    "type 2 for the Secondary location \n type  3 for the third location ");
                storeNumber = Console.ReadLine();
            }
        }
        #endregion
    }
}
