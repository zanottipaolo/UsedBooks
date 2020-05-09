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
using Microsoft.EntityFrameworkCore;

namespace libri_identity.Pages.BookingCRUD
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly libri_identity.Data.BookDbContext _context;

        [BindProperty]
        public Booking Booking { set; get; }

        //[BindProperty]
        public Book Book { set; get; }

        public CreateModel(libri_identity.Data.BookDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet(long? id_book)
        {
            if (id_book == null)
            {
                return NotFound();
            }

            Book = await _context.Book.FirstOrDefaultAsync(m => m.Id == id_book);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id_book)
        {
            if (id_book == null)
            {
                return NotFound();
            }

            Book = await _context.Book.FirstOrDefaultAsync(m => m.Id == id_book);

            if (Book == null)
            {
                return NotFound();
            }

            Booking.Start_Booking = DateTime.Now.ToString("dd/MM/yyyy");
            Booking.End_Booking = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy");
            Booking.Title = Book.Name;
            Booking.Isbn = Book.Isbn;
            Booking.Student = User.Identity.Name;
            Booking.Id_Book = id_book.Value;
            Book.State = 1;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
