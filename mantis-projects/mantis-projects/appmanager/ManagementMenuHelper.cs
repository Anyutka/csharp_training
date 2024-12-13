using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace mantis_projects
{
    public class ManagementMenuHelper : HelperBase
    {        

        public ManagementMenuHelper(ApplicationManager manager) : base(manager)
        {
        }
        
        public void GoToProjectManagement()
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt/manage_overview_page.php");
            driver.FindElement(By.LinkText("Manage Projects")).Click();
        }

        public void GoToManagementPane()
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt/account_page.php");
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[7]/a/span")).Click();
        }
    }
    }


