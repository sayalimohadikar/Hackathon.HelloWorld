using HelloWorld.SimpleWebsite.Tests.Factory;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Net.Http;

namespace HelloWorld.SimpleWebsite.Tests
{
    [TestFixture]
    internal abstract class UiTestBase
    {
        protected UiTestServerFactory<SimpleWebsiteService> ServerFactory { get; private set; }

        protected IWebDriver Browser { get; private set; }

        protected HttpClient Client { get; private set; }

        protected ILogs Logs { get; private set; }

        [SetUp]
        protected virtual void SetUp()
        {
            ServerFactory = new UiTestServerFactory<SimpleWebsiteService>();
            Client = ServerFactory.CreateClient(); //weird side effect thing here. This call shouldn't be required for setup, but it is.

            var opts = new ChromeOptions();
            //opts.AddArgument("--headless"); //Optional, comment this out if you want to SEE the browser window
            opts.SetLoggingPreference(OpenQA.Selenium.LogType.Browser, LogLevel.All);

            var driver = new RemoteWebDriver(opts);
            Browser = driver;
            Logs = new RemoteLogs(driver);
        }


        [TearDown]
        protected virtual void TearDown()
        {
            Browser.Quit();
            Browser.Dispose();
            ServerFactory.Dispose();
        }

    }
}
