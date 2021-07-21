using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IReviewRepository: IAsyncRepository<Review>
    {
        Task<List<Review>> GetAllReviews(int id);
       
    }
}
