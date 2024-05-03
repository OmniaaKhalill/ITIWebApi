using ITIWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIWebApi.BLL.Interfaces
{
    public interface IStudentRepo:IGenericRepo<Student>
    {
        public Student GetByName(string name);

    }
}
