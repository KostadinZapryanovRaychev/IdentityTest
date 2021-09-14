using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace NetCoreFromScratch.Controllers
{
    [Authorize] // noone which is not authenticated cannot acces this place 
    public class ProtectedController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
