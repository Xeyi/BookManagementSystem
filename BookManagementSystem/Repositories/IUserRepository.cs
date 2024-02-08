using BookManagementSystem.Entities;

namespace BookManagementSystem.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAllUsers();
        public User FindUserById(int id);

        public int AddUserIfNotExist(User user);

        public int UpdateUser(User user);

        public int DeleteUser(int id);
    }
}
