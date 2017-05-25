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
            Assert.AreEqual(0.3m, services.CalculatePercantage(30));
        }

        [TestMethod]
        public void CalculatePercantage_Zero()
        {
            Assert.AreEqual(0m, services.CalculatePercantage(0));
        }

        [TestMethod]
        public void CalculatePercantage_MaxDiscount()
        {
            Assert.AreEqual(1m, services.CalculatePercantage(100));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculatePercantage_MoreThan100()
        {
            services.CalculatePercantage(1000);
        }
    }
}
