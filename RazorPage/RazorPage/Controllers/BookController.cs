using Microsoft.AspNetCore.Mvc;
using RazorPage.Models.Context;

namespace RazorPage.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {

        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Books.ToList() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _db.Books.FindAsync(id);
            if (book == null)
                return Json(new { success = false, message = "not found data" });
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete SuccessFully" });
        }
    }
}
