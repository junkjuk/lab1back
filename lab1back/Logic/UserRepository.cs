using lab1back.Models;

namespace lab1back.Logic;

public class UserRepository : BaseStorage, IUserRepository
{
    public void DeleteUser(Guid id)
    {
        var existUser = GetUserById(id);
        if (existUser is null)
            return;

        _user.Remove(existUser);
    }

    public void AddUser(User user)
    {
        var existUser = GetUserById(user.Id);
        if (existUser is not null)
            return;

        _user.Add(user);
    }

    public User GetUserById(Guid id)
        => _user.FirstOrDefault(i => i.Id == id);

    public IEnumerable<User> GetAllUsers()
        => _user;
}