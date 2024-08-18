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
    public class TeacherTblsController : Controller
    {
        private readonly SystemdbContext _context;

        public TeacherTblsController(SystemdbContext context)
        {
            _context = context;
        }

        // GET: TeacherTbls
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeacherTbl.ToListAsync());
        }

        // GET: TeacherTbls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherTbl = await _context.TeacherTbl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherTbl == null)
            {
                return NotFound();
            }

            return View(teacherTbl);
        }

        // GET: TeacherTbls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeacherTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Phone,CreateDate")] TeacherTbl teacherTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacherTbl);
        }

        // GET: TeacherTbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherTbl = await _context.TeacherTbl.FindAsync(id);
            if (teacherTbl == null)
            {
                return NotFound();
            }
            return View(teacherTbl);
        }

        // POST: TeacherTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Phone,CreateDate")] TeacherTbl teacherTbl)
        {
            if (id != teacherTbl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherTblExists(teacherTbl.Id))
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
            return View(teacherTbl);
        }

        // GET: TeacherTbls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherTbl = await _context.TeacherTbl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherTbl == null)
            {
                return NotFound();
            }

            return View(teacherTbl);
        }

        // POST: TeacherTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherTbl = await _context.TeacherTbl.FindAsync(id);
            if (teacherTbl != null)
            {
                _context.TeacherTbl.Remove(teacherTbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherTblExists(int id)
        {
            return _context.TeacherTbl.Any(e => e.Id == id);
        }
    }
}
