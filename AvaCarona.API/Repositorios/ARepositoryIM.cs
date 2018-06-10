using AvaCarona.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AvaCarona.API.Repositorios
{
    public abstract class ARepositoryIM<T> : IRepository<T> where T : AEntidadeBase
    {
        private List<T> _entidades { get; set; } = new List<T>();
        public int Count
        {
            get
            {
                return _entidades.Count;
            }
        }

        public T Add(T entity)
        {
            if (entity != null)
            {
                entity.Id = CalcularProximoId();
                _entidades.Add(entity);
                return entity;
            }
            return null;
        }

        public T Delete(T entity)
        {
            if (entity != null)
            {
                entity = GetById(entity.Id);

                _entidades.Remove(entity);
                return entity;
            }
            return null;
        }

        public T GetById(int id)
        {
            return _entidades.Where(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<T> ListarRepository()
        {
            return _entidades;
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            return _entidades.AsQueryable().Where(predicate);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _entidades.AsQueryable().Where(predicate).FirstOrDefault();

        }

        private int CalcularProximoId()
        {
            if (Count == 0) return 1;
            var UltimoId = _entidades[_entidades.Count - 1].Id;
            return UltimoId + 1;
        }

        
    }
}
