using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
   public interface ICastService
    {
        //Task<List<MovieDetailsResponseModel>> GetAllMovies(int id);
        Task<CastDetailsResponseModel> GetCastDetails(int id);
    }
}
