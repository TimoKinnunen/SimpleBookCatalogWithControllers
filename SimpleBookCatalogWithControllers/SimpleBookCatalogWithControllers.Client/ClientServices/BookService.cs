using SimpleBookCatalogWithControllers.Shared.Entities;
using SimpleBookCatalogWithControllers.Shared.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace SimpleBookCatalogWithControllers.Client.ClientServices
{
    public class BookService : IBookService
    {
        private readonly HttpClient httpClient;

        public BookService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Book>?> GetAllAsync()
        {
            var response = await httpClient.GetAsync($"api/book");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var books = JsonSerializer.Deserialize<List<Book>>(content);
                return books;
            }
            else
            {
                return null;
            }
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            var response = await httpClient.GetAsync($"api/book/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var book = JsonSerializer.Deserialize<Book>(content);
                return book;
            }
            else
            {
                return null;
            }
        }

        public async Task AddAsync(Book book)
        {
            var response = await httpClient.PostAsJsonAsync("api/book", book);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(Book book)
        {
            var response = await httpClient.PutAsJsonAsync($"api/book", book);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteByIdAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"api/book/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
