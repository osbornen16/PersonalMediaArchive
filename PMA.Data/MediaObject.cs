using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMA.Data
{
    public class MediaObject
    {
        [Key]
        [Display(Name = "EntryId")]
        public int ObjectId { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string ObjectName { get; set; }

        public string Contributor { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(MediaType))]
        [Display(Name = "GenreId")]
        public int TypeId { get; set; }
        public virtual MediaType MediaType { get; set; }

        [ForeignKey(nameof(MediaPlaylist))]
        public int PlaylistId { get; set; }
        public virtual MediaPlaylist MediaPlaylist { get; set; }
    }
}