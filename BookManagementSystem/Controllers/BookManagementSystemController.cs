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
        private IUserService _userService;
        private IBookUserService _bookUserService;

        public BookManagementSystemController(IBookService bookService, IUserService userService, IBookUserService bookUserService)
        {
            _bookService = bookService;
            _userService = userService;
            _bookUserService = bookUserService;
        }

        [HttpGet("/books")]
        public IEnumerable<Book> GetAllBooks()
        {
            return _bookService.GetAllBooks();
        }

        [HttpGet("/books/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) return BadRequest("Cannot find the book");
            return new JsonResult(book);
        }

        [HttpPost("/books/update")]
        public IActionResult UpdateBook([FromBody] Book book)
        {
            int success = _bookService.UpdateBook(book);
            if(success == 0) {
                return BadRequest("Fail to update");
            }
            return Ok("Update successful");
        }

        [HttpPost("/books/add")]
        public IActionResult AddBook([FromBody] Book book)
        {
            try
            {
                int success = _bookService.AddBook(book);
            }catch(Exception ex)
            {
                return BadRequest($"{ex.Message}");
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

        [HttpGet("/users")]
        public IEnumerable<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("/users/{id}")]
        public IActionResult GetUsersById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return BadRequest("Cannot find the user");
            return new JsonResult(user);
        }

        [HttpPost("/users/update")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            try
            {
                int success = _userService.UpdateUser(user);
                
                return Ok("Update successful");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/users/add")]
        public IActionResult AddUser([FromBody] User user)
        {
            try
            {
                int success = _userService.AddUser(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }


            return Ok("Update successful");
        }




        [HttpGet("/users/delete")]
        public IActionResult DeleteUser([FromQuery] int id)
        {
            int result = _userService.DeleteUser(id);

            if (result == 0)
            {
                return BadRequest("Fail to delete");
            }
            return Ok("Update successful");
        }

        [HttpGet("/bookUsers/GetAllUsersBy{id}")]
        public IActionResult GetAllUsersByBookId( int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            var bookUser = new
            {
                BookName = _bookService.GetBookById(id).Title,
                NoOfReaders = _bookUserService.GetAllUsersByBookId(id)
            };
            return new JsonResult(bookUser);
        }

        [HttpGet("/bookUsers/GetAllBooksBy{id}")]
        public IEnumerable<Book> GetAllBooksByUserId( int id)
        {
            return _bookUserService.GetAllBooksByUserId(id);
        }

        [HttpPost("/bookUsers/addRecord")]
        public bool AddRecord(BookUser bookUser)
        {
            return _bookUserService.AddRecord(bookUser.BookId,bookUser.UserId);
        }

        [HttpGet("/bookUsers/GetAllBooksWithUsers")]
        public IActionResult GetAllBooksWithUseres()
        {
            return new JsonResult(_bookUserService.GetAllBooksWithUsers());
        }
    }
}