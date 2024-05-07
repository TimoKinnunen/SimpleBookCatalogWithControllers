using Microsoft.EntityFrameworkCore;
using SimpleBookCatalogWithControllers.Data;
using SimpleBookCatalogWithControllers.Shared.Entities;
using SimpleBookCatalogWithControllers.Shared.Interfaces;

namespace SimpleBookCatalogWithControllers.ServerServices
{
    public class BookService : IBookService
    {
        private readonly DataContext context;

        public BookService(DataContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Book book)
        {
            context.Books.Add(book);
            await context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var book = await GetByIdAsync(id);
            if (book is not null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Book>?> GetAllAsync()
        {
            var books = await context.Books.ToListAsync();
            return books;
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            var book = await context.Books.FindAsync(id);
            return book;
        }

        public async Task UpdateAsync(Book book)
        {
            context.Books.Update(book);
            await context.SaveChangesAsync();
        }
    }
}
