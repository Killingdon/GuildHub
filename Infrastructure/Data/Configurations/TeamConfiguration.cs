using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using Infrastructure.Data.Configurations;
namespace Infrastructure.Data.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams");

            builder.HasKey(team => team.Id);

            builder.Property(team => team.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(team => team.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(team => team.OwnerId)
                .IsRequired();

            builder.Property(team => team.CreatedAt)
                .IsRequired();

            builder.HasOne(team => team.Owner)
                .WithMany(user => user.OwnedTeams)
                .HasForeignKey(team => team.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
