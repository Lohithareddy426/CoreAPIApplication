using CoreAPIApplication.Models;

namespace CoreAPIApplication.Interfaces
{
    public interface IAssigneeRepository
    {
        public List<Assignee> GetAssignees();

        public List<Assignee> AddAssignees(Assignee assignee);

        public List<Assignee> EditAssignees(Assignee assignee);
        public Assignee GetAssignee(int assigneeId);
        public int DeleteAssignee(int assigneeId);
        public bool VerifyAssignee(int id);
    }
}
