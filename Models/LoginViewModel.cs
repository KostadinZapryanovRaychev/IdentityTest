using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreFromScratch.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }


        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
