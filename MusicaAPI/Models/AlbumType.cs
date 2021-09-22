using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace MusicaAPI.Models
{
    //for example CD, Vinul etc.
    public partial class AlbumType
    {
        public int AlbumTypeId { get; set; }
        public string AlbumTypeDescr { get; set; }

    }
}
