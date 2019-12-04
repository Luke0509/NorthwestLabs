using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
    [Table("Work_Orders")]
    public class WorkOrders
    {
        [Key]
        public int Order_ID { get; set; }

        public int Cust_ID { get; set; }

        public int Invoice_ID { get; set; }

        public int Employee_ID { get; set; }

        [DisplayName("Start Date")]
        public string Date_Created { get; set; }

        [DisplayName("Finish Date")]
        public string Date_Completed { get; set; }

        [DisplayName("Work Order Discount")]
        public float WO_Discount { get; set; }

        [Range(0, 1)]
        [DisplayName("Order Expedited")]
        public int ExpediteOrder { get; set; }

        [Range(0, 1)]
        public int Test2_IfActive { get; set; }

        [Range(0, 1)]
        public int Test2_IfInactive { get; set; }

        [DisplayName("Results File")]
        public string Results_File_Ascii { get; set; }

        [DisplayName("Analysis")]
        public string Analysis { get; set; }

        [Range(0,1)]
        [DisplayName("Analysis Completed")]
        public int Analysis_Completed { get; set; }
    }
}