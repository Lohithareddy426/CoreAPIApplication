using CoreAPIApplication.Interfaces;
using CoreAPIApplication.Models;

namespace CoreAPIApplication.Repository
{
    public class AssignmentManagementRepository : IAssignmentManagementRepository
    {
        private IAssigneeRepository _assigneeRepository;
        private IAssignmentRepository _assignmentRepository;
        public AssignmentManagementRepository(IAssigneeRepository assigneeRepository, IAssignmentRepository assignmentRepository)
        {
            _assigneeRepository = assigneeRepository;
            _assignmentRepository = assignmentRepository;
        }

        public List<Assignment> Assignments(string status)
        {
            List<Assignment> filteredAssignments = _assignmentRepository.GetAssignments().FindAll(a => a.Status == status);
            return filteredAssignments;
        }
        public List<Assignee> GetAssigneesWithOutAssignments()
        {
            List<Assignee> assignees = _assigneeRepository.GetAssignees();
            return assignees;
        }

        public List<Assignee> GetAssigneesForGivenAssignment(int Assignmentid)
        {
            List<Assignee> assignees = _assigneeRepository.GetAssignees();
            return assignees;
        }

        public List<Assignee> AddAssignmentToResource(int AssignmentId, int AssigneeID)
        {
            List<Assignee> assignees = _assigneeRepository.GetAssignees().FindAll(a => a.AssigneeId == AssigneeID);
           // assignees.ForEach(a => { a.AssignmentID = AssignmentId; });
            return assignees;
        }



    }
}
