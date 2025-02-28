using Microsoft.AspNetCore.Mvc;
using ShinovaIrinaKt_31_22.Dto;
using ShinovaIrinaKt_31_22.Models;
using ShinovaIrinaKt_31_22.Services;
namespace ShinovaIrinaKt_31_22.Controllers
{
    [ApiController]
    [Route("api/subjects")]
    public class SubjectController : ControllerBase
    {
        private readonly SubjectService _subjectService;

        public SubjectController(SubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<PageResponseDto<Subject>>> GetSubjects([FromQuery] PageRequestDto pageRequest)
        {
            var pagedResponse = await _subjectService.GetAllSubjects(pageRequest);
            return Ok(pagedResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            var subject = await _subjectService.GetSubjectById(id);

            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult<Subject>> CreateSubject(Subject subject)
        {
            var newSubject = await _subjectService.CreateSubject(subject);

            return CreatedAtAction(nameof(GetSubject), new { id = newSubject.SubjectId }, newSubject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int id, Subject subject) { 
        
            if (id != subject.SubjectId)
            {
                return BadRequest();
            }

            var updateSubject= await _subjectService.UpdateSubject(subject);

            if (updateSubject == null)
            {
                return NotFound();
            }

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var result = await _subjectService.DeleteSubject(id);

            if (!result)
            {
                return NotFound(); 
            }

            return NoContent(); 
        }
    }
}
