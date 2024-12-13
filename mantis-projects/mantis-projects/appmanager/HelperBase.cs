using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_projects
{
    public class HelperBase
    {
        protected IWebDriver driver;
        private ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;           
        }
    }
}
