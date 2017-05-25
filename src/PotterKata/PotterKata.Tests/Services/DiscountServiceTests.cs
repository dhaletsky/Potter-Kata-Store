using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterKata.Business.Services;
using PotterKata.Models.Books;

namespace PotterKata.Tests.Services
{
    [TestClass]
    public class DiscountServiceTests
    {
        private IDiscountService service;

        [TestInitialize]
        public void Initialize()
        {
            service = new DiscountService(new InterestService());
        }

        [TestMethod]
        public void CalculateDiscount_ThreeDifferentGroupBooks()
        {
            var orderedBooks = new List<HarryPotterBook>
            {
                new HarryPotterBook {Type = BookTypes.TheChamberOfSecrets},

                new HarryPotterBook {Type = BookTypes.TheGobletOfFire},
                new HarryPotterBook {Type = BookTypes.TheGobletOfFire},

                new HarryPotterBook {Type = BookTypes.TheOrderofThePhoenix},
                new HarryPotterBook {Type = BookTypes.TheOrderofThePhoenix}
            };

            Assert.AreEqual(2.4m, service.CalculateDiscount(orderedBooks));
        }

        [TestMethod]
        public void CalculateDiscount_OneBook()
        {
            var orderedBooks = new List<HarryPotterBook>
            {
                new HarryPotterBook {Type = BookTypes.TheChamberOfSecrets}
            };

            Assert.AreEqual(0m, service.CalculateDiscount(orderedBooks));
        }

        [TestMethod]
        public void CalculateDiscount_AllSameBooksInGroup()
        {
            var orderedBooks = new List<HarryPotterBook>
            {
                new HarryPotterBook {Type = BookTypes.TheChamberOfSecrets},
                new HarryPotterBook {Type = BookTypes.TheChamberOfSecrets},
                new HarryPotterBook {Type = BookTypes.TheChamberOfSecrets},
                new HarryPotterBook {Type = BookTypes.TheChamberOfSecrets},
            };

            Assert.AreEqual(0m, service.CalculateDiscount(orderedBooks));
        }

        [TestMethod]
        public void CalculateDiscount_AllSeriesOfBooks()
        {
            var orderedBooks = new List<HarryPotterBook>
            {
                new HarryPotterBook {Type = BookTypes.TheChamberOfSecrets},
                new HarryPotterBook {Type = BookTypes.TheDeathlyHallows},
                new HarryPotterBook {Type = BookTypes.TheGobletOfFire},
                new HarryPotterBook {Type = BookTypes.TheHalfBloodPrince},
                new HarryPotterBook {Type = BookTypes.TheOrderofThePhoenix},
                new HarryPotterBook {Type = BookTypes.ThePhilosopherStone},
                new HarryPotterBook {Type = BookTypes.ThePrisonerOfAzkaban},
            };

            Assert.AreEqual(19.6m, service.CalculateDiscount(orderedBooks));
        }
    }
}
