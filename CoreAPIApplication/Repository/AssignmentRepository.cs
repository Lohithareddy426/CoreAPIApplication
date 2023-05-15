
using CoreAPIApplication.Interfaces;
using CoreAPIApplication.Models;

namespace CoreAPIApplication.Repository
{
    public class AssignmentRepository : IAssignmentRepository
    {
        public List<Assignment> Assignments = new List<Assignment>();

       // Assignment assignment1 = new Assignment( 1, "Test","", System.DateTime.Now, System.DateTime.Now.AddDays(5), "","" );
        
        private readonly ILogger<AssignmentRepository> _logger;
        public AssignmentRepository(ILogger<AssignmentRepository> logger)
        {

            _logger = logger;
        }

        public List<Assignment> GetAssignments()
        {

            return Assignments;
        }

        public List<Assignment> AddAssignment(Assignment assignment)
        {
            Assignments.Add(assignment);

            return Assignments;
        }

        public List<Assignment> EditAssignment(Assignment assignment)
        {
            Assignments.First(a => a.AssignmentId == assignment.AssignmentId).Status = assignment.Status;
            Assignments.First(a => a.AssignmentId == assignment.AssignmentId).StartDate = assignment.StartDate;
            Assignments.First(a => a.AssignmentId == assignment.AssignmentId).EndDate = assignment.EndDate;
            return Assignments;
        }

        public Assignment GetAssignment(int assignmentId)
        {
            return Assignments.FirstOrDefault(a => a.AssignmentId == assignmentId) ?? new Assignment  ();
        }

        public void DeleteAssignment(int assignmentId)
        {
            int NoOfAssignee = 0;
            if (Assignments.FirstOrDefault(a => a.AssignmentId == assignmentId) != null)
            {
                NoOfAssignee = Assignments.RemoveAll(a => a.AssignmentId == assignmentId);
            }
            else
            {
                _logger.LogInformation(" Not found Ássignment: {0}  ", assignmentId);
            }

            if (NoOfAssignee > 0)
            {
                _logger.LogInformation("Sucessfully deleted Ássignment : {0} ", assignmentId);
            }
            else
            {
                _logger.LogInformation("Failed delete of Ássignment : {0} ", assignmentId);
            }
        }

    }
}
