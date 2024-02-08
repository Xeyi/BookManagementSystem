using BookManagementSystem.Entities;
using BookManagementSystem.Repositories;

namespace BookManagementSystem.Implement
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext _dbContext;
        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        int IUserRepository.AddUserIfNotExist(User user)
        {
            return _dbContext.AddUserIfNotExist(user);
        }

        int IUserRepository.DeleteUser(int id)
        {
            return _dbContext.DeleteUser(id);
        }

        User IUserRepository.FindUserById(int id)
        {
            return _dbContext.GetUserById(id);
        }

        IEnumerable<User> IUserRepository.GetAllUsers()
        {
            return (IEnumerable<User>)_dbContext.Users.ToList();
        }

        int IUserRepository.UpdateUser(User user)
        {
            try
            {
                _dbContext.UpdateUser(user);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
