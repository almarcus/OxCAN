using OxCAN.Shared.Models;

namespace OxCAN.Shared.Services;

public class ProjectService : IProjectService
{
    public IEnumerable<Project> Get()
    {
        return new List<Project>()
        {
            new Project{ Name = "Granville Greenways Master Plan", Link = "http://www.granvillegreenways.org/wp-content/uploads/2013/12/Granville-County-Greenway-Master-Plan-Final.pdf", Timeframe = "approximately 2012"},
            new Project{ Name = "Granville Greenways Publicity Video", Link = "https://youtu.be/PteO5HiY1Qc?t=171", Timeframe = "2011"},
            new Project{ Name = "City of Oxford Bicycle Plan", Link = "https://cms8.revize.com/revize/cityofoxford/Bicycle%20Plan.pdf", Timeframe = "the Winter of 2013"},
            new Project{ Name = "City of Oxford Pedestrian Plan", Link = "https://cms8.revize.com/revize/cityofoxford/Pedestrian%20Plan.pdf", Timeframe = "August of 2014"}
        };
    }
}