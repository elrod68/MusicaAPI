#nullable disable
using System.ComponentModel.DataAnnotations;

namespace MusicaMVC.Models
{
    public partial class Album:GenericEntity<int>
    {
        [Required(ErrorMessage ="Please put an album name")]
        public string AlbumName { get; set; }
        [Required(ErrorMessage = "Please put an artist name")]
        public string ArtistName { get; set; }
        [Required(ErrorMessage = "Please put a label")]
        public string AlbumLabel { get; set; }
        //[Required(ErrorMessage = "Please select an album type")]
        public int AlbumTypeId { get; set; }
        [Required(ErrorMessage = "Please put stock quantity")]
        public int? AlbumStock { get; set; }

        public virtual AlbumType AlbumType {
            get;
            set; }
    }
}
