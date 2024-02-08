using BookManagementSystem.Entities;
using BookManagementSystem.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystem
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<BookUser> bookUsers { get; set; }

        public Boolean AddBookUserRecord(BookUser bookUser)
        {

            bookUsers.Add(bookUser);
            SaveChanges();

            return true;
        }


        public IEnumerable<Book> FindAllBooksByUserId(int userId)
        {
            List<Book> target = bookUsers.Where(b => b.UserId == userId).Select(b => b.book).ToList();

            return target;
        }

        public IEnumerable<User> FindAllUsersByBookId(int bookId)
        {
            List<User> target = bookUsers.Where(u => u.BookId == bookId).Select(u => u.user).ToList();

            return target;
        }


        public int AddBookIfNotExist(Book book)
        {
            var existingBook = Books.FirstOrDefault(b => b.BookId == book.BookId);
            if (existingBook != null)
            {
                throw new ItemAlreadyExistException("Item Already Exist");
            }
            Books.Add(book);
            SaveChanges();
            return 1;
        }

        public int UpdateBook(Book book)
        {
            var existingBook = Books.FirstOrDefault(b => b.BookId == book.BookId);
            if (existingBook == null)
            {
                throw new ItemCouldNotFoundException("cannot find the book");
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.PublicationYear = book.PublicationYear;
            SaveChanges();
            return 1;
        }

        public int DeleteBook(int id)
        {
            var book = Books.FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                throw new ItemCouldNotFoundException("Cannot target the boook");
            }
            Books.Remove(book);
            SaveChanges();
            return 1;
        }

        public Book GetBookById(int id)
        {
            return Books.FirstOrDefault(b => b.BookId == id);
        }



        internal int AddUserIfNotExist(User user)
        {
            var existingUser = Users.FirstOrDefault(u => u.UserId == u.UserId);
            if (existingUser != null)
            {
                throw new ItemAlreadyExistException("User Already Exist");
            }
            Users.Add(user);
            SaveChanges();
            return 1;
        }

        internal int DeleteUser(int id)
        {
            var user = Users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                Users.Remove(user);
                SaveChanges();
                return 1;
            }
            return 0;
        }

        internal User GetUserById(int id)
        {
            return Users.FirstOrDefault(u => u.UserId == id);
        }

        internal int UpdateUser(User user)
        {

            var existingUser = Users.FirstOrDefault(u => u.UserId == u.UserId);
            if (existingUser == null)
            {
                throw new ItemCouldNotFoundException("Cannot find the user");
            }

            existingUser.Name = user.Name;
            existingUser.address = user.address;
            existingUser.Email = user.Email;

            SaveChanges();
            return 1;

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=bookmngmtsys;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookUser>().HasKey(bwu => new { bwu.BookId, bwu.UserId });

            modelBuilder.Entity<BookUser>()
                .HasOne(bu => bu.book)
                .WithMany()
                .HasForeignKey(bu => bu.BookId);

            modelBuilder.Entity<BookUser>()
                .HasOne(bu => bu.user)
                .WithMany()
                .HasForeignKey(bu => bu.UserId);
            modelBuilder.Entity<Book>().HasKey(b => b.BookId);
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
        }
    }
}
