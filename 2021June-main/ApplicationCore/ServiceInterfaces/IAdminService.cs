using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;


namespace ApplicationCore.ServiceInterfaces
{
    public interface IAdminService
    {
         Task<MovieCreateResponseModel> CreateMovie(MovieCreateRequestModel requestModel);
        Task<IEnumerable<Purchase>> GetAllPurchases();
    }
}
