using Domain.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Game
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Developer { get; private set; } = string.Empty;
        public DateTime ReleaseDate { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public ICollection<UserGame> UserGames { get; private set; } = new List<UserGame>();

        private Game()
        {

        }

        public Game(string title, string description, string developer, DateTime releaseDate)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException("Game title cannot be empty.");

            if (string.IsNullOrWhiteSpace(developer))
                throw new DomainException("Developer cannot be empty.");

            Id = Guid.NewGuid();
            Title = title.Trim();
            Description = description?.Trim() ?? string.Empty;
            Developer = developer.Trim();
            ReleaseDate = releaseDate;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
