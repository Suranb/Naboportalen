using Microsoft.AspNetCore.Routing;

namespace Naboportalen.Application.Interfaces;

public interface IFeatureEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
