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
            ModifyGroup(0, groupnewData);
            return this;
        }

        public GroupHelper Modify(GroupData toBeModified, GroupData groupnewData)
        {
            manager.Navigator.GoToGroupsPage();
            ModifyGroup(toBeModified, groupnewData);
            return this;
        }

        public void VerifyGroupPresent(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            if (!IsGroupPresentIn())
            {
                CreateGroup(group);
            }
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
        public void ModifyGroup(int p, GroupData groupnewData)
        {
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(groupnewData);
            SubmitGroupModification();
            ReturnToGroupsPage();
        }
        public void ModifyGroup(GroupData toBeModified, GroupData groupnewData)
        {
            SelectGroup(toBeModified.Id);
            InitGroupModification();
            FillGroupForm(groupnewData);
            SubmitGroupModification();
            ReturnToGroupsPage();
        }
        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(group.Id);
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
            groupCache = null;
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();

            return this;
        }
        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();

            return this;
        }
        
        public GroupHelper RemoveGroup()
        {

            if (IsElementPresent(By.Name("delete")))
            {
                driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();

            }
            groupCache = null;
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            if (IsElementPresent(By.Name("update")))
            {
                driver.FindElement(By.Name("update")).Click();
                groupCache = null;
            }
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(null)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
                    string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                    string[] parts = allGroupNames.Split('\n');
                    int shift = groupCache.Count - parts.Length;


                    for (int i = 0; i < groupCache.Count; i++)
                    {
                        if (i < shift)
                        {
                            groupCache[i].Name = "";
                        }
                        else
                        {
                            groupCache[i].Name = parts[i - shift].Trim(); // вот так пропишем имена всех групп
                        }
                    }
                }

                return new List<GroupData>(groupCache);
            }

            public int GetGroupCount()
            {
                return driver.FindElements(By.CssSelector("span.group")).Count;
            }

        
    }
    }


