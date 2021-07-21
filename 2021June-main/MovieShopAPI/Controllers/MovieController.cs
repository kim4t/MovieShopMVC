using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly IReviewService _reviewService;
        public MovieController(IMovieService movieService, IGenreService genreService, IReviewService reviewService )
        {
            _movieService = movieService;
            _genreService = genreService;
            _reviewService = reviewService;
        }
        //attribute based routing


        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMovies();

            if (movies == null)
            {
                return NotFound($"There is no movie");
            }
            return Ok(movies);
        }


        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopRevenueMovies()  //error
        {
            var movies = await _movieService.GetTopRevenueMovies();

            // json data HTTP status codes
            //Newtonsoft.Json   older ver
            // System.text.json ner ver

            if(!movies.Any())
            {
                return NotFound("No movies found");
            }
            return Ok(movies);
        }
        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetTopRatedMovies()  //error
        {
            var movies = await _movieService.GetTopRatedMovies();
            if (!movies.Any())
            {
                return NotFound("No movies found");
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);

            if (movie == null)
            {
                return NotFound($"No movie found for that {id}");
            }
            return Ok(movie);
        }

        [HttpGet]
        [Route("Genre/{id:int}")]
        public async Task<IActionResult> GetTopRevenueMoviesByGenre(int id) // error
        {
            var genreMovies = await _genreService.GetTopRevenueMoviesByGenre(id);

            if (genreMovies == null)
            {
                return NotFound($"No movies found for that genre {id}");
            }
            
            return Ok(genreMovies);
        }

        [HttpGet]
        [Route("Review/{id:int}")]
        public async Task<IActionResult> GetMovieReviews(int id)
        {
            var reviews = await _reviewService.GetAllReviews(id);
            if (reviews == null)
            {
                return NotFound($"No reviews found for that {id}");
            }
            return Ok(reviews);
        }


    }
}
