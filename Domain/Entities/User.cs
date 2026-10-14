using Domain.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public ICollection<UserGame> UserGames { get; private set; } = new List<UserGame>();
        public ICollection<Team> OwnedTeams { get; private set; } = new List<Team>();

        private User() { } // For EF Core

        public User(string username, string email, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new DomainException("Username cannot be empty.");

            if (string.IsNullOrWhiteSpace(email))
                throw new DomainException("Email cannot be empty.");

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new DomainException("Password hash cannot be empty.");

            Id = Guid.NewGuid();
            Username = username.Trim();
            Email = email.Trim();
            PasswordHash = passwordHash;
            CreatedAt = DateTime.UtcNow;
        }


    }
}
