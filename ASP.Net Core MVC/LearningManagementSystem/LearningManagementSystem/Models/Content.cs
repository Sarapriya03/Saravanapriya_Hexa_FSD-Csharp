namespace LearningManagementSystem.Models
{
    public class Content
    {
        public int ContentId { get; set; }
        public string Title { get; set; }
        public string FileUrl { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
