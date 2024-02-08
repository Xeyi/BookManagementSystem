using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementSystem.Entities
{
    [Table("Users")]
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string address {  get; set; }

    }
}
