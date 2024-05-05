using SimpleBookCatalogWithControllers.Shared.Entities;

namespace SimpleBookCatalogWithControllers.Shared.Interfaces
{
    public interface IBookService
    {
        Task AddAsync(Book book);
        Task<List<Book>?> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task UpdateAsync(Book book);
        Task DeleteByIdAsync(int id);
    }
}
