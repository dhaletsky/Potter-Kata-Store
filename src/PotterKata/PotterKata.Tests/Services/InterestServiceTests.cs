using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterKata.Business.Services;

namespace PotterKata.Tests.Services
{
    [TestClass]
    public class InterestServiceTests
    {
        private IInterestService services;

        [TestInitialize]
        public void Inititlize()
        {
            services = new InterestService();
        }

        [TestMethod]
        public void CalculatePercantage_30()
        {
            Assert.AreEqual(0.3m, services.CalculatePercentage(30));
        }

        [TestMethod]
        public void CalculatePercantage_Zero()
        {
            Assert.AreEqual(0m, services.CalculatePercentage(0));
        }

        [TestMethod]
        public void CalculatePercantage_MaxDiscount()
        {
            Assert.AreEqual(1m, services.CalculatePercentage(100));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculatePercantage_MoreThan100()
        {
            services.CalculatePercentage(1000);
        }
    }
}
