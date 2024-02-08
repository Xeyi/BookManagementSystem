using BookManagementSystem.Entities;

namespace BookManagementSystem.Service
{
    public interface IUserService
    {
        public IEnumerable<Book> GetPurchasedBooksByUserID(int id);
    }
}
