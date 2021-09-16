using System;
using System.Collections.Generic;
using MusicaAPI.Interfaces;

#nullable disable

namespace MusicaAPI.Models
{
    public partial class Album:GenericEntity<int>
    {
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public string AlbumLabel { get; set; }
        public byte? AlbumTypeId { get; set; }
        public int? AlbumStock { get; set; }

        public virtual AlbumType AlbumType { get; set; }
    }
}
