using CoreAPIApplication.Controllers;
using CoreAPIApplication.Data;
using CoreAPIApplication.Interfaces.v2;
using CoreAPIApplication.Models;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace CoreAPIApplication.Repository.v2
{
    public class AssigneeRepository : IAssigneeRepository
    {
       

        private readonly ILogger<AssigneeRepository> _logger;
        private readonly ContractsDbContext _contractsDbContext;

        public AssigneeRepository(ILogger<AssigneeRepository> logger, ContractsDbContext contractsDbContext) {

            _logger = logger;
            _contractsDbContext = contractsDbContext;
        }       

        public List<Assignee> GetAssignees(){

            return _contractsDbContext.Assignees.ToList();
        }

        public List<Assignee> AddAssignees(Assignee assignee)
        {
            List<Assignee> assignees = _contractsDbContext.Assignees.ToList();
            
            _contractsDbContext.Assignees.Add(assignee);
            _contractsDbContext.SaveChanges();
            return assignees;
        }

        public List<Assignee> EditAssignees(Assignee assignee)
        {
            List<Assignee> Assignees = _contractsDbContext.Assignees.ToList();
            //Assignees.First(a => a.AssigneeId == assignee.AssigneeId).AssignmentID = assignee.AssignmentID;
            Assignees.First(a => a.AssigneeId == assignee.AssigneeId).Status = assignee.Status;
            // Assignees.First(a => a.AssigneeId == assignee.AssigneeId).StartDate = assignee.StartDate;
            // Assignees.First(a => a.AssigneeId == assignee.AssigneeId).EndDate = assignee.EndDate;
            _contractsDbContext.SaveChanges();
            return Assignees;
        }

        public bool VerifyAssignee(int id)
        {
            List<Assignee> Assignees = _contractsDbContext.Assignees.ToList();
            return Assignees.Find(a => a.AssigneeId == id) == null;
        }
        public Assignee GetAssignee(int assigneeId )
        {
            List<Assignee> Assignees = _contractsDbContext.Assignees.ToList();
            return Assignees.FirstOrDefault(a => a.AssigneeId == assigneeId)?? new Assignee();
        }

        public int DeleteAssignee(int assigneeId)
        {
            List<Assignee> Assignees = _contractsDbContext.Assignees.ToList();
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
            _contractsDbContext.SaveChanges();
            return NoOfAssignee;
        }
    }
}
