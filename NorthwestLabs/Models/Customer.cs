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
        [DisplayName("Customer ID")]
        public int Cust_ID { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [DisplayName("First Name")]
        public string Cust_First_Name{ get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Last Name")]
        public string Cust_Last_Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Street Address")]
        public string Cust_Address { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("City")]
        public string Cust_City { get; set; }
        [StringLength(2, ErrorMessage ="Please enter 2 letter state abbreviation")]
        [DisplayName("State")]
        public string Cust_State { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Country")]
        public string Cust_Country { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Zip")]
        public string Cust_Zip { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Email Address")]
        [EmailAddress(ErrorMessage ="Please enter a valid Email address")]
        public string Cust_Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Password")]
        public string Cust_Password { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Phone Number")]
        public string Cust_Phone { get; set; }
        [DisplayName("Date of Account Creation")]
        public DateTime Account_Created_Date { get; set; }
        [DisplayName("Discount")]
        public double Cust_Discount { get; set; }

    }
}