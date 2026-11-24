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
    }
}
