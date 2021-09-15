using System;
using System.Collections.Generic;

#nullable disable

namespace MusicaAPI.Models
{
    public partial class VwAlbumsGeneral
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public string AlbumLabel { get; set; }
        public byte? AlbumTypeId { get; set; }
        public int? AlbumStock { get; set; }
        public string AlbumTypeDescr { get; set; }
    }
}
