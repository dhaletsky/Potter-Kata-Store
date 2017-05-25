using System.Collections.Generic;
using PotterKata.Models.Books;

namespace PotterKata.Business.Services
{
    public interface IDiscountService
    {
        decimal CalculateDiscount(IList<HarryPotterBook> orderedBooks);
    }
}
