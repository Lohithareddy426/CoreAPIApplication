namespace CoreAPIApplication.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.MinValue;
        public string? Type { get; set; }
        public string? Status { get; set; }

        public Assignment() { }
        public Assignment(int assignmentId, string name, string description, DateTime startDate, DateTime endDate, string type, string status)
        {
            AssignmentId = assignmentId;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Type = type;
            Status = status;
        }
    }
}
