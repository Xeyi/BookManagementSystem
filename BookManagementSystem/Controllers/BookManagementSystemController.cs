using BookManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;
using BookManagementSystem.Entities;

namespace BookManagementSystem.Controllers
{
    [ApiController]
    [Route("[booksManagement]")]
    public class BookManagementSystemController : ControllerBase
    {
        private IBookService _bookService;
        /*private IUserService _userService;*/

        public BookManagementSystemController(IBookService bookService)
        {
            _bookService = bookService;
            /*_userService = userService;*/
        }

        [HttpGet("/books")]
        public IEnumerable<Book> GetAllBooks()
        {
            return _bookService.GetAllBooks();
        }

        [HttpGet("/books/{id}")]
        public Book GetBookById(int id)
        {
            return _bookService.GetBookById(id);
        }

        [HttpPost("/books/update")]
        public IActionResult UpdateBook([FromBody] Book book, [FromQuery] int id = -1)
        {
            int success = _bookService.AddOrUpdateBook(book,id);
            if(success == 0) {
                return BadRequest("Fail to update");
            }
            return Ok("Update successful");
        }


        [HttpGet("/books/delete")]
        public IActionResult DeleteBook([FromQuery] int id)
        {
            int result = _bookService.DeleteBook(id);

            if(result == 0)
            {
                return BadRequest("Fail to delete");
            }
            return Ok("Update successful");
        }

        /*[HttpGet("/booksWithUserCount")]
        public IEnumerable<BookWithUsersCount> GetAllBooksWithUserCount() {
            return _bookService.GetAllBooksWithUserCount();
        }*/
    }
}