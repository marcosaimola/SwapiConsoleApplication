using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwapiCL;
using SwapiCL.Model;
using SwapiCL.Services;

namespace SwapiTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly StarShip _ss = new StarShip();

        [TestMethod]
        public void TestAuthonomyShipByHour()
        {
            _ss.consumables = "20 hours";

            var ret = Utils.GetAuthonomyByShip(_ss);
            Assert.AreEqual(20, ret);
        }

        [TestMethod]
        public void TestAuthonomyShipByDay()
        {
            _ss.consumables = "10 days";
            var ret = Utils.GetAuthonomyByShip(_ss);
            Assert.AreEqual(240, ret);
        }

        [TestMethod]
        public void TestAuthonomyShipByWeek()
        {
            _ss.consumables = "2 weeks";
            var ret = Utils.GetAuthonomyByShip(_ss);
            Assert.AreEqual(336, ret);
        }

        [TestMethod]
        public void TestAuthonomyShipByMonth()
        {
            _ss.consumables = "3 months";
            var ret = Utils.GetAuthonomyByShip(_ss);
            Assert.AreEqual(2160, ret);
        }

        [TestMethod]
        public void TestAuthonomyShipByYear()
        {
            _ss.consumables = "1 year";
            var ret = Utils.GetAuthonomyByShip(_ss);
            Assert.AreEqual(8760, ret);
        }

        [TestMethod]
        public void TestAuthonomyShipByUnknown()
        {
            _ss.consumables = "unknown";
            var ret = Utils.GetAuthonomyByShip(_ss);
            Assert.AreEqual(0, ret);
        }

        [TestMethod]
        public void TestInputInvalidData()
        {
            Assert.AreEqual(false, Utils.InputValidDade("1000000a"));
        }

        [TestMethod]
        public void TestInputValidData()
        {
            Assert.AreEqual(true, Utils.InputValidDade("10000000000000"));
        }

        [TestMethod]
        public void TestApiAvailabilityApi()
        {
            var root = ShipsService.Get();
            Assert.IsTrue(root.results.Count > 0);
        }

        [TestMethod]
        public void TestCalculateShipStop()
        {
            _ss.autonomy = 13440;
            Assert.AreEqual(74,Utils.CalculateShipStop("1000000", _ss));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestCalculateShipStopDividebyZero()
        {
            _ss.autonomy = 0;
            Utils.CalculateShipStop("1000000", _ss);
        }

        [TestMethod]
        public void TestCallPeopleApi()
        {
            Assert.IsTrue(PeopleService.GetAsync().Result.count > 0); 
        }

        [TestMethod]
        public void TestCallVehiclesApi()
        {
            Assert.IsTrue(VehiclesService.GetAsync().Result.count > 0);
        }

        [TestMethod]
        public void TestCallFilmsApi()
        {
            Assert.IsTrue(FilmsService.GetAsync().Result.count > 0);
        }

        [TestMethod]
        public void TestCallSpeciesApi()
        {
            Assert.IsTrue(SpeciesService.GetAsync().Result.count > 0);
        }

        [TestMethod]
        public void TestCallPlanetsApi()
        {
            Assert.IsTrue(PlanetsService.GetAsync().Result.count > 0);
        }
    }
}
