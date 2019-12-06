using NorthwestLabs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NorthwestLabs.DAL
{
    public class LabContext : DbContext
    {
        public LabContext()
            : base("LabContext")
        {

        }

        //list different models here

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkOrders> WorkOrders { get; set; }
        public DbSet<Tests> Tests { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Compound_Samples> Compound_Samples { get; set; }



    }
}