using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using DataAccess;
using Project_0.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Project_0;
using System.Runtime.CompilerServices;

namespace Xunittest
{
    public class XunitTesting
    {
        #region TestStoreIDSave
        [Fact]
        public void DoesCustStoreIDExist()
        {//Arrange
            // locally configures for testing
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                 .UseInMemoryDatabase(databaseName: "customerDatabase")
                 .Options;

            //ACT
            // Declares a using disposable with new db context with options parameter
            using (var db = new DataBaseContext(options))
            {
                //instantisates cust to save for saving
                Customer cust = new Customer();
                // sets cust id
                cust.CustomerID = "testingTest";
                //sets Customer first name
                cust.FirstName = "I Am";
                // Sets customer last name
                cust.LastName = "A Test";
                // sets cust store id
                cust.StoreID = 1;
                // add and save changes
                db.Add(cust);
                db.SaveChanges();
            }
            /// Assert
            using (var db = new DataBaseContext(options))
            {
                var storeID = db.Customers.Where(cust => cust.CustomerID == "testingTest").FirstOrDefault();
                Assert.Equal(1, storeID.StoreID);
            }
        }
        #endregion
        #region Test CustID

        [Fact]
        public void DoesCustIDEqualTestingID()
        {//Arrange
            // locally configures for testing
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                 .UseInMemoryDatabase(databaseName: "customerDatabase")
                 .Options;

            //ACT
            // Declares a using disposable with new db context with options parameter
            using (var db = new DataBaseContext(options))
            {
                //instantisates cust to save for saving
                Customer cust = new Customer();
                //sets Customer first name
                cust.FirstName = "ThisIs";
                // Sets customer last name
                cust.LastName = "ATest";
                // sets cust id
                cust.CustomerID = cust.FirstName + cust.LastName;
                // sets cust store id
                cust.StoreID = 1;
                // add and save changes
                db.Add(cust);
                db.SaveChanges();
            }
            /// Assert
            using (var db = new DataBaseContext(options))
            {
                var custID = db.Customers.Where(cust => cust.StoreID == 1).FirstOrDefault();
                Assert.Equal("ThisIsATest", custID.CustomerID);
            }
        }
        #endregion
        #region Tests does String go to Upper when applied directly to the string
        [Fact]
        public void DoesStringGoToUpperDirect()
        {
            //Arrange
            string testing;

            //Act
            testing = "uPpeR".ToUpper();
            // testing = To.Upper() failed
            //Assert
            Assert.Equal("UPPER",testing);

        }
        #endregion
        # region Input validation Test While Loop

        [Fact]
        public void InputValidationTest()
        {
            //Arrange
            string testing = null;
            //Act
            while (string.IsNullOrWhiteSpace(testing))
            {
                testing = "Exit";
            }
            //Assert
            Assert.Equal("Exit", testing);
        }
        #endregion
        #region intParsing
        [Fact]
        public void ParseInt()
        {
            //Arrange
            string testing;
            //Act
            testing = "1";
            //Convert.ToInt32(testing); Doing it here did not pass
            //Assert
            Assert.Equal(1,Convert.ToInt32(testing));
        }
        #endregion
        #region CheckInventorySave
        [Fact]
        public void GetInventoryID()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(databaseName: "customerDatabase")
                .Options;
            //Act
            using (var db = new DataBaseContext(options))
            {
                Inventory inv = new Inventory();
                inv.InventoryID = 3;
                inv.StoreID = 2;
                inv.PotionID = 2;
                inv.PotionQuantity = 20;
                db.Add(inv);
                db.SaveChanges();
                var inventory = db.Inventory.Where(inv => inv.InventoryID == 3).FirstOrDefault();
                db.SaveChanges();

                //Assert
                Assert.Equal(3, inventory.InventoryID);
            }

        }
        #endregion
        #region Check  Inventory test
        [Fact]
        public void CheckInventory()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(databaseName: "customerDatabase")
                .Options;
            int checkAgainstNumber = 30;
            //Act
            using (var db =  new DataBaseContext(options))
            {
                Inventory inv = new Inventory();
                inv.InventoryID = 2;
                inv.StoreID = 1;
                inv.PotionID = 1;
                inv.PotionQuantity = 10;
                db.Add(inv);
                db.SaveChanges();
                var quantity = db.Inventory.Where(inv => inv.PotionID == 1).Where(storeInv => storeInv.StoreID == 1).Select(inv => inv.PotionQuantity).FirstOrDefault();

                //Assert
                Assert.True(quantity < checkAgainstNumber);
            }

        }
        #endregion
        #region Modify Inventory
        [Fact]
        public void ModifyInventory()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(databaseName: "customerDatabase")
                .Options;
            int itemSubstract = 5;
            //Act
            using (var db = new DataBaseContext(options))
            {
                Inventory inv = new Inventory();
                inv.InventoryID = 1;
                inv.StoreID = 1;
                inv.PotionID = 1;
                inv.PotionQuantity = 10;
                db.Add(inv);
                db.SaveChanges();
                var quantityChange = db.Inventory.Where(inv => inv.PotionID == 1).Where(storeInv => storeInv.StoreID == 1).Select(inv => inv.PotionQuantity).FirstOrDefault();
                quantityChange -= itemSubstract;
                db.SaveChanges();

                //Assert
                Assert.Equal(5, quantityChange);
            }

        }
        #endregion
        #region TestSwitch
        [Fact]
        public void TestsIfSwitchWorksForRun()
        {
            //Arrange
            string testS;
            string doesItWork = null; ;
            //Act
            testS = "TESTING";
            switch (testS)
            {
                case "TESTING":
                    doesItWork = "yes";
                    break;
                case "NOT":
                    break;
            }
            //Assert
            Assert.Equal("yes", doesItWork);
        }
        #endregion
        #region TestOrders
        [Fact]
        public void TestAddingOrders()
        {//Arrange
            // locally configures for testing
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                 .UseInMemoryDatabase(databaseName: "customerDatabase")
                 .Options;

            //ACT
            using (var db = new DataBaseContext(options))
            {
                //instantisates order to save for saving
                Order order = new Order();
                // sets cust id
                order.OrderID = 1;
                order.CustomerID = "Testing";
                order.Date = DateTime.Now;
                order.HealthPotionsBought = 3;
                order.ManaPotionsBought = 4;
                order.StaminaPotionsBought = 5;
                order.StoreID = 3;
                db.Add(order);
                db.SaveChanges();
            }
            /// Assert
            using (var db = new DataBaseContext(options))
            {
                var healthBought = db.Orders.Where(order => order.OrderID == 1).FirstOrDefault();
                Assert.Equal(3,healthBought.HealthPotionsBought );
            }
        }
        #endregion

    }
}

