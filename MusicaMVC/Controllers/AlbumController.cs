using Microsoft.AspNetCore.Mvc;
using MusicaMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MusicaMVC.Controllers
{
    public class AlbumController : Controller
    {
        public async Task< IActionResult> Index()
        {
            List<Album> albumList = new List<Album>();

            using(var httpClient=new HttpClient())
            {
                using (var response=await httpClient.GetAsync("https://localhost:44364/api/Album/GetAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    albumList = JsonConvert.DeserializeObject<List<Album>>(apiResponse);
                }
            }

            return View(albumList);
        }

        [HttpGet]
        public ViewResult GetAlbum()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAlbum(int id)
        {
            Album album = new Album();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44364/api/Album/" + id.ToString()))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    album = JsonConvert.DeserializeObject<Album>(apiResponse);
                }
            }

            return View(album);
        }

        [HttpGet]
        public ViewResult AddAlbum()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAlbum(Album album)
        {
            //if (album.AlbumTypeId == 0) album.AlbumTypeId = 1;

            if (ModelState.IsValid)
            {
                using (var httpClient=new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(album), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:44364/api/Album/Add", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        int newAlbumID = JsonConvert.DeserializeObject<int>(apiResponse);
                        if (newAlbumID <= 0) return View();
                    }
                }
                return View(album);
            }
            return View();
        }
    }
    
}
