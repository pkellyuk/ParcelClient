using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParcelClient;

namespace ParcelClientTests
{
    [TestClass]
    public class ParcelAPITests
    {
        [TestMethod]
        public void TestLibGetToken()
        {
            Config.InitSettings();
            ParcelClient.Lib.ParcelLib parcelLib = new ParcelClient.Lib.ParcelLib(Config.ApiEndpoint, Config.ApiClientId, Config.ApiSecret, Config.ApiScope);
            var token = parcelLib.GetToken();
            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void TestLibGetQuote()
        {
            Config.InitSettings();
            ParcelClient.Lib.ParcelLib parcelLib = new ParcelClient.Lib.ParcelLib(Config.ApiEndpoint, Config.ApiClientId, Config.ApiSecret, Config.ApiScope);
            var token = parcelLib.GetToken();
            Assert.IsNotNull(token);
            var result = parcelLib.GetQuote(2, "GBR", "GBR");
            Assert.IsNotNull(result);
        }
    }
}
