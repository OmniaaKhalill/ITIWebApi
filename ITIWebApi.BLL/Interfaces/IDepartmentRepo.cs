using ITIWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIWebApi.BLL.Interfaces
{
    public interface IDepartmentRepo:IGenericRepo<Department>
    {
        public Department GetByName(string name);
        //header of methods here
    }
}
