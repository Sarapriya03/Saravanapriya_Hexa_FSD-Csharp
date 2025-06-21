using DAL.DataAccess;
using DAL.Models;
using System;

namespace DAL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userRepo = new UserInfoRepo();
            var eventRepo = new EventDetailsRepo();
            var sessionRepo = new SessionInfoRepo();

            while (true)
            {
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. Manage Users");
                Console.WriteLine("2. Manage Events");
                Console.WriteLine("3. Manage Sessions");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n-- Add User --");
                        var newUser = new UserInfo
                        {
                            EmailId = "john@example.com",
                            UserName = "John",
                            Role = "Admin",
                            Password = "password123"
                        };
                        var addedUser = userRepo.AddUser(newUser);
                        Console.WriteLine(addedUser != null ? "User Added." : "Failed to add user.");
                        break;

                    case "2":
                        Console.WriteLine("\n-- Add Event --");
                        var newEvent = new EventDetails
                        {
                            EventName = "Tech Conference",
                            EventCategory = "Technology",
                            EventDate = DateTime.Now.AddDays(10),
                            Description = "Annual tech event.",
                            Status = "Active"
                        };
                        var addedEvent = eventRepo.AddEvent(newEvent);
                        Console.WriteLine(addedEvent != null ? "Event Added." : "Failed to add event.");
                        break;

                    case "3":
                        Console.WriteLine("\n-- Add Session --");
                        var newSession = new SessionInfo
                        {
                            SessionTitle = "AI and Future",
                            SpeakerId = 1,
                            Description = "Talk about AI.",
                            EventId = 1
                        };
                        var addedSession = sessionRepo.AddSession(newSession);
                        Console.WriteLine(addedSession != null ? "Session Added." : "Failed to add session.");
                        break;

                    case "4":
                        Console.WriteLine("Exiting application...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
