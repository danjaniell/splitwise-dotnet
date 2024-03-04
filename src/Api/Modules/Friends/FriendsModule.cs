using System.Net.Http.Headers;
using Api.Core.Interfaces;
using Api.Core.Options;
using Api.Modules.Friends.Adapters;
using Api.Modules.Friends.Ports;
using Microsoft.Extensions.Options;

namespace Api.Modules.Friends;

public class FriendsModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        return endpoints;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        using var serviceProvider = services.BuildServiceProvider();
        var options = serviceProvider.GetRequiredService<IOptions<SplitwiseOptions>>().Value;

        services
            .AddScoped<IFriendsService, FriendsService>()
            .AddHttpClient<IFriendsService, FriendsService>(
                "SpltwiseClient",
                x =>
                {
                    x.BaseAddress = new Uri(options.BaseUrl);
                    x.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                        "Bearer",
                        options.Token
                    );
                }
            );

        return services;
    }
}
