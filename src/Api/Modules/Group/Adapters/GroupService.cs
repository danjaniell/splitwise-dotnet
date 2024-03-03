using System.Text.Json;
using Api.Core.Extensions;
using Api.Modules.Group.Core;
using Api.Modules.Group.Ports;
using Microsoft.Extensions.Options;

namespace Api.Modules.Group.Adapters
{
    public class GroupService : IGroupService
    {
        private readonly string _apiUrl;
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public GroupService(
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

        public async Task<GroupsResponse> GetMyGroups(CancellationToken cancellationToken)
        {
            var request = HttpRequestExtensions.CreateRequest(
                $"{_apiUrl}/get_groups",
                HttpMethod.Get
            );
            var response = await HttpRequestExtensions
                .GetObjectResponseFromRequest<GroupsResponse>(
                    request,
                    _httpClient,
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false);

            return response;
        }

        public async Task<GroupResponse> GetGroupById(int id, CancellationToken cancellationToken)
        {
            var request = HttpRequestExtensions.CreateRequest(
                $"{_apiUrl}/get_group/{id}",
                HttpMethod.Get
            );
            var response = await HttpRequestExtensions
                .GetObjectResponseFromRequest<GroupResponse>(
                    request,
                    _httpClient,
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false);

            return response;
        }
    }
}
