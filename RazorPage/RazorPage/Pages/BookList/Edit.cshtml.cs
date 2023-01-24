using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPage.Models;
using RazorPage.Models.Context;

namespace RazorPage.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet(int id)
        {
            var book = _db.Books.FirstOrDefault(m => m.Id == id);
            if (book != null)
                Book = book;
            
        }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Update(Book);
                _db.SaveChanges();
                return RedirectToPage("Index");
            }
            else
                return Page();
        }
    }
}
