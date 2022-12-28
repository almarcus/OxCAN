using OxCAN.Shared.Models;

namespace OxCAN.Shared.Services;

public class ProjectService : IProjectService
{
    private readonly List<Project> allProjects = new List<Project>()
    {
        new Project{ Name = "Granville Greenways Master Plan", Link = "http://www.granvillegreenways.org/wp-content/uploads/2013/12/Granville-County-Greenway-Master-Plan-Final.pdf", Timeframe = "approximately 2012", ProjectStatus=Project.Status.Past},
        new Project{ Name = "Granville Greenways Publicity Video", Link = "https://youtu.be/PteO5HiY1Qc?t=171", Timeframe = "2011", ProjectStatus=Project.Status.Past},
        new Project{ Name = "City of Oxford Bicycle Plan", Link = "https://cms8.revize.com/revize/cityofoxford/Bicycle%20Plan.pdf", Timeframe = "the Winter of 2013", ProjectStatus=Project.Status.Past},
        new Project{ Name = "City of Oxford Pedestrian Plan", Link = "https://cms8.revize.com/revize/cityofoxford/Pedestrian%20Plan.pdf", Timeframe = "August of 2014", ProjectStatus=Project.Status.Past},
        new Project{ Name = "Hix to Mary Potter Connector", Description= "This is the pilot project that we are currently working to get done, targeting the close of 2022 for a completion date.", ImageLink="~/images/hix-mary-connector.png", ProjectStatus=Project.Status.Future},
    };

    public IEnumerable<Project> Get(Project.Status status)
    {
        return allProjects.Where(x => x.ProjectStatus == status);
    }
}