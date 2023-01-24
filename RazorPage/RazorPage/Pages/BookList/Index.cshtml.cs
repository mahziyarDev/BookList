using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage.Interfaceses;
using RazorPage.Models;
using RazorPage.Models.Context;
using RazorPage.Models.ViewModel;

namespace RazorPage.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly IBook _book;
        private readonly ApplicationDbContext _context;

        public IndexModel(IBook book, ApplicationDbContext context)
        {
            _book = book;
            _context = context;
        }

        public List<Book> Books { get; set; }
        public void OnGet()
        {
            Books =  _context.Books.ToList();
        }


        public async Task<IActionResult> OnGetDelete(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
                return NotFound();
            _context.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
