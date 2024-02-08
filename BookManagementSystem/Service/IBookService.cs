using BookManagementSystem.Entities;

namespace BookManagementSystem.Service
{
    public interface IBookService
    {
        public IEnumerable<Book> GetAllBooks();
        public Book GetBookById(int id);
        public int UpdateBook(Book book);
        public int DeleteBook(int id);

        public int AddBook(Book book);
    }
}
