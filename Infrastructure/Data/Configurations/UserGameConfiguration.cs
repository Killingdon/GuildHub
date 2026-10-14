using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Data.Configurations
{
    public class UserGameConfiguration : IEntityTypeConfiguration<UserGame>
    {
        public void Configure(EntityTypeBuilder<UserGame> builder)
        {
            builder.ToTable("UserGames");   

            builder.HasKey(userGame => userGame.Id);

            builder.HasIndex(userGame => new { userGame.UserId, userGame.GameId })
                .IsUnique();

            builder.Property(userGame => userGame.UserId)
                .IsRequired();

            builder.Property(userGame => userGame.GameId)
                .IsRequired();
    
            builder.Property(userGame => userGame.AddedAt)
                .IsRequired();

            builder.Property(userGame => userGame.PlayTimeMinutes)
                .IsRequired();
            
            builder.Property(userGame => userGame.LastPlayedAt)
                .IsRequired(false);

            builder.HasOne(userGame => userGame.User)
                .WithMany(user => user.UserGames)
                .HasForeignKey(userGame => userGame.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(userGame => userGame.Game)
                .WithMany(game => game.UserGames)
                .HasForeignKey(userGame => userGame.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(table =>
                        table.HasCheckConstraint(
                            "CK_UserGames_PlayTimeMinutes_NonNegative",
                            "[PlayTimeMinutes] >= 0"));
        }

    }
}
