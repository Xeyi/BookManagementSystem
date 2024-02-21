using BookManagementSystem.Entities;
using BookManagementSystem.Repositories;

namespace BookManagementSystem.Service
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        int IBookService.UpdateBook(Book book)
        {
            try
            {
                _bookRepository.UpdateBook(book);
            }
            catch (Exception ex)
            {
                return 0;
            }

            return 1;

        }

        int IBookService.AddBook(Book book)
        {
            
            _bookRepository.AddBookIfNotExist(book);
            

            return 1;

        }

        int IBookService.DeleteBook(int id)
        {
            int ActionResult;
            try
            {
                ActionResult = _bookRepository.DeleteBook(id);
            }
            catch (Exception ex)
            {
                return 0;
            }
            return ActionResult;
        }

        IEnumerable<Book> IBookService.GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        Book IBookService.GetBookById(int id)
        {
            return _bookRepository.FindBookById(id);
        }



    }
}
