using System.Collections.Generic;
using System.Linq;
using PotterKata.Models.Books;

namespace PotterKata.Business.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IList<ushort> discounts = new List<ushort> { 0, 0, 5, 10, 15, 25, 30, 35 };
        
        private readonly IInterestService interestService;

        public DiscountService(IInterestService interestService)
        {
            this.interestService = interestService;
        }

        public decimal CalculateDiscount(IList<HarryPotterBook> orderedBooks)
        {
            var toDiscountAmountBooks = orderedBooks.GroupBy(x => x.Type).Count();

            return toDiscountAmountBooks * Prices.HarryPotterPrice * interestService.CalculatePercentage(discounts[toDiscountAmountBooks]);
        }
    }
}
