using System.Text.Json;
using Api.Modules.Users.Core;
using Api.Modules.Users.Core.DTO;
using Api.Modules.Users.Ports;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Options;

namespace Api.Modules.Users.Adapters;

public class UserService : IUserService
{
    private readonly string _apiUrl;
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public UserService(HttpClient httpClient, IOptions<JsonSerializerOptions> jsonSerializerOptions)
    {
        Guard.Against.Null(httpClient, nameof(httpClient), "The parameter cannot be null.");
        Guard.Against.Null(
            jsonSerializerOptions,
            nameof(jsonSerializerOptions),
            "The parameter cannot be null."
        );

        _apiUrl = $"{httpClient.BaseAddress!.AbsolutePath}";
        _httpClient = httpClient;
        _jsonSerializerOptions = jsonSerializerOptions.Value;
    }

    public async Task<UserResponse> GetCurrentUser(CancellationToken cancellationToken)
    {
        var request = CreateRequest($"{_apiUrl}/get_current_user", HttpMethod.Get);
        var response = await GetResponseFromRequest<UserResponse>(request, cancellationToken)
            .ConfigureAwait(false);

        return response;
    }

    public async Task<UserResponse> GetUserById(int id, CancellationToken cancellationToken)
    {
        var request = CreateRequest($"{_apiUrl}/get_user/{id}", HttpMethod.Get);
        var response = await GetResponseFromRequest<UserResponse>(request, cancellationToken)
            .ConfigureAwait(false);

        return response;
    }

    public async Task<bool> UpdateUser(
        int id,
        UserUpdate userUpdate,
        CancellationToken cancellationToken
    )
    {
        var request = CreateRequest($"{_apiUrl}/update_user/{id}", HttpMethod.Post);
        var response = await _httpClient.PostAsJsonAsync(
            request.RequestUri,
            userUpdate,
            cancellationToken
        );
        response.EnsureSuccessStatusCode();

        return response.IsSuccessStatusCode;
    }

    private async Task<T> GetResponseFromRequest<T>(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
        where T : class, new()
    {
        var result = await _httpClient
            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
            .ConfigureAwait(false);
        result.EnsureSuccessStatusCode();

        var contentStream = await result.Content.ReadAsStreamAsync(cancellationToken);

        var response = await JsonSerializer.DeserializeAsync<T>(
            contentStream,
            _jsonSerializerOptions,
            cancellationToken
        );
        if (result is null)
        {
            throw new JsonException("Failed to deserialize the JSON.");
        }

        return response!;
    }

    private static HttpRequestMessage CreateRequest(string path, HttpMethod httpMethod)
    {
        return new HttpRequestMessage(httpMethod, $"{path}");
    }
}
