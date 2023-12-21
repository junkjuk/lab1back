using DB;
using Entities;
using lab1back.Models;
using Microsoft.EntityFrameworkCore;
using AppContext = DB.AppContext;

namespace lab1back.Logic;

public class UserRepository : IUserRepository
{
    private readonly Repositories _repositories;

    public UserRepository(Repositories repositories)
    {
        _repositories = repositories;
    }

    public Task DeleteUser(Guid id)
        => _repositories.UserRepository.DeleteByIdAsync(id);
    
    public async Task AddUser(User user)
    => await _repositories.UserRepository.AddAsync(user);
    
    public Task<User> GetUserById(Guid id)
        => _repositories.UserRepository.GetByIdAsync(id);

    public async Task<IEnumerable<User>> GetAllUsers()
        => await _repositories.UserRepository.GetAllAsync();
}