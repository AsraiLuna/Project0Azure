using System;
using System.Collections.Generic;
using System.Text;
using Project_0.Models;

namespace Project_0
{
    // Store orders class uses IOrders Interface
   public class GetStoreOrders : IOrders
    {
        #region Fields and Properties 
        /// <summary>
        /// Fields and Properties for use 
        /// </summary>
        private List<Order> storeOrders = new List<Order>();
        public List<Order> StoreOrders { get => storeOrders; set => storeOrders = value; }
        #endregion
        #region GetOrders/ Print out 
        /// <summary>
        /// Get Orders  Impliments the IOrder interface
        /// </summary>
        public void GetOrders()
        {
            Console.WriteLine("All Order History At this Location");
            //Fore each loop that prints the desired information from the store orders list to the console.
            foreach (Order ord in storeOrders)
            {
                try
                {
                    Console.WriteLine("The Order Number is " + ord.OrderID + "\n" +" The Date this was ordered was "+ ord.Date + "The Number of Health Potions Bought" + ord.HealthPotionsBought +
                       "\n The Number of Mana Potions Bought" + ord.ManaPotionsBought + "\n The number of Stamina Potions Bought" + ord.StaminaPotionsBought);
                }
                catch (Exception e)
                {
                    Console.WriteLine("that operation is not allowed", e);
                }
            } 
        }
        #endregion
    }
}
