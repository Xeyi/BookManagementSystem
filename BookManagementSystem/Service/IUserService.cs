using BookManagementSystem.Entities;

namespace BookManagementSystem.Service
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUserById(int id);
        public int AddOrUpdateUser(User user, int id);
        public int DeleteUser(int id);
    }
}
