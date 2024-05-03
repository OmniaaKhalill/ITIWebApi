using ITIWebApi.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIWebApi.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICourseRepo CourseRepo { get;  }
        public IDepartmentRepo DepartmentRepo { get;  }
        public IStudentRepo StudentRepo { get; }
     
        
        public UnitOfWork (ICourseRepo courseRepo, IDepartmentRepo departmentRepo,  IStudentRepo studentRepo)
        {
            CourseRepo= courseRepo;
            DepartmentRepo= departmentRepo;
            StudentRepo= studentRepo;

        }

    }
}
