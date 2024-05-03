using ITIWebApi.BLL.Interfaces;
using ITIWebApi.BLL.Repositories;
using ITIWebApi.Models;

namespace ITIWebApi.Repository
{
    public class StudentRepo : GenericRepo<Student>, IStudentRepo
    {
        private readonly ITIContext _context;
        public StudentRepo(ITIContext context) : base(context)
        {
            _context = context;
        }

        public Student GetByName(string name)
        {
           return _context.Students.FirstOrDefault(s => s.St_Fname == name);
        }
    }
}
