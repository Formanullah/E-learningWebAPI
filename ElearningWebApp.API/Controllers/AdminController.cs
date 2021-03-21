using System.Threading.Tasks;
using AutoMapper;
using ElearningWebApp.API.Data;
using ElearningWebApp.API.Dtos;
using ELearningWebApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElearningWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ICourseRepository _repo;
        private readonly IMapper _mapper;
        public AdminController(ICourseRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpPost("AddSubject")]
        public async Task<IActionResult> AddSubject([FromForm] SubjectForCreationDto subjectForCreationDto)
        {
            if (await _repo.IsExistSubject(subjectForCreationDto.Name))
                return BadRequest("Subject Name already Exist");

            var file = subjectForCreationDto.File;

            var imagePath = _repo.AddImage(file, "Subject");
            var subjectToCreate = _mapper.Map<Subjects>(subjectForCreationDto);
            subjectToCreate.VirtualPath = imagePath.VirtualPath;
            subjectToCreate.FileName = imagePath.FileName;
            
            _repo.Add<Subjects>(subjectToCreate);

            if(await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Failed to add subject");

        }

    }
}