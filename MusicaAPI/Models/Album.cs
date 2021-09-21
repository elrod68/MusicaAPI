#nullable disable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicaAPI.Models
{
    public partial class Album : GenericEntity<int>
    {

        private ApplicationDBContext _context;

        public Album()
        {

        }

        public Album(ApplicationDBContext context)
        {
            _context = context;
        }

        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public string AlbumLabel { get; set; }

        [DefaultValue(1)]
        public int AlbumTypeId { get; set; }
        public int? AlbumStock { get; set; }

        [NotMapped]
        public virtual string AlbumTypeDescr
        {
            get
            {
                if (_context != null) return _context.Set<AlbumType>().Find(AlbumTypeId).AlbumTypeDescr;
                else return "Context not initialized";
            }
        }
    }
}
