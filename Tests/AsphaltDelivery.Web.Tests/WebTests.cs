namespace AsphaltDelivery.Web.Tests
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Testing;

    using Xunit;

    public class WebTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> server;

        public WebTests(WebApplicationFactory<Startup> server)
        {
            this.server = server;
        }

        [Fact]
        public async Task IndexPageShouldReturnStatusCode200WithTitle()
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains("<title>", responseContent);
        }

        [Theory]
        [InlineData("/AsphaltBases/All")]
        [InlineData("/AsphaltBases/Details")]
        [InlineData("/Administration/AsphaltBases/Create")]
        [InlineData("/Administration/AsphaltBases/Edit")]
        [InlineData("/Administration/AsphaltBases/Delete")]
        public async Task AsphaltBasesPagesRequireAuthorizationAndReturnSuccess(string url)
        {
            var client = this.server.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
            var response = await client.GetAsync(url);

            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        }

        [Theory]
        [InlineData("/Home/Index")]
        [InlineData("/Home/Privacy")]
        [InlineData("/AsphaltBases/All")]
        [InlineData("/AsphaltBases/Details")]
        [InlineData("/Administration/AsphaltBases/Create")]
        [InlineData("/Administration/AsphaltBases/Edit")]
        [InlineData("/Administration/AsphaltBases/Delete")]
        public async Task Test_EndpointReturnSuccessAndCorrectContentType(string url)
        {
            var client = this.server.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
