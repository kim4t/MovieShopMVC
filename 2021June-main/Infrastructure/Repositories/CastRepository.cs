using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class CastRepository : EfRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async override Task<Cast> GetByIdAsync(int id)
        {
            var cast = await _dbContext.Casts.Include(c=>c.MovieCasts).ThenInclude(mc =>mc.Movie).FirstOrDefaultAsync(c => c.Id == id);
            
            if (cast == null)
            {
                throw new Exception($"No Cast Found with {id}");
            }
            return cast;
        }

        //public async Task<List<Movie>> GetAllMovies(int id)
        //{
        //    var movie = await _dbContext.Movies.Include(m => m.MovieCasts).ThenInclude(m => m.Cast)
        //        .Include(m => m.Genres).FirstOrDefaultAsync(m => m.Id == id);

        //    if (movie == null)
        //    {
        //        throw new Exception($"No Movie Found with {id}");
        //    }

        //    var movieRating = await _dbContext.Reviews.Where(m => m.MovieId == id).AverageAsync(r => r == null ? 0 : r.Rating);

        //    if (movieRating > 0)
        //    {
        //        movie.Rating = movieRating;
        //    }
        //    return movie;
        //}
    }
}
