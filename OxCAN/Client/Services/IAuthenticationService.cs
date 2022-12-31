public interface IAuthenticationService
{
    //Task<RegisterResult> RegisterUser(RegisterDTO userForRegistration);
    Task<LoginResultDTO> Login(LoginDTO userForAuthentication);
    Task Logout();
}

// https://code-maze.com/blazor-webassembly-authentication-aspnetcore-identity/