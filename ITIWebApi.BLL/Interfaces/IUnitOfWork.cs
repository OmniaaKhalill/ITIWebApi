

namespace ITIWebApi.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        public ICourseRepo CourseRepo { get; }
        public IDepartmentRepo DepartmentRepo { get; }
        public IStudentRepo StudentRepo { get; }


    }
}
