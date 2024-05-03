using ITIWebApi.BLL.Interfaces;
using ITIWebApi.BLL.Repositories;
using ITIWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIWebApi.Repository
{
    public class DepartmentRepo : GenericRepo<Department>, IDepartmentRepo
    {
        private readonly ITIContext _context;
        public DepartmentRepo(ITIContext context) : base(context)
        {
            _context = context;
        }

        public Department GetByName(string name)
        {
            return _context.Departments.FirstOrDefault(d=> d.Dept_Name == name);
        }
    }
}
