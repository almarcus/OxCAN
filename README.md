# Oxford Community Action Network
This project hosts a prototype version of OxC.A.N.'s new website.
## Setup and Run
1. Install the latest version of the .NET 7 SDK from Microsoft's [Website](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
1. Set secrets one of 2 ways:
    1. Add in the secrets with `dotnet user-secrets set [key] [value]` in the `Server` directory. 
    1. Fill in the secret in the appropriate `appSettings.XXX.json` file
1. From the repository root, run `dotnet watch --project OxCAN/Server/OxCAN.Server.csproj` to run the project. A browser window should launch but if not, the terminal output should say the host and port that the site is running on.