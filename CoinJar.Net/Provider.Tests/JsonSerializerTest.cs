using Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Providers.Tests
{
    /// <summary>
    ///This is a test class for JsonSerTest and is intended
    ///to contain all JsonSerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JsonSerializer
    {


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


        [TestMethod()]
        public void GetObjectFromStringTest()
        {
            JsonSerializer<Models.CoinJar.PaymentResponse> target = new JsonSerializer<Models.CoinJar.PaymentResponse>();
            string data = "{\"payment\":{\"uuid\":\"e965c910-dd4b-416e-83c0-be76e2a836c2\",\"payee_name\":\"1MoKQiSceQxwFif8Az5tigWS4SskSGpyhR\",\"payee_type\":\"ADDRESS\",\"amount\":\"0.001\",\"status\":\"PENDING\",\"reference\":null,\"created_at\":\"2013-08-07T11:22:30.331+10:00\",\"updated_at\":\"2013-08-07T11:22:30.331+10:00\",\"related_transaction\":null}}";

            Models.CoinJar.PaymentResponse actual;
            actual = target.GetObjectFromString(data);
            Assert.IsFalse(actual == null);
            Assert.AreEqual(actual.Payment.Uuid, "e965c910-dd4b-416e-83c0-be76e2a836c2");
        }
    }
}
