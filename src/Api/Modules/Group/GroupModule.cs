using System.Net.Http.Headers;
using Api.Core.Interfaces;
using Api.Core.Options;
using Api.Modules.Group.Adapters;
using Api.Modules.Group.Ports;
using Microsoft.Extensions.Options;

namespace Api.Modules.Group;

public class GroupModule : IModule
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
            .AddScoped<IGroupService, GroupService>()
            .AddHttpClient<IGroupService, GroupService>(
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
