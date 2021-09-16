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
    public class AlbumRepository : GenericRepository<Album, int>
    {
        private readonly ApplicationDBContext _context;

        public AlbumRepository(ApplicationDBContext context) : base(context) { }

    }
}
