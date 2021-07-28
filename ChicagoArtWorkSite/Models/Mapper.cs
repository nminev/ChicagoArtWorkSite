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
                    result.Add(ToArtEntity(item));
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
                    Artist = obj.artist_display,
                    Image_Id = obj.image_id,
                };
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error during response parsing with message: " + ex.Message);
            }
        }
    }
}
