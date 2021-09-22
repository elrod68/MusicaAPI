﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Index()
        {
            List<Album> albumList = new List<Album>();

            using(var httpClient=new HttpClient())
            {
                using (var response=await httpClient.GetAsync(Startup.APIBaseURL+ "GetAll"))
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
                using (var response = await httpClient.GetAsync(Startup.APIBaseURL + id.ToString()))
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
            if (ModelState.IsValid)
            {
                using (var httpClient=new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(album), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(Startup.APIBaseURL + "Add", content))
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

        [HttpGet]
        public async Task<IActionResult> UpdateAlbum(int id)
        {
            Album album = new Album();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Startup.APIBaseURL + id.ToString()))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    album = JsonConvert.DeserializeObject<Album>(apiResponse);
                }
            }
            return View(album);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAlbum(Album album)
        {
            Album receivedAlbum = new Album();
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(album.ID.ToString()), "ID");
                    content.Add(new StringContent(album.AlbumName), "AlbumName");
                    content.Add(new StringContent(album.ArtistName), "ArtistName");
                    content.Add(new StringContent(album.AlbumLabel), "AlbumLabel");
                    content.Add(new StringContent(album.AlbumTypeId.ToString()), "AlbumTypeId");
                    content.Add(new StringContent(album.AlbumStock.ToString()), "AlbumStock");
                    using (var response = await httpClient.PutAsync(Startup.APIBaseURL, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ViewBag.Result = "Success";
                        receivedAlbum = JsonConvert.DeserializeObject<Album>(apiResponse);
                    }
                }
            }
            return View(receivedAlbum);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(Startup.APIBaseURL + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }
    
}
