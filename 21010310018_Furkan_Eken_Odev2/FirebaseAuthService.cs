
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
public class FirebaseAuthService : ContentPage

{
    private readonly HttpClient _httpClient = new HttpClient();
    private const string FirebaseApiKey = "AIzaSyAK38MwJ8mh16PpFkz3bbarxyqHo1_xvCo";

    public async Task<string> RegisterUserAsync(string email, string password)
    {
        var request = new
        {
            email,
            password,
            returnSecureToken = true
        };

        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={FirebaseApiKey}", content);

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            return "Kay�t ba�ar�l�!";
        }
        else
        {
            var error = await response.Content.ReadAsStringAsync();
            return $"Kay�t ba�ar�s�z: {error}";
        }
    }

    public async Task<string> LoginUserAsync(string email, string password)
    {
        var request = new
        {
            email,
            password,
            returnSecureToken = true
        };

        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={FirebaseApiKey}", content);

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            return "Giri� ba�ar�l�!";
        }
        else
        {
            var error = await response.Content.ReadAsStringAsync();
            return $"Giri� ba�ar�s�z: {error}";
        }
    }
}
