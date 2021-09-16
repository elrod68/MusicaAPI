using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MusicaAPI.Interfaces;

#nullable disable

namespace MusicaAPI.Models
{
    public partial class Album:GenericEntity<int>
    {
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public string AlbumLabel { get; set; }
        
        public int AlbumTypeId { get; set; }
        public int? AlbumStock { get; set; }

        public virtual AlbumType AlbumType {
            get;
            set; }
    }
}
