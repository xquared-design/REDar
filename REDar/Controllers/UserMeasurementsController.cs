#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using REDar.Models;
using REDar.Areas.Identity.Data;


namespace REDar.Controllers
{
    public class UserMeasurementsController : Controller
    {
        private readonly REDarDataContext _context;

        public UserMeasurementsController(REDarDataContext context)
        {
            _context = context;
        }

        // GET: UserMeasurements
        public async Task<IActionResult> Index()
        {
            var rEDarDataContext = _context.UserMeasurement.Include(u => u.User);
            return View(await rEDarDataContext.ToListAsync());
        }

        // GET: UserMeasurements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMeasurement = await _context.UserMeasurement
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userMeasurement == null)
            {
                return NotFound();
            }

            return View(userMeasurement);
        }

        // GET: UserMeasurements/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Set<REDarUser>(), "Id", "Id");
            return View();
        }

        // POST: UserMeasurements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,type,val,TimeStamp")] UserMeasurement userMeasurement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userMeasurement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<REDarUser>(), "Id", "Id", userMeasurement.UserId);
            return View(userMeasurement);
        }

        // GET: UserMeasurements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMeasurement = await _context.UserMeasurement.FindAsync(id);
            if (userMeasurement == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Set<REDarUser>(), "Id", "Id", userMeasurement.UserId);
            return View(userMeasurement);
        }

        // POST: UserMeasurements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,type,val,TimeStamp")] UserMeasurement userMeasurement)
        {
            if (id != userMeasurement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userMeasurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserMeasurementExists(userMeasurement.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<REDarUser>(), "Id", "Id", userMeasurement.UserId);
            return View(userMeasurement);
        }

        // GET: UserMeasurements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMeasurement = await _context.UserMeasurement
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userMeasurement == null)
            {
                return NotFound();
            }

            return View(userMeasurement);
        }

        // POST: UserMeasurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userMeasurement = await _context.UserMeasurement.FindAsync(id);
            _context.UserMeasurement.Remove(userMeasurement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserMeasurementExists(int id)
        {
            return _context.UserMeasurement.Any(e => e.Id == id);
        }
    }
}
