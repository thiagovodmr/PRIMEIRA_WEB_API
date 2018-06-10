using AvaCarona.API.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaCarona.API.Repositorios
{
    public abstract class ARepositoryEF<T> : IRepository<T> where T : AEntidadeBase
    {
        private AppContext _context;

        public ARepositoryEF(AppContext context){
            _context = context;
        }


        public T Add(T entity)
        {
            var entry = _context.Add(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public T Delete(T entity)
        {
            var entry = _context.Remove(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var result = _context.Set<T>().AsNoTracking().Where(predicate).FirstOrDefault();
            return result;
        }

        public T GetById(int id)
        {
            var result = Get(c=> c.Id == id);
            return result;
        }

        public IEnumerable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
           return _context.Set<T>().AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<T> ListarRepository()
        {
            return List(p => true);
        }
    }
}
