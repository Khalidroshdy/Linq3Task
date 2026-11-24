namespace Linq3Task;

public static class Seeding
{
    public static void SeedStudentsAndEnrollments(AppDbContext context)
    {
        if (!context.Students.Any())
        {
            var students = new List<Student>
            {
                new Student
                {
                    FullName = "Ali Hassan",
                    Email = "ali@example.com",
                    DateOfBirth = new DateTime(2003, 5, 10)
                },
                new Student
                {
                    FullName = "Mona Ahmed",
                    Email = "mona@example.com",
                    DateOfBirth = new DateTime(2002, 8, 15)
                },
                new Student
                {
                    FullName = "Omar Khaled",
                    Email = "omar@example.com",
                    DateOfBirth = new DateTime(2004, 2, 20)
                },
                new Student
                {
                    FullName = "Sara Mahmoud",
                    Email = "sara.student@example.com",
                    DateOfBirth = new DateTime(2003, 11, 5)
                },
                new Student
                {
                    FullName = "Youssef Ali",
                    Email = "youssef@example.com",
                    DateOfBirth = new DateTime(2002, 6, 25)
                }
            };

            context.Students.AddRange(students);
            context.SaveChanges();
        }

        if (!context.Enrollments.Any())
        {
            var students = context.Students.ToList();

            var enrollments = new List<Enrollment>
            {
                new Enrollment
                {
                    StudentId = students[0].Id,
                    CourseId = 1,
                    EnrolledAt = new DateTime(2024, 5, 1),
                    ProgressPercentage = 100,
                    Status = EnrollmentStatus.Completed,
                    FinalGrade = 95
                },
                new Enrollment
                {
                    StudentId = students[0].Id,
                    CourseId = 3,
                    EnrolledAt = new DateTime(2024, 5, 5),
                    ProgressPercentage = 40,
                    Status = EnrollmentStatus.Active
                },
                new Enrollment
                {
                    StudentId = students[1].Id,
                    CourseId = 1,
                    EnrolledAt = new DateTime(2024, 5, 2),
                    ProgressPercentage = 60,
                    Status = EnrollmentStatus.Active
                },
                new Enrollment
                {
                    StudentId = students[1].Id,
                    CourseId = 4,
                    EnrolledAt = new DateTime(2024, 5, 6),
                    ProgressPercentage = 100,
                    Status = EnrollmentStatus.Completed,
                    FinalGrade = 88
                },
                new Enrollment
                {
                    StudentId = students[2].Id,
                    CourseId = 2,
                    EnrolledAt = new DateTime(2024, 5, 3),
                    ProgressPercentage = 20,
                    Status = EnrollmentStatus.Active
                },
                new Enrollment
                {
                    StudentId = students[2].Id,
                    CourseId = 5,
                    EnrolledAt = new DateTime(2024, 5, 7),
                    ProgressPercentage = 10,
                    Status = EnrollmentStatus.Dropped
                },
                new Enrollment
                {
                    StudentId = students[3].Id,
                    CourseId = 3,
                    EnrolledAt = new DateTime(2024, 5, 4),
                    ProgressPercentage = 100,
                    Status = EnrollmentStatus.Completed,
                    FinalGrade = 92
                },
                new Enrollment
                {
                    StudentId = students[4].Id,
                    CourseId = 6,
                    EnrolledAt = new DateTime(2024, 5, 8),
                    ProgressPercentage = 0,
                    Status = EnrollmentStatus.Dropped
                }
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}