using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Entities;

namespace ChicagoArtWorkSite.Models
{
    public static class Mapper
    {
        public static IList<Artwork> ToArtEntityBulk(dynamic obj)
        {
            try
            {
                var result = new List<Artwork>();
                foreach (var item in obj.data)
                {
                    var art = new Artwork()
                    {
                        API_Id = item.id,
                        Title = item.title,
                        Artist = item.artist_display
                    };
                    result.Add(art);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error during response parsing with message: " + ex.Message);
            }
        }

        public static Artwork ToArtEntity(dynamic obj)
        {
            try
            {
                return new Artwork()
                {
                    API_Id = obj.id,
                    Title = obj.title,
                    Artist = obj.artist_display
                };
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error during response parsing with message: " + ex.Message);
            }
        }
    }
}
