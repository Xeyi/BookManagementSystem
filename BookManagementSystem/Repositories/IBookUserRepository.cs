using BookManagementSystem.Entities;

namespace BookManagementSystem.Repositories
{
    public interface IBookUserRepository
    {

        public IEnumerable<Book> FindAllBooksWithUserId(int userId);

        public IEnumerable<User> FindAllUsersWithBookId(int BookId);

        public Boolean AddRecord(int bookId, int userId);


    }
}
