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
        public async Task<IActionResult> PostPurchase([FromBody] PurchaseRequestModel model)
        {
            var createdPurchase = await _purchaseService.ConfirmPurchase(model);
            
            return CreatedAtRoute("GetPurchase", new { id = createdPurchase.UserId }, createdPurchase);
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> PostFavorite([FromBody] FavoriteRequestModel model)
        {
            var createdFavorite = await _favoriteService.ConfirmFavorite(model);
            return CreatedAtRoute("GetFavorites", new { id = createdFavorite.UserId }, createdFavorite);
        }

        [HttpPost]
        [Route("review")]
        public async Task<IActionResult> PostReview([FromBody] ReviewRequestModel model)
        {
            var createdReviews = await _reviewService.PostReview(model);
            return CreatedAtRoute("GetReviews", new { id = createdReviews.UserId }, createdReviews);
        }

        [HttpPut]
        [Route("review")]
        public async Task<IActionResult> PutReview([FromBody] ReviewRequestModel model)
        {
            var review = await _reviewService.PutReview(model);
            return Ok(review);
        }

        [HttpGet]
        [Route("{id:int}/purchases", Name = "GetPurchase")]
        public async Task<IActionResult> GetPurchasesById(int id)
        {
            var purchases = await _purchaseService.GetAllPurchases(id);
            if (purchases == null)
            {
                return NotFound($"purchases does not exists for {id}");
            }

            return Ok(purchases);
        }

        [HttpGet]
        [Route("{id:int}/favorites", Name = "GetFavorites")]
        public async Task<IActionResult> GetFavoritesById(int id)
        {
            var favorites = await _favoriteService.GetAllFavorites(id);
            if (favorites == null)
            {
                return NotFound($"favorite does not exists for {id}");
            }

            return Ok(favorites);
        }

        [HttpGet]
        [Route("{id:int}/revies", Name = "GetReviews")]
        public async Task<IActionResult> GetReviewsById(int id)
        {
            var reviews = await _reviewService.GetAllReviews(id);
            if (reviews == null)
            {
                return NotFound($"review does not exists for {id}");
            }

            return Ok(reviews);
        }

       
    }
}
