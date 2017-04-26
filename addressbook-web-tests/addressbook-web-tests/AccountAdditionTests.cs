using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AccountAdditionTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver(new FirefoxBinary("C:\\Users\\anik\\Downloads\\firefox-sdk\\bin\\firefox.exe"), new FirefoxProfile());
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
        public void AccountAdditionTest()
        {
            OpenHomePage();
            Login("admin", "secret");
            InitNewAccountAddition();
            ContactData contact = new ContactData("Alisa");
            contact.Lastname = "Moonny";
            FillAccountForm(contact);
            SubmitNewAccountAdditionHomePage();
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void SubmitNewAccountAdditionHomePage()
        {
            
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillAccountForm(ContactData contact) 
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            //driver.FindElement(By.Name("nickname")).Clear();
            //driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            //driver.FindElement(By.Name("title")).Clear();
            //driver.FindElement(By.Name("title")).SendKeys(title);
            //driver.FindElement(By.Name("company")).Clear();
            //driver.FindElement(By.Name("company")).SendKeys(company);
            //driver.FindElement(By.Name("address")).Clear();
            //driver.FindElement(By.Name("address")).SendKeys(address);
            //driver.FindElement(By.Name("home")).Clear();
            //driver.FindElement(By.Name("home")).SendKeys(home);
            //driver.FindElement(By.Name("mobile")).Clear();
            //driver.FindElement(By.Name("mobile")).SendKeys(mobile);
            //driver.FindElement(By.Name("work")).Clear();
            //driver.FindElement(By.Name("work")).SendKeys(work);
            //driver.FindElement(By.Name("fax")).Clear();
            //driver.FindElement(By.Name("fax")).SendKeys(fax);
            //driver.FindElement(By.Name("email")).Clear();
            //driver.FindElement(By.Name("email")).SendKeys(email);
            //driver.FindElement(By.Name("email2")).Clear();
            //driver.FindElement(By.Name("email2")).SendKeys(email2);
            //driver.FindElement(By.Name("email3")).Clear();
            //driver.FindElement(By.Name("email3")).SendKeys(email3);
            //driver.FindElement(By.Name("homepage")).Clear();
            //driver.FindElement(By.Name("homepage")).SendKeys(homepage);
            //driver.FindElement(By.Name("address2")).Clear();
            //driver.FindElement(By.Name("address2")).SendKeys(address2);
            //driver.FindElement(By.Name("phone2")).Clear();
            //driver.FindElement(By.Name("phone2")).SendKeys(phone2);
            //driver.FindElement(By.Name("notes")).Clear();
            //driver.FindElement(By.Name("notes")).SendKeys(notes);
        }

        private void InitNewAccountAddition()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void Login(string username, string password)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
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
