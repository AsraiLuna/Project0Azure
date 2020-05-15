using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_0.Models
{/// <summary>
/// This class sets up the information to make the Order table
/// </summary>
    public class Order
    {
        //primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        //foreign key
        public Customer Customer { get; set; }
        public string CustomerID { get; set; }
        //foreign key
        public Store Store { get; set; }
        public int StoreID { get; set; }
        public int ManaPotionsBought { get; set; }
        public int HealthPotionsBought { get; set; }
        public int StaminaPotionsBought { get; set; }

        private DateTime date;
        public DateTime Date { get=>date; set=>date=value; }
        public Order() { }
    }
}
