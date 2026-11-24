
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Linq3Task;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> b)
    {
        b.HasKey(i => i.Id);

        b.Property(i => i.FullName)
            .IsRequired()
            .HasMaxLength(100);

        b.Property(i => i.Email)
            .IsRequired()
            .HasMaxLength(150);

        b.Property(i => i.Bio)
            .HasMaxLength(500);

        b.HasIndex(i => i.Email).IsUnique();
    }
}

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> b)
    {
        b.HasKey(c => c.Id);

        b.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        b.Property(c => c.Description)
            .HasMaxLength(300);

        b.HasOne(c => c.Parent)
            .WithMany(c => c.SubCategories)
            .HasForeignKey(c => c.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> b)
    {
        b.HasKey(c => c.Id);

        b.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(200);

        b.Property(c => c.Description)
            .HasMaxLength(1000);

        b.Property(c => c.Price)
            .HasPrecision(18, 2);

        b.Property(c => c.Level)
            .HasConversion<string>()
            .HasMaxLength(20);

        b.HasOne(c => c.Instructor)
            .WithMany(i => i.Courses)
            .HasForeignKey(c => c.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(c => c.Category)
            .WithMany(cat => cat.Courses)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> b)
    {
        b.HasKey(s => s.Id);

        b.Property(s => s.FullName)
            .IsRequired()
            .HasMaxLength(100);

        b.Property(s => s.Email)
            .IsRequired()
            .HasMaxLength(150);

        b.HasIndex(s => s.Email).IsUnique();
    }
}

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> b)
    {
        b.HasKey(e => new { e.StudentId, e.CourseId });

        b.Property(e => e.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        b.Property(e => e.FinalGrade)
            .HasPrecision(5, 2);

        b.HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
