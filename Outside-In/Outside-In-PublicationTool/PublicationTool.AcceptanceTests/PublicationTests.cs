using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PublicationTool.AcceptanceTests
{
    public class PublicationTests
    {
        [Test]
        public async Task Publication_service_can_be_reached()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:56985/Publication");

            var result = await httpClient.GetAsync("");

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}