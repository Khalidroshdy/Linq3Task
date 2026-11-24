using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq3Task
{
    

    public class CreateOperations
    {
        public static void CreateInstructor(AppDbContext context)
        {
            var instructor = new Instructor
            {
                FullName = "Mohamed Samir",
                Email = "mohamed@example.com",
                Bio = "Software Development Instructor",
                JoinedAt = DateTime.Now
            };

            context.Instructors.Add(instructor);
            context.SaveChanges();

            Console.WriteLine("Instructor created successfully!");
            Console.WriteLine($"ID: {instructor.Id}");
            Console.WriteLine($"Name: {instructor.FullName}");
        }
        public static void CreateCourse(AppDbContext context)
        {
            int instructorId = 1;
            int categoryId = 3;

            bool instructorExists = context.Instructors
                .Any(i => i.Id == instructorId);

            bool categoryExists = context.Categories
                .Any(c => c.Id == categoryId);

            if (!instructorExists || !categoryExists)
            {
                Console.WriteLine("Instructor or Category does not exist!");
                return;
            }

            var course = new Course
            {
                Title = "Entity Framework Core",
                Description = "Learn EF Core with C#",
                Price = 700,
                Level = CourseLevel.Intermediate,
                IsPublished = false,
                PublishedAt = null,
                InstructorId = instructorId,
                CategoryId = categoryId
            };

            context.Courses.Add(course);
            context.SaveChanges();

            Console.WriteLine("Course created successfully!");
            Console.WriteLine($"ID: {course.Id}");
            Console.WriteLine($"Title: {course.Title}");
        }
        public static void CreateStudents(AppDbContext context)
        {
            var students = new List<Student>
    {
        new Student
        {
            FullName = "Mostafa Adel",
            Email = "mostafa@example.com",
            DateOfBirth = new DateTime(2003, 4, 12)
        },
        new Student
        {
            FullName = "Nour Ahmed",
            Email = "nour@example.com",
            DateOfBirth = new DateTime(2002, 7, 20)
        },
        new Student
        {
            FullName = "Hassan Mohamed",
            Email = "hassan@example.com",
            DateOfBirth = new DateTime(2004, 1, 5)
        }
    };

            context.Students.AddRange(students);
            context.SaveChanges();

            Console.WriteLine("3 Students added successfully!");

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id} - {student.FullName}");
            }
        }
        public static void EnrollStudent(AppDbContext context)
        {
            int studentId = 6;
            int courseId = 1;

            bool studentExists = context.Students
                .Any(s => s.Id == studentId);

            if (!studentExists)
            {
                Console.WriteLine("Student does not exist!");
                return;
            }

            var course = context.Courses
                .FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                Console.WriteLine("Course does not exist!");
                return;
            }

            if (!course.IsPublished)
            {
                Console.WriteLine("Course is not published!");
                return;
            }

            bool alreadyEnrolled = context.Enrollments
                .Any(e => e.StudentId == studentId && e.CourseId == courseId);

            if (alreadyEnrolled)
            {
                Console.WriteLine("Student is already enrolled!");
                return;
            }

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrolledAt = DateTime.Now,
                ProgressPercentage = 0,
                Status = EnrollmentStatus.Active
            };

            context.Enrollments.Add(enrollment);
            context.SaveChanges();

            Console.WriteLine("Student enrolled successfully!");
        }
    }
}
