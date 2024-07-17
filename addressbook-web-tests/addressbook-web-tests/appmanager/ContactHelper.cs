using System;
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
            SelectContact();
            InitContactModification();
            System.Threading.Thread.Sleep(3000);
            EnterContactData(contactnewData);
            SelectContactDates();
            SubmitContactModification();
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
            SelectContact();
            RemoveContact();
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
            return this;
        }
        public ContactHelper ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public ContactHelper SelectContact()
        {
            driver.FindElement(By.LinkText("home")).Click();
            // driver.FindElement(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[3]/td[1]/input")).Click();
            driver.FindElement(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[2]/td[1]/input")).Click();

            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;

        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {
            
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();     
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();

            IList<IWebElement> rows = driver.FindElements(By.TagName("tr"));
            
            foreach (IWebElement row in rows) 

            {
                IList<IWebElement> cells= row.FindElements(By.TagName("td"));
            if (cells.Count > 0) 
                {
                    string name = cells[2].Text;
                    string surname = cells[1].Text;
                    ContactData contact = new ContactData();

                    contact.Name = name;
                    contact.Surname = surname;  

                    contacts.Add(contact);
                }

            }
            return contacts;

        }
    }
}



    

