using AvaCarona.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AvaCarona.API.Repositorios
{
    public interface IRepository<T> where T : AEntidadeBase
    {

        T Add(T entity);
        T Delete(T entity);

        T GetById(int id);

        T Get(Expression<Func<T, bool>> predicate);

        IEnumerable<T> ListarRepository();

        IEnumerable<T> List(Expression<Func<T, bool>> predicate);

    }
}
