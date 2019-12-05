using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
    public class OrderStatus
    {
        [DisplayName("Order Status ID")]
        public int Status_ID { get; set; }
        [DisplayName("Status Description")]
        public string Status_Description { get; set; }
     
    }
}

    /*
    Received
    Testing
    FinalizingReports
    Finished
    */