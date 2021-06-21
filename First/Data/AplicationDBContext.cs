using First.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.Data
{
    public class AplicationDBContext:DbContext
    {
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options):base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Expense> Expenses { get; set; }

    }
}
