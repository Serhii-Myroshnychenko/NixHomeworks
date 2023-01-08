using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4Homework4.Models;

namespace Module4Homework4.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project").HasKey(p => p.ProjectId);
            builder.Property(p => p.ProjectId).HasColumnName("ProjectId")
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasColumnName("Name")
                .HasMaxLength(50);
            builder.Property(p => p.Budget).HasColumnName("Budget");
            builder.Property(p => p.StartedDate).HasColumnName("StartedDate")
                .HasMaxLength(7);
            builder.Property(p => p.ClientId).HasColumnName("ClientId")
                .IsRequired();
            builder.HasMany(p => p.EmployeeProjects)
                .WithOne(ep => ep.Project)
                .HasForeignKey(ep => ep.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
