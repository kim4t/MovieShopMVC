using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {

        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieDetailsResponseModel>> GetAllMovies()
        {
            var movies = await _movieRepository.ListAllAsync();

            var movieModel = new List<MovieDetailsResponseModel>();

            int count = 0;
            foreach (var movie in movies)
            {
                movieModel.Add(new MovieDetailsResponseModel {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl,
                    BackdropUrl = movie.BackdropUrl,
                    Rating = movie.Rating.GetValueOrDefault(),
                    Overview = movie.Overview,
                    Tagline = movie.Tagline,
                    Budget = movie.Budget.GetValueOrDefault(),
                    Revenue = movie.Revenue.GetValueOrDefault(),
                    ImdbUrl = movie.ImdbUrl,
                    TmdbUrl = movie.TmdbUrl,
                    ReleaseDate = movie.ReleaseDate.GetValueOrDefault(),
                    RunTime = movie.RunTime,
                    Price = movie.Price,

                });
                if (movie.Favorites != null)
                    movieModel[count].FavoritesCount = movie.Favorites.Count;

                if (movie.MovieCasts != null)
                {
                    movieModel[count].Casts = new List<CastResponseModel>();
                    foreach (var Cast in movie.MovieCasts)
                    {
                        movieModel[count].Casts.Add(
                            new CastResponseModel
                            {
                                Id = Cast.CastId,
                                Name = Cast.Cast.Name,
                                Gender = Cast.Cast.Gender,
                                TmdbUrl = Cast.Cast.TmdbUrl,
                                ProfilePath = Cast.Cast.ProfilePath,
                                Character = Cast.Character,
                            }
                        );
                    }
                }
                count++;
            }

            return movieModel;
        }



        public async Task<List<MovieCardResponseModel>> GetTopRevenueMovies()
        {
            var movies = await _movieRepository.GetHighest30GrossingMovies();

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

        public async Task<MovieDetailsResponseModel> GetMovieDetails(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            var c = movie.MovieCasts;
            var movieDetails = new MovieDetailsResponseModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                Rating = movie.Rating.GetValueOrDefault(),
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                Budget = movie.Budget.GetValueOrDefault(),
                Revenue = movie.Revenue.GetValueOrDefault(),
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                ReleaseDate = movie.ReleaseDate.GetValueOrDefault(),
                RunTime = movie.RunTime,
                Price = movie.Price,
               
            };

            if (movie.Favorites != null)
                movieDetails.FavoritesCount = movie.Favorites.Count;

            movieDetails.Casts = new List<CastResponseModel>();
            foreach (var Cast in movie.MovieCasts)
            {
                movieDetails.Casts.Add(
                    new CastResponseModel
                    {
                        Id = Cast.CastId,
                        Name = Cast.Cast.Name,
                        Gender = Cast.Cast.Gender,
                        TmdbUrl = Cast.Cast.TmdbUrl,
                        ProfilePath = Cast.Cast.ProfilePath,
                        Character = Cast.Character,
                    }
                );
            }

            movieDetails.Genres = new List<GenreModel>();
            foreach (var genre in movie.Genres)
            {
                movieDetails.Genres.Add(
                    new GenreModel
                    {
                        Id = genre.Id,
                        Name = genre.Name
                    }
                );
            }

            return movieDetails;
        }

        public async Task<List<MovieCardResponseModel>> GetTopRatedMovies()
        {
            var movies = await _movieRepository.GetHighest30RatedMovies();

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

