using CoreAPIApplication.Models;

namespace CoreAPIApplication.Interfaces
{
    public interface IAssignmentRepository
    {
        public List<Assignment> GetAssignments();
        public List<Assignment> AddAssignment(Assignment assignment);
        public List<Assignment> EditAssignment(Assignment assignment);
        public Assignment GetAssignment(int assignmentId);
        public void DeleteAssignment(int assignmentId);
    }
}
