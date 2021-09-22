using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicaAPI.Interfaces;
using MusicaAPI.Models;

namespace MusicaAPI.Repositories
{
    //generic repository, implementing all basic functions, so the API could be extended rapidly by just adding new descendants of it
    public class GenericRepository<T, Q> : IGenericRepository<T, Q> where T : GenericEntity<Q> where Q : IComparable
    {
        protected readonly ApplicationDBContext _context;

        public GenericRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public virtual async Task<Q> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            int res = await _context.SaveChangesAsync();
            if (res > 0) return entity.ID;
            else return default(Q);
        }

        public virtual async Task<List<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetPage(int pageNumber, int pageSize)
        {
            return await _context.Set<T>()
                .Skip((pageNumber - 1) * pageSize)
               .Take(pageSize).ToListAsync();
        }

        public virtual Task<T> GetById(Q id)
        {
            return Task.FromResult(_context.Set<T>().Find(id));
        }

        public virtual async Task<Q> Remove(Q id)
        {
            var toRemove = _context.Set<T>().Find(id);
            if (toRemove != null)
            {
                _context.Set<T>().Remove(toRemove);
                int res = await _context.SaveChangesAsync();
                if (res > 0) return id;
            }
            return default(Q);
        }

        public virtual async Task<Q> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            int res = await _context.SaveChangesAsync();
            if (res > 0) return entity.ID;
            else return default(Q);
        }
    }
}
