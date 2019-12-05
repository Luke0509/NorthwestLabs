using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
    [Table("Assays")]
    public class Assay
    {
        [Key]
        [DisplayName("Assay ID")]
        public int Assay_ID { get; set; }
        [DisplayName("Compound ID")]
        public int Compound_ID { get; set; }
        [DisplayName("Estimated Duration of Assay")]
        public int Assay_Duration { get; set; }
        [DisplayName("Number of Tests in the Assay")]
        public int No_Of_Tests { get; set; }
        [DisplayName("Assay Price")]
        public double Assay_Price { get; set; }
        [DisplayName("Assay Name")]
        public string Assay_Name { get; set; }
        [DisplayName("Assay Summary")]
        public string Assay_Summary { get; set; }
        [DisplayName("Assay Details")]
        public string Assay_Details { get; set; }
    }
}