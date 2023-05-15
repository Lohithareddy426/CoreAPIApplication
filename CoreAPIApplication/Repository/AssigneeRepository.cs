using CoreAPIApplication.Controllers;
using CoreAPIApplication.Interfaces;
using CoreAPIApplication.Models;
using System.Data.SqlTypes;

namespace CoreAPIApplication.Repository
{
    public class AssigneeRepository : IAssigneeRepository
    {
        public List<Assignee> Assignees = new List<Assignee>();

        private readonly ILogger<AssigneeRepository> _logger;
        
        public AssigneeRepository(ILogger<AssigneeRepository> logger) {

            _logger = logger;
        }       

        public List<Assignee> GetAssignees(){

            return Assignees;
        }

        public List<Assignee> AddAssignees(Assignee assignee)
        {
            if(assignee.AssigneeId == 0)
            {
                var highestId = Assignees.Any() ? Assignees.Max(x => x.AssigneeId) : 0;
                assignee.AssigneeId = highestId + 1;
            }            
            Assignees.Add(assignee);
            return Assignees;
        }

        public List<Assignee> EditAssignees(Assignee assignee)
        {
            //Assignees.First(a => a.AssigneeId == assignee.AssigneeId).AssignmentID = assignee.AssignmentID;
            Assignees.First(a => a.AssigneeId == assignee.AssigneeId).Status = assignee.Status;
           // Assignees.First(a => a.AssigneeId == assignee.AssigneeId).StartDate = assignee.StartDate;
           // Assignees.First(a => a.AssigneeId == assignee.AssigneeId).EndDate = assignee.EndDate;
            return Assignees;
        }

        public bool VerifyAssignee(int id)
        {
            return Assignees.Find(a => a.AssigneeId == id) == null;
        }
        public Assignee GetAssignee(int assigneeId )
        {
            return Assignees.FirstOrDefault(a => a.AssigneeId == assigneeId)?? new Assignee();
        }

        public int DeleteAssignee(int assigneeId)
        {
            int NoOfAssignee = 0;
            if (Assignees.FirstOrDefault(a => a.AssigneeId == assigneeId) != null )
            {
               NoOfAssignee = Assignees.RemoveAll( a => a.AssigneeId == assigneeId);
            }
            else
            {
                _logger.LogInformation(" Not found Ássignee : {0}  ", assigneeId);
            }
            
            if(NoOfAssignee > 0)
            {
                _logger.LogInformation("Sucessfully deleted Ássignee : {0} ", assigneeId);
            }
            else
            {
                _logger.LogInformation("Failed delete of Ássignee : {0} ", assigneeId);
            }
            return NoOfAssignee;
        }
    }
}
