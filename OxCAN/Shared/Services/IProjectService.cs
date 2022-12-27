using OxCAN.Shared.Models;

namespace OxCAN.Shared.Services;

public interface IProjectService
{
    IEnumerable<Project> Get();
}