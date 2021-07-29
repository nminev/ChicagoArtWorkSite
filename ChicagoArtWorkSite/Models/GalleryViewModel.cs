using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChicagoArtWorkSite.Models
{
    public class GalleryViewModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Author { get; set; }

        public bool? Like { get; set; }

        public string ImageSrc { get; set; }
    }
}
