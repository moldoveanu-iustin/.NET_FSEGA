using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Moldoveanu_Iustin_Lab2.Data;
using Moldoveanu_Iustin_Lab2.Models;

namespace Moldoveanu_Iustin_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Moldoveanu_Iustin_Lab2.Data.Moldoveanu_Iustin_Lab2Context _context;

        public DetailsModel(Moldoveanu_Iustin_Lab2.Data.Moldoveanu_Iustin_Lab2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = new Book();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }
    }
}
