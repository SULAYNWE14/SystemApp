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
    public class AccountUsersController : Controller
    {
        private readonly SystemdbContext _context;

        public AccountUsersController(SystemdbContext context)
        {
            _context = context;
        }

        // GET: AccountUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountUsers.ToListAsync());
        }

        // GET: AccountUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountUser = await _context.AccountUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountUser == null)
            {
                return NotFound();
            }

            return View(accountUser);
        }

        // GET: AccountUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password,MailAddress,Phone,CreateDate")] AccountUser accountUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountUser);
        }

        // GET: AccountUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountUser = await _context.AccountUsers.FindAsync(id);
            if (accountUser == null)
            {
                return NotFound();
            }
            return View(accountUser);
        }

        // POST: AccountUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Password,MailAddress,Phone,CreateDate")] AccountUser accountUser)
        {
            if (id != accountUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountUserExists(accountUser.Id))
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
            return View(accountUser);
        }

        // GET: AccountUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountUser = await _context.AccountUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountUser == null)
            {
                return NotFound();
            }

            return View(accountUser);
        }

        // POST: AccountUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountUser = await _context.AccountUsers.FindAsync(id);
            if (accountUser != null)
            {
                _context.AccountUsers.Remove(accountUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountUserExists(int id)
        {
            return _context.AccountUsers.Any(e => e.Id == id);
        }
    }
}
