using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicaAPI.Interfaces
{
    public interface IGenericRepository<T,Q> where T : class where Q: IConvertible
    {
        Task<T> GetById(Q id);
        Task<IEnumerable<T>> GetAll();
        Task<List<T>> Find(Expression<Func<T, bool>> expression);
        Task Add(T entity);
        Task Remove(T entity);
    }
}
