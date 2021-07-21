using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MovieShopMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ICurrentUser _currentUser;
        private readonly IMovieService _movieService;
        private readonly IUserRepository _userRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IPurchaseService _purchaseService;
        private readonly IPurchaseRepository _purchaseRepository;
        public UserController(ICurrentUser currentUser, IMovieService movieService, IPurchaseRepository purchaseRepository,
                              IUserRepository userRepository, IMovieRepository movieRepository, IPurchaseService purchaseService)
        {
            _currentUser = currentUser;
            _movieService = movieService;
            _userRepository = userRepository;
            _movieRepository = movieRepository;
            _purchaseService = purchaseService;
            _purchaseRepository = purchaseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Purchase(int id)
        {
            
            var movie = await _movieService.GetMovieDetails(id);
            return View(movie);
            
        }

        public async Task<IActionResult> ConfirmPurchase(int id)
        {
            var userId = _currentUser.UserId;
            var user = await _userRepository.GetByIdAsync(userId);
            var movie = await _movieRepository.GetByIdAsync(id);
            var purchase = new Purchase
            {

                UserId = user.Id,
                TotalPrice = movie.Price.GetValueOrDefault(),
                MovieId = id
                
            };
            
            var createdPurchase = await _purchaseRepository.AddAsync(purchase);
            purchase.Id = createdPurchase.Id;
            return View("ThanksToPurchase");
        }



        // View Profile

        // Edit Profile

        // Library (MyMovieCount)
    }
}
