namespace Linq3Task;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            Seeding.SeedStudentsAndEnrollments(context);

            Console.WriteLine("Students:");
            foreach (var student in context.Students)
            {
                Console.WriteLine($"{student.Id} - {student.FullName}");
            }

            Console.WriteLine("\nEnrollments:");
            foreach (var enrollment in context.Enrollments)
            {
                Console.WriteLine(
                    $"Student: {enrollment.StudentId}, Course: {enrollment.CourseId}, Status: {enrollment.Status}");
            }
        }
    }
}