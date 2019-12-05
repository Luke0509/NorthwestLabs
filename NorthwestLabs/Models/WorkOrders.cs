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

        [DisplayName("Start Date")]
        public DateTime Date_Created { get; set; }

        [DisplayName("Finish Date")]
        public DateTime? Date_Completed { get; set; }

        [DisplayName("Order Status")]
        public DateTime? Order_Status { get; set; }

        [DisplayName("Work Order Discount")]
        public double WO_Discount { get; set; }

        [Range(0, 1)]
        [DisplayName("Order Expedited")]
        public bool Expedite_Order { get; set; }

        [Range(0, 1)]
        public bool Test2_IfActive { get; set; }

        [Range(0, 1)]
        public bool Test2_IfInactive { get; set; }

        [DisplayName("Comments/Analysis")]
        public string Analysis { get; set; }

        [Range(0,1)]
        [DisplayName("Analysis Completed")]
        public bool Analysis_Completed { get; set; }
    }
}