using PMA.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMA.Models
{
    public class PlaylistCreate
    {
        /*public int PlaylistId { get; set; }*/
        [Display(Name = "Name")]
        public string PlaylistName { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public virtual ICollection<MediaObject> PlaylistObjects { get; set; } = new List<MediaObject>();
    }
}
