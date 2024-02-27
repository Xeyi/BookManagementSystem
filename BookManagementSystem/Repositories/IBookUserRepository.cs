using BookManagementSystem.Entities;

namespace BookManagementSystem.Repositories
{
    public interface IBookUserRepository
    {

        public IEnumerable<Book> FindAllBooksWithUserId(int userId);

        public int FindAllUsersWithBookId(int BookId);

        public Boolean AddRecord(int bookId, int userId);

        public List<BookWithReaderCount> FindAllBooksWithUsers();
    }
}
