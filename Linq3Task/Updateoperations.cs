using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Linq3Task;

public class UpdateOperations
{
    // 1. Update Course Price
    public static void UpdateCoursePrice(AppDbContext context)
    {
        int courseId = 1;
        decimal newPrice = 1000;

        var course = context.Courses.Find(courseId);

        if (course == null)
        {
            Console.WriteLine("Course not found!");
            return;
        }

        course.Price = newPrice;

        context.SaveChanges();

        Console.WriteLine("Course price updated successfully!");
    }

    // 2. Update Enrollment Progress
    public static void UpdateEnrollmentProgress(AppDbContext context)
    {
        int studentId = 1;
        int courseId = 1;
        int newProgress = 100;

        if (newProgress < 0 || newProgress > 100)
        {
            Console.WriteLine("Progress must be between 0 and 100!");
            return;
        }

        var enrollment = context.Enrollments.Find(studentId, courseId);

        if (enrollment == null)
        {
            Console.WriteLine("Enrollment not found!");
            return;
        }

        enrollment.ProgressPercentage = newProgress;

        if (newProgress == 100)
        {
            enrollment.Status = EnrollmentStatus.Completed;
        }

        context.SaveChanges();

        Console.WriteLine("Enrollment progress updated!");
    }

    // 3. Publish Course
    public static void PublishCourse(AppDbContext context)
    {
        int courseId = 5;

        var course = context.Courses.Find(courseId);

        if (course == null)
        {
            Console.WriteLine("Course not found!");
            return;
        }

        course.IsPublished = true;
        course.PublishedAt = DateTime.Now;

        context.SaveChanges();

        Console.WriteLine("Course published successfully!");
    }
}
