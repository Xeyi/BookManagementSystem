using BookManagementSystem.Entities;
using BookManagementSystem.Repositories;
using BookManagementSystem.Service;

namespace BookManagementSystem.Implement
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        int IUserService.AddOrUpdateUser(User user, int id)
        {
            Console.WriteLine(id);
            try
            {
                if (id != -1)
                {
                    _userRepository.AddUserIfNotExist(user);
                }
                else
                {
                    _userRepository.UpdateUser(user);
                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
            
        }

        int IUserService.DeleteUser(int id)
        {
            int ActionResult;
            try
            {
                ActionResult = _userRepository.DeleteUser(id);
            }
            catch (Exception ex)
            {
                return 0;
            }
            return ActionResult;
        }

        IEnumerable<User> IUserService.GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        User IUserService.GetUserById(int id)
        {
            return _userRepository.FindUserById(id);
        }
    }
}
