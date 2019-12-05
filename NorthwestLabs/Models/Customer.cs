using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
    [Table("Customer_Information")]
    public class Customer
    {
        [Key]
        public int Cust_ID { get; set; }
        [DisplayName("First Name")]
        public string Cust_First_Name{ get; set; }
        [DisplayName("Last Name")]
        public string Cust_Last_Name { get; set; }
        [DisplayName("Street Address")]
        public string Cust_Address { get; set; }
        [DisplayName("City")]
        public string Cust_City { get; set; }
        [DisplayName("State")]
        public string Cust_State { get; set; }
        [DisplayName("Country")]
        public string Cust_Country { get; set; }
        [DisplayName("Zip")]
        public string Cust_Zip { get; set; }
        [DisplayName("Email Address")]
        [EmailAddress(ErrorMessage ="Please enter a valid Email address")]
        public string Cust_Email { get; set; }
        [DisplayName("Password")]
        public string Cust_Password { get; set; }
        [DisplayName("Phone Number")]
        public string Cust_Phone { get; set; }
        [DisplayName("Date of Account Creation")]
        public DateTime Account_Created_Date { get; set; }
        [DisplayName("Discount")]
        public double Cust_Discount { get; set; }

    }
}