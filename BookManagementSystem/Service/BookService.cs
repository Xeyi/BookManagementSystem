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
            try
            {
                _bookRepository.AddBookIfNotExist(new Book
                {
                    BookId = 0,
                    Title = book.Title,
                    Author = book.Author,
                    PublicationYear = book.PublicationYear,
                });
            }
            catch (Exception ex)
            {
                return 0;
            }

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
