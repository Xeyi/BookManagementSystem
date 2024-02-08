using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementSystem.Entities
{
    [Table("Books")]
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }

    }
}
