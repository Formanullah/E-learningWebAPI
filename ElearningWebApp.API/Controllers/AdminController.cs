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

        // api/Admin/AddSubject
        [HttpPost("AddSubject")]
        public async Task<IActionResult> AddSubject(SubjectForCreationDto subjectForCreationDto)
        {
            if(subjectForCreationDto != null)
            {
                if (await _repo.IsExistSubjectName(subjectForCreationDto.Name))
                return BadRequest("Subject Name already Exist");

            // var file = subjectForCreationDto.File;

            // var imagePath = _repo.AddImage(file, "Subject");
            var subjectToCreate = _mapper.Map<Subjects>(subjectForCreationDto);
            /* subjectToCreate.VirtualPath = imagePath.VirtualPath;
            subjectToCreate.FileName = imagePath.FileName; */
            
            _repo.Add<Subjects>(subjectToCreate);

            if(await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Failed to add subject");
            }

            return BadRequest();
            

        }

        [HttpDelete("DeleteSubject/{subjectId}")]
        public async Task<IActionResult> DeleteSubject(int subjectId)
        {
            if (! await _repo.IsExistSubject(subjectId))
                return BadRequest("Subject is not Exist");

            var subject = await _repo.GetSubjectById(subjectId);
            _repo.Delete(subject);

            if(await _repo.SaveAll())
            {
                return Ok("Subject Delete Successfully");
            }
            return BadRequest("Failed to Delete this subject");
        }
        
        // api/Admin/GetAllSubjects
        [HttpGet("GetAllSubjects")]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjects = await _repo.GetAllSubjects();
            return Ok(subjects);
        }

        [HttpPost("AddSubjectForClass")]
        public async Task<IActionResult> AddSubjectForClass(SubjectForClassCreationDto subjectForClassCreationDto)
        {
            if(await _repo.IsExistSubjectNameInClass(subjectForClassCreationDto.ClassId, subjectForClassCreationDto.SubjectName))
                return BadRequest("Subject Exist for this Class");

            var createdSubjectForClass = _mapper.Map<SubjectForClass>(subjectForClassCreationDto);
            return Ok(createdSubjectForClass);
            
        }



    }
}