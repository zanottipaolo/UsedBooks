using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using libri_identity.Data;
using libri_identity.Models;

namespace libri_identity.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly libri_identity.Data.BookDbContext _context;

        [BindProperty]
        public string Course_filter { set; get; }
        [BindProperty]
        public string Class_filter { set; get; }
        [BindProperty]
        public string Subject_filter { set; get; }
        [BindProperty]
        public string Student_filter { set; get; }

        public IndexModel(libri_identity.Data.BookDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(string Course_filter, string Class_filter, string Subject_filter, string Student_filter)
        {
            var Book_search = await _context.Book.ToListAsync();

            if (Course_filter == null && Class_filter == null && Subject_filter == null && Student_filter == null)
                Book_search = await _context.Book.ToListAsync(); ;
            if (Course_filter != null)
                Book_search = Book_search.Where(m => m.Course.ToLower() == Course_filter.ToLower()).ToList();
            if (Class_filter != null)
                Book_search = Book_search.Where(m => m.Class.ToLower() == Class_filter.ToLower()).ToList();
            if (Subject_filter != null)
                Book_search = Book_search.Where(m => m.Subject.ToLower() == Subject_filter.ToLower()).ToList();
            if (Student_filter != null)
                Book_search = Book_search.Where(m => m.Name_Student.ToLower() == Student_filter.ToLower()).ToList();

            Book = Book_search;

            return Page();
        }
    }
}
