using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4Homework3.Models;

namespace Module4Homework3.Configurations
{
    public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.ToTable("EmployeeProject").HasKey(ep => ep.EmployeeProjectId);
            builder.Property(ep => ep.EmployeeProjectId).HasColumnName("EmployeeProjectId")
                .ValueGeneratedOnAdd();
            builder.Property(ep => ep.Rate).HasColumnName("Rate");
            builder.Property(ep => ep.StartedDate).HasColumnName("StartedDate")
                .HasMaxLength(7);
            builder.Property(ep => ep.EmployeeId).HasColumnName("EmployeeId");
            builder.Property(ep => ep.ProjectId).HasColumnName("ProjectId");
            builder.HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(ep => ep.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
