using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PurchaseService: IPurchaseService
    {
        private readonly ICurrentUser _currentUser;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;
        public PurchaseService(ICurrentUser currentUser,IPurchaseRepository purchaseRepository, IMovieService movieService,
                                IUserService userService)
        {
            _purchaseRepository = purchaseRepository;
            _movieService = movieService;
            _currentUser = currentUser;
            _userService = userService;
        }

        public async Task<Purchase> ConfirmPurchase(PurchaseRequestModel model)
        {
            var userId = _currentUser.UserId;
            var user = await _userService.GetUserById(model.UserId);
            var movie = await _movieService.GetMovieDetails(model.MovieId);
            var purchase = new Purchase
            {

                UserId = user.Id,
                TotalPrice = movie.Price.GetValueOrDefault(),
                MovieId = movie.Id,
                PurchaseNumber = model.PurchaseNumber,
                PurchaseDateTime = model.PurchaseDateTime,
            };

            var createdPurchase = await _purchaseRepository.AddAsync(purchase);
            return createdPurchase;
        }

        public async Task<List<Purchase>> GetAllPurchases(int id)
        {
            var purchases = await _purchaseRepository.GetAllPurchases(id);
            return purchases;
        }
    }
}
