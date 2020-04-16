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

            List<LizardPirate> Lps = _context.LizardCrew.OrderByDescending(l => l.PirateRoll).ToList();
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

        [HttpGet("{LPId}")]
        public IActionResult Show(int LPId)
        {
            LizardPirate show = _context.LizardCrew.FirstOrDefault( l => l.LizardPirateId == LPId);
            return View(show);
        }

        [HttpGet("edit/{LPId}")]
        public IActionResult Edit(int LPId)
        {
            LizardPirate edit = _context.LizardCrew.FirstOrDefault( l => l.LizardPirateId == LPId);
            return View(edit);
        }

        [HttpPost("update/{LPId}")]
        public IActionResult Update(int LPId,LizardPirate update)
        {
            LizardPirate retrieved = _context.LizardCrew.FirstOrDefault( l => l.LizardPirateId == LPId );

            if(ModelState.IsValid)
            {
                retrieved.Name = update.Name;
                retrieved.LizardType = update.LizardType;
                retrieved.PirateRoll = update.PirateRoll;
                retrieved.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return Redirect($"/{LPId}");
            }
            else
            {
                update.LizardPirateId = LPId;
                return View("Edit",update);
            }
        }

        [HttpGet("delete/{LPId}")]
        public IActionResult Destroy(int LPId)
        {
            LizardPirate walkThePlank = _context.LizardCrew.FirstOrDefault( l => l.LizardPirateId == LPId);
            _context.LizardCrew.Remove(walkThePlank);
            _context.SaveChanges();
            return Redirect("/");
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
