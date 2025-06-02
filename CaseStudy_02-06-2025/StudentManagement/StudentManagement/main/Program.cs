using System;
using Microsoft.VisualBasic;
using StudentManagement.model;

namespace StudentManagement.main
{
    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main()
        {
            students.Add(new Student { ID = 1, Name = "Alice" });
            students.Add(new Student { ID = 2, Name = "Bob" });
            students.Add(new Student { ID = 3, Name = "Charlie" });

            Console.WriteLine("All Students:");
            DisplayAllStudents();

            Console.Write("\nEnter name to search: ");
            string searchName = Console.ReadLine();
            SearchStudentByName(searchName);

            Console.Write("\nEnter name to remove: ");
            string removeName = Console.ReadLine();
            RemoveStudentByName(removeName);

            Console.WriteLine("\nUpdated List of Students:");
            DisplayAllStudents();

            Console.WriteLine($"\nTotal number of students: {students.Count}");
        }

        static void DisplayAllStudents()
        {
            foreach (Student s in students)
            {
                Console.WriteLine($"ID: {s.ID}, Name: {s.Name}");
            }
        }

        static void SearchStudentByName(string name)
        {
            bool found = false;
            foreach (Student s in students)
            {
                if (string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Found: ID={s.ID}, Name={s.Name}");
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void RemoveStudentByName(string name)
        {
            Student toRemove = students.Find(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase));
            if (toRemove != null)
            {
                students.Remove(toRemove);
                Console.WriteLine("Student removed.");
            }
            else
            {
                Console.WriteLine("Student not found. Cannot remove.");
            }
        }
    }
}

