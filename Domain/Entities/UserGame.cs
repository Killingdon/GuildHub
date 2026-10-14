using Domain.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class UserGame
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid GameId { get; private set; }
        public DateTime AddedAt { get; private set; }
        public int PlayTimeMinutes { get; private set; }
        public DateTime? LastPlayedAt { get; private set; }

        public User User { get; private set; } = null!;
        public Game Game { get; private set; } = null!;

        private UserGame()
        {

        }

        public UserGame(Guid userId, Guid gameId)
        {
            if(userId == Guid.Empty || gameId == Guid.Empty)
            {
                throw new DomainException("UserId, GameId, and Id cannot be empty.");
            }
            else
            {
                Id = Guid.NewGuid();
                UserId = userId;
                GameId = gameId;
                AddedAt = DateTime.UtcNow;
                PlayTimeMinutes = 0;
                LastPlayedAt = null;
            }
        }

        public void AddPlayTime(int minutes)
        {
            if (minutes <= 0)
                throw new DomainException(
                    "Play time must be greater than zero.");

            PlayTimeMinutes = checked(PlayTimeMinutes + minutes);
            LastPlayedAt = DateTime.UtcNow;
        }


    }
}
