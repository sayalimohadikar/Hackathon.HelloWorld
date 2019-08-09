using Atlas.WebService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Diagnostics;
using System.Linq;

namespace HelloWorld.SimpleWebsite.Tests.Factory
{

    /// <remarks>
    /// Idea taken from: https://www.hanselman.com/blog/RealBrowserIntegrationTestingWithSeleniumStandaloneChromeAndASPNETCore21.aspx
    /// </remarks>
    internal class UiTestServerFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : AtlasService
    {
        public const string SeleniumFilename = "selenium-standalone";
        public const string SeleniumArguments = "start";

        public string RootUri { get; set; }
       
        private readonly Process _seleniumStandaloneProcess;
        private IWebHost _host;

        private TStartup _atlasService;

        public UiTestServerFactory()
        {
            ClientOptions.BaseAddress = new Uri("http://localhost");

            _atlasService = Activator.CreateInstance<TStartup>();

            //_seleniumStandaloneProcess = StartSeleniumProcess();
        }

        /// <summary>
        /// Starts and returns the selenium standalone process.
        /// </summary>
        /// <returns>
        /// The process created so you can later close it.
        /// </returns>
        /// <remarks>
        /// The standalone process is the application that allows selenium to control a browser
        /// </remarks>
        private Process StartSeleniumProcess()
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = SeleniumFilename,
                    Arguments = SeleniumArguments,
                    UseShellExecute = true
                }
            };

            process.Start();
            return process;
        }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return new WebHostBuilder().UseAtlasWeb(_atlasService, null);
        }

        protected override TestServer CreateServer(IWebHostBuilder builder)
        {                        
            _host = builder.Build();
            _host.Start();
                                    
            RootUri = _host.ServerFeatures.Get<IServerAddressesFeature>().Addresses.LastOrDefault();

            //this return is not used - we are instead holding onto our host so selenium can hit it            
            return FakeServer.Create();
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;

            _host.Dispose();
            _seleniumStandaloneProcess?.CloseMainWindow();
        }

    }
}
