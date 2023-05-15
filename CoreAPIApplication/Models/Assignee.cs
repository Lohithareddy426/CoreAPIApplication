using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoreAPIApplication.Models
{
    public class Assignee
    {
        public int AssigneeId { get; set; } 
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string AssigneeEmail { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string ContactNumber { get; set; } = string.Empty;
        public StatusType Status { get; set; }
       
        public Assignee() { }
        public Assignee(int assigneeId, string firstName,string lastName, string assigneeEmail, string contactNumber, StatusType status)
        {   
            AssigneeId = assigneeId;
            FirstName = firstName;
            LastName = lastName;
            AssigneeEmail = assigneeEmail;
            ContactNumber = contactNumber;
            Status = status;            
        }
        public enum StatusType
        {
            OnBoarding = 0,
            WaitingForAssignment,
            WrokingInAssignment
        }

    }
}
