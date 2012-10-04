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
            using (var client = HttpClientFactory.Create())
            {
                var response = client.GetAsync("").Result;

                Assert.True(
                    response.IsSuccessStatusCode,
                    "Actual status code: " + response.StatusCode);
            }
        }

        [Fact]
        public void GetReturnsJsonContent()
        {
            using (var client = HttpClientFactory.Create())
            {
                var response = client.GetAsync("").Result;

                Assert.Equal(
                    "application/json",
                    response.Content.Headers.ContentType.MediaType);
                var json = response.Content.ReadAsJsonAsync().Result;
                Assert.NotNull(json);
            }
        }

        [Fact]
        public void PostEntrySucceeds()
        {
            using (var client = HttpClientFactory.Create())
            {
                var json = new
                {
                    time = DateTimeOffset.Now,
                    distance = 8500,
                    duration = TimeSpan.FromMinutes(44)
                };
                var content = new JsonContent(json);
                content.Headers.ContentType.MediaType = "application/json";

                var response = client.PostAsync("", content).Result;

                Assert.True(
                    response.IsSuccessStatusCode,
                    "Actual status code: " + response.StatusCode);
            }
        }
    }
}
