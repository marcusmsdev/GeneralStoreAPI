﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GeneralStoreAPI.Models.GeneralStore_Contexts
{
    public class GeneralStore_Context : DbContext
    {
        public GeneralStore_Context():base("DefaultConnection")
        {
            
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }
}