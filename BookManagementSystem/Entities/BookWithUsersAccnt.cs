using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementSystem.Entities
{
    [Table("BooksWithUsersCnt")]
    public class BookWithUsersAccnt
    {
        public int BookId { get; set; }
        public ICollection<int> UsersID { get; set; }
    }
}
