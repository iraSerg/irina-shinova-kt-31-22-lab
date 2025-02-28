using Microsoft.AspNetCore.Mvc;
using ShinovaIrinaKt_31_22.Models;
using ShinovaIrinaKt_31_22.Services;
using ShinovaIrinaKt_31_22.Dto;

namespace ShinovaIrinaKt_31_22.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeacherController : ControllerBase
    {
        private readonly TeacherService _teacherService;

        public TeacherController(TeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers([FromQuery] TeacherFilterDto filter)
        {
            var teachers = await _teacherService.GetTeachers(filter);
            return Ok(teachers);
        }
    }
}
