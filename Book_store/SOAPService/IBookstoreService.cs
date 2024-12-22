using System.ServiceModel;
using bookstore.Entities;

namespace bookstore.SOAPService
{
    [ServiceContract]
    public interface IBookstoreService
    {
        [OperationContract]
        Task<Book> AddBook(Book book);

        [OperationContract]
        Task<List<Book>> GetAllBooks();

        [OperationContract]
        Task<Book> GetBookById(int id);

        [OperationContract]
        Task<bool> UpdateBook(int id, Book updatedBook);

        [OperationContract]
        Task<bool> DeleteBook(int id);
    }
}
