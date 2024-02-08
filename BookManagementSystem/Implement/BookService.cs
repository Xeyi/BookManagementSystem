using BookManagementSystem.Entities;
using BookManagementSystem.Service;
using BookManagementSystem.Repositories;

namespace BookManagementSystem.Implement
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        int IBookService.AddOrUpdateBook(Book book, int id)
        {
            try
            {
                if (id == -1)
                {
                    _bookRepository.AddBookIfNotExist(book);
                }
                else
                {
                    _bookRepository.UpdateBook(book);
                }
            }catch(Exception ex)
            {
                return 0;
            }

            return 1;
            
        }

        int IBookService.DeleteBook(int id)
        {
            try
            {
                _bookRepository.DeleteBook(id);
            }catch(Exception ex)
            {
                return 0;
            }
            return 1;
        }

        IEnumerable<Book> IBookService.GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        /*IEnumerable<BookWithUsersCount> IBookService.GetAllBooksWithUserCount()
        {
            return _bookRepository.FindAllBooksWithUsersCount();
        }*/

        Book IBookService.GetBookById(int id)
        {
            return _bookRepository.FindBookById(id);
        }

        /*BookWithUsersCount IBookService.GetBookWithUserCount(int id)
        {
            return _bookRepository.FindBookWithUserCount(id);
        }*/

    }
}
