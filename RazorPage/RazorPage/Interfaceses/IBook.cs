using RazorPage.Models.ViewModel;
using RazorPage.Utilities;

namespace RazorPage.Interfaceses;

public interface IBook
{
    Task<OperationResult<List<IndexBookListViewModel>>> GetIndex();
}