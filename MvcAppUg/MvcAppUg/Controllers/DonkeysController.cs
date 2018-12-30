using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //get
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donkey = await _db.Donkeys.SingleOrDefaultAsync(m => m.Id == id);

            if (donkey == null)
            {
                return NotFound();
            }
            return View(donkey);
        }

        //post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveDonkey(int id)
        {
            var donkey = await _db.Donkeys.SingleOrDefaultAsync(m => m.Id == id);
            _db.Donkeys.Remove(donkey);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (Donkey donkey)
        {
            if (ModelState.IsValid)
            {
                _db.Donkeys.Add(donkey);
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