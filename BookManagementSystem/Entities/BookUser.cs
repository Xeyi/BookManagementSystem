using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementSystem.Entities
{
    [Table("BookUsers")]
    public class BookUser
    {
        public int BookId { get; set; }
        public Book book { get; set; }
        public int UserId {  get; set; }
        public User user { get; set; }
    }
}
