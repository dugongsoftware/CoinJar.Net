using Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Models;
using System.Net;

namespace Provider.Tests
{
    
    
    /// <summary>
    ///This is a test class for CoinJarTest and is intended
    ///to contain all CoinJarTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CoinJarTest
    {

        private const string API_KEY = "YOUR API KEY HERE";

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetAddress
        ///</summary>
        [TestMethod()]
        public void CoinJar_GetAddressTest()
        {
            CoinJar target = new CoinJar();
            target.ApiKey = API_KEY;

            string bitcoinAddress = "14aXSCWnahcDiLekAjTYNxuLTt7inxLRXw";
            Models.IAddress actual;
            actual = target.GetAddress(bitcoinAddress);
            Assert.AreEqual(bitcoinAddress, actual.Address);
        }

        /// <summary>
        ///A test for GetRate
        ///</summary>
        [TestMethod()]
        public void CoinJar_GetRateTest()
        {
            CoinJar target = new CoinJar();
            target.ApiKey = API_KEY;

            double actual;
            actual = target.GetRate(CurrencyCode.AUD);
            Assert.IsTrue(actual > 0);
        }

        /// <summary>
        ///A test for SendPayment
        ///</summary>
        [TestMethod()]
        public void CoinJar_SendPaymentTest()
        {
            CoinJar target = new CoinJar();
            target.ApiKey = API_KEY;

            String address = "1MoKQiSceQxwFif8Az5tigWS4SskSGpyhR";
            double amount = 0.0001;
            string label = "Unit Test";
            double fee = 0F;
            string actual;
            actual = target.SendPayment(address, amount, label, fee);
            Assert.IsTrue(actual.Contains("PENDING"));
        }

        /// <summary>
        ///A test for CreateAddress
        ///</summary>
        [TestMethod()]
        public void CoinJar_CreateAddressTest()
        {
            CoinJar target = new CoinJar();
            target.ApiKey = API_KEY;

            string label = "Unit test";
            Models.IAddress actual;
            actual = target.CreateAddress(label);
            Assert.IsFalse(String.IsNullOrEmpty(actual.Address));
            Assert.AreEqual(actual.Label, label);
        }
    }
}
