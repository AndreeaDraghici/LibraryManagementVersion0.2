using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationFinal.Data;
using WebApplicationFinal.Models;

namespace WebApplicationFinal.Controllers
{
    public class AuthorBooksController : Controller
    {
        private readonly LibraryWebDBContext _context;

        public AuthorBooksController(LibraryWebDBContext context)
        {
            _context = context;
        }

        // GET: AuthorBooks
        public async Task<IActionResult> Index()
        {
              return _context.AuthorBooks != null ? 
                          View(await _context.AuthorBooks.ToListAsync()) :
                          Problem("Entity set 'LibraryWebDBContext.AuthorBooks'  is null.");
        }

        // GET: AuthorBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AuthorBooks == null)
            {
                return NotFound();
            }

            var authorBook = await _context.AuthorBooks
                .FirstOrDefaultAsync(m => m.id == id);
            if (authorBook == null)
            {
                return NotFound();
            }

            return View(authorBook);
        }

        // GET: AuthorBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AuthorBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,author_id,book_id")] AuthorBook authorBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authorBook);
        }

        // GET: AuthorBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AuthorBooks == null)
            {
                return NotFound();
            }

            var authorBook = await _context.AuthorBooks.FindAsync(id);
            if (authorBook == null)
            {
                return NotFound();
            }
            return View(authorBook);
        }

        // POST: AuthorBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,author_id,book_id")] AuthorBook authorBook)
        {
            if (id != authorBook.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorBookExists(authorBook.id))
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
            return View(authorBook);
        }

        // GET: AuthorBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AuthorBooks == null)
            {
                return NotFound();
            }

            var authorBook = await _context.AuthorBooks
                .FirstOrDefaultAsync(m => m.id == id);
            if (authorBook == null)
            {
                return NotFound();
            }

            return View(authorBook);
        }

        // POST: AuthorBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AuthorBooks == null)
            {
                return Problem("Entity set 'LibraryWebDBContext.AuthorBooks'  is null.");
            }
            var authorBook = await _context.AuthorBooks.FindAsync(id);
            if (authorBook != null)
            {
                _context.AuthorBooks.Remove(authorBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorBookExists(int id)
        {
          return (_context.AuthorBooks?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
