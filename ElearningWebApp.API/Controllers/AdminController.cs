using System;
using System.Threading.Tasks;
using AutoMapper;
using ElearningWebApp.API.Data;
using ElearningWebApp.API.Dtos;
using ELearningWebApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElearningWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles= "Admin")]
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
            if(subjectForCreationDto == null)
                return NoContent();

            if (await _repo.IsExistSubjectName(subjectForCreationDto.Name))
                return BadRequest("Subject Name already Exist");

            
            var subjectToCreate = _mapper.Map<Subjects>(subjectForCreationDto);
            
            
            _repo.Add<Subjects>(subjectToCreate);

            if(await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Failed to add subject");
            
        }


        // api/Admin/GetAllSubjects
        [HttpGet("GetAllSubjects")]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjects = await _repo.GetAllSubjects();
            return Ok(subjects);
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
        

        // api/Admin/AddSubjectForClass
        [HttpPost("AddSubjectForClass")]
        public async Task<IActionResult> AddSubjectForClass([FromForm] SubjectForClassCreationDto subjectForClassCreationDto)
        {
            if(subjectForClassCreationDto == null)
                return BadRequest();
            
            if(! await _repo.IsExistClass(subjectForClassCreationDto.ClassId))
                return BadRequest("Class Doesn't Exist");

            var createdClass = await _repo.GetClassById(subjectForClassCreationDto.ClassId);

            if( ! await _repo.IsExistSubject(subjectForClassCreationDto.SubjectId))
                return BadRequest("Subject Doesn't Exist");

            var subject = await _repo.GetSubjectById(subjectForClassCreationDto.SubjectId);   

            var subjectImage = subjectForClassCreationDto.SubjectImage;

            var imagePath = _repo.AddImage(subjectImage, "Subject");

            var createdSubjectForClass = _mapper.Map<SubjectForClass>(subjectForClassCreationDto);
            createdSubjectForClass.ClassName = createdClass.Name;
            createdSubjectForClass.SubjectName = subject.Name;
            createdSubjectForClass.VirtualPath = imagePath.VirtualPath;
            createdSubjectForClass.FileName = imagePath.FileName;
            createdSubjectForClass.CreatedDate = DateTime.Now;

            _repo.Add<SubjectForClass>(createdSubjectForClass);

            if(await _repo.SaveAll())
            {
                return Ok("Subject add in the class successfully");
            }

            return BadRequest("Failed to add subject in the class");
            
        }

        // api/Admin/GetAllSubjectsFromClass/1
        [HttpGet("GetAllSubjectsByClassId/{classId}")]
        public async Task<IActionResult> GetAllSubjectsByClassId(int classId)
        {
            if(! await _repo.IsExistClass(classId))
                return BadRequest("Class Doesn't Exist");

            var subjectsFromClass = await _repo.GetAllSubjectsFromClass(classId);
            return Ok(subjectsFromClass);
        }

        // api/Admin/DeleteSubjectInAClass/1/1
        [HttpDelete("DeleteSubjectInAClass/{classId}/{subjectId}")]
        public async Task<IActionResult> DeleteSubjectInAClass(int classId, int subjectId)
        {
            if (! await _repo.IsExistSubjectInClass(classId, subjectId))
                return BadRequest("Subject is not Exist");

            var subject = await _repo.GetSubjectFromClass(subjectId);
            _repo.Delete(subject);

            if(await _repo.SaveAll())
            {
                return Ok("Subject Delete Successfully");
            }
            return BadRequest("Failed to Delete this subject from class");
        }


        [HttpGet("GetAllClass")]
        public async Task<IActionResult> GetAllClass()
        {
            var classes = await _repo.GetAllClasses();
            return Ok(classes);
        }

        [HttpPost("AddChapter")]
        public async Task<IActionResult> AddChapter(ChapterCreationDto chapterCreationDto)
        {
            if(chapterCreationDto == null)
                return BadRequest();
            
            if(! await _repo.IsExistSubjectInClass(chapterCreationDto.SubjectForClassId))
                return BadRequest("Subject Doesn't belongs to the class");
            
            var subjectfromClass = await _repo.GetSubjectFromClass(chapterCreationDto.SubjectForClassId);

            var chapterToCreate = _mapper.Map<Chapters>(chapterCreationDto);
            chapterToCreate.SubjectName = subjectfromClass.SubjectName;
            chapterToCreate.ClassName = subjectfromClass.ClassName;

            _repo.Add<Chapters>(chapterToCreate);

            if(await _repo.SaveAll())
            {
                return Ok("Chapter add in the class successfully");
            }

            return BadRequest("Failed to add Chapter");

        }

        [HttpGet("GetAllChaptersBySubjectId")]
        public async Task<IActionResult> GetAllChaptersBySubjectId(int subjectId)
        {
            if(! await _repo.IsExistSubjectInClass(subjectId))
                return BadRequest("Subject Doesn't belongs to the class");

            var chapters = await _repo.GetChaptersBySubjectId(subjectId);
            return Ok(chapters);
        }

        [HttpDelete("DeleteChapter/{chapterId}")]
        public async Task<IActionResult> DeleteChapter(int chapterId)
        {
            if(! await _repo.IsExistChapter(chapterId))
                return BadRequest("Chapter doesn't Exist");
            
            var chapter = await _repo.GetChapter(chapterId);

            _repo.Delete(chapter);

            if(await _repo.SaveAll())
            {
                return Ok("Chpater Delete Successfully");
            }
            return BadRequest("Failed to Delete this Chpater");
        }


        [HttpPost("AddTopic")]
        public async Task<IActionResult> AddTopic(TopicCreationDto topicCreationDto)
        {
            if(topicCreationDto == null)
                return BadRequest();
            
            if(! await _repo.IsExistChapter(topicCreationDto.ChapterId))
                return BadRequest("Chapter doesn't Exist");

            var chapter = await _repo.GetChapter(topicCreationDto.ChapterId);

            var topicToCreate = _mapper.Map<Topics>(topicCreationDto);
            topicToCreate.ChapterName = chapter.Name;
            topicToCreate.ClassName = chapter.ClassName;
            topicToCreate.SubjctName = chapter.SubjectName;

            _repo.Add<Topics>(topicToCreate);

            if(await _repo.SaveAll())
            {
                return Ok("Topic add successfully");
            }

            return BadRequest("Failed to add topic");

        }

        [HttpGet("GetAllTopicsByChapterId/{chapterId}")]
        public async Task<IActionResult> GetAllTopicsByChapterId(int chapterId)
        {
            if(! await _repo.IsExistChapter(chapterId))
                return BadRequest("Chapter doesn't Exist");

            var topics = await _repo.GetAllTopicByChapterId(chapterId);
            return Ok(topics);
        }

        [HttpDelete("DeleteTopic/{topicId}")]
        public async Task<IActionResult> DeleteTopic(int topicId)
        {
            if(! await _repo.IsExistTopic(topicId))
                return BadRequest("Topic doesn't Exist");

            var topic = await _repo.GetTopicsById(topicId);
            _repo.Delete(topic);

            if(await _repo.SaveAll())
            {
                return Ok("Topic Delete Successfully");
            }
            return BadRequest("Failed to Delete this topic");
        }



    }
}