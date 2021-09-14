using Microsoft.AspNetCore.Mvc;
using NetCoreFromScratch.Data;
using NetCoreFromScratch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreFromScratch.Controllers
{
   
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public IActionResult Index () 
        {
            return View();
        }

        //IEnumerable<Customer> data;

        ////IAction result ni pozvolqva da vrushtame vsqkvi neshta za tva e takyv data type
        //public IActionResult Index()
        //{
        //    data = new List<Customer>()
        //    {
        //        new Customer {},
        //        new Customer {},
        //    };
        //    return View(data);

        //}
        //// tva [FromServices] e nqkvo izvrashtenie deto ne go razbiram
        //public async Task <IActionResult> ProcessDatabase([FromServices] IRepository repository)
        //{
        //    //var data = new List<Customer>()
        //    //{
        //    //    new Customer {Name="George"},
        //    //    new Customer {Name="Paul"},
        //    //};


        //    //foreach (var customer in data)
        //    //{
        //    //   await repository.InsertIntoDB(customer);
        //    //}

        //    return Content("Data was processed");
        //}

    }
}
