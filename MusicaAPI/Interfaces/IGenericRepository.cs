using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicaAPI.Interfaces
{
    public interface IGenericRepository<T,Q> where T : class where Q: IComparable
    {
        Task<T> GetById(Q id);
        Task<IEnumerable<T>> GetAll();
        Task<List<T>> Find(Expression<Func<T, bool>> expression);
        Task<Q> Add(T entity);
        Task<Q> Update(T entity);
        Task<Q> Remove(Q id);
    }
}
