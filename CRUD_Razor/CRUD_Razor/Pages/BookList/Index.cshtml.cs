using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD_Razor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbcontext _db;
        public IEnumerable<Book> Books { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        //public IndexModel(ApplicationDbcontext db)
        //{
        //    _db = db;
        //}

        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }
        //public async Task OnGet()
        //{
        //    Books = await _db.Books.ToListAsync();
        //}
    }
}
