using BookManagementSystem.Entities;

namespace BookManagementSystem.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<Book> FindPurchasedBooksByUserID(int id);
    }
}
