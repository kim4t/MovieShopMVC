using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IReviewService
    {
        Task<List<Review>> GetAllReviews(int id);
        Task<Review> PostReview(ReviewRequestModel model);
        Task<Review> PutReview(ReviewRequestModel model);
    }
}
