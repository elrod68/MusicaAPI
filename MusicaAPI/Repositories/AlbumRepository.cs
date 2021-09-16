using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;
using MusicaAPI.Interfaces;
using MusicaAPI.Models;

namespace MusicaAPI.Repositories
{
    public class AlbumRepository : IRepository<Album, int>
    {
        private readonly ApplicationDBContext _context;

        public AlbumRepository(ApplicationDBContext context)
        {
            _context = context;   
        }

        public Task<Album> Add(Album album)
        {
            throw new NotImplementedException();
        }

        public Task<Album> Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Album>> GetAll()
        {
            try
            {
                using (var context = _context)
                {
                    var albums = context.Albums.ToList();
                  
                    return albums;
                }
            }
            catch (Exception ex) // catch any error and report
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "API execution failed"
                };
                throw new HttpResponseException(resp);
            }
        }

        public Task<Album> GetSingle(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<Album> Update(Album album)
        {
            throw new NotImplementedException();
        }
    }
}
