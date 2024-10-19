using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moldoveanu_Iustin_Lab2.Data;
using Moldoveanu_Iustin_Lab2.Models;

namespace Moldoveanu_Iustin_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Moldoveanu_Iustin_Lab2.Data.Moldoveanu_Iustin_Lab2Context _context;

        public CreateModel(Moldoveanu_Iustin_Lab2.Data.Moldoveanu_Iustin_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            try
            {
                ViewData["Title"] = "Create";
                ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
                ViewData["AuthorsList"] = new SelectList(_context.Authors, "Id", "FirstName");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OnGet: {ex.Message}");
                ViewData["ErrorMessage"] = ex.Message;
            }

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = new Book();

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
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
