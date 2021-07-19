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
    public class GenreRepository : EfRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Movie>> GetHighest30GrossingMoviesByGenre(int id)
        {
           
            // this return every movies
            // var movie = await _dbContext.Movies.Include(m => m.Genres.Where(g=>g.Id == id)).ToListAsync();
            
            var genre = await _dbContext.Genres.Include(g => g.Movies).FirstOrDefaultAsync(g => g.Id == id);
            var movie = genre.Movies.ToList();
            return movie;
        }


    }
}
