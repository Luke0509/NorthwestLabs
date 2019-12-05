using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
        [Table("Compounds")]
        public class Compounds
        {
            [Key]
            [DisplayName("Compound ID")]
            public int Compound_ID { get; set; }
            [DisplayName("Compound Name")]
            public string Compound_Name { get; set; }
        }

}