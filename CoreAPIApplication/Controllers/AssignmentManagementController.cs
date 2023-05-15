using CoreAPIApplication.Interfaces;
using CoreAPIApplication.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreAPIApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentManagementController : ControllerBase
    {
        private IAssignmentManagementRepository _assignmentManagementRepository;

        public AssignmentManagementController(IAssignmentManagementRepository assignmentManagementRepository)
        {
            _assignmentManagementRepository = assignmentManagementRepository;
        }

        // GET: api/<AssignmentManagementController>
        //[Route("api/[controller]/AssignmentsBasedonStatus")]
        [HttpGet("{status}")]
        public IEnumerable<Assignment> GetActiveAssignments(string status)
        {
            return _assignmentManagementRepository.Assignments(status);
        }

        [HttpGet]
        public IEnumerable<Assignee> GetAssigneesWithoutAssignment()
        {
            return _assignmentManagementRepository.GetAssigneesWithOutAssignments();
        }

        [HttpGet("{AssignmentId:int}")]
        public IEnumerable<Assignee> GetAssigneesForGivenAssignment(int AssignmentId)
        {
            return _assignmentManagementRepository.GetAssigneesForGivenAssignment(AssignmentId);
        }

        [HttpPut("{AssignmentId},{AssigneeId}")]
        public IEnumerable<Assignee> AddAssigneeToTheAssignment(int AssignmentId, int AssigneeId)
        {
            return _assignmentManagementRepository.AddAssignmentToResource(AssignmentId, AssigneeId);
        }

    }
}
