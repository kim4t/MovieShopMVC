using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IFavoriteService
    {
        Task<Favorite> ConfirmFavorite(FavoriteRequestModel model);
        Task<List<Favorite>> GetAllFavorites(int id);
    }
}
