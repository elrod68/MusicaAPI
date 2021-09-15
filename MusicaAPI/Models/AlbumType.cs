using System;
using System.Collections.Generic;

#nullable disable

namespace MusicaAPI.Models
{
    public partial class AlbumType
    {
        public AlbumType()
        {
            Albums = new HashSet<Album>();
        }

        public byte AlbumTypeId { get; set; }
        public string AlbumTypeDescr { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
