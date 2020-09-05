using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Model;

namespace WebApplication1.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db; 
        }

        [BindProperty]
        public Book book { get; set; }

        [TempData]
        public string Message { get; set; }
        public void OnGet(int id)
        {
            book = _db.Books.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var BookFromDb = _db.Books.Find(book.Id);
                BookFromDb.Name = book.Name;
                BookFromDb.ISBN= book.ISBN;
                BookFromDb.Author = book.Author;

                await _db.SaveChangesAsync();
                Message = "Book has been updated successfully.";

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
