using System.Text.Json;

namespace Api.Core.Extensions;

public static class HttpRequestExtensions
{
    public static HttpRequestMessage CreateRequest(string path, HttpMethod httpMethod)
    {
        return new HttpRequestMessage(httpMethod, $"{path}");
    }

    public static async Task<T> GetObjectResponseFromRequest<T>(
        this HttpRequestMessage request,
        HttpClient httpClient,
        JsonSerializerOptions jsonSerializerOptions,
        CancellationToken cancellationToken
    )
        where T : class, new()
    {
        var result = await httpClient
            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
            .ConfigureAwait(false);
        result.EnsureSuccessStatusCode();

        var contentStream = await result.Content.ReadAsStreamAsync(cancellationToken);

        var response = await JsonSerializer.DeserializeAsync<T>(
            contentStream,
            jsonSerializerOptions,
            cancellationToken
        );
        if (result is null)
        {
            throw new JsonException("Failed to deserialize the JSON.");
        }

        return response!;
    }
}
