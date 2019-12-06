using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        [DisplayName("Invoice ID")]
        public int Invoice_ID { get; set; }
        [DisplayName("Order ID")]
        public int Order_ID { get; set; }
        [DisplayName("Net Price")]
        public double Net_Price { get; set; }
        [DisplayName("Total Discounts Applied")]
        public double Total_Discount { get; set; }
        [DisplayName("Final Price")]
        public double Final_Price { get; set; }
    }
}