using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPage.Models;
using RazorPage.Models.Context;

namespace RazorPage.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }


        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Books.Add(Book);
                _db.SaveChanges();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
            
        }
    }

}
