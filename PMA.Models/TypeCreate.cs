using PMA.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMA.Models
{
    public class TypeCreate
    {
        /*public int TypeId { get; set; }*/
        [Display(Name = "Name")]
        public string TypeName { get; set; }
        public virtual ICollection<MediaObject> TypeObjects { get; set; } = new List<MediaObject>();
    }
}
