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


namespace TestAPI
{
    public class APITests
    {
        private const string conString = "Server=.;Database=musicalog;Trusted_Connection=True;";

        private AlbumController GetController()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionsBuilder.UseSqlServer(conString);
            var AppDBContext = new ApplicationDBContext(optionsBuilder.Options);

            var genRepo = new GenericRepository<Album, int>(AppDBContext);
            var controller = new AlbumController(new Microsoft.Extensions.Logging.Abstractions.NullLogger<AlbumController>(), genRepo);

            return controller;
        }

        [Fact]
        public async void GetAllReturnsOK()
        {
          
            var a= await GetController().GetAll();
            var albums = (a as OkObjectResult).Value as List<Album>;

            Assert.True(albums.Count > 2);
        }
    }
}
