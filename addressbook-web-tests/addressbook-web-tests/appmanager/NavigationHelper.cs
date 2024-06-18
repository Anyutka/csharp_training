﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace WebAddressbookTests
{
    
        public class NavigationHelper : HelperBase
    {
        
            private string baseURL;
            public NavigationHelper(IWebDriver driver, string baseURL) : base(driver)
        {
                this.baseURL = baseURL;
            }
            public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

    }
}