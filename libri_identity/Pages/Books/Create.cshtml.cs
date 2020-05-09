using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using libri_identity.Data;
using libri_identity.Models;
using Microsoft.AspNetCore.Authorization;

namespace libri_identity.Pages.Books
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly libri_identity.Data.BookDbContext _context;

        [BindProperty]
        public Book Book { get; set; }

        public CreateModel(libri_identity.Data.BookDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Book.Name_Student = User.Identity.Name;
            Book.State = 0;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
