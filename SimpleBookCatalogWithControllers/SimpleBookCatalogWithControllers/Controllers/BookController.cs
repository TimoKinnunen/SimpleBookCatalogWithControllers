using Microsoft.AspNetCore.Mvc;
using SimpleBookCatalogWithControllers.Shared.Entities;
using SimpleBookCatalogWithControllers.Shared.Interfaces;

namespace SimpleBookCatalogWithControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>?>> GetAllAsync()
        {
            var books = await bookService.GetAllAsync();
            return books;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book?>> GetByIdAsync(int id)
        {
            var book = await bookService.GetByIdAsync(id);
            return book;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(Book book)
        {
            await bookService.AddAsync(book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteByIdAsync(int id)
        {
            await bookService.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Book book)
        {
            await bookService.UpdateAsync(book);
            return Ok();
        }
    }
}
