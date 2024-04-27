using System.ComponentModel.DataAnnotations;

namespace ITIWebApi.DTO
{
    public class DeptDTO
    {
        public int Dept_Id { get; set; }
        public string Dept_Name { get; set; }
        public string Dept_Desc { get; set; }
        public string Dept_Location { get; set; }
        public string? Dept_Manager { get; set; }
        public DateOnly? Manager_hiredate { get; set; }
        public int Students_Count { get; set; }


    }
}
