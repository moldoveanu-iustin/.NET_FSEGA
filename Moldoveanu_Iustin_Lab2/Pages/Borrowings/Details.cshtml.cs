using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moldoveanu_Iustin_Lab2.Data;
using Moldoveanu_Iustin_Lab2.Models;

namespace Moldoveanu_Iustin_Lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Moldoveanu_Iustin_Lab2.Data.Moldoveanu_Iustin_Lab2Context _context;

        public DetailsModel(Moldoveanu_Iustin_Lab2.Data.Moldoveanu_Iustin_Lab2Context context)
        {
            _context = context;
        }

        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing
                // +++++++++++++++
                .Include (m => m.Member)
                .Include(b => b.Book)
                    .ThenInclude(a => a.Author)
                .Include(b => b.Book)
                    .ThenInclude(p => p.Publisher)
                .Include (b => b.Book)
                    .ThenInclude(c => c.BookCategories)
                // +++++++++++++++
                .FirstOrDefaultAsync(m => m.ID == id);

            if (borrowing == null)
            {
                return NotFound();
            }
            else
            {
                Borrowing = borrowing;
            }
            
            return Page();
        }
    }
}
