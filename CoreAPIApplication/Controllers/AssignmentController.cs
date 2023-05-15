using CoreAPIApplication.Interfaces;
using CoreAPIApplication.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreAPIApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private IAssignmentRepository _assignmentRepository { get; set; }
        public AssignmentController(IAssignmentRepository assignmentRepository) {
            _assignmentRepository = assignmentRepository;
        }


        // GET: api/<AssignmentController>
        [HttpGet]
        public IEnumerable<Assignment> Get()
        {
            return _assignmentRepository.GetAssignments();
        }

        // GET api/<AssignmentController>/5
        [HttpGet("{id}")]
        public Assignment Get(int id)
        {
            return _assignmentRepository.GetAssignment(id);
        }

        // POST api/<AssignmentController>
        [HttpPost]
        public IEnumerable<Assignment> Post([FromBody] Assignment assignment)
        {
            return _assignmentRepository.AddAssignment(assignment);
        }

        // PUT api/<AssignmentController>/5
        //[HttpPut("{id}")]
        [HttpPut]
        public IEnumerable<Assignment> Put([FromBody] Assignment assignment)
        {
            return _assignmentRepository.EditAssignment(assignment);
        }

        // DELETE api/<AssignmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _assignmentRepository.DeleteAssignment(id);
        }
    }
}
