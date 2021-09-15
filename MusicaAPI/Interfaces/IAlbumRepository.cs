using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicaAPI.Models;

namespace MusicaAPI.Interfaces
{
    public interface IRepository<T,Q> where T:Album
    {
        Task<List<T>> GetAll();

        Task<T> GetSingle(Q ID);

        Task<T> Add(T album);

        Task<T> Update(T album);

        Task<T> Delete(Q ID);
    }
}
