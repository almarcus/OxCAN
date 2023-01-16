using MongoDB.Driver;
using OxCAN.Shared.Models;
using OxCAN.Shared.Repositories;

namespace OxCAN.Shared.Services;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User Get(string userid)
    {
        return _userRepository.Get(userid);
    }

    public User Add(User user)
    {
        if(Get(user.UserID) == null)
        {
            _userRepository.Add(user);
            return _userRepository.Get(user.UserID);
        }
        else
            throw new ArgumentException("User already exists");
    }
}