using HelloWorld.SimpleWebsite.Controllers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HelloWorld.SimpleWebsite.Tests
{

    internal class SampleTests : UiTestBase
    {
        protected override void SetUp()
        {
            base.SetUp();

            Browser.Navigate().GoToUrl("http://localhost:81/Simple/Main");         
        }

        [Test]
        public void ClickButton_Succeeds_WhenCnn()
        {
            //Act - click the button
            var hackButtonEl = Browser.FindElement(By.Id(SimpleWebsiteController.HackButtonId));
            hackButtonEl.Click();

            //Validate - that the site changed to cnn
            var actual = Browser.Title;
            var expected = "CNN - Breaking News, Latest News and Videos";
            Assert.AreEqual(expected, actual);
        }
    }
}