﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System.Diagnostics.Contracts;
using System.Runtime.Remoting.Contexts;
using System.Reflection;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper Create(ContactData contact)
        {
            AddNewContact();
            ContactHelper contactHelper = EnterContactData(contact);
            SelectContactDates();
            SelectGroupforContact();
            SubmitContact();
            ReturnToContactsPage();
            return this;
        }
        public ContactHelper Modify(int v, ContactData contactnewData)
        {
            manager.Contacts.
            
            InitContactModification(v);
            System.Threading.Thread.Sleep(3000);
            EnterContactData(contactnewData);
            SelectContactDates();
            SubmitContactModification();
            ReturnToContactsPage();
            return this;
        }
        public void VerifyContactPresent(ContactData contact)
        {
            manager.Navigator.GoToHomePage();

            if (!IsContactPresentIn())
            {
                Create(contact);
            }
        }

        public bool IsContactPresentIn()
        {
            return IsElementPresent(By.Name("entry"));
        }


        public ContactHelper Remove(int v)
        {
            manager.Contacts.
            SelectContact(v);
            RemoveContact();
            System.Threading.Thread.Sleep(3000);
            return this;
        }

        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper EnterContactData(ContactData contact)

        {
            Type(By.Name("firstname"), contact.Name);
            Type(By.Name("middlename"), contact.Middle);
            Type(By.Name("lastname"), contact.Surname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Telhome);
            Type(By.Name("mobile"), contact.Telmobile);
            Type(By.Name("work"), contact.Telwork);
            Type(By.Name("fax"), contact.Telfax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            return this;
        }

        public ContactHelper SelectContactDates()
        {
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("15");
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("14");
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("April");
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("December");
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("September");
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys("2021");
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("11");
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("July");
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys("2022");
            return this;
        }

        public ContactHelper SelectGroupforContact()
        {
            driver.FindElement(By.Name("new_group")).Click();
            driver.FindElement(By.Name("new_group")).Click();
            return this;
        }

        public ContactHelper SubmitContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
            contactCache =null;
            return this;
        }
        public ContactHelper ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.LinkText("home")).Click();
            driver.FindElement
    (By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("//*[@id='maintable']/tbody/tr[" + (index+2) + "]/td[8]/a/img")).Click();
            
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                List<ContactData> contacts = new List<ContactData>();
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                IList<IWebElement> rows = driver.FindElements(By.TagName("tr"));

                foreach (IWebElement row in rows)
                {
                    IList<IWebElement> cells = row.FindElements(By.TagName("td"));
                    if (cells.Count > 0)
                    {
                        string name = cells[2].Text;
                        string surname = cells[1].Text;
                        string id = row.FindElement(By.TagName("input")).GetAttribute("value");

                        ContactData contact = new ContactData(); // объект , contact - то как обращаюсь к объекту
                        contact.Name = name; // присвоила данные объекта?
                        contact.Surname = surname;
                        contact.Id = id;
                        contactCache.Add(contact);
                        
                    }
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
             
            IList<IWebElement> rows = driver.FindElements(By.TagName("tr"));
            int count = 0;
            foreach (IWebElement row in rows)
            {
                IList<IWebElement> cells = row.FindElements(By.TagName("td"));
                if (cells.Count > 0)
                {
                    count = count + 1;
                }
            }
            return count;
        } 

    }
}





