using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Xml.Linq;

namespace Ploeh.Samples.RunningJournalApi.AcceptanceTests
{
    public class HomeXmlTests
    {
        private readonly static XNamespace j = "http://samples.ploeh.dk/journal/2012";

        [Fact]
        public void GetReturnsResponseWithCorrectStatusCode()
        {
            using (var client = HttpClientFactory.Create())
            {
                client.DefaultRequestHeaders.Accept.ParseAdd("application/xml");

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
                client.DefaultRequestHeaders.Accept.ParseAdd("application/xml");

                var response = client.GetAsync("").Result;

                Assert.Equal(
                    "application/xml",
                    response.Content.Headers.ContentType.MediaType);
                var xml = response.Content.ReadAsXmlAsync().Result;
                Assert.Equal(1, xml.Elements(j + "journal").Count());
            }
        }
    }
}
