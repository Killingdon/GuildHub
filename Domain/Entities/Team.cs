
using Domain.Exeptions;

namespace Domain.Entities;

public class Team
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public DateTime CreatedAt { get; private set; }

    public Guid OwnerId { get; private set; }
    public User Owner { get; private set; } = null!;

    private Team()
    {
        // For EF Core
    }
    public Team(string name, Guid ownerId, string? description = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException(
                "Team name cannot be empty.");
        }

        if (ownerId == Guid.Empty)
        {
            throw new DomainException(
                "OwnerId cannot be empty.");
        }

        Id = Guid.NewGuid();
        Name = name;
        OwnerId = ownerId;
        Description = description ?? string.Empty;
        CreatedAt = DateTime.UtcNow;
    }

    public void ChangeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException(
                "Team name cannot be empty.");
        }

        Name = name;
    }

    public void ChangeDescription(string description)
    {
        Description = description?.Trim() ?? string.Empty;
    }
    public void TransferOwnership(Guid newOwnerId)
    {
        if (newOwnerId == Guid.Empty)
            throw new DomainException("OwnerId cannot be empty.");

        if (newOwnerId == OwnerId)
            throw new DomainException(
                "The new owner must be different from the current owner.");

        OwnerId = newOwnerId;
    } 
}
