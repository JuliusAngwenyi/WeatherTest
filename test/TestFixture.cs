using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TestFixture<TStartup> : IDisposable where TStartup : class
    {
        private readonly TestServer _server;
        public TestFixture()
        {
            var builder = new WebHostBuilder().UseStartup<TStartup>();
            _server = new TestServer(builder);

            Client = _server.CreateClient();
            Client.BaseAddress = new Uri("http://localhost:53532");
        }

        public HttpClient Client { get;}

        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}
