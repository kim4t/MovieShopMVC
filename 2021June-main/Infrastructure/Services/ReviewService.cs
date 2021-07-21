using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{
    public class ReviewService : IReviewService
    {
       
        private readonly IReviewRepository _reviewRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IMovieService _movieService;
        public ReviewService( IReviewRepository reviewRepository, ICurrentUser currentUser, IMovieService movieService)
        {
            _reviewRepository = reviewRepository;
            _currentUser = currentUser;
            _movieService = movieService;
        }
        public Task<List<Review>> GetAllReviews(int id)
        {
            var reviews = _reviewRepository.GetAllReviews(id);
            return reviews;
        }
        public Task<List<Review>> GetAllReviews(ReviewRequestModel model)
        {
            var reviews = _reviewRepository.GetAllReviews(model.UserId);
            return reviews;
        }

        public async Task<Review> PostReview(ReviewRequestModel model)
        {
            var userId = _currentUser.UserId;
            var movie = await _movieService.GetMovieDetails(model.movieId);

            var review = new Review
            {
                UserId = userId,
                MovieId = movie.Id,
                ReviewText = model.ReviewText,
                Rating = model.Rating
            };
            var createdReview = await _reviewRepository.AddAsync(review);
            return createdReview;
        }

        public async Task<Review> PutReview(ReviewRequestModel model)
        {
            var userId = _currentUser.UserId;
            var movie = await _movieService.GetMovieDetails(model.movieId);

            var review = new Review
            {
                UserId = userId,
                MovieId = movie.Id,
                ReviewText = model.ReviewText,
                Rating = model.Rating
            };
           var newReview = await _reviewRepository.UpdateAsync(review);
         
            return newReview;
        }
    }
}
