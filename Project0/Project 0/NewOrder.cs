using System;
using System.Collections.Generic;
using System.Text;
using Project_0;
using Project_0.Models;

namespace Project_0
{
    public static class NewOrder
    {
        #region Feilds and Properties 
        /// <summary>
        /// Feild and property declarations
        /// </summary>
        public static string custID { get; set; }
        private static string custInput;
        private static Order curOrder = new Order();
        public static Order CurOrder { get; set; }
        private static int orderID;
        private static DateTime date;
        public static int StoreID { get; set; }
        private static int howManytoBuy;
        private static int inStock;
        private static int totalHealth;
        public static int TotalHealth { get=>totalHealth; set=>totalHealth = value; }
        private static int totalMana;
        public static int TotalMana { get=>totalMana; set=>totalMana = value; }
        private static int totalStamina;
        public static int TotalStamina { get=>totalStamina; set=>totalStamina = value; }
        public static int HealthInStock { get; set; }
        public static int ManaInStock { get; set; }
        public static int StaminaInStock { get; set; }
        #endregion
        #region New Order Setup
        /// <summary>
        /// New order Setup asks the user if which potion they would like to buy and presents 
        /// </summary>
        public static void NewOrderSetup()
        {
            // asks the user to select the potion they want 
            custInput = null;
            while (string.IsNullOrWhiteSpace(custInput))
            {
                Console.WriteLine("Please enter which potion you are interested int \n type HEALTH for a health potion" +
                    "\n Type MANA for a Mana Potion \n Type Stamina for Stamina Potions");
                custInput = Console.ReadLine().ToUpper();
            }
            /// runs this switch statement based on what the user inputs
            switch (custInput)
            {
                case "HEALTH":
                    inStock = HealthInStock;
                    ChoosePotionQuantity();
                    CheckInventory();
                    HealthInStock -= howManytoBuy;
                    totalHealth += howManytoBuy;
                    PlaceNewOrderCheck();
                
                    
                    break;
                case "MANA":
                    inStock = ManaInStock;
                    ChoosePotionQuantity();
                    CheckInventory();
                    ManaInStock -= howManytoBuy;
                    totalMana += howManytoBuy;
                    PlaceNewOrderCheck();
          
                    
                    break;
                case "STAMINA":
                    inStock = StaminaInStock;
                    ChoosePotionQuantity();
                    CheckInventory();
                    StaminaInStock -= howManytoBuy;
                    totalStamina += howManytoBuy;
                    PlaceNewOrderCheck();
              
                    break;
                default:
                    Console.WriteLine("You have not chosen one of the options");
                    NewOrderSetup();
                    break;
            }
            #endregion
            #region Place New Order
            /// Place new order check, the name is misleading, it actually checks whether the player wants to add another
            /// item to the checks they user input
            /// if the user says yes run new order set up again
            static void PlaceNewOrderCheck()
            {
                Console.WriteLine("Would you like to add another item? \n Type YES if you would like to add another item\n Press enter to go to checkout");
                custInput = Console.ReadLine().ToUpper();
                if (custInput == "YES")
                {
                    NewOrderSetup();
                }
                else PlaceOrder();
            }
            #endregion
            #region Choose Potion Quantity
            /// Lets the user input the quantity that they want of the potion they have selected 
            /// Converts the input to int after it has been typed in
            static void ChoosePotionQuantity()
            {
                Console.WriteLine("How many would you like to buy");
                howManytoBuy = Convert.ToInt32(Console.ReadLine());
            }
            #endregion
            #region CheckInventory
            ///checks the inventory stock to make sure that the requested amount is 
            ///actually in the inventory
            static void CheckInventory()
            {
                if (howManytoBuy > inStock)
                {
                    Console.WriteLine("There are not that many in stock");
                    ChoosePotionQuantity();
                }
            }
            #endregion
            #region Place Order 
            /// Sets the cur order information to the information that has been gathered in 
            /// this class  to the respective values in preperation to be saved
            static void PlaceOrder()
            {
                date = DateTime.Now;
                curOrder.HealthPotionsBought = totalHealth;
                curOrder.ManaPotionsBought = totalMana;
                curOrder.StaminaPotionsBought = totalStamina;
                curOrder.Date = date;
                curOrder.CustomerID = custID;
                curOrder.StoreID = StoreID;
                CurOrder = curOrder;
                Console.WriteLine("Your current order is" + "\nDate" +curOrder.Date + "\nHealth Potions"+ curOrder.HealthPotionsBought +
                    "\nMana Potions "+curOrder.ManaPotionsBought +"\nStamina Potions "+ curOrder.StaminaPotionsBought +"\nCustomer" +  curOrder.CustomerID +"\nStoreID" +  curOrder.StoreID);
            }
            #endregion
        }
    }
}
