using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMA.Models
{
    public class ObjectDetail
    {
        public int ObjectId { get; set; }
        [Display(Name = "Name")]
        public string ObjectName { get; set; }

        public string Contributor { get; set; }

        public string Description { get; set; }

        [Display(Name = "GenreId")]
        public int TypeId { get; set; }

        public int PlaylistId { get; set; }
    }
}
