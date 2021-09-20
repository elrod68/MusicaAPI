#nullable disable

namespace MusicaMVC.Models
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
