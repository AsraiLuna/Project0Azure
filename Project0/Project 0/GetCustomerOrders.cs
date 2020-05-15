using Project_0.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    /// <summary>
    /// This class handles getting order for customers specifically
    /// This class uses the Interface IOrders
    /// </summary>
    public class GetCustomerOrdersInfo: IOrders
    {
        #region Lists to store info in
        /// <summary>
        /// Declare Lists that the info from the database will be set in
        /// </summary>
       
        private List<Order> cusOrders = new List<Order>();
        public List<Order> CusOrders { get=>cusOrders; set=>cusOrders = value; }
        #endregion
        #region GetOrders
        /// <summary>
        /// Get orders Writes out the information that is stored in the customer orders list
        /// </summary>
        public void GetOrders()
        {
            Console.WriteLine("Customer Order History At this Location");
            foreach (Order ord in cusOrders)
            {
                try
                {
                    Console.WriteLine("The Order Number is " + ord.OrderID+"\n"+ "The Date This was ordered was "+ord.Date +"The Number of Health Potions Bought" +  ord.HealthPotionsBought + 
                       "\n The Number of Mana Potions Bought" +  ord.ManaPotionsBought + "\n The number of Stamina Potions Bought"+ ord.StaminaPotionsBought);
                }
                catch (Exception e)
                {
                    Console.WriteLine("that operation is not allowed",e);
                }

            }
        }
        #endregion
    }
}
