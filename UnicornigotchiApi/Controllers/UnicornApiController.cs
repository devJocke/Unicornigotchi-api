using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnicornigotchiApi.DataModel;

namespace EFGetStarted.AspNetCore.NewDb.Controllers {

    [Route("[controller]")]
    public class UnicornApiController : Controller {

        private readonly mobileRemoteDbContext _context;

        public UnicornApiController(mobileRemoteDbContext context) {
            _context = context;
        }

        // GET: Unicorns 
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<Unicorn>> GetAll() {
            var unicorn = await _context.Unicorn
            .Include(i => i.Care.Discipline)
            .Include(i => i.Care.Play)
            .Include(i => i.Care.Toilet).ToListAsync();
            return   unicorn;
        }

        //[HttpGet("{id:int}")]
        //public async Task<Unicorn> Details(int? id) {
        //    var unicorn = await _context.Unicorn.FirstOrDefaultAsync(m => m.Id == id);
        //    foreach (var k in _context.Unicorn.Select(j => j.FirstName)) {
        //        Console.WriteLine("--------------------------------------------------------------");
        //        Console.WriteLine(k);
        //        Console.WriteLine("--------------------------------------------------------------");
        //    }
        //    return unicorn;
        //}
        [HttpGet("{id:int}")]
        public async Task<Unicorn> Details(int? id) {
            await _context.Unicorn.FirstOrDefaultAsync(m => m.Id == id);

            var unicorn = await _context.Unicorn
                .Include(i => i.Care.Discipline)
                .Include(i => i.Care.Play)
                .Include(i => i.Care.Toilet)
                .FirstOrDefaultAsync(m => m.Id == id);


            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine(unicorn.CareId);
            Console.WriteLine("--------------------------------------------------------------");


            return unicorn;
        }

        //public static IQueryable<Unicorn> GetFullUnicorn(this IQueryable<Unicorn> query) {
        //    return query.Include(u => u.Care).i
        //}

        // GET: Unicorns/Delete/5
        [HttpDelete("{id:int}")]
        public async Task<Unicorn> Delete(decimal? id) {
            var unicorn = await _context.Unicorn.FirstOrDefaultAsync(m => m.Id == id);
            _context.Unicorn.Remove(await _context.Unicorn.FindAsync(id));
            await _context.SaveChangesAsync();

            return unicorn;
        }

        [HttpPut]
        public async Task<Unicorn> Create(Unicorn unicorn) {
            await _context.Unicorn.AddAsync(unicorn);
            await _context.SaveChangesAsync();
            return unicorn;
        }


        private bool UnicornExists(int? id) {
            return _context.Unicorn.Any(e => e.Id == id);
        }
    }
}
