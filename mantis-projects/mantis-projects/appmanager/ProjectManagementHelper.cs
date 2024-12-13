using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace mantis_projects
{
    
    public class ProjectManagementHelper : HelperBase
    {        
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ProjectManagementHelper CreateProject(ProjectData project)
        {

            InitProjectCreation();
            FillProjectForms(project);
            SubmitProjectCreation();
            return this;
        }

        public ProjectManagementHelper InitProjectCreation()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.Navigate().GoToUrl("http://localhost/mantisbt/manage_proj_create_page.php");
            return this;
        }
        public ProjectManagementHelper FillProjectForms(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).Click();
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            driver.FindElement(By.Id("project-description")).Click();
            driver.FindElement(By.Id("project-description")).Clear();
            driver.FindElement(By.Id("project-description")).SendKeys(project.Description);
            return this;
        }
        public ProjectManagementHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
            driver.Navigate().GoToUrl("http://localhost/mantisbt/manage_proj_create.php");
            return this;
        }
        public ProjectManagementHelper InitProjectRemoving()
        {
            //driver.Navigate().GoToUrl("http://localhost/mantisbt/manage_proj_edit_page.php?project_id=3");
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            return this;
        }

        public ProjectManagementHelper SelectProjectForRemoving(int v)
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt/manage_proj_page.php");           
            driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr/td/a")).Click();
            // /html/body/div[2]/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr/td[1]/a
            
            return this;
        }

        
        public ProjectManagementHelper FinishProjectRemoving()
        {
            
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            return this;
        }

        public ProjectManagementHelper Remove(int v)
        {
            SelectProjectForRemoving(1);
            InitProjectRemoving();
            FinishProjectRemoving();
            return this;
        }
    }
}
