using ITIWebApi.BLL.Interfaces;
using ITIWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIWebApi.BLL.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        ITIContext _context;
        public GenericRepo(ITIContext context)
        {
            _context = context;
        }
        public void Add(T TEntity)
        {
            _context.Entry(TEntity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        }

        public void Delete(int? id)
        {
            var TEntity= _context.Set<T>().Find(id);
            _context.Entry(TEntity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
          
        }

        public T GetById(int? id)
        {
           return _context.Set<T>().Find(id);
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

      

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T TEntity)
        {
            _context.Entry(TEntity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
