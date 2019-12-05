using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
    [Table("Office_Locations")]
    public class Office_Locations
    {
        [Key]
        [DisplayName("Office ID")]
        public int Office_ID { get; set; }
        [DisplayName("Office Name")]
        public string Office_Name { get; set; }
        [DisplayName("Office Address")]
        public string Office_Address { get; set; }
        [DisplayName("City")]
        public string Office_City { get; set; }
        [DisplayName("State")]
        public string Office_Sate { get; set; }
        [DisplayName("Country")]
        public string Office_Country { get; set; }
        [DisplayName("Zip Code")]
        public string Office_Zip { get; set; }
    }
}