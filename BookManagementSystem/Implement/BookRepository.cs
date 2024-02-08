using BookManagementSystem.Entities;
using BookManagementSystem.Repositories;

namespace BookManagementSystem.Implement
{
    public class BookRepository : IBookRepository
    {
        private DatabaseContext _dbContext;

        public BookRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        int IBookRepository.AddBookIfNotExist(Book book)
        {
            return _dbContext.AddBookIfNotExist(book);
        }

        int IBookRepository.DeleteBook(int id)
        {
            return _dbContext.DeleteBook(id);
        }

       /* IEnumerable<BookWithUsersCount> IBookRepository.FindAllBooksWithUsersCount()
        {
            return (IEnumerable<BookWithUsersCount>)_dbContext.BooksWithUsersCount.ToList();
        }*/

        Book IBookRepository.FindBookById(int id)
        {
            return _dbContext.GetBookById(id);
        }

        /*BookWithUsersCount IBookRepository.FindBookWithUserCount(int id)
        {
            throw new NotImplementedException();
        }*/

        IEnumerable<Book> IBookRepository.GetAllBooks()
        {
            return (IEnumerable<Book>)_dbContext.Books.ToList();
        }

        int IBookRepository.UpdateBook(Book book)
        {
            try
            {
                _dbContext.UpdateBook(book);
            }catch(Exception ex)
            {
                return 0;
            }
            return 1;
        }
    }
}
