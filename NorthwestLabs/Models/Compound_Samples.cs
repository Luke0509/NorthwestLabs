using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
    [Table("Compound_Samples")]
    public class Compound_Samples
    {
        [Key]
        [DisplayName("LT_Number")]
        public int LT_Number { get; set; }
        [DisplayName("Assay ID")]
        public int Assay_ID { get; set; }
        [DisplayName("Order ID")]
        public int Order_ID { get; set; }
        [DisplayName("Date Submitted")]
        public DateTime Date_Arrived { get; set; }
        [DisplayName("Date Processed")]
        public DateTime? Date_Processed { get; set; }
        [DisplayName("Due Date")]
        public DateTime Date_Due { get; set; }
        [DisplayName("Recorded Weight by Client")]
        public double Compound_Weight_Client { get; set; }
        [DisplayName("Actual Weight")]
        public double? Actual_Weight { get; set; }
        [DisplayName("Appearance")]
        public string Compound_Appearance { get; set; }
        [DisplayName("Molecular Mass")]
        public double Molecular_Mass { get; set; }
    }
}