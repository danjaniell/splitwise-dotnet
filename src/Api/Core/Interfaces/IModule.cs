namespace Api.Core.Interfaces;

public interface IModule
{
    IServiceCollection RegisterModule(IServiceCollection services);
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}
