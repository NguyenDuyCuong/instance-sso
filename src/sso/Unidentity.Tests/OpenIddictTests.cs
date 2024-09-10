using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Unidentity;
using Microsoft.AspNetCore.Hosting;

public class OpenIddictTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public OpenIddictTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CanGetToken()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Post, "/connect/token");
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("username", "testuser"),
            new KeyValuePair<string, string>("password", "password"),
            new KeyValuePair<string, string>("client_id", "client_id"),
            new KeyValuePair<string, string>("client_secret", "client_secret")
        });
        request.Content = content;

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        Assert.Contains("access_token", responseString);
    }
}
