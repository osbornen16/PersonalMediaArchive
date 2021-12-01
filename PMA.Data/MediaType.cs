using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMA.Data
{
    public class MediaType
    {
        [Key]
        [Display(Name = "GenreId")]
        public int TypeId { get; set; }
        [Display(Name = "Name")]
        public string TypeName { get; set; }
        [Display(Name = "Entries")]
        public virtual ICollection<MediaObject> TypeObjects { get; set; } = new List<MediaObject>();
    }
}
