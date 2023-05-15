using CoreAPIApplication.Interfaces.v2;
using CoreAPIApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreAPIApplication.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class AssigneeController : ControllerBase
    {
        private IAssigneeRepository _assigneeRepository;
        public AssigneeController(IAssigneeRepository assigneeRepository) {
            _assigneeRepository = assigneeRepository;
        }
        
        [HttpGet]
        [Route("GetAssignees")]        
        public IActionResult  Get()
        {
            try { 
                if(_assigneeRepository.GetAssignees().Count() > 0)
                    return Ok(_assigneeRepository.GetAssignees());
                else 
                    return NotFound();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (_assigneeRepository.VerifyAssignee(id))
                {
                    return NotFound($"Assignee with Id {id} is not found in system");
                }
                else
                {
                    if (_assigneeRepository.GetAssignee(id) != null)
                        return Ok(_assigneeRepository.GetAssignee(id));
                    else
                        return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

      
        [HttpPost]
        public IActionResult Post([FromBody] Assignee assignee)
        {
            try
            {                
              List<Assignee> _assigneesList =  _assigneeRepository.AddAssignees(assignee);
                Assignee _assignee = _assigneeRepository.GetAssignee(assignee.AssigneeId);
                if (_assignee != null)
                    return Ok(_assignee);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    
        [HttpPut()]
        public IActionResult Put([FromBody] Assignee assignee)
        {
            try
            {
                if (_assigneeRepository.VerifyAssignee(assignee.AssigneeId))
                {
                    return NotFound($"Assignee with Id{assignee.AssigneeId} not found in system");
                }
                else {
                    List<Assignee> _assigneesList = _assigneeRepository.EditAssignees(assignee);

                    Assignee _assignee = _assigneeRepository.GetAssignee(assignee.AssigneeId);
                    if (_assignee != null)
                        return Ok(_assignee);
                    else
                        return NotFound();
                }               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete()]        
        public IActionResult Delete(int assigneeId)
        {
            try
            {
                var deleted = _assigneeRepository.DeleteAssignee(assigneeId);
                if (deleted > 0)
                    return Ok($"Assignee {assigneeId} successfully deleted");
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
