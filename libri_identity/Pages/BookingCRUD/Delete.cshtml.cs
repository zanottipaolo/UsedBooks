using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using libri_identity.Data;
using libri_identity.Models;
using Microsoft.AspNetCore.Authorization;

namespace libri_identity.Pages.BookingCRUD
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly libri_identity.Data.BookDbContext _context;

        public DeleteModel(libri_identity.Data.BookDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id_search)
        {
            if (id_search == null)
            {
                return NotFound();
            }

            Booking = await _context.Booking.FirstOrDefaultAsync(m => m.Id_Booking == id_search);

            if (Booking == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id_search)
        {
            if (id_search == null)
            {
                return NotFound();
            }

            Booking = await _context.Booking.FindAsync(id_search);

            if (Booking != null)
            {
                Book = await _context.Book.FirstOrDefaultAsync(m => m.Id == Booking.Id_Book);

                if (Book == null)
                {
                    return NotFound();
                }
                Book.State = 0;

                _context.Booking.Remove(Booking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
