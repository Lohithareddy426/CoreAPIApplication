namespace CoreAPIApplication.Models
{
    public class ContractInfo
    {
        public int Id { get; set; }
        public int AssigneeId { get; set; }
        public int? AssignmentID { get; set; }
        public DateTime? StartDate { get; set; } = DateTime.MinValue;
        public DateTime? EndDate { get; set; } = DateTime.MinValue;
        public string? Status { get; set; }
        public string? Reason { get; set; }

        public ContractInfo() { }

    }
}
