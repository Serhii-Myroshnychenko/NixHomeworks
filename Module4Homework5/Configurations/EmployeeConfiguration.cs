using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4Homework5.Models;

namespace Module4Homework5.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee").HasKey(e => e.EmployeeId);
            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeId")
                .ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).HasColumnName("FirstName")
                .HasMaxLength(50);
            builder.Property(e => e.LastName).HasColumnName("LastName")
                .HasMaxLength(50);
            builder.Property(e => e.HiredDate).HasColumnName("HiredDate")
                .HasMaxLength(7);
            builder.Property(e => e.DateOfBirth).HasColumnName("DateOfBirth")
                .IsRequired();
            builder.Property(e => e.OfficeId).HasColumnName("OfficeId");
            builder.Property(e => e.TitleId).HasColumnName("TitleId");
            builder.HasOne(e => e.Office)
                .WithMany(o => o.Employees)
                .HasForeignKey(e => e.OfficeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Title)
                .WithMany(t => t.Employees)
                .HasForeignKey(e => e.TitleId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.EmployeeProjects)
                .WithOne(ep => ep.Employee)
                .HasForeignKey(ep => ep.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
