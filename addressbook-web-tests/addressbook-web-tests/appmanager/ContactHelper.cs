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
using WebAddressbookTests;
using System.Text.RegularExpressions;


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
            Type(By.Name("home"), contact.TelHome);
            Type(By.Name("mobile"), contact.TelMobile);
            Type(By.Name("work"), contact.TelWork);
            Type(By.Name("fax"), contact.TelFax);
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
            
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("April");           
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
        //driver.FindElement(By.XPath("//*[@id='maintable']/tbody/tr[" + (index+2) + "]/td[8]/a/img")).Click();
            
          driver.FindElements(By.Name("entry"))[index]
              .FindElements(By.TagName("td"))[7]
               .FindElement(By.TagName("a")).Click();
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

                        ContactData contact = new ContactData(name, surname); // объект , contact - то как обращаюсь к объекту
                        //contact.Name = name; // присвоила данные объекта?
                        //contact.Surname = surname;
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

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                  .FindElements(By.TagName("td"));

            string secondName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;


            return new ContactData(firstName, secondName)
            {
                Address = address,
                AllPhones= allPhones,
                AllEmails = allEmails                
            };

        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(1);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string secondName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string faxPhone = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string emailAdd = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2Add = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3Add = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            string bDay = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bMonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string bYear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aDay = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string aMonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            string aYear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            
            return new ContactData(firstName, secondName)
            {
                Middle = middleName,
                Nickname = nickname,
                Title = title,
                Company = company,
                
                Address = address,

                TelHome = homePhone,
                TelMobile = mobilePhone,
                TelWork = workPhone,
                
                TelFax = faxPhone,
               
                Email = emailAdd,
                Email2 = email2Add,
                Email3 = email3Add,
                
                Homepage = homePage,
                
                BDay = bDay,
                BMonth = bMonth,
                BYear = bYear,
                
                ADay = aDay,
                AMonth = aMonth,
                AYear = aYear

    };            
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);  
        }

        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            driver.FindElement(By.XPath("//*[@id='maintable']/tbody/tr[" + (index + 2) + "]/td[7]/a/img")).Click();
            IWebElement details = driver.FindElement(By.Id("content"));

            return new ContactData(null, null)
            {
                AllDetails = details.Text
            };

        }
    }
}





