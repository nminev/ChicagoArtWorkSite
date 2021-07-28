using Database.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace ChicagoArtWorkSite.Services
{
    public interface IRequestService
    {
        Task<IList<Artwork>> MakeRequestForArtWorks(int take);
    }
}
