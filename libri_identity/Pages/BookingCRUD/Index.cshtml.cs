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
    public class IndexModel : PageModel
    {
        private readonly libri_identity.Data.BookDbContext _context;

        public IndexModel(libri_identity.Data.BookDbContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; }

        public async Task OnGetAsync()
        {
            Booking = await _context.Booking.ToListAsync();
        }
    }
}
