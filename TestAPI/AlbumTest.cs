using MusicaAPI.Controllers;
using System;
using Xunit;
using FakeItEasy;
using MusicaAPI.Repositories;
using MusicaAPI.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Xunit.Sdk;

namespace TestAPI
{
    public class APITests
    {
        private const string conString = "Server=.;Database=musicalog;Trusted_Connection=True;MultipleActiveResultSets=true;";
        private ApplicationDBContext _context;

        private AlbumController GetAPIController()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionsBuilder.UseSqlServer(conString);
            _context = new ApplicationDBContext(optionsBuilder.Options);

            var genRepo = new AlbumRepository(_context);
            var controller = new AlbumController(new Microsoft.Extensions.Logging.Abstractions.NullLogger<AlbumController>(), genRepo);

            return controller;
        }

        //private MusicaMVC.Controllers.AlbumController GetMVCController()
        //{
        //    return new MusicaMVC.Controllers.AlbumController("https://localhost:44364/api/Album/");
        //}

        [Fact]
        public async void APIGetAllReturnsSome()
        {
          
            var res= await GetAPIController().GetAll();
            var albums = (res as OkObjectResult).Value as List<Album>;

            Assert.True(albums.Count >= 2);
        }

        [Fact]
        public async void APIGetOne()
        {
            var res = await GetAPIController().Get(1);
            var album = (res as OkObjectResult).Value as Album;

            Assert.True(album!=null);
        }

        [Fact]
        public async void APIGetOneAndUpdate()
        {
            AlbumController con = GetAPIController();

            var resGet = await con.Get(2);
            var album = (resGet as OkObjectResult).Value as Album;

            Assert.True(album != null);

            int? oldStock = album.AlbumStock;
            album.AlbumStock = 99;
            var resUpdate=await con.Update(album);
            Assert.True((resUpdate as OkObjectResult).StatusCode == 200);
            album.AlbumStock = oldStock;
            var resUpdate2 = await con.Update(album);
            Assert.True((resUpdate2 as OkObjectResult).StatusCode == 200);
        }

        [Fact]
        public async void APIGetAlbumTypes()
        {
            var res = await GetAPIController().GetAlbumTypes();
            var albumTypes = (res as OkObjectResult).Value as List<AlbumType>;

            Assert.True(albumTypes.Count >= 5);
        }

        [Theory]
        [InlineData("Just a new album", "John Doe", "Sony", 1, 5)]
        [InlineData("50 great hits", "Annie Lennox", "Columbia", 2, 99)]
        [InlineData("Rap music", "Unknown", "Sony", 5, 1)]
        [InlineData("World music", "Various", "Sony", 1, 3)]
        [InlineData("Pop music", "Various", "N/A", 3, 1)]
        public async void APIAddAndDelete(string name, string artist, string label, int typeID, int stock)
        {
            AlbumController con = GetAPIController();

            Album newAlbum = new Album(_context)
            {
                AlbumName = name,
                ArtistName = artist,
                AlbumLabel = label,
                AlbumTypeId = typeID,
                AlbumStock = stock
            };

            var resAdd = await con.Add(newAlbum);
            int newAlbumID = Convert.ToInt32( (resAdd as OkObjectResult).Value);

            Assert.True(newAlbumID>0);
            if (newAlbumID > 0)
            {
                var resDel = await con.Delete(newAlbumID);
                Assert.True((resDel as OkObjectResult).StatusCode == 200);
            }
            else throw new XunitException("AddAndDeleteFailed while adding new record");
        }

        //[Fact]
        //public async void MVCGetOne()
        //{
        //    var res = await GetMVCController().GetAlbum(1) as ViewResult;

        //    Assert.True(res != null);
        //}
    }
}
