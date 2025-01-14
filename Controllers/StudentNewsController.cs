﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFirstWebApp.Models;

namespace MyFirstWebApp.Controllers
{
    public class StudentNewsController : Controller
    {
        private readonly MajuContext _context;

        public StudentNewsController(MajuContext context)
        {
            _context = context;
        }

        // GET: StudentNews
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentNews.ToListAsync());
        }

        // GET: StudentNews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentNew = await _context.StudentNews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentNew == null)
            {
                return NotFound();
            }

            return View(studentNew);
        }

        // GET: StudentNews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentNews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Semester,Age,Contact")] StudentNew studentNew)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentNew);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentNew);
        }

        // GET: StudentNews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentNew = await _context.StudentNews.FindAsync(id);
            if (studentNew == null)
            {
                return NotFound();
            }
            return View(studentNew);
        }

        // POST: StudentNews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Semester,Age,Contact")] StudentNew studentNew)
        {
            if (id != studentNew.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentNew);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentNewExists(studentNew.Id))
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
            return View(studentNew);
        }

        // GET: StudentNews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentNew = await _context.StudentNews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentNew == null)
            {
                return NotFound();
            }

            return View(studentNew);
        }

        // POST: StudentNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentNew = await _context.StudentNews.FindAsync(id);
            if (studentNew != null)
            {
                _context.StudentNews.Remove(studentNew);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentNewExists(int id)
        {
            return _context.StudentNews.Any(e => e.Id == id);
        }
    }
}
