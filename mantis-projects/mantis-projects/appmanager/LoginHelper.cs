using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_projects
{
    public class LoginHelper : HelperBase
    {        
        public LoginHelper(ApplicationManager manager) : base (manager)
        {    
        }
        public void Login(AccountData account)
        {
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys(account.Username);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            //driver.Navigate().GoToUrl("http://localhost/mantisbt/login_password_page.php");
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//form[@id='login-form']/fieldset/div/label/span")).Click();
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
    }
}
