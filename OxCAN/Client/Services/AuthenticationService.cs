using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;
    private readonly AuthenticationStateProvider _authStateProvider; 
    private readonly ILocalStorageService _localStorage;

    public AuthenticationService(HttpClient client, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
    {
        _client = client;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _authStateProvider = authStateProvider; 
        _localStorage = localStorage;
    }

    public async Task<LoginResultDTO> Login(LoginDTO login)
    {
        var content = JsonSerializer.Serialize(login);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        var authResult = await _client.PostAsync("Authentication", bodyContent);
        var authContent = await authResult.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<LoginResultDTO>(authContent, _options);

        if (!authResult.IsSuccessStatusCode)
            return result;

        await _localStorage.SetItemAsync("authToken", result.Token);
        ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(login.UserID);
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);

        return new LoginResultDTO { Successful = true };
    }

public async Task Logout()
{
    await _localStorage.RemoveItemAsync("authToken");
    ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
    _client.DefaultRequestHeaders.Authorization = null;
}
}