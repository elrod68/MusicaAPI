using System;
using System.Collections.Generic;

#nullable disable

namespace MusicaAPI.Models
{
    public partial class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public string AlbumLabel { get; set; }
        public byte? AlbumTypeId { get; set; }
        public int? AlbumStock { get; set; }

        public virtual AlbumType AlbumType { get; set; }
    }
}
