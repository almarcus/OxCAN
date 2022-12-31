using OxCAN.Shared.Models;

namespace OxCAN.Shared.Services;

public interface IUserService
{
    User Get(string userid);
}