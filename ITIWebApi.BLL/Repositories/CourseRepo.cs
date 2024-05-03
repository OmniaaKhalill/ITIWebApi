using ITIWebApi.BLL.Interfaces;
using ITIWebApi.BLL.Repositories;

using ITIWebApi.Models;

namespace ITIWebApi.Repository
{
    public class CourseRepo : GenericRepo<Course> , ICourseRepo
    {
        public CourseRepo(ITIContext context) : base(context)
        {
        }
    }
}
