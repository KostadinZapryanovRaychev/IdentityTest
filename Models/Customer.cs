using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreFromScratch.Models
{
    public class Customer : IdentityUser<int> // toq int go nashivsame shtot go nashihme kato treti argument v IdentityDbContexta i ebi mu maikata i tuka i v CustomerRole traq da go ima 
    {
        public int Id { get; set; }
        public int DateBirth { get; set; }
        //public int CustomerId { get; set; }

        //public string Name { get; set; }


    }
}
