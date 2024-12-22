using bookstore.Entities;
using bookstore.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bookstore.SOAPService
{
    public class BookstoreService : IBookstoreService
    {
        private readonly IBookRepo _bookRepo;

        public BookstoreService(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public async Task<Book> AddBook(Book book)
        {
            return await _bookRepo.AddNewBook(book);
        }

       public async Task<List<Book>> GetAllBooks()
        {
            var books = await _bookRepo.GetAllBooks();
            return books.ToList(); 
        }
        public async Task<Book> GetBookById(int id)
        {
            return await _bookRepo.GetBookById(id);
        }

        public async Task<bool> UpdateBook(int id, Book updatedBook)
        {
            await _bookRepo.UpdateBook(id, updatedBook);
            return true;
        }

        public async Task<bool> DeleteBook(int id)
        {
            return await _bookRepo.DeleteBook(id);
        }
    }
}
