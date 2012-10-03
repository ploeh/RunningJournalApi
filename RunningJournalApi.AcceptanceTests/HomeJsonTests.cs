using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Web.Http.SelfHost;
using System.Net.Http;
using Ploeh.Samples.RunningJournalApi;

namespace Ploeh.Samples.RunningJournalApi.AcceptanceTests
{
    public class HomeJsonTests
    {
        [Fact]
        public void GetReturnsResponseWithCorrectStatusCode()
        {
            var baseAddress = new Uri("http://localhost:8765");
            var config = new HttpSelfHostConfiguration(baseAddress);
            new Bootstrap().Configure(config);
            var server = new HttpSelfHostServer(config);
            using (var client = new HttpClient(server))
            {
                client.BaseAddress = baseAddress;

                var response = client.GetAsync("").Result;

                Assert.True(
                    response.IsSuccessStatusCode,
                    "Actual status code: " + response.StatusCode);
            }
        }
    }
}
