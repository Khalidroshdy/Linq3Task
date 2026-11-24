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
    }
}
