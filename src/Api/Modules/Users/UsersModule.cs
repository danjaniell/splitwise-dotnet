using System.Net.Http.Headers;
using Api.Core.Interface;
using Api.Core.Options;
using Api.Modules.Users.Adapters;
using Api.Modules.Users.Ports;
using Microsoft.Extensions.Options;

namespace Api.Modules.Users;

public class UsersModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet(
            "/getCurrentUser",
            async (HttpContext context) =>
            {
                var userService = context.RequestServices.GetRequiredService<IUserService>();
                var cancellationToken = context.RequestAborted;

                return await userService.GetCurrentUser(cancellationToken);
            }
        );

        return endpoints;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        using var serviceProvider = services.BuildServiceProvider();
        var options = serviceProvider.GetRequiredService<IOptions<SplitwiseOptions>>().Value;

        services
            .AddScoped<IUserService, UserService>()
            .AddHttpClient<IUserService, UserService>(
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
