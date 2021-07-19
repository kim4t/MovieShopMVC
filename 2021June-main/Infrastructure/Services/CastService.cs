using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;


namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;
        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }
        
        public async Task<CastDetailsResponseModel> GetCastDetails(int id)
        {
            var cast = await _castRepository.GetByIdAsync(id);
            
            var castDetails = new CastDetailsResponseModel()
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                TmdbUrl = cast.TmdbUrl,
                ProfilePath = cast.ProfilePath, 
            };
            var characters = cast.MovieCasts.Where(c => c.CastId == id).Select(c=>c.Character).ToList();
            var movies = cast.MovieCasts.Where(c => c.CastId == id).Select(c => c.Movie).ToList();
            if (characters != null)
                castDetails.Characters = characters;
            if (movies != null)
                castDetails.Movies = movies;
            return castDetails;
           
        }
    }
}
