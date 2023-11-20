using lab1back.Models;

namespace lab1back.Logic;

public interface IUserRepository
{
    void DeleteUser(Guid id);
    void AddUser(User user);
    User GetUserById(Guid id);
    IEnumerable<User> GetAllUsers();
}