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
        [DisplayName("Assay Description")]
        public string Assay_Description{ get; set; }
        [DisplayName("Estimated Duration of Assay")]
        public int Assay_Duration { get; set; }
        [DisplayName("Number of Tests in the Assay")]
        public int No_Of_Tests { get; set; }
    }
}