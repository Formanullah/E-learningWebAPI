using System.Threading.Tasks;
using AutoMapper;
using ElearningWebApp.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace ElearningWebApp.API.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public HomeController(IUserRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet("GetAllSubject")]
        public async Task<IActionResult> GetAllSubject()
        {
            var subjects = await _repo.GetAllSubjects();
            return Ok(subjects);
        }

        [HttpGet("GetAllClass")]
        public async Task<IActionResult> GetAllClass()
        {
            var classes = await _repo.GetAllClasses();
            return Ok(classes);
        }

        [HttpGet("GetVideos/{id}")]
        public async Task<IActionResult> GetVideos(int id)
        {
            if(! await _repo.IsExistSubject(id))
                return BadRequest("Subject Doesn't exist");

            var videos = await _repo.GetVideoBySubjectId(id);
            return Ok(videos);
        }

        
    }
}