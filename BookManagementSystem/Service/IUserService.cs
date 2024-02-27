using BookManagementSystem.Entities;

namespace BookManagementSystem.Service
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUserById(int id);
        public int UpdateUser(User user);
        public int DeleteUser(int id);

        public int AddUser(User user);
    }
}
