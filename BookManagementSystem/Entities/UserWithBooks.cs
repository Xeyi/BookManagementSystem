using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementSystem.Entities
{
    [Table("UserWithBooks")]
    public class UserWithBooks
    {
        public int UserId;
        public ICollection<int> BooksId;
    }
}
