using OxCAN.Shared.Models;

namespace OxCAN.Shared.Services;

public class ProjectService : IProjectService
{
    public IEnumerable<Project> Get()
    {
        return new List<Project>()
        {
            new Project{ Name = "Granville Greenways Master Plan", Link = "http://www.granvillegreenways.org/wp-content/uploads/2013/12/Granville-County-Greenway-Master-Plan-Final.pdf", Timeframe = "approximately 2012"}
        };
    }
}