using BookManagementSystem.Entities;

namespace BookManagementSystem.Repositories
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAllBooks();
        public Book FindBookById(int id);

        public int AddBookIfNotExist(Book book);

        public int UpdateBook(Book book);

        public int DeleteBook(int id);

    }
}
