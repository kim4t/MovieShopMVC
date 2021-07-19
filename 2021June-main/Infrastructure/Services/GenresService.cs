using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{
    public class GenresService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenresService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<IEnumerable<GenreModel>> GetAllGenres()
        {
            var genres = await _genreRepository.ListAllAsync();

            var genresModel = new List<GenreModel>();

            foreach (var genre in genres)
            {
                genresModel.Add(new GenreModel { Id = genre.Id, Name = genre.Name });
            }
            return genresModel;
        }

        public async Task<List<MovieCardResponseModel>> GetTopRevenueMoviesByGenre(int id)
        {
            var movies = await _genreRepository.GetHighest30GrossingMoviesByGenre(id);

            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Budget = movie.Budget.GetValueOrDefault(),
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return movieCards;
        }
    }
}
