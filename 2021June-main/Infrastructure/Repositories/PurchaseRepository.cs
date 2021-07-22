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
   public class PurchaseRepository: EfRepository<Purchase>,IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Purchase>> GetAllPurchases(int id)
        {
            var purchases = await _dbContext.Purchases.Where(p => p.UserId == id).ToListAsync();
            if(purchases == null)
            {
                throw new Exception($"No user Found with {id}");
            }
            
            return purchases;
        }
    }
}
