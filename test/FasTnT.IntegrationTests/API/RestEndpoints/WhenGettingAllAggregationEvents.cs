﻿using FasTnT.IntegrationTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;

namespace FasTnT.IntegrationTests.API.RestEndpoints
{
    [TestClass]
    [TestCategory("IntegrationTests")]
    public class WhenGettingAllAggregationEvents : BaseMigratedIntegrationTest
    {
        public override void Act()
        {
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "YWRtaW46UEBzc3cwcmQ=");
            var request = new HttpRequestMessage(HttpMethod.Get, "/v2_0/events/AggregationEvent/all") { Content = new StringContent("", Encoding.UTF8, "application/json") };
            Result = Client.SendAsync(request).Result;
        }

        [Assert]
        public void ItShouldReturnHttp200OK() => Assert.AreEqual(HttpStatusCode.OK, Result.StatusCode);

        [Assert]
        public void ItShouldReturnAnArrayOfString() => Assert.IsNotNull(JsonConvert.DeserializeObject<object[]>(Result.Content.ReadAsStringAsync().Result));
    }
}
