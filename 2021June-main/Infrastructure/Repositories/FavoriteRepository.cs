using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class FavoriteRepository: EfRepository<Favorite>,IFavoriteRepository
    {
        public FavoriteRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Favorite>> GetAllFavorites(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            var favorites = user.Favorites.ToList();
            if (favorites == null)
            {
                throw new Exception($"No Favorites Found with {id}");
            }
            return favorites;
        }
    }
}
