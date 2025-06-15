using Microsoft.AspNetCore.Mvc;
using LearningManagementSystem.Models;
using System.Collections.Generic;

namespace LearningManagementSystem.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        // Sample static data (later replace with DB or service)
        private static List<Course> courses = new List<Course>
        {
            new Course { CourseId = 1, Title = "C# Basics", Description = "Learn C# from scratch" },
            new Course { CourseId = 2, Title = "ASP.NET MVC", Description = "Build web apps using ASP.NET Core MVC" }
        };

        private static List<Trainer> trainers = new List<Trainer>
        {
            new Trainer { TrainerId = 1, Name = "John Doe", Expertise = "C#" },
            new Trainer { TrainerId = 2, Name = "Priya Sharma", Expertise = "ASP.NET" }
        };

        private static List<Learner> learners = new List<Learner>
        {
            new Learner { LearnerId = 1, Name = "Ravi Kumar", Email = "ravi@example.com" },
            new Learner { LearnerId = 2, Name = "Sneha Mehta", Email = "sneha@example.com" }
        };

        [HttpPost("dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet("update-profile")]
        public IActionResult UpdateProfile()
        {
            return View();
        }

        [HttpGet("manage-courses")]
        public IActionResult ManageCourses(int? deleteId)
        {
            if (deleteId != null)
            {
                var course = courses.FirstOrDefault(c => c.CourseId == deleteId);
                if (course != null)
                    courses.Remove(course);
            }

            return View(courses);
        }

        [HttpPost("manage-courses")]
        public IActionResult ManageCourses(Course newCourse)
        {
            if (!string.IsNullOrWhiteSpace(newCourse.Title) && !string.IsNullOrWhiteSpace(newCourse.Description))
            {
                newCourse.CourseId = courses.Count > 0 ? courses.Max(c => c.CourseId) + 1 : 1;
                courses.Add(newCourse);
            }

            return RedirectToAction("ManageCourses");
        }


        [HttpGet("manage-trainers")]
        public IActionResult ManageTrainers(int? deleteId)
        {
            if (deleteId != null)
            {
                var trainer = trainers.FirstOrDefault(t => t.TrainerId == deleteId);
                if (trainer != null)
                    trainers.Remove(trainer);
            }

            return View(trainers);
        }

        [HttpPost("manage-trainers")]
        public IActionResult ManageTrainers(Trainer newTrainer)
        {
            if (!string.IsNullOrWhiteSpace(newTrainer.Name) && !string.IsNullOrWhiteSpace(newTrainer.Expertise))
            {
                newTrainer.TrainerId = trainers.Count > 0 ? trainers.Max(t => t.TrainerId) + 1 : 1;
                trainers.Add(newTrainer);
            }

            return RedirectToAction("ManageTrainers");
        }

        [HttpGet("manage-learners")]
        public IActionResult ManageLearners(int? deleteId)
        {
            if (deleteId != null)
            {
                var learner = learners.FirstOrDefault(l => l.LearnerId == deleteId);
                if (learner != null)
                    learners.Remove(learner);
            }

            return View(learners);
        }

        [HttpPost("manage-learners")]
        public IActionResult ManageLearners(Learner newLearner)
        {
            if (!string.IsNullOrWhiteSpace(newLearner.Name) && !string.IsNullOrWhiteSpace(newLearner.Email))
            {
                newLearner.LearnerId = learners.Count > 0 ? learners.Max(l => l.LearnerId) + 1 : 1;
                learners.Add(newLearner);
            }

            return RedirectToAction("ManageLearners");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
