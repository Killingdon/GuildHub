
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {

        builder.ToTable("Games");

        builder.HasKey(game => game.Id);

        builder.Property(game => game.Title)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(game => game.Description)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(game => game.Developer)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(game => game.ReleaseDate)
            .IsRequired();

        builder.Property(game => game.CreatedAt)
            .IsRequired();
    }
}

