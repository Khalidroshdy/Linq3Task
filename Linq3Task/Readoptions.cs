using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Linq3Task;

public class ReadOperations
{
    // 1. Find Course by ID
    public static void FindCourseById(AppDbContext context)
    {
        int courseId = 1;

        var course = context.Courses.Find(courseId);

        if (course == null)
        {
            Console.WriteLine("Course not found!");
            return;
        }

        Console.WriteLine($"ID: {course.Id}");
        Console.WriteLine($"Title: {course.Title}");
        Console.WriteLine($"Price: {course.Price}");
    }

    // 2. Find Course by Title
    public static void FindCourseByTitle(AppDbContext context)
    {
        string title = "C# Fundamentals";

        var course = context.Courses
            .FirstOrDefault(c => c.Title == title);

        if (course == null)
        {
            Console.WriteLine("Course not found!");
            return;
        }

        Console.WriteLine($"ID: {course.Id}");
        Console.WriteLine($"Title: {course.Title}");
        Console.WriteLine($"Price: {course.Price}");
    }

    // 3. Filter Courses by Price Range
    public static void GetCoursesByPriceRange(AppDbContext context)
    {
        decimal minPrice = 400;
        decimal maxPrice = 800;

        var courses = context.Courses
            .Where(c => c.Price >= minPrice && c.Price <= maxPrice)
            .OrderByDescending(c => c.Price)
            .ToList();

        foreach (var course in courses)
        {
            Console.WriteLine($"{course.Title} - {course.Price}");
        }
    }

    // 4. Get Subcategories
    public static void GetSubCategories(AppDbContext context)
    {
        int categoryId = 1;

        var categories = context.Categories
            .Where(c => c.ParentCategoryId == categoryId)
            .ToList();

        foreach (var category in categories)
        {
            Console.WriteLine($"{category.Id} - {category.Name}");
        }
    }

    // 5. Get Top-Level Categories
    public static void GetTopLevelCategories(AppDbContext context)
    {
        var categories = context.Categories
            .Where(c => c.ParentCategoryId == null)
            .ToList();

        foreach (var category in categories)
        {
            Console.WriteLine($"{category.Id} - {category.Name}");
        }
    }

    // 6. Get Course Roster
    public static void GetCourseRoster(AppDbContext context)
    {
        int courseId = 1;

        var studentIds = context.Enrollments
            .Where(e => e.CourseId == courseId)
            .Select(e => e.StudentId)
            .ToList();

        var students = context.Students
            .Where(s => studentIds.Contains(s.Id))
            .ToList();

        foreach (var student in students)
        {
            Console.WriteLine($"{student.Id} - {student.FullName}");
        }
    }
}
