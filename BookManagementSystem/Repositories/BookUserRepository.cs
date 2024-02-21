using BookManagementSystem.Entities;
using BookManagementSystem.Service;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;

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

        List<object> IBookUserRepository.FindAllBooksWithUsers()
        {
            var query = from book in _dbContext.Books
                        join buser in _dbContext.bookUsers on book.BookId equals buser.BookId into gj
                        from subBU in gj.DefaultIfEmpty()
                        group new { book, subBU } by book.BookId into g
                        
                        select new
                        {
                            BookName = g.FirstOrDefault().book.Title,
                            NoOfReaders = g.Select(gr => gr.subBU.UserId).Distinct().Count()
                        };

            return query.ToList<object>();

        }

        int IBookUserRepository.FindAllUsersWithBookId(int BookId)
        {
            return _dbContext.FindAllUsersByBookId(BookId);
        }
    }
}
