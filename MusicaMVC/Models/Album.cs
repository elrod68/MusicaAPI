#nullable disable

using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;

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
        [DefaultValue(1)]
        [Required(ErrorMessage = "Please select a type")]
        public int AlbumTypeId { get; set; }
        [Required(ErrorMessage = "Please put stock quantity")]
        public int? AlbumStock { get; set; }

        public virtual AlbumType AlbumType {
            get;
            set; }

        //

        public static async Task<List<AlbumType>> AlbumTypes()
        {
            List<AlbumType> typeList = new List<AlbumType>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44364/api/Album/GetAlbumTypes"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    typeList = JsonConvert.DeserializeObject<List<AlbumType>>(apiResponse);
                }
            }

            return typeList;
        }

    }
}
