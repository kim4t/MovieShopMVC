using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Entities;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICurrentUser _currentUser;
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;
        private readonly IPurchaseService _purchaseService;
        private readonly IFavoriteService _favoriteService;
        private readonly IReviewService _reviewService;
        public UserController(IUserService userService, IMovieService movieService, IFavoriteService favoriteService,
                                IPurchaseService purchaseService, ICurrentUser currentUser, IReviewService reviewService)
        {
            _userService = userService;
            _movieService = movieService;
            _purchaseService = purchaseService;
            _currentUser = currentUser;
            _favoriteService = favoriteService;
            _reviewService = reviewService;
        }

        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> PutPurchase([FromBody] PurchaseRequestModel model)
        {
            var purchase = await _purchaseService.ConfirmPurchase(model);
            
            return Ok(purchase);
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> PostFavorite([FromBody] FavoriteRequestModel model)
        {
            var favorite = await _favoriteService.ConfirmFavorite(model);
            return Ok(favorite);
        }

        [HttpPost]
        [Route("review")]
        public async Task<IActionResult> PostReview([FromBody] ReviewRequestModel model)
        {
            var review = await _reviewService.PostReview(model);
            return Ok(review);
        }

        [HttpPut]
        [Route("review")]
        public async Task<IActionResult> PutReviwe([FromBody] ReviewRequestModel model)
        {
            var review = await _reviewService.PutReview(model);
            return Ok(review);
        }

        [HttpGet]
        [Route("{id:int}/review")]
        public async Task<IActionResult> GetAllReviws(int id)
        {
            var reviews = await _reviewService.GetAllReviews(id);
            return Ok(reviews);
        }

        [HttpGet]
        [Route("{id:int}/purchase")]
        public async Task<IActionResult> GetAllPurchases(int id)
        {
            var reviews = await _purchaseService.GetAllPurchases(id);
            return Ok(reviews);
        }

        [HttpGet]
        [Route("{id:int}/favorate")]
        public async Task<IActionResult> GetAllFavortes(int id)
        {
            var reviews = await _favoriteService.GetAllFavorites(id);
           
            return Ok(reviews);
        }
    }
}
