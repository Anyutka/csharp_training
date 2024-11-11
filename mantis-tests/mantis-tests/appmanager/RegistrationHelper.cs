using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using static OpenQA.Selenium.BiDi.Modules.Script.EvaluateResult;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            //OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistrationForm();                            
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.CssSelector("#login-box > div > div.toolbar.center > a.back-to-login-link.pull-left")).Click();
        }

        private void SubmitRegistrationForm()
        {
            driver.FindElement(By.CssSelector("#signup-form > fieldset > input.width-40.pull-right.btn.btn-success.btn-inverse.bigger-110")).Click();               
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt/login_page.php";
        }
    }
}
