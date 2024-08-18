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
    public class StudentTblsController : Controller
    {
        private readonly SystemdbContext _context;

        public StudentTblsController(SystemdbContext context)
        {
            _context = context;
        }

        // GET: StudentTbls
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentTbl.ToListAsync());
        }

        // GET: StudentTbls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTbl = await _context.StudentTbl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentTbl == null)
            {
                return NotFound();
            }

            return View(studentTbl);
        }

        // GET: StudentTbls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentName,Emailaddress,Remark,CreateDate")] StudentTbl studentTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentTbl);
        }

        // GET: StudentTbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTbl = await _context.StudentTbl.FindAsync(id);
            if (studentTbl == null)
            {
                return NotFound();
            }
            return View(studentTbl);
        }

        // POST: StudentTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentName,Emailaddress,Remark,CreateDate")] StudentTbl studentTbl)
        {
            if (id != studentTbl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentTblExists(studentTbl.Id))
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
            return View(studentTbl);
        }

        // GET: StudentTbls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTbl = await _context.StudentTbl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentTbl == null)
            {
                return NotFound();
            }

            return View(studentTbl);
        }

        // POST: StudentTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentTbl = await _context.StudentTbl.FindAsync(id);
            if (studentTbl != null)
            {
                _context.StudentTbl.Remove(studentTbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentTblExists(int id)
        {
            return _context.StudentTbl.Any(e => e.Id == id);
        }
    }
}
