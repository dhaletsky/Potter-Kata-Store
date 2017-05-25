using System.Collections.Generic;
using PotterKata.Business.Services;
using PotterKata.Models.Books;

namespace PotterKata.Calculator
{
    public class StoreCalculator : IStoreCalculator
    {
        private readonly IDiscountService discountService;

        public StoreCalculator(IDiscountService discountService)
        {
            this.discountService = discountService;
        }

        public decimal Calculate(IList<HarryPotterBook> orderredBooks)
        {
            return orderredBooks.Count * Prices.HarryPotterPrice - discountService.CalculateDiscount(orderredBooks);
        }
    }
}
