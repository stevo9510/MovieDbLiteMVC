﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public UsersController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,EmailAddress,HashedPassword")] User user)
        {
            if (ModelState.IsValid)
            {
                user.HashedPassword = HashUsersPassword(user.HashedPassword);

                // Set all users added via this form to user role.  Admins must be added via database.
                user.UserRoleId = (int)DbEnum.UserRole.User;

                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            // clear it out so that they can re-enter
            user.HashedPassword = string.Empty;

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,EmailAddress,HashedPassword")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (await _context.User.AnyAsync(u => u.Id == id && u.UserName != user.UserName))
                    {
                        throw new InvalidOperationException("User name cannot be changed");
                    }

                    user.HashedPassword = HashUsersPassword(user.HashedPassword);

                    // Set all users added via this form to user role.  Admins must be added via database.
                    user.UserRoleId = (int)DbEnum.UserRole.User;

                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private static string HashUsersPassword(string unhashedPassword)
        {
            const int workFactor = 15;
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(unhashedPassword, workFactor);
            return hashedPassword;
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
