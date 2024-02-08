namespace BookManagementSystem.Exceptions
{
    public class ItemCouldNotFoundException : Exception
    {
        public ItemCouldNotFoundException(string? message) : base(message)
        {
        }
    }
}
