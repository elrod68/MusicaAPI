using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicaAPI.Interfaces;
using MusicaAPI.Models;
using MusicaAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController : ControllerBase
    {

        private readonly ILogger<AlbumController> _logger;
        private readonly GenericRepository<Album, int> _repo;

        public AlbumController(ILogger<AlbumController> logger, GenericRepository<Album,int> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Album>> GetAll()
        {
            try
            {
                return await _repo.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("{ID}")]
        public async Task<Album> Get(int ID)
        {
            try
            {
                return await _repo.GetById(ID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

    }
}
