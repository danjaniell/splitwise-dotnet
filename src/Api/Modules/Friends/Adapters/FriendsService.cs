using System.Text.Json;
using Api.Core.Extensions;
using Api.Modules.Friends.Core;
using Api.Modules.Friends.Ports;
using Microsoft.Extensions.Options;

namespace Api.Modules.Friends.Adapters;

public class FriendsService : IFriendsService
{
    private readonly string _apiUrl;
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public FriendsService(
        HttpClient httpClient,
        IOptions<JsonSerializerOptions> jsonSerializerOptions
    )
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

    public async Task<FriendsResponse> GetMyFriends(CancellationToken cancellationToken)
    {
        var request = HttpRequestExtensions.CreateRequest($"{_apiUrl}/get_friends", HttpMethod.Get);
        var response = await HttpRequestExtensions
            .GetObjectResponseFromRequest<FriendsResponse>(
                request,
                _httpClient,
                _jsonSerializerOptions,
                cancellationToken
            )
            .ConfigureAwait(false);

        return response;
    }
}
