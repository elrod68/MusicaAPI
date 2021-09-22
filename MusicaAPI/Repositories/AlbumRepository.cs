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
    //the main album repository, just implements album type specific methods
    public class AlbumRepository : GenericRepository<Album, int>
    {

        public AlbumRepository(ApplicationDBContext context) : base(context) { }

        public async Task<IEnumerable<AlbumType>> GetAllAlbumTypes()
        {
            return await _context.Set<AlbumType>().ToListAsync();
        }

        public string GetAlbumTypeDescr(int albumTypeID)
        {
           return _context.Set<AlbumType>().Find(albumTypeID).AlbumTypeDescr;
        }
    }
}
