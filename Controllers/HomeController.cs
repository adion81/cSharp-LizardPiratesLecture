using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LizardPirates.Models;

namespace LizardPirates.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context { get;set; }

        public HomeController(MyContext context)
        {
            _context = context;
        }



        [HttpGet("")]
        public IActionResult Index()
        {

            List<LizardPirate> Lps = _context.LizardCrew.ToList();
            return View(Lps);
        }

        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(LizardPirate newLP)
        {
            if(ModelState.IsValid)
            {
                _context.LizardCrew.Add(newLP);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Add");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
