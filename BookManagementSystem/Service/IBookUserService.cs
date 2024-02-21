using BookManagementSystem.Entities;

namespace BookManagementSystem.Service
{
    public interface IBookUserService
    {
        public IEnumerable<Book> GetAllBooksByUserId(int  userId);

        public int GetAllUsersByBookId(int bookId);

        public Boolean AddRecord(int bookId, int userId);

        public List<object> GetAllBooksWithUsers();

    }
}
