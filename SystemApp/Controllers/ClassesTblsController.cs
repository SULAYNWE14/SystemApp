using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SystemApp.Models;

namespace SystemApp.Controllers
{
    [Authorize]
    public class ClassesTblsController : Controller
    {
        private readonly SystemdbContext _context;

        public ClassesTblsController(SystemdbContext context)
        {
            _context = context;
        }

        // GET: ClassesTbls
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassesTbl.ToListAsync());
        }

        // GET: ClassesTbls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classesTbl = await _context.ClassesTbl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classesTbl == null)
            {
                return NotFound();
            }

            return View(classesTbl);
        }

        // GET: ClassesTbls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassesTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClassName,Description,Address,CreateDate")] ClassesTbl classesTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classesTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classesTbl);
        }

        // GET: ClassesTbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classesTbl = await _context.ClassesTbl.FindAsync(id);
            if (classesTbl == null)
            {
                return NotFound();
            }
            return View(classesTbl);
        }

        // POST: ClassesTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClassName,Description,Address,CreateDate")] ClassesTbl classesTbl)
        {
            if (id != classesTbl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classesTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassesTblExists(classesTbl.Id))
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
            return View(classesTbl);
        }

        // GET: ClassesTbls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classesTbl = await _context.ClassesTbl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classesTbl == null)
            {
                return NotFound();
            }

            return View(classesTbl);
        }

        // POST: ClassesTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classesTbl = await _context.ClassesTbl.FindAsync(id);
            if (classesTbl != null)
            {
                _context.ClassesTbl.Remove(classesTbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassesTblExists(int id)
        {
            return _context.ClassesTbl.Any(e => e.Id == id);
        }
    }
}
