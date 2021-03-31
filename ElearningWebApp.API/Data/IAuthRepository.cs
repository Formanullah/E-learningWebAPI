using System.Collections.Generic;
using System.Threading.Tasks;
using ELearningWebApp.API.Models;

namespace ElearningWebApp.API.Data
{
    public interface IAuthRepository
    {
         Task<Students> Register(Students student,string password);
         Task<Students> Login(string mobileNo,string password);
         Task<bool> IsUserExists(string mobileNo);
         Task<Admins> AdminLogIn(string username, string password);

         Task<bool> IsExistsAdmin(string username);

         Task<Admins> AddAdmin(Admins admin, string password);

         Task<bool> IsExistClass(int id);
         Task<Class> GetClassById(int id);

         Task<ICollection<Students>> GetAllStudent();
         Task<Students> GetStudentById(int id);

         Task<bool> IsExistStudent(int id);
    }
}