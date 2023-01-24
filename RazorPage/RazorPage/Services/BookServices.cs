using Microsoft.EntityFrameworkCore;
using RazorPage.Interfaceses;
using RazorPage.Models.Context;
using RazorPage.Models.ViewModel;
using RazorPage.Utilities;

namespace RazorPage.Services;

public class BookServices : IBook
{
    private readonly ApplicationDbContext _db;

    public BookServices(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<OperationResult<List<IndexBookListViewModel>>> GetIndex()
    {
        List<IndexBookListViewModel> viewModel = new List<IndexBookListViewModel>();

         viewModel= await _db.Books.OrderByDescending(m => m.CreateData).Select(m => new
            IndexBookListViewModel
            {
                AuthorName = m.Author,
                Name = m.Name
            }).ToListAsync();

         return new OperationResult<List<IndexBookListViewModel>>("", true, "", viewModel);
    }
}