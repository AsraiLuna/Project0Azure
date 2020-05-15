using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Project_0.Models
{
    /// <summary>
    /// This class declares the information that is used to make the customer table
    /// </summary>
    public class Customer
    {
        [Key]
        public string CustomerID { get; set; }
        public Customer() { }
        private string firstName;
        public string FirstName { get =>firstName;set=>firstName = value; }
        private string lastName;
        public string LastName { get=>lastName;set=>lastName = value; }
        public Store Store { get; set; }
        public int StoreID { get; set; }

    }
}
