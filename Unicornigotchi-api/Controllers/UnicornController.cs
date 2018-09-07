using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted.AspNetCore.NewDb.Controllers {
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UnicornController : Controller {

        private readonly mobileRemoteDbContext _context;

        public UnicornController(mobileRemoteDbContext context) {
            _context = context;
        }
         
        [HttpGet]
        public async Task<IActionResult> Index() {
            return View(await _context.Unicorn.ToListAsync());
        }
        
        //GET: Unicorns/Details/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var unicorn = await _context.Unicorn
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unicorn == null) {
                return NotFound();
            }
            return View(unicorn);
        }

        // GET: Unicorns/Create
        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        //GET: Unicorns/Delete/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var unicorn = await _context.Unicorn.FirstOrDefaultAsync(m => m.Id == id);
            if (unicorn == null) {
                return NotFound();
            }

            return View(unicorn);
        }

        // POST: Unicorns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ThirdName")] Unicorn unicorn) {
            if (ModelState.IsValid) {
                _context.Add(unicorn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unicorn);
        }

        //GET: Unicorns/Edit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var unicorn = await _context.Unicorn.FindAsync(id);
            if (unicorn == null) {
                return NotFound();
            }
            return View(unicorn);
        }
         
  
        // POST: Unicorns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,ThirdName")] Unicorn unicorn) {
        //    if (id != unicorn.Id) {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid) {
        //        try {
        //            _context.Update(unicorn);
        //            await _context.SaveChangesAsync();
        //        } catch (DbUpdateConcurrencyException) {
        //            if (!UnicornExists(unicorn.Id)) {
        //                return NotFound();
        //            } else {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(unicorn);
        //}

        //// GET: Unicorns/Delete/5
        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> Delete(int? id) {
        //    if (id == null) {
        //        return NotFound();
        //    }

        //    var unicorn = await _context.Unicorn
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (unicorn == null) {
        //        return NotFound();
        //    }

        //    return View(unicorn);
        //}

        //// POST: Unicorns/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id) {
        //    var unicorn = await _context.Unicorn.FindAsync(id);
        //    _context.Unicorn.Remove(unicorn);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UnicornExists(int id) {
        //    return _context.Unicorn.Any(e => e.Id == id);
        //}
    }
}
