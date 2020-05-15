using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Project_0.Models
{
    public class Store 
    {
        [Key]
        public int StoreID { get; set; }
        public string StoreName { get; set;}
        public Store() { }
   }
}
