using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project_0.Models
{/// <summary>
/// This class declares the and sets the information for the Potions tables
/// </summary>
    public class Potions
    {
        [Key]
        public int PotionID { get; set; }
        public string PotionName { get ; set; }
        public string PotionDescription { get ; set; }
        public int PotionPrice { get; set; }
        public Potions() { }

    }
}
