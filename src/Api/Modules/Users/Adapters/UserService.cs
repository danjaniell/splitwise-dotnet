using System.Text.Json;
using Api.Modules.Users.Core;
using Api.Modules.Users.Ports;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Options;

namespace Api.Modules.Users.Adapters;

public class UserService(
    HttpClient httpClient,
    IOptions<JsonSerializerOptions> jsonSerializerOptions
) : IUserService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions = jsonSerializerOptions.Value;

    public async Task<UserResponse> GetCurrentUser(CancellationToken cancellationToken)
    {
        Guard.Against.Null(_httpClient, nameof(_httpClient), "The parameter cannot be null.");
        Guard.Against.Null(
            _jsonSerializerOptions,
            nameof(_jsonSerializerOptions),
            "The parameter cannot be null."
        );

        var request = CreateRequest(
            $"{_httpClient.BaseAddress!.AbsolutePath}/get_current_user",
            HttpMethod.Get
        );

        using var result = await _httpClient
            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
            .ConfigureAwait(false);
        result.EnsureSuccessStatusCode();

        using var contentStream = await result.Content.ReadAsStreamAsync(cancellationToken);
        var response = await JsonSerializer.DeserializeAsync<UserResponse>(
            contentStream,
            _jsonSerializerOptions,
            cancellationToken
        );

        return response!;
    }

    private static HttpRequestMessage CreateRequest(string path, HttpMethod httpMethod)
    {
        return new HttpRequestMessage(httpMethod, $"{path}");
    }
}
