﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace WebAddressbookTests
{
        public class GroupHelper : HelperBase
    {           
            public GroupHelper(ApplicationManager manager) : base(manager)
            {               
            }
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
                InitGroupCreation();
                FillGroupForm(group);
                SubmitGroupCreation();
                ReturnToGroupsPage();
            return this;       
        }
        public GroupHelper Modify(int p, GroupData groupnewData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(groupnewData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this; 
        }

        

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;

        }
        
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            
            return this;
        }
       

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }


    }
}
