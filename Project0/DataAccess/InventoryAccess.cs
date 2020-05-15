using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project_0;
using Project_0.Models;
using System.Linq;


namespace DataAccess
{
    class InventoryAccess
    {
        #region Feilds and Properties
        /// <summary>
        /// Private feilds and properties declaration in order to be used for 
        /// Invertory access
        /// </summary>
        private int manaStock;
        private int healthStock;
        private int staminaStock;
        Customer curCust;
        int curStore;
        #endregion
        #region ChangeStoreInventory
        /// <summary>
        /// Changes store inventory to reflect orders that have been placed
        /// </summary>
        internal void ChangeStoreInventory()
        {
            
            using (var db = new DataBaseContext())
            {
                // sets cur Cust to the cur customer that is accessing the app
                curCust = db.Customers.Where(cust => cust.CustomerID == GetCustLookupInfo.CustIDHolder).FirstOrDefault();
                // sets the cur store
                curStore = curCust.StoreID;
                /// accesses the stocks stores in enventory
                healthStock = db.Inventory.Where(inv => inv.StoreID == curStore)
                    .Where(pID => pID.PotionID == 1).Select(inv => inv.PotionQuantity).FirstOrDefault();
                manaStock = db.Inventory.Where(inv => inv.StoreID == curStore)
                    .Where(pID => pID.PotionID == 2).Select(inv => inv.PotionQuantity).FirstOrDefault();
                staminaStock = db.Inventory.Where(inv => inv.StoreID == curStore)
                    .Where(pID => pID.PotionID == 3).Select(inv => inv.PotionQuantity).FirstOrDefault();
                // set the database health stock to health stock minus the total items bought in the order that was 
                // placed
                healthStock = healthStock -= NewOrder.TotalHealth;
                manaStock = manaStock -= NewOrder.TotalMana;
                staminaStock = staminaStock -= NewOrder.TotalStamina;
                //save changes
                db.SaveChanges();
                Console.WriteLine("Health Stock Left" + healthStock);
                Console.WriteLine("ManaStock" + manaStock);
                Console.WriteLine("Stamina Stock" + staminaStock);


            }
        }
        #endregion
        #region Get Store Inventory
        /// <summary>
        /// Get store Inventory gets the current inventory of items from the store and sets the new order inventory items to their correlating
        /// counterparts
        /// </summary>
        internal void GetStoreInventory()
        {
            // using block declares db to use while retrieving database info
            using (var db = new DataBaseContext())
            {
                // sets cur cust info to the current User info 
                curCust = db.Customers.Where(cust => cust.CustomerID == GetCustLookupInfo.CustIDHolder).FirstOrDefault();
                // sets the cur store to the current users preferred store
                curStore = curCust.StoreID;
                ///gets the stock items from inventory
                healthStock = db.Inventory.Where(inv => inv.StoreID == curStore)
                    .Where(pID => pID.PotionID == 1).Select(inv => inv.PotionQuantity).FirstOrDefault();
                manaStock = db.Inventory.Where(inv => inv.StoreID == curStore)
                    .Where(pID => pID.PotionID == 2).Select(inv => inv.PotionQuantity).FirstOrDefault();
                staminaStock = db.Inventory.Where(inv => inv.StoreID == curStore)
                    .Where(pID => pID.PotionID == 3).Select(inv => inv.PotionQuantity).FirstOrDefault();
            }
            // sets the new order stock references to the stock values pulled from inventory 
            NewOrder.HealthInStock = healthStock;
            NewOrder.ManaInStock = manaStock;
            NewOrder.StaminaInStock = staminaStock;
        }
        #endregion
    }
}
