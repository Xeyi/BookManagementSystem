using BookManagementSystem.Entities;

namespace BookManagementSystem.Repositories
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

        Book IBookRepository.FindBookById(int id)
        {
            return _dbContext.GetBookById(id);
        }

        IEnumerable<Book> IBookRepository.GetAllBooks()
        {
            return _dbContext.Books.ToList();
        }

        int IBookRepository.UpdateBook(Book book)
        {
            try
            {
                _dbContext.UpdateBook(book);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
