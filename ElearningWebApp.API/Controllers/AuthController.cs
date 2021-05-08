using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ElearningWebApp.API.Data;
using ElearningWebApp.API.Dtos;
using ELearningWebApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ElearningWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet("GetAllStudent")]
        public async Task<IActionResult> GetAllStudent()
        {
            var students = await _repo.GetAllStudent();
            return Ok(students);
        }

        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {

            if (! await _repo.IsExistStudent(id))
                return BadRequest("Student doesn't exist");
            
            var student = await _repo.GetStudentById(id);
            return Ok(student);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(StudentForRegisterDto studentForRegisterDto)
        {
            if (studentForRegisterDto == null)
                return BadRequest();

            if (await _repo.IsUserExists(studentForRegisterDto.MobileNo))
                return BadRequest("User already Exist");

            if (!await _repo.IsExistClass(studentForRegisterDto.ClassId))
                return BadRequest("Class Doesn't Exist");

            var userToCreate = _mapper.Map<Students>(studentForRegisterDto);

            var stClass = await _repo.GetClassById(studentForRegisterDto.ClassId);
            userToCreate.ClassName = stClass.Name;
            userToCreate.RoleId = 1; //Role 1 means student

            var createdUser = await _repo.Register(userToCreate, studentForRegisterDto.Password);
            /* var userToReturn = _mapper.Map<UserForDetailedDto>(userToCreate);

            return CreatedAtRoute("GetUser", new{Controller = "Users", id =userToCreate.Id}, userToReturn); */

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(StudentForLoginDto studentForLoginDto)
        {
            var userFromRepo = await _repo.Login(studentForLoginDto.MobileNo, studentForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

           
           var token = GenerateToken(userFromRepo.Name, userFromRepo.Role.RoleName);
            var user = _mapper.Map<StudentForReturnDto>(userFromRepo);

            return Ok(new {
                token,
                user
            });
        }

        private string GenerateToken(string name, string role)
        {
             var claims = new[]
            {
                // new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenToCreate = tokenHandler.CreateToken(tokenDescriptor);
            
            var token = tokenHandler.WriteToken(tokenToCreate);

            HttpContext.Session.SetString("token",token);
            return token;
        }

        [HttpPost("AddAdmin")]
        public async Task<IActionResult> AddAdmin(AdminAddDto admin)
        {
            if (admin == null)
                return BadRequest();

            if (await _repo.IsExistsAdmin(admin.Name))
                return BadRequest("Admin already Exist");

            var AdminToCreate = _mapper.Map<Admins>(admin);
            AdminToCreate.RoleId = 2; //Role 2 means Admin

            var createdAdmin = await _repo.AddAdmin(AdminToCreate, admin.Password);
            /* var userToReturn = _mapper.Map<UserForDetailedDto>(userToCreate);

            return CreatedAtRoute("GetUser", new{Controller = "Users", id =userToCreate.Id}, userToReturn); */

            return Ok();

            
        }

        [HttpPost("AdminLogin")]
        public async Task<IActionResult> AdminLogin(AdminAddDto adminAddDto)
        {
            var adminFromRepo = await _repo.AdminLogIn(adminAddDto.Name, adminAddDto.Password);

            if (adminFromRepo == null)
                return Unauthorized();

           
            var token = GenerateToken(adminFromRepo.Name, adminFromRepo.Role.RoleName);
            var user = _mapper.Map<AdminForReturnDto>(adminFromRepo);

            return Ok(new {
                token,
                user
            });
        }
    }
}