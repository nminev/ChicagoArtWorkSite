using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Entities
{
    public class Like
    {
        [ForeignKey("User")]
        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        [ForeignKey("Offer")]
        public int ArtworkId { get; set; }

        public Artwork Artwork { get; set; }

        public bool? ThumbsUp { get; set; }

    }
}
