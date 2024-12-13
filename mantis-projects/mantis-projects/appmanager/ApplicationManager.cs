using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.DevTools.V129.Audits;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_projects
{
    public class ApplicationManager
    {
        protected IWebDriver driver;        
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected ManagementMenuHelper management;
        protected ProjectManagementHelper projectManagement;


        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt/login_page.php";
            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this,baseURL);
            management = new ManagementMenuHelper(this);
            projectManagement = new ProjectManagementHelper(this);
        }
        public IWebDriver Driver
        {
            get 
            { 
                return driver;
            }
        }
        
        
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
       
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }
        public ManagementMenuHelper Management
        {
            get
            {
                return management;
            }
        }
        public ProjectManagementHelper ProjectManagement
        {
            get
            {
                return projectManagement;
            }
        }

       
    }
}


