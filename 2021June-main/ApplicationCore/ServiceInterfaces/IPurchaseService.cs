using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IPurchaseService
    {
        Task<Purchase> ConfirmPurchase(PurchaseRequestModel model);
        Task<List<Purchase>> GetAllPurchases(int id);
    }
}
