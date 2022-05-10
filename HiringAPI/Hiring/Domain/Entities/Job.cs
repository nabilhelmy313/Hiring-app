using Domain.Entities.General;


namespace Domain.Entities
{
    public class Job:BaseEntity
    {
        public string JobTitle { get; set; }
        public DateTime ClosedDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Requirement { get; set; }
        public string JobType { get; set; }
        public string? Email { get; set; }
        public string? Language { get; set; }
        public string? Salary { get; set; }
        public string? Website { get; set; }
        public JobCategory  JobCategory { get; set; }

    }
}
