using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
    public class States
    {
        [DisplayName("State")]
        public string State_ID { get; set; }
        [DisplayName("State")]
        public string State_Name { get; set; }
    }
}