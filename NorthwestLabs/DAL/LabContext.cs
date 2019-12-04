// using NorthwestLabs.Models;
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

        //public DbSet<model> model {get; set; } 

    }
}