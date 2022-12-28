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
        new Project{ Name = "Hix to Mary Potter Connector", Description= "This is the pilot project that we are currently working to get done, targeting the close of 2022 for a completion date.", ImageLink="images/hix-mary-connector.png", Link="https://oxfordcan.org/wp-content/uploads/2022/11/OrangeStreet.pdf", ProjectStatus=Project.Status.Future},
        new Project{ Name = "Wilmington Avenue Connector", Description= "This connector is already partially maintained by the City, and could easily connect residents east of Martin Luther King, Jr. Ave to sidewalks, and prevent dangerous foot crossings between Easy Street and Industry Drive.", ImageLink="images/wilmington-avenue-connector.png", ProjectStatus=Project.Status.Future},
        new Project{ Name = "Green Acres Roundabout Park", Description= "Located at the corner of Tranquil Drive and Hillcrest, residents have expressed an interest in turning this City-owned and maintained island into a pocket park, and rallying residents to help beautify this space, and turning it into an attractive destination.", ImageLink="images/green-acres-roundabout.png", ProjectStatus=Project.Status.Future},
        new Project{ Name = "Railroad Right-of-Way Path", Description= "This is already a worn-in footpath between West College Street and Roxboro Road. We’ve heard that residents would like to be able to walk to Food Lion, and not potentially have to dodge trains to do it. As this neighborhood is devoid of sidewalks, this is a great solution to allow move foot traffic to the closest commercial destination.", ImageLink="images/railroad-right-of-way.png", ProjectStatus=Project.Status.Future},
        new Project{ Name = "Lake Devin Trail Network/Red Barn Upkeep", Description= "The City Parks facilities at Lake Devin are a part of Oxford’s culture, and holds lots of memories for long-term Oxford residents. This effort is two-fold: we want to offer support to the Lake Devin trail network, a shovel-ready project that has been proposed to the City by several private citizens, and help to save the Red Barn, which has fallen into disrepair.", ImageLink="images/lake-devin-trail.png", ProjectStatus=Project.Status.Future},
        new Project{ Name = "Treasures of Joy Greenway", Link="https://oxfordcan.org/wp-content/uploads/2022/11/OrangeStreet.pdf", ProjectStatus=Project.Status.Future},
    };

    public IEnumerable<Project> Get(Project.Status status)
    {
        return allProjects.Where(x => x.ProjectStatus == status);
    }
}