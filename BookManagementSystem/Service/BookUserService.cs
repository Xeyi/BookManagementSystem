using BookManagementSystem.Entities;
using BookManagementSystem.Repositories;

namespace BookManagementSystem.Service
{
    public class BookUserService : IBookUserService
    {
        IBookUserRepository _bookUserRepository;

        public BookUserService(IBookUserRepository bookUserRepository)
        {
            _bookUserRepository = bookUserRepository;
        }

        bool IBookUserService.AddRecord(int bookId, int userId)
        {
            return _bookUserRepository.AddRecord(bookId, userId);
        }

        IEnumerable<Book> IBookUserService.GetAllBooksByUserId(int userId)
        {
            return _bookUserRepository.FindAllBooksWithUserId(userId);
        }

        IEnumerable<User> IBookUserService.GetAllUsersByBookId(int bookId)
        {
            return _bookUserRepository.FindAllUsersWithBookId(bookId);
        }
    }
}
