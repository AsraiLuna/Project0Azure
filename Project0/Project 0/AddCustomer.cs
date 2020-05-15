using System;
using System.Collections.Generic;
using System.Text;
using Project_0.Models;


namespace Project_0
{
   public static class AddCustomer
    {
        public static Customer nCust { get; set; }
        private static string firstNameHolder;
        private static string lastNameHolder;
        private static string preferredStore;
        private static string custID;
        private static Customer newCustomer = new Customer();
        public static void NewCustomer()
        {
             
            while (string.IsNullOrWhiteSpace(firstNameHolder) )
            {
                Console.WriteLine("Please enter your first name");
                firstNameHolder = Console.ReadLine().ToUpper();
            }
            while (string.IsNullOrWhiteSpace(lastNameHolder))
            {
                Console.WriteLine("Please Enter Your Last Name");
                lastNameHolder = Console.ReadLine().ToUpper();
            }
            /*
            while (string.IsNullOrWhiteSpace(custID))
            {
                Console.WriteLine("Please Enter Your Phone Number");
                custID = Console.ReadLine().ToUpper();
            }*/
            while (string.IsNullOrWhiteSpace(preferredStore))
            {
                Console.WriteLine("Please enter a preferred Store \n type 1 for Sleeping Selkie Primary Location" +
                    "\n Type 2 for Sleeping Selking Location Two \n Type 3 fore Sleeping Selkie Location Three");
                preferredStore = Console.ReadLine().ToUpper();
            }
            newCustomer.FirstName = firstNameHolder;
            newCustomer.LastName = lastNameHolder;
            custID = firstNameHolder + lastNameHolder;
            GetCustLookupInfo.CustIDHolder = custID;
            newCustomer.CustomerID = custID;
            newCustomer.StoreID = Convert.ToInt32(preferredStore);
            nCust = newCustomer;
            
        }

    }
}
