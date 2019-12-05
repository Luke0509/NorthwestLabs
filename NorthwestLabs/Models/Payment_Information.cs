using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
    [Table("Payment_Information")]
    public class Payment_Information
    {
        [Key]
        public int Payment_ID { get; set; }

        public int Cust_ID { get; set; }

        [DisplayName("Card Type")]
        [Required]
        public string Card_Type { get; set; }

        [DisplayName("Card Number")]
        [Required]
        [MaxLength(16)]
        [RegularExpression("[^0-9]", ErrorMessage = "CVV must be numeric")]
        public string Card_Number { get; set; }

        [DisplayName("CVV")]
        [Required]
        [MinLength(3)]
        [MaxLength(4)]
        [RegularExpression("[^0-9]", ErrorMessage = "CVV must be numeric")]
        public string Card_CVV { get; set; }
    }
}