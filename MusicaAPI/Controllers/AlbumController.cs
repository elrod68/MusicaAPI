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

        public AlbumController(ILogger<AlbumController> logger, GenericRepository<Album, int> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var albums= await _repo.GetAll();
                if (albums == null) return NotFound();
                return Ok(albums);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("GetPage")]
        public async Task<ActionResult> GetPage(int pageNumber, int pageSize)
        {
            try
            {
                var albums = await _repo.GetPage(pageNumber, pageSize);
                if (albums == null) return NotFound();
                return Ok(albums);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult> Get(int ID)
        {
            try
            {
                var album= await _repo.GetById(ID);
                if (album == null) return NotFound();
                return Ok(album);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add(Album album)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _repo.Add(album);
                    if (postId > 0)
                    {
                        return Ok(postId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult> Delete(int ID)
        {
            int result = 0;

            try
            {
                result = await _repo.Remove(ID);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok(ID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPut()]
        public async Task<ActionResult> Update([FromForm] Album album)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Update(album);

                    return Ok(album);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpGet("GetAlbumTypes")]
        public async Task<ActionResult> GetAlbumTypes()
        {
            try
            {
                var albumTypes = await ((AlbumRepository)_repo).GetAllAlbumTypes();
                if (albumTypes == null) return NotFound();
                return Ok(albumTypes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

    }
}
