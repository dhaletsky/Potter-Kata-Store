using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterKata.Business.Services;
using PotterKata.Calculator;
using PotterKata.Models.Books;

namespace PotterKata.Tests.Calculator
{
    [TestClass]
    public class StoreCalculatorTests
    {
        private IStoreCalculator calculator;

        [TestInitialize]
        public void Initialize()
        {
            calculator = new StoreCalculator(new DiscountService(new InterestService()));
        }

        [TestMethod]
        public void Calculate_SameBooks()
        {
            var books = new List<HarryPotterBook>
            {
                new HarryPotterBook {Type = BookTypes.TheChamberOfSecrets},
                new HarryPotterBook {Type = BookTypes.TheChamberOfSecrets}
            };

            Assert.AreEqual(16m, calculator.Calculate(books));
        }

        [TestMethod]
        public void Calculate_DifferentGroupBooks()
        {
            var books = new List<HarryPotterBook>
            {
                new HarryPotterBook {Type = BookTypes.TheChamberOfSecrets},
                new HarryPotterBook {Type = BookTypes.TheGobletOfFire}
            };

            Assert.AreEqual(15.2m, calculator.Calculate(books));
        }

        [TestMethod]
        public void Calculate_6DifferentAnd4SameSeries()
        {
            var books = new List<HarryPotterBook>
            {
                new HarryPotterBook {Type = BookTypes.TheChamberOfSecrets},

                new HarryPotterBook {Type = BookTypes.TheGobletOfFire},
                new HarryPotterBook {Type = BookTypes.TheGobletOfFire},

                new HarryPotterBook {Type = BookTypes.TheOrderofThePhoenix},
                new HarryPotterBook {Type = BookTypes.TheOrderofThePhoenix},

                new HarryPotterBook {Type = BookTypes.TheDeathlyHallows},
                new HarryPotterBook {Type = BookTypes.TheDeathlyHallows},

                new HarryPotterBook {Type = BookTypes.ThePhilosopherStone},
                new HarryPotterBook {Type = BookTypes.ThePhilosopherStone},

                new HarryPotterBook {Type = BookTypes.ThePrisonerOfAzkaban}
            };

            Assert.AreEqual(65.6m, calculator.Calculate(books));
        }

        [TestMethod]
        public void Calculate_5DifferentAnd3SameSeries()
        {
            var books = new List<HarryPotterBook>
            {
                new HarryPotterBook {Type = BookTypes.TheGobletOfFire},
                new HarryPotterBook {Type = BookTypes.TheGobletOfFire},

                new HarryPotterBook {Type = BookTypes.TheOrderofThePhoenix},
                new HarryPotterBook {Type = BookTypes.TheOrderofThePhoenix},

                new HarryPotterBook {Type = BookTypes.TheDeathlyHallows},
                new HarryPotterBook {Type = BookTypes.TheDeathlyHallows},

                new HarryPotterBook {Type = BookTypes.ThePhilosopherStone},

                new HarryPotterBook {Type = BookTypes.ThePrisonerOfAzkaban}
            };

            Assert.AreEqual(54m, calculator.Calculate(books));
        }

        [TestMethod]
        public void Calculate_AllDifferentSeries()
        {
            var books = new List<HarryPotterBook>
            {
                new HarryPotterBook {Type = BookTypes.TheChamberOfSecrets},
                new HarryPotterBook {Type = BookTypes.TheDeathlyHallows},
                new HarryPotterBook {Type = BookTypes.TheGobletOfFire},
                new HarryPotterBook {Type = BookTypes.TheHalfBloodPrince},
                new HarryPotterBook {Type = BookTypes.TheOrderofThePhoenix},
                new HarryPotterBook {Type = BookTypes.ThePhilosopherStone},
                new HarryPotterBook {Type = BookTypes.ThePrisonerOfAzkaban},
            };

            Assert.AreEqual(36.4m, calculator.Calculate(books));
        }

        [TestMethod]
        public void Calculate_NoBooks()
        {
            Assert.AreEqual(0m, calculator.Calculate(new List<HarryPotterBook>()));
        }
    }
}
