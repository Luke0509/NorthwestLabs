using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace NorthwestLabs.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [Display(Name = "Employee ID")]
        public int Employee_ID { get; set; }
        [Display(Name = "Employee Fist Name")]
        public string Employee_First_Name { get; set; }
        [Display(Name = "Employee_Last_Name")]
        public string Employee_Last_Name { get; set; }
        [Display(Name = "Employee Email")]
        public string Employee_Email { get; set; }
        [Display(Name = "Employee Password")]
        public string Employee_Password { get; set; }
        [Display(Name = "Employee Role ID")]
        public int Employee_Role_ID { get; set; }
        [Display(Name = "Office ID")]
        public int Office_ID { get; set; }
        [Display(Name = "Employee Address")]
        public string Employee_Address { get; set; }
        [Display(Name = "Employee City")]
        public string Employee_City { get; set; }
        [Display(Name = "Employee State")]
        public string Employee_State { get; set; }
        [Display(Name = "Employee Country")]
        public string Employee_Country { get; set; }
        [Display(Name = "Employee Zip")]
        public int Employee_Zip { get; set; }
    }
}