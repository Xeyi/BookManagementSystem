using BookManagementSystem.Entities;

namespace BookManagementSystem.Service
{
    public interface IBookService
    {
        public IEnumerable<Book> GetAllBooks();
        public Book GetBookById(int id);
        public int AddOrUpdateBook(Book book, int id);
        public int DeleteBook(int id);

        /*public IEnumerable<BookWithUsersCount> GetAllBooksWithUserCount();
        public BookWithUsersCount GetBookWithUserCount(int id);*/
    }
}
