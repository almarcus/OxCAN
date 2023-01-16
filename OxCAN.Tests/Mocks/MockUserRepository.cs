using System.Linq;
public class MockUserRepository : IUserRepository
{
    List<User> users = new();
    
    public User? Get(string userid)
    {
        return users.Where(x => x.UserID == userid).FirstOrDefault();
    }

    public void Add(User user)
    {
        users.Add(user);
    }
}