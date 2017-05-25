using System.Collections.Generic;
using PotterKata.Models.Books;

namespace PotterKata.Calculator
{
    public interface IStoreCalculator
    {
        decimal Calculate(IList<HarryPotterBook> orderedBooks);
    }
}
