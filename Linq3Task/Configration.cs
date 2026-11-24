
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

        b.HasData(
            new Instructor
            {
                Id = 1,
                FullName = "Ahmed Mohamed",
                Email = "ahmed@example.com",
                Bio = "C# and .NET Instructor",
                JoinedAt = new DateTime(2022, 1, 10)
            },
            new Instructor
            {
                Id = 2,
                FullName = "Sara Ali",
                Email = "sara@example.com",
                Bio = "Web Development Instructor",
                JoinedAt = new DateTime(2021, 5, 15)
            },
            new Instructor
            {
                Id = 3,
                FullName = "Omar Hassan",
                Email = "omar@example.com",
                Bio = "Database and SQL Instructor",
                JoinedAt = new DateTime(2023, 3, 20)
            }
        );
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

        b.HasData(
            new Category
            {
                Id = 1,
                Name = "Programming",
                Description = "Programming courses",
                ParentCategoryId = null
            },
            new Category
            {
                Id = 2,
                Name = "Data Science",
                Description = "Data science courses",
                ParentCategoryId = null
            },
            new Category
            {
                Id = 3,
                Name = "C#",
                Description = "C# programming",
                ParentCategoryId = 1
            },
            new Category
            {
                Id = 4,
                Name = "Web Development",
                Description = "Web development courses",
                ParentCategoryId = 1
            },
            new Category
            {
                Id = 5,
                Name = "ASP.NET Core",
                Description = "ASP.NET Core courses",
                ParentCategoryId = 4
            }
        );
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

        b.HasData(
            new Course
            {
                Id = 1,
                Title = "C# Fundamentals",
                Description = "Learn C# basics",
                Price = 500,
                Level = CourseLevel.Beginner,
                IsPublished = true,
                PublishedAt = new DateTime(2024, 1, 10),
                InstructorId = 1,
                CategoryId = 3
            },
            new Course
            {
                Id = 2,
                Title = "Advanced C#",
                Description = "Advanced C# concepts",
                Price = 900,
                Level = CourseLevel.Advanced,
                IsPublished = true,
                PublishedAt = new DateTime(2024, 2, 15),
                InstructorId = 1,
                CategoryId = 3
            },
            new Course
            {
                Id = 3,
                Title = "ASP.NET Core Web API",
                Description = "Build APIs using ASP.NET Core",
                Price = 800,
                Level = CourseLevel.Intermediate,
                IsPublished = true,
                PublishedAt = new DateTime(2024, 3, 1),
                InstructorId = 2,
                CategoryId = 5
            },
            new Course
            {
                Id = 4,
                Title = "HTML and CSS",
                Description = "Web development basics",
                Price = 400,
                Level = CourseLevel.Beginner,
                IsPublished = true,
                PublishedAt = new DateTime(2024, 4, 1),
                InstructorId = 2,
                CategoryId = 4
            },
            new Course
            {
                Id = 5,
                Title = "SQL Fundamentals",
                Description = "Learn SQL and databases",
                Price = 600,
                Level = CourseLevel.Beginner,
                IsPublished = false,
                PublishedAt = null,
                InstructorId = 3,
                CategoryId = 2
            },
            new Course
            {
                Id = 6,
                Title = "Data Analysis",
                Description = "Introduction to data analysis",
                Price = 750,
                Level = CourseLevel.Intermediate,
                IsPublished = false,
                PublishedAt = null,
                InstructorId = 3,
                CategoryId = 2
            }
        );
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
