using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
    
    [Table("Order_Details")]
    public class Order_Details
    {
        [Key]
        [Column(Order = 1)]
        [DisplayName("Order ID")]
        public int Order_ID { get; set; }
        [Key]
        [Column(Order = 2)]
        [DisplayName("LT Number")]
        public int LT_Number { get; set; }
        [DisplayName("Item Price")]
        public double Item_Price { get; set; }
        [DisplayName("Results Ascii")]
        public string Results_File_Ascii { get; set; }
    }
    
}