using bookstore.Entities;
using bookstore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.EndPoint
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo _bookRepo;

        public BookController(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpPost("AddNewBook")]
        public async Task<IActionResult> AddNewBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest(new { message = "Invalid book data provided." });
            }

            try
            {
                var addedBook = await _bookRepo.AddNewBook(book);
                return CreatedAtAction(nameof(GetBookById), new { id = addedBook.Id }, addedBook);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepo.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("GetBookById/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepo.GetBookById(id);

            if (book == null)
            {
                return NotFound(new { message = "Book not found with the provided ID." });
            }

            return Ok(book);
        }

        [HttpPut("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book updatedBook)
        {
            try
            {
                await _bookRepo.UpdateBook(id, updatedBook);
                return Ok(new { message = "Book updated successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookRepo.DeleteBook(id);

            if (!result)
            {
                return NotFound(new { message = "Book not found with the provided ID." });
            }

            return Ok(new { message = "Book deleted successfully." });
        }
    }
}