using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted.AspNetCore.NewDb.Controllers {

    [Route("api/[controller]")]
    public class UnicornApiController : Controller {

        private readonly mobileRemoteDbContext _context;

        public UnicornApiController(mobileRemoteDbContext context) {
            _context = context;
        }

        // GET: Unicorns 
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<Unicorn>> GetAll() {
            return await _context.Unicorn.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<Unicorn> Details(int? id) {
            //if (id == null) {
            //    return NotFound();
            //}

            var unicorn = await _context.Unicorn.FirstOrDefaultAsync(m => m.Id == id);
            //if (unicorn == null) {
            //    return NotFound();
            //}
            return unicorn;
        }
        // GET: Unicorns/Delete/5
        [HttpDelete("{id:int}")]
        public async Task<Unicorn> Delete(int? id) {
            //if (id == null) {
            //    return NotFound();
            //}

            var unicorn = await _context.Unicorn.FirstOrDefaultAsync(m => m.Id == id);
            //if (unicorn == null) {
            //    return NotFound();
            //}

            return unicorn;
        }


        //private bool UnicornExists(int id) {
        //    return _context.Unicorn.Any(e => e.Id == id);
        //}
    }
}
