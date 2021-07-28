using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Entities
{
    public class Artwork
    {
        [Key]
        public int Id { get; set; }

        public int API_Id { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public string Image_Id { get; set; }
    }
}
