namespace LearningManagementSystem.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public int LearnerId { get; set; }
        public Learner Learner { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime EnrolledOn { get; set; }
    }
}
