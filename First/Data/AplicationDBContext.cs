﻿using First.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.Data
{
    public class AplicationDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder.UseSqlServer(connectionString: @"Data Source=localhost;Initial Catalog=ASP;User ID=sa;Password=<oficoidelio@gmail.com>");
        }
     
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }

    }
}
