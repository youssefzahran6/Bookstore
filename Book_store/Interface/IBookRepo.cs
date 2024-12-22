using bookstore.Entities;

namespace bookstore.Interface
{
    public interface IBookRepo
    {
        Task<Book> AddNewBook(Book book);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book?> GetBookById(int id);
        Task<bool> DeleteBook(int id);
        Task UpdateBook(int id, Book updatedBook);
    }
}