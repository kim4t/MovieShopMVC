using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
   public class PurchaseRequestModel
    {
        public int UserId { get; set; }
        public Guid PurchaseNumber { get; set; }
        public int MovieId { get; set; }
        public DateTime PurchaseDateTime { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
