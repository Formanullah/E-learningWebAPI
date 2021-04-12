using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ElearningWebApp.API.Data;
using ElearningWebApp.API.Dtos;
using ELearningWebApp.API.Helpers;
using ELearningWebApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ElearningWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /* [Authorize(Roles= "Admin")] */
    public class AdminController : ControllerBase
    {
        private readonly ICourseRepository _repo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public AdminController(ICourseRepository repo, IMapper mapper,
        IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig;
            _mapper = mapper;
            _repo = repo;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);

        }

        // api/Admin/AddSubject
        [HttpPost("AddSubject")]
        public async Task<IActionResult> AddSubject(SubjectForCreationDto subjectForCreationDto)
        {
            if (subjectForCreationDto == null)
                return NoContent();

            if (await _repo.IsExistSubjectName(subjectForCreationDto.Name))
                return BadRequest("Subject Name already Exist");


            var subjectToCreate = _mapper.Map<Subjects>(subjectForCreationDto);


            _repo.Add<Subjects>(subjectToCreate);

            if (await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Failed to add subject");

        }


        [HttpPut("UpdateSubject")]
        public async Task<IActionResult> UpdateSubject(SubjectForUpdateDto subjectForUpdateDto)
        {
            if (!await _repo.IsExistSubject(subjectForUpdateDto.Id))
                return BadRequest("Subject is not Exist");

            var subjectFromRepo = await _repo.GetSubjectById(subjectForUpdateDto.Id);

            _mapper.Map(subjectForUpdateDto,subjectFromRepo);

            if(await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating Subject {subjectForUpdateDto.Id} failed on save");
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
            if (!await _repo.IsExistSubject(subjectId))
                return BadRequest("Subject is not Exist");

            var subject = await _repo.GetSubjectById(subjectId);
            _repo.Delete(subject);

            if (await _repo.SaveAll())
            {
                return Ok("Subject Delete Successfully");
            }
            return BadRequest("Failed to Delete this subject");
        }


        // api/Admin/AddSubjectForClass
        [HttpPost("AddSubjectInClass")]
        public async Task<IActionResult> AddSubjectInClass([FromForm] SubjectForClassCreationDto subjectForClassCreationDto)
        {
            if (subjectForClassCreationDto == null)
                return BadRequest();

            if (!await _repo.IsExistClass(subjectForClassCreationDto.ClassId))
                return BadRequest("Class Doesn't Exist");

            var createdClass = await _repo.GetClassById(subjectForClassCreationDto.ClassId);

            if (!await _repo.IsExistSubject(subjectForClassCreationDto.SubjectId))
                return BadRequest("Subject Doesn't Exist");

            if (await _repo.IsExistSubjectInClass(subjectForClassCreationDto.ClassId, subjectForClassCreationDto.SubjectId))
                return BadRequest("Subject Exist in this class");


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

            if (await _repo.SaveAll())
            {
                return Ok("Subject add in the class successfully");
            }

            return BadRequest("Failed to add subject in the class");

        }


        [HttpPut("UpdateSubjectInClass")]
        public async Task<IActionResult> UpdateSubjectInClass([FromForm] SubjectForClassUpdateDto subjectForClassUpdateDto)
        {
            if (!await _repo.IsExistSubjectInClass(subjectForClassUpdateDto.Id))
                return BadRequest("Subject doesn't not Exist");

            if (!await _repo.IsExistSubjectInClass(subjectForClassUpdateDto.ClassId, subjectForClassUpdateDto.SubjectId))
                return BadRequest("Subject is not Exist in this class");

             var createdClass = await _repo.GetClassById(subjectForClassUpdateDto.ClassId);

             var subject = await _repo.GetSubjectById(subjectForClassUpdateDto.SubjectId);

            var subjectforclass = await _repo.GetSubjectFromClass(subjectForClassUpdateDto.Id);

            var subjectImage = subjectForClassUpdateDto.SubjectImage;

            if(subjectImage != null)
            {

                // Delete from folder
                _repo.DeleteFromRoot(subjectforclass.VirtualPath);

                var imagePath = _repo.AddImage(subjectImage, "Subject");


                var createdSubjectForClass = _mapper.Map(subjectForClassUpdateDto, subjectforclass);
                createdSubjectForClass.ClassName = createdClass.Name;
                createdSubjectForClass.SubjectName = subject.Name;
                createdSubjectForClass.VirtualPath = imagePath.VirtualPath;
                createdSubjectForClass.FileName = imagePath.FileName;
                createdSubjectForClass.CreatedDate = DateTime.Now;
            }
            else
            {
                var createdSubjectForClass = _mapper.Map(subjectForClassUpdateDto, subjectforclass);
                createdSubjectForClass.ClassName = createdClass.Name;
                createdSubjectForClass.SubjectName = subject.Name;
                createdSubjectForClass.UpdateDate = DateTime.Now;
            }

            if(await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating Subject {subjectForClassUpdateDto.Id} failed on save");
        }

        // api/Admin/GetAllSubjectsFromClass/1
        [HttpGet("GetAllSubjectsByClassId/{classId}")]
        public async Task<IActionResult> GetAllSubjectsByClassId(int classId)
        {
            if (!await _repo.IsExistClass(classId))
                return BadRequest("Class Doesn't Exist");

            var subjectsFromClass = await _repo.GetAllSubjectsFromClass(classId);
            return Ok(subjectsFromClass);
        }

        // api/Admin/DeleteSubjectInAClass/1/1
        [HttpDelete("DeleteSubjectInAClass/{Id}")]
        public async Task<IActionResult> DeleteSubjectInAClass(int Id)
        {
            if (!await _repo.IsExistSubjectInClass(Id))
                return BadRequest("Subject is not Exist");

            var subject = await _repo.GetSubjectFromClass(Id);
            _repo.Delete(subject);

            if (await _repo.SaveAll())
            {
                _repo.DeleteFromRoot(subject.VirtualPath);
                return Ok("Subject Delete Successfully");
            }
            return BadRequest("Failed to Delete this subject from class");
        }

        [HttpPost("AddClass")]
        public async Task<IActionResult> AddClass(ClassCreationDto classs)
        {
            if(classs.Name != null)
            {
                var createdClass = _mapper.Map<Class>(classs);
                _repo.Add<Class>(createdClass);
            }
            
            if (await _repo.SaveAll())
            {
                return Ok("Class added successfully");
            }

            return BadRequest("Failed to add class");
        }

        [HttpGet("GetAllClass")]
        public async Task<IActionResult> GetAllClass()
        {
            var classes = await _repo.GetAllClasses();
            return Ok(classes);
        }

        [HttpPut("UpdateClass")]
        public async Task<IActionResult> UpdateClass(ClassCreationDto updatedCLass)
        {
            if(! await _repo.IsExistClass(updatedCLass.Id))
                return BadRequest("Class doesn't Exist");

            var classFromRepo = await _repo.GetClassById(updatedCLass.Id);
            classFromRepo.Name = updatedCLass.Name;

             if(await _repo.SaveAll())
                return Ok();

            throw new Exception($"Updating class {updatedCLass.Id} failed on save");
        }

        [HttpDelete("DeleteClass/{classid}")]
        public async Task<IActionResult> DeleteClass(int classid)
        {
            if(! await _repo.IsExistClass(classid))
                return BadRequest("Class doesn't Exist");

            var classFromRepo = await _repo.GetClassById(classid);

            _repo.Delete(classFromRepo); 

            if (await _repo.SaveAll())
            {
                return Ok("Class Delete Successfully");
            }
            return BadRequest("Failed to Delete this Class");
        }

        [HttpPost("AddChapter")]
        public async Task<IActionResult> AddChapter(ChapterCreationDto chapterCreationDto)
        {
            if (chapterCreationDto == null)
                return BadRequest();

            if (!await _repo.IsExistSubjectInClass(chapterCreationDto.SubjectForClassId))
                return BadRequest("Subject Doesn't Exist");

            var subjectfromClass = await _repo.GetSubjectFromClass(chapterCreationDto.SubjectForClassId);

            var chapterToCreate = _mapper.Map<Chapters>(chapterCreationDto);
            chapterToCreate.SubjectName = subjectfromClass.SubjectName;
            chapterToCreate.ClassName = subjectfromClass.ClassName;
            chapterToCreate.ClassId = subjectfromClass.ClassId;

            _repo.Add<Chapters>(chapterToCreate);

            if (await _repo.SaveAll())
            {
                return Ok("Chapter add in the class successfully");
            }

            return BadRequest("Failed to add Chapter");

        }

        // bring data by subjectIdForClass from Chapter table
        [HttpGet("GetAllChaptersBySubjectId/{id}")]
        public async Task<IActionResult> GetAllChaptersBySubjectId(int id)
        {
            if (!await _repo.IsExistSubjectInClass(id))
                return BadRequest("Subject Doesn't exist");

            var chapters = await _repo.GetChaptersBySubjectId(id);
            return Ok(chapters);
        }

        [HttpPut("UpdateChapter")]
        public async Task<IActionResult> UpdateChapter(ChapterForUpdateDto chapterForUpdateDto)
        {
            if (!await _repo.IsExistSubjectInClass(chapterForUpdateDto.SubjectForClassId))
                return BadRequest("Subject Doesn't Exist");
                
            var subjectFromClass = await _repo.GetSubjectFromClass(chapterForUpdateDto.SubjectForClassId);


            if (!await _repo.IsExistChapter(chapterForUpdateDto.Id))
                return BadRequest("Chapter doesn't Exist");

            var chapterFromRepo = await _repo.GetChapter(chapterForUpdateDto.Id);

            var updatedChapter = _mapper.Map(chapterForUpdateDto, chapterFromRepo);
            updatedChapter.ClassName = subjectFromClass.ClassName;
            updatedChapter.ClassId = subjectFromClass.ClassId;
            updatedChapter.SubjectName = subjectFromClass.SubjectName;

            if(await _repo.SaveAll())
                return Ok();

            throw new Exception($"Updating Chapter {chapterForUpdateDto.Id} failed on save");
            

        }

        [HttpDelete("DeleteChapter/{chapterId}")]
        public async Task<IActionResult> DeleteChapter(int chapterId)
        {
            if (!await _repo.IsExistChapter(chapterId))
                return BadRequest("Chapter doesn't Exist");

            var chapter = await _repo.GetChapter(chapterId);

            _repo.Delete(chapter);

            if (await _repo.SaveAll())
            {
                return Ok("Chpater Delete Successfully");
            }
            return BadRequest("Failed to Delete this Chpater");
        }


        [HttpPost("AddTopic")]
        public async Task<IActionResult> AddTopic(TopicCreationDto topicCreationDto)
        {
            if (topicCreationDto == null)
                return BadRequest();

            if (!await _repo.IsExistChapter(topicCreationDto.ChapterId))
                return BadRequest("Chapter doesn't Exist");

            var chapter = await _repo.GetChapter(topicCreationDto.ChapterId);

            var topicToCreate = _mapper.Map<Topics>(topicCreationDto);
            topicToCreate.ChapterName = chapter.Name;
            topicToCreate.ClassName = chapter.ClassName;
            topicToCreate.ClassId = chapter.ClassId;
            topicToCreate.SubjctName = chapter.SubjectName;
            topicToCreate.SubjectIdInClass = chapter.SubjectForClassId;

            _repo.Add<Topics>(topicToCreate);

            if (await _repo.SaveAll())
            {
                return Ok("Topic add successfully");
            }

            return BadRequest("Failed to add topic");

        }

        [HttpGet("GetAllTopicsByChapterId/{chapterId}")]
        public async Task<IActionResult> GetAllTopicsByChapterId(int chapterId)
        {
            if (!await _repo.IsExistChapter(chapterId))
                return BadRequest("Chapter doesn't Exist");

            var topics = await _repo.GetAllTopicByChapterId(chapterId);
            return Ok(topics);
        }

        [HttpPut("UpdateTopic")]
        public async Task<IActionResult> UpdateTopic(TopicForUpdateDto topicForUpdateDto)
        {
            if (!await _repo.IsExistTopic(topicForUpdateDto.Id))
                return BadRequest("Topic doesn't Exist");

            if (!await _repo.IsExistChapter(topicForUpdateDto.ChapterId))
                return BadRequest("Chapter doesn't Exist");
            
            var chapterFromRepo = await _repo.GetChapter(topicForUpdateDto.ChapterId);

            var topicFromRepo = await _repo.GetTopicsById(topicForUpdateDto.Id);

            var updatedTopic = _mapper.Map(topicForUpdateDto, topicFromRepo);
            updatedTopic.ChapterName = chapterFromRepo.Name;
            updatedTopic.ClassName = chapterFromRepo.ClassName;
            updatedTopic.ClassId = chapterFromRepo.ClassId;
            updatedTopic.SubjctName = chapterFromRepo.SubjectName;
            updatedTopic.SubjectIdInClass = chapterFromRepo.SubjectForClassId;

            if(await _repo.SaveAll())
                return Ok();

            throw new Exception($"Updating Topic {topicForUpdateDto.Id} failed on save");
        }

        [HttpDelete("DeleteTopic/{topicId}")]
        public async Task<IActionResult> DeleteTopic(int topicId)
        {
            if (!await _repo.IsExistTopic(topicId))
                return BadRequest("Topic doesn't Exist");

            var topic = await _repo.GetTopicsById(topicId);
            _repo.Delete(topic);

            if (await _repo.SaveAll())
            {
                return Ok("Topic Delete Successfully");
            }
            return BadRequest("Failed to Delete this topic");
        }

        // private MaxFileSize = 10L * 1024L * 1024L * 1024L; // 10GB, adjust to your need

        [HttpPost("AddVideo")]
        [RequestSizeLimit(10L * 1024L * 1024L * 1024L)]
        [RequestFormLimits(MultipartBodyLengthLimit = 10L * 1024L * 1024L * 1024L)]
        public async Task<IActionResult> AddVideo([FromForm] VideoForCreationDto videoForCreationDto)
        {
            if (!await _repo.IsExistClass(videoForCreationDto.ClassId))
                return BadRequest("Class Doesn't Exist");

            if (!await _repo.IsExistSubjectInClass(videoForCreationDto.ClassId, videoForCreationDto.SubjectIdInClass))
                return BadRequest("Subject is not Exist in this class");

            if (!await _repo.IsExistChapter(videoForCreationDto.ChapterId))
                return BadRequest("Chapter doesn't Exist");

            if (!await _repo.IsExistTopic(videoForCreationDto.TopicId))
                return BadRequest("Topic doesn't Exist");

            var topic = await _repo.GetTopicsById(videoForCreationDto.TopicId);

            var file = videoForCreationDto.File;
            var uploadResult = new VideoUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {

                    var uploadParams = new VideoUploadParams()
                    {
                        File = new FileDescription(file.FileName, stream),
                        /* Transformation = new Transformation()
                        .Width(500).Height(500).Crop("fill").Gravity("face"), */
                        EagerTransforms = new List<Transformation>()
                        {
                            new EagerTransformation().Width(300).Height(300).Crop("pad").AudioCodec("none"),
                            new EagerTransformation().Width(160).Height(100).Crop("crop").Gravity("south").AudioCodec("none")},
                        EagerAsync = true
                    };

                    uploadResult = _cloudinary.UploadLarge(uploadParams);
                }
            }

            var videoToCreate = _mapper.Map<Videos>(videoForCreationDto);
            videoToCreate.Url = uploadResult.Uri.ToString();
            videoToCreate.PublicId = uploadResult.PublicId;
            videoToCreate.ChapterName = topic.ChapterName;
            videoToCreate.ClassName = topic.ClassName;
            videoToCreate.CreatedDate = DateTime.Now;
            videoToCreate.SubjectName = topic.SubjctName;
            videoToCreate.TopicName = topic.Name;


            _repo.Add<Videos>(videoToCreate);

            if (await _repo.SaveAll())
            {
                return Ok("Video add successfully");
            }

            return BadRequest("Failed to add Video");


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo(int id)
        {

            var videoFromRepo = await _repo.GetVideo(id);

            if (videoFromRepo == null)
                return BadRequest("No Video found");

            if (videoFromRepo.PublicId != null)
            {
                var deleteParams = new DeletionParams(videoFromRepo.PublicId);

                var result = _cloudinary.Destroy(deleteParams);

                if (result.Result == "ok")
                {
                    _repo.Delete(videoFromRepo);
                }
            }

            if (videoFromRepo.PublicId == null)
            {
                _repo.Delete(videoFromRepo);
            }

            if (await _repo.SaveAll())
            {
                return Ok();
            }
            return BadRequest("Failed to Delete this Video");
        }


    }
}