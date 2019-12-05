using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
        [Table("Tests")]
        public class Tests
        {
            [Key]
            [DisplayName("ID")]
            [StringLength(2, ErrorMessage = "Max character length for ID is two characters")]
            public string Test_ID { get; set; }
            [DisplayName("Description")]
            public string Test_Description { get; set; }
            [DisplayName("Test Details")]
            public string Test_Details { get; set; }
            [DisplayName("Test Price")]
            public double Test_Price { get; set; }
    }

    
}