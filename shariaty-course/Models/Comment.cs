namespace shariaty_course.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Professor { get; set; }
        public string? Field { get; set; }
        public string? Course { get; set; }
        public string? ProfessorPresence { get; set; }
        public string? PresenceAbsence { get; set; }
        public string? ProfessorBehavior { get; set; }
        public string? ClassResources { get; set; }
        public string? ExamResources { get; set; }
        public string? Homeworks { get; set; }
        public string? ResourcesEnough { get; set; }
        public string? TeachedEnough { get; set; }
        public string? Grading { get; set; }
        public string? Contact { get; set; }
        public string? Semester { get; set; }
        public string? Description { get; set; }
        public int? Score { get; set; }
    }
}
