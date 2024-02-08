using BookManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace BookManagementSystem.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookWithUsersAccnt> BooksWithUsersCount { get; set; }

        public int AddBookIfNotExist(Book book)
        {
            var existingBook = Books.FirstOrDefault(b => b.BookId == book.BookId);
            if (existingBook == null)
            {
                Books.Add(book);
                SaveChanges();
                return 1;
            }
            return 0;
        }

        public void UpdateBook(Book book)
        {
            Books.Update(book);
            SaveChanges();
        }

        public int DeleteBook(int id)
        {
            var book = Books.FirstOrDefault(b => b.BookId == id);
            if (book != null)
            {
                Books.Remove(book);
                SaveChanges();
                return 1;
            }
            return 0;
        }

        public Book GetBookById(int id)
        {
            return Books.FirstOrDefault(b => b.BookId == id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;port=3306;Database=bookmngmtsys;User=root;Password=888888;",
            new MariaDbServerVersion(new Version(8, 0, 36)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserWithBooks>().HasKey(uwb => uwb.UserId);
            modelBuilder.Entity<BookWithUsersAccnt>().HasKey(bwu => bwu.BookId);
            modelBuilder.Entity<Book>().HasKey(b => b.BookId);
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
        }
    
    }
}
