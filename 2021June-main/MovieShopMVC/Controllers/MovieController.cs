using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MovieShopMVC.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService _movieService;
        private IGenreService _genreService;
        public MovieController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }
       public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            return View(movie);
        }

        public async Task<IActionResult> Genre(int id)
        {
            var movie = await _genreService.GetTopRevenueMoviesByGenre(id);
            return View(movie);
        }
    }
}
