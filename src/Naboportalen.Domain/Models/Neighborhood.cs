namespace Naboportalen.Domain.Models;

public class Neighborhood
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Neighborhood() { }

    public Neighborhood(string name, string? description)
    {
        Name = name;
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }
}
