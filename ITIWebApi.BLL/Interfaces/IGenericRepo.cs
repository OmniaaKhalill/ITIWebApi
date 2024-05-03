


namespace ITIWebApi.BLL.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int? id);
   
        void Add(T obj);
        void Update(T obj);
        void Delete(int? id);
        void Save();

    }

}




