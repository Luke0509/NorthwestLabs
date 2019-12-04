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
            [DisplayName("LT_Number")]
            public int LT_Number { get; set; }
            [DisplayName("Compound Name")]
            public string Compound_Name { get; set; }
            [DisplayName("Quantity")]
            public int Quantity { get; set; }
            [DisplayName("Date Arrived")]
            public DateTime Date_Arrived { get; set; }
            [DisplayName("Date Processed")]
            public DateTime? Date_Processed { get; set; }
            [DisplayName("Due Date")]
            public DateTime Date_Due { get; set; }
            [DisplayName("Appearance")]
            public string Compount_Appeareance { get; set; }
            [DisplayName("Recorded Weight by Client")]
            public double Compound_Weight_Client { get; set; }
            [DisplayName("Actual Weight")]
            public double Actual_Weight { get; set; }
            [DisplayName("Molecular Mass")]
            public double Molecular_Mass { get; set; }
        }

}