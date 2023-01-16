using OxCAN.Shared.Models;

namespace OxCAN.Shared.Repositories;

public interface IUserRepository
{
    User Get(string userid);
}