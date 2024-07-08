using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Internal;

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

            public void ModifyGroup(int p, GroupData groupnewData, GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            if (IsGroupPresentIn())
            {
                if (IsGroupPresentIn())
                {
                    return;
                }
                CreateGroup(group);
            }
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(groupnewData);
            SubmitGroupModification();
            ReturnToGroupsPage();
        }


        public bool IsGroupPresentIn()
        {
            return IsElementPresent(By.Name("selected[]"));
        }
        
        public void CreateGroup(GroupData group)
        {
           InitGroupCreation();
           FillGroupForm(group);
           SubmitGroupCreation();
           ReturnToGroupsPage();
       }
       //public void ModifyGroup(int p, GroupData groupnewData)
        //{
          //SelectGroup(p);
          //InitGroupModification();
          //FillGroupForm(groupnewData);
          //SubmitGroupModification();
          //ReturnToGroupsPage();
      // }

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
            if (IsElementPresent(By.XPath("//*[.='zzz']"))
                && IsElementPresent(By.XPath("/html/body/div/div[4]/form/span[7]/input")))
            {
                driver.FindElement(By.XPath("/html/body/div/div[4]/form/span[7]/input")).Click();
            }
            else
            {
                driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            }
            return this;
        }
        public GroupHelper RemoveGroup()
        {

            if (IsElementPresent(By.Name("delete")))
            {
                driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
            }
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            if (IsElementPresent(By.Name("update")))
            {
                driver.FindElement(By.Name("update")).Click();
            }
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }
    }
}

