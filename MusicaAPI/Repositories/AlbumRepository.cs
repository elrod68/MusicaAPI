using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicaAPI.Interfaces;
using MusicaAPI.Models;

namespace MusicaAPI.Repositories
{
    public class AlbumRepository : GenericRepository<Album, int>
    {

        public AlbumRepository(ApplicationDBContext context) : base(context) { }

        public override async Task<IEnumerable<Album>> GetAll()
        {
            return await _context.Set<Album>().Include("AlbumType").ToListAsync();
        }

        public override Task<Album> GetById(int id)
        {
            return Task.FromResult(_context.Set<Album>().Include("AlbumType").Where(t => t.ID == id).FirstOrDefault());
        }

        public async Task<IEnumerable<AlbumType>> GetAllAlbumTypes()
        {
            return await _context.Set<AlbumType>().ToListAsync();
        }
    }
}
