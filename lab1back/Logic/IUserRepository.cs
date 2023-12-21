using Entities;
using lab1back.Models;

namespace lab1back.Logic;

public interface IUserRepository
{
    Task DeleteUser(Guid id);
    Task AddUser(User user);
    Task<User> GetUserById(Guid id);
    Task<IEnumerable<User>> GetAllUsers();
}