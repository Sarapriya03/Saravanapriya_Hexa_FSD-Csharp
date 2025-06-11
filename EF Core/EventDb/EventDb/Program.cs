using System;
using System.Collections.Generic;
using DAL.DataAccess;
using DAL.Models;

namespace AppUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInfoBL = new UserInfoBL(new UserInfoRepo());
            var eventDetailsBL = new EventDetailsBL(new EventDetailsRepo());
            var sessionInfoBL = new SessionInfoBL(new SessionInfoRepo());

            while (true)
            {
                Console.WriteLine("\n==== Event Management System ====");
                Console.WriteLine("1. Manage Users");
                Console.WriteLine("2. Manage Events");
                Console.WriteLine("3. Manage Sessions");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageUsers(userInfoBL);
                        break;
                    case "2":
                        ManageEvents(eventDetailsBL);
                        break;
                    case "3":
                        ManageSessions(sessionInfoBL);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void ManageUsers(UserInfoBL userInfoBL)
        {
            Console.WriteLine("\n--- User Management ---");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Update User");
            Console.WriteLine("3. Delete User");
            Console.WriteLine("4. View All Users");
            Console.Write("Choose an option: ");
            string opt = Console.ReadLine();

            switch (opt)
            {
                case "1":
                    var newUser = new UserInfo();
                    Console.Write("Email: ");
                    newUser.EmailId = Console.ReadLine();
                    Console.Write("Username: ");
                    newUser.UserName = Console.ReadLine();
                    Console.Write("Role (Admin/Participant): ");
                    newUser.Role = Console.ReadLine();
                    Console.Write("Password: ");
                    newUser.Password = Console.ReadLine();
                    userInfoBL.AddUser(newUser);
                    Console.WriteLine("User added.");
                    break;

                case "2":
                    var updateUser = new UserInfo();
                    Console.Write("Email of user to update: ");
                    updateUser.EmailId = Console.ReadLine();
                    Console.Write("New Username: ");
                    updateUser.UserName = Console.ReadLine();
                    Console.Write("New Role: ");
                    updateUser.Role = Console.ReadLine();
                    Console.Write("New Password: ");
                    updateUser.Password = Console.ReadLine();
                    userInfoBL.UpdateUser(updateUser);
                    Console.WriteLine("User updated.");
                    break;

                case "3":
                    Console.Write("Email to delete: ");
                    userInfoBL.DeleteUser(Console.ReadLine());
                    Console.WriteLine("User deleted.");
                    break;

                case "4":
                    var users = userInfoBL.GetAllUsers();
                    foreach (var user in users)
                        Console.WriteLine($"{user.EmailId} | {user.UserName} | {user.Role}");
                    break;
            }
        }

        static void ManageEvents(EventDetailsBL eventDetailsBL)
        {
            Console.WriteLine("\n--- Event Management ---");
            Console.WriteLine("1. Add Event");
            Console.WriteLine("2. Update Event");
            Console.WriteLine("3. Delete Event");
            Console.WriteLine("4. View All Events");
            Console.WriteLine("5. View Events by Category");
            Console.Write("Choose an option: ");
            string opt = Console.ReadLine();

            switch (opt)
            {
                case "1":
                    var newEvent = new EventDetails();
                    Console.Write("Event Name: ");
                    newEvent.EventName = Console.ReadLine();
                    Console.Write("Category: ");
                    newEvent.EventCategory = Console.ReadLine();
                    Console.Write("Date (yyyy-mm-dd): ");
                    newEvent.EventDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Description: ");
                    newEvent.Description = Console.ReadLine();
                    Console.Write("Status: ");
                    newEvent.Status = Console.ReadLine();
                    var result = eventDetailsBL.AddEvent(newEvent);
                    Console.WriteLine(result != null ? "Event added." : "Failed to add event.");
                    break;

                case "2":
                    var updateEvent = new EventDetails();
                    Console.Write("Event ID to update: ");
                    updateEvent.EventId = int.Parse(Console.ReadLine());
                    Console.Write("New Name: ");
                    updateEvent.EventName = Console.ReadLine();
                    Console.Write("New Category: ");
                    updateEvent.EventCategory = Console.ReadLine();
                    Console.Write("New Date: ");
                    updateEvent.EventDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("New Description: ");
                    updateEvent.Description = Console.ReadLine();
                    Console.Write("New Status: ");
                    updateEvent.Status = Console.ReadLine();
                    var updated = eventDetailsBL.UpdateEvent(updateEvent);
                    Console.WriteLine(updated != null ? "Event updated." : "Failed to update event.");
                    break;

                case "3":
                    Console.Write("Event ID to delete: ");
                    var deleted = eventDetailsBL.DeleteEvent(int.Parse(Console.ReadLine()));
                    Console.WriteLine(deleted != null ? "Event deleted." : "Event not found.");
                    break;

                case "4":
                    var events = eventDetailsBL.GetAllEvents();
                    foreach (var ev in events)
                        Console.WriteLine($"{ev.EventId} | {ev.EventName} | {ev.EventDate.ToShortDateString()} | {ev.Status}");
                    break;

                case "5":
                    Console.Write("Enter category: ");
                    var categoryEvents = eventDetailsBL.GetEventsByCategory(Console.ReadLine());
                    foreach (var ev in categoryEvents)
                        Console.WriteLine($"{ev.EventId} | {ev.EventName} | {ev.EventCategory}");
                    break;
            }
        }

        static void ManageSessions(SessionInfoBL sessionInfoBL)
        {
            Console.WriteLine("\n--- Session Management ---");
            Console.WriteLine("1. Add Session");
            Console.WriteLine("2. Update Session");
            Console.WriteLine("3. Delete Session");
            Console.WriteLine("4. View All Sessions");
            Console.WriteLine("5. Get Session by ID");
            Console.Write("Choose an option: ");
            string opt = Console.ReadLine();

            switch (opt)
            {
                case "1":
                    var newSession = new SessionInfo();
                    Console.Write("Title: ");
                    newSession.SessionTitle = Console.ReadLine();
                    Console.Write("Speaker ID: ");
                    newSession.SpeakerId = int.Parse(Console.ReadLine());
                    Console.Write("Description: ");
                    newSession.Description = Console.ReadLine();
                    Console.Write("Event ID: ");
                    newSession.EventId = int.Parse(Console.ReadLine());
                    Console.Write("Session Url: ");
                    newSession.SessionUrl = Console.ReadLine();
                    sessionInfoBL.AddSession(newSession);
                    Console.WriteLine("Session added.");
                    break;

                case "2":
                    var updateSession = new SessionInfo();
                    Console.Write("Session ID to update: ");
                    updateSession.SessionId = int.Parse(Console.ReadLine());
                    Console.Write("New Title: ");
                    updateSession.SessionTitle = Console.ReadLine();
                    Console.Write("New Speaker ID: ");
                    updateSession.SpeakerId = int.Parse(Console.ReadLine());
                    Console.Write("New Description: ");
                    updateSession.Description = Console.ReadLine();
                    Console.Write("New Event ID: ");
                    updateSession.EventId = int.Parse(Console.ReadLine());
                    sessionInfoBL.UpdateSession(updateSession);
                    Console.WriteLine("Session updated.");
                    break;

                case "3":
                    Console.Write("Session ID to delete: ");
                    sessionInfoBL.DeleteSession(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Session deleted.");
                    break;

                case "4":
                    var sessions = sessionInfoBL.GetAllSessions();
                    foreach (var s in sessions)
                        Console.WriteLine($"{s.SessionId} | {s.SessionTitle} | Event: {s.EventId}");
                    break;

                case "5":
                    Console.Write("Enter Session ID: ");
                    var session = sessionInfoBL.GetSessionById(int.Parse(Console.ReadLine()));
                    Console.WriteLine($"{session.SessionId} | {session.SessionTitle} | {session.Description}");
                    break;
            }
        }
    }
}
