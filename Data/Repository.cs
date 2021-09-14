using NetCoreFromScratch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreFromScratch.Data
{
    public class Repository : IRepository
    {
        public Repository(CustomerDbContext _context)
        {
            Context = _context;
        }

        public CustomerDbContext Context { get; }

        public async Task InsertIntoDB(Customer customer)
        {
            await Context.Customers.AddAsync(customer);
            await Context.SaveChangesAsync();
        }
    }
}
