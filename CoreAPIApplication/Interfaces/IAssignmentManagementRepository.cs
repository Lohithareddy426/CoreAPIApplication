using CoreAPIApplication.Models;

namespace CoreAPIApplication.Interfaces
{
    public interface IAssignmentManagementRepository
    {
        public List<Assignment> Assignments(string status);
        public List<Assignee> GetAssigneesWithOutAssignments();
        public List<Assignee> GetAssigneesForGivenAssignment(int Assignmentid);
        public List<Assignee> AddAssignmentToResource(int AssignmentId, int AssigneeID);
    }
}
