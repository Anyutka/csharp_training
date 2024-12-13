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
    public class NavigationHelper : HelperBase
    {                     
        private string baseUrl;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseUrl = baseURL;
        }
           
        public void OpenLoginPage()
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt/manage_proj_create_page.php");
        }

        public void ReturnToProjectsPage()
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt/manage_proj_page.php");
        }
    }
}
