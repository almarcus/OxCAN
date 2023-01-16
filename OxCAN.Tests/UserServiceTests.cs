
namespace OxCAN.Tests;

public class UserServiceTests
{
    private readonly UserService userService;
    private readonly IUserRepository userRepository;
    public UserServiceTests()
    {
        userRepository = new MockUserRepository();
        userService = new UserService(userRepository);
    }

    [Fact]
    public void EmptyRepoReturnsNull()
    {
        User? user = userService.Get("test");
        Assert.Null(user);
    }

    [Fact]
    public void NoMatchReturnsNull()
    {
        User user1 = new User()
        {
            UserID = "user1"
        };

        userService.Add(user1);

        User? user2 = userService.Get("user2");

        Assert.Null(user2);
    }

    [Fact]
    public void MatchReturnsUser()
    {
        User user = new User()
        {
            UserID = "user"
        };

        userService.Add(user);

        User gottenUser = userService.Get(user.UserID);

        Assert.Equal(user, gottenUser);
    }

    [Fact]
    public void CantAddDuplicateUser()
    {
        User user = new User()
        {
            UserID = "user"
        };

        userService.Add(user);

        Assert.Throws<ArgumentException>(() => userService.Add(user));
    }
}