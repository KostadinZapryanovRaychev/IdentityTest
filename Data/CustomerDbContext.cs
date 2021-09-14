
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCoreFromScratch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreFromScratch.Data
{
    public class CustomerDbContext:IdentityDbContext <Customer , CustomerRole ,int> // tuk mu kazvame che shte izpolzvame typa Customer to store user
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options):base (options)
        {
                
        }

        //public CustomerDbContext()
        //   : base()
        //{
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

        }

        internal DbSet<Customer> Customers { get; set; }
    }
}
