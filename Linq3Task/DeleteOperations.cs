using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Linq3Task;

public class DeleteOperations
{
    // 1. Delete Enrollment
    public static void DeleteEnrollment(AppDbContext context)
    {
        int studentId = 3;
        int courseId = 5;

        var enrollment = context.Enrollments.Find(studentId, courseId);

        if (enrollment == null)
        {
            Console.WriteLine("Enrollment not found!");
            return;
        }

        context.Enrollments.Remove(enrollment);
        context.SaveChanges();

        Console.WriteLine("Enrollment deleted successfully!");
    }

    // 2. Try Delete Category with Children
    public static void TryDeleteCategoryWithChildren(AppDbContext context)
    {
        int categoryId = 1;

        var category = context.Categories.Find(categoryId);

        if (category == null)
        {
            Console.WriteLine("Category not found!");
            return;
        }

        context.Categories.Remove(category);

        try
        {
            context.SaveChanges();
            Console.WriteLine("Category deleted!");
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
        {
            context.ChangeTracker.Clear();
            Console.WriteLine("Cannot delete category because it has subcategories!");
        }
    }

    // 3. Safe Delete Category
    public static void SafeDeleteCategory(AppDbContext context)
    {
        int categoryId = 1;

        var category = context.Categories.Find(categoryId);

        if (category == null)
        {
            Console.WriteLine("Category not found!");
            return;
        }

        bool hasChildren = context.Categories
            .Any(c => c.ParentCategoryId == categoryId);

        if (hasChildren)
        {
            Console.WriteLine("Cannot delete category: It has subcategories!");
            return;
        }

        bool hasCourses = context.Courses
            .Any(c => c.CategoryId == categoryId);

        if (hasCourses)
        {
            Console.WriteLine("Cannot delete category: It has courses!");
            return;
        }

        context.Categories.Remove(category);
        context.SaveChanges();

        Console.WriteLine("Category deleted successfully!");
    }

    // 4. Delete Course with Enrollments
    public static void DeleteCourseWithEnrollments(AppDbContext context)
    {
        int courseId = 6;

        var course = context.Courses.Find(courseId);

        if (course == null)
        {
            Console.WriteLine("Course not found!");
            return;
        }

        int beforeCount = context.Enrollments
            .Count(e => e.CourseId == courseId);

        Console.WriteLine($"Enrollments before delete: {beforeCount}");

        context.Courses.Remove(course);
        context.SaveChanges();

        int afterCount = context.Enrollments
            .Count(e => e.CourseId == courseId);

        Console.WriteLine($"Enrollments after delete: {afterCount}");

        // Enrollments are deleted because Cascade Delete is configured.
    }
}
