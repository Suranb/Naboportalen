using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Naboportalen.Application.Generics;
using Naboportalen.Application.Interfaces;
using Naboportalen.Domain.Models;

namespace Naboportalen.Application.Features.Neighborhoods;

public class CreateNeighborhood() { }

public interface INeighborhoodRepository
{
    Task CreateAsync(Neighborhood neighborhood, CancellationToken cancellationToken);
}

public sealed record CreateNeighborhoodCommand(
    string Name,
    string Description
);

public sealed class CreateNeighborhoodResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

public sealed class CreateNeighborhoodHandler
{
    private readonly INeighborhoodRepository _repository;

    public CreateNeighborhoodHandler(INeighborhoodRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<int>> Handle(CreateNeighborhoodCommand command, CancellationToken cancellationToken)
    {
        var neighborhood = new Neighborhood(command.Name, command.Description);

        await _repository.CreateAsync(neighborhood, cancellationToken);

        return Result<int>.Success(neighborhood.Id);
    }
}

public sealed class CreateNeighborhoodEndpoint : IFeatureEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/neighborhoods", async (
            CreateNeighborhoodCommand command,
            CreateNeighborhoodHandler handler,
            CancellationToken cancellationToken
        ) =>
        {
            var id = await handler.Handle(command, cancellationToken);
            return Results.Created($"/api/neighborhoods/{id}", new CreateNeighborhoodResponse { Id = id.Value, Name = command.Name });
            // return Results.Created("/api/neighborhoods/1", new { Id = 1, Name = "New Neighborhood" });
        })
        .WithName("CreateNeighborhood");
    }
}