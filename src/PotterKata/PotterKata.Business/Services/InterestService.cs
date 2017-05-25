using System;

namespace PotterKata.Business.Services
{
    public class InterestService : IInterestService
    {
        public decimal CalculatePercantage(ushort percentageDiscount)
        {
            if (percentageDiscount > 100) throw new ArgumentOutOfRangeException("percentageDiscount", "Can`t be more than 100%");

            return (decimal)percentageDiscount / 100;
        }
    }
}
