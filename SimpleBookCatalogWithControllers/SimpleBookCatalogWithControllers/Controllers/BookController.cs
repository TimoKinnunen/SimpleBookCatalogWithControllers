using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleBookCatalogWithControllers.Data;
using SimpleBookCatalogWithControllers.Shared.Entities;

namespace SimpleBookCatalogWithControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly DataContext context;

        public BookController(DataContext context)
        {
            this.context = context;
       }

        [HttpGet]
        public async Task<ActionResult<List<Book>?>> GetAllAsync()
        {
            var books = await context.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book?>> GetByIdAsync(int id)
        {
            var book = await context.Books.FindAsync(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(Book book)
        {
            context.Books.Add(book);
            await context.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteByIdAsync(int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book is not null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Book book)
        {
            context.Books.Update(book);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
