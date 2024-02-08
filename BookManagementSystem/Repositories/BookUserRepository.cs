using BookManagementSystem.Entities;

namespace BookManagementSystem.Repositories
{
    public class BookUserRepository : IBookUserRepository
    {
        DatabaseContext _dbContext;

        public BookUserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        bool IBookUserRepository.AddRecord(int bookId, int userId)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.BookId == bookId);
            var user = _dbContext.Users.FirstOrDefault(u => u.UserId == userId);

            _dbContext.AddBookUserRecord(new BookUser
            {
                BookId = bookId,
                UserId = userId,
                book = book,
                user = user
            });

            return true;
        }



        IEnumerable<Book> IBookUserRepository.FindAllBooksWithUserId(int userId)
        {
            return _dbContext.FindAllBooksByUserId(userId);
        }

        IEnumerable<User> IBookUserRepository.FindAllUsersWithBookId(int BookId)
        {
            return _dbContext.FindAllUsersByBookId(BookId);
        }
    }
}
