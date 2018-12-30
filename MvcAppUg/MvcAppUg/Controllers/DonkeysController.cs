using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcAppUg.Models;

namespace MvcAppUg.Controllers
{
    public class DonkeysController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DonkeysController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Donkeys.ToList());
        }

        //Get: Donkey/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (Donkey donkey)
        {
            if (ModelState.IsValid)
            {
                _db.Add(donkey);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //if model is not valid, osiolek has no ogon or something, zwracamy liste osiolkow
            return View(donkey);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}