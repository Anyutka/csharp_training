using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Untitled
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheUntitledTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/group.php");
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys("admin");
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys("secret");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            driver.FindElement(By.Name("new")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys("q");
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys("q");
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys("q");
            driver.FindElement(By.Name("submit")).Click();
            driver.FindElement(By.CssSelector("#label_5_17 > span.item-content-wrap")).Click();
            driver.FindElement(By.CssSelector("button.vjs-big-play-button")).Click();
            driver.FindElement(By.XPath("(//button[@type='button'])[2]")).Click();
            driver.FindElement(By.LinkText("group page")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
            driver.FindElement(By.Id("yui_3_17_2_1_1492284354449_97")).Click();
            driver.FindElement(By.Id("yui_3_17_2_1_1492284354449_99")).Click();
            driver.FindElement(By.CssSelector("div.vjs-play-progress.vjs-slider-bar")).Click();
            driver.FindElement(By.Id("yui_3_17_2_1_1492284354449_97")).Click();
            driver.FindElement(By.Id("fv_14922843551158695455_html5_api")).Click();
            driver.FindElement(By.Id("yui_3_17_2_1_1492284354449_97")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}

