using System.Threading.Tasks;
using AutoMapper;
using ElearningWebApp.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace ElearningWebApp.API.Controllers
{

    [Route("api/[controller]")]

    [ApiController]

    public class UserController: ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public UserController(IUserRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet("AllSubject/{classId}")]
        public async Task<IActionResult> GetAllSubject(int classId)
        {
            if(! await _repo.IsExistClass(classId))
                return BadRequest("Class doesn't Exist");

            var subjects = await _repo.GetAllSubjectsFromClass(classId);
            return Ok(subjects);
        }

        [HttpGet("GetAllChapter/{id}")]
        public async Task<IActionResult> GetAllChapter(int id)
        {
            if(! await _repo.IsExistSubjectInClass(id))
                return BadRequest("Subject doesn't Exist");
                
            var chapters = await _repo.GetChaptersBySubjectId(id);
            return Ok(chapters);
        }
    }
}