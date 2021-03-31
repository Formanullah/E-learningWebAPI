using System.Collections.Generic;
using System.Threading.Tasks;
using ELearningWebApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ElearningWebApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ElearningWebAppdbContext _context;
        public AuthRepository(ElearningWebAppdbContext context)
        {
            _context = context;

        }
        public async Task<Admins> AdminLogIn(string username, string password)
        {
            var user = await _context.Admins.Include(r => r.Role).FirstOrDefaultAsync(x => x.Name == username);
            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<Students> Login(string mobileNo, string password)
        {
            var user = await _context.Students.Include(r => r.Role).FirstOrDefaultAsync(x => x.MobileNo == mobileNo);
            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac= new System.Security.Cryptography.HMACSHA512(passwordSalt)) //for hashing password using password sslt
            {
                var computedHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i])
                    return false;
                }
            }
            return true;
        }

        public async Task<Students> Register(Students student, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            student.PasswordHash=passwordHash;
            student.PasswordSalt=passwordSalt;

            await _context.Students.AddAsync(student); //save user
            await _context.SaveChangesAsync();//save changes back to the database
            return student;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
           using (var hmac= new System.Security.Cryptography.HMACSHA512()) //for hashing password
            {
                passwordSalt=hmac.Key; //rendomly generate key
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> IsUserExists(string mobileNo)
        {
            if(await _context.Students.AnyAsync(x => x.MobileNo == mobileNo))
                return true;

            return false;
        }

        public async Task<bool> IsExistsAdmin(string username)
        {
            if(await _context.Admins.AnyAsync(x => x.Name == username))
                return true;

            return false;
        }

        public async Task<bool> IsExistClass(int id)
        {
            if (await _context.Class.AnyAsync(x => x.Id == id))
                return true;

            return false;
        }

        public async Task<Class> GetClassById(int id)
        {
            var classFromClass = await _context.Class.FindAsync(id);
            return classFromClass;
        }

        public async Task<Admins> AddAdmin(Admins admin, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            admin.PasswordHash=passwordHash;
            admin.PasswordSalt=passwordSalt;

            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
            return admin;
            
        }

        public async Task<ICollection<Students>> GetAllStudent()
        {
            var students = await _context.Students.ToListAsync();
            return students;
        }


        public async Task<Students> GetStudentById(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            return student;
        }

        public async Task<bool> IsExistStudent(int id)
        {
            if(await _context.Students.AnyAsync(x => x.Id == id))
                return true;

            return false;
        }
    }
}