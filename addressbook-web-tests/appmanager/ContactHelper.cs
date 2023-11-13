﻿using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation(); 
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Modify(int index, ContactData newContactData)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(index);
            FillContactForm(newContactData);
            SubmitContactModification();
            
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper Remove(int index)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(index);
            SubmitContactDeletion();
            
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper SubmitContactDeletion()
        {
            driver.FindElement(By.CssSelector("input[value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElements(By.CssSelector("input[id]"))[index - 1].Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.CssSelector("a[href^='edit.php?id=']"))[index - 1].Click();
            return this;
        }
        
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        
        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.CssSelector("input[name='submit']")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            // mandatory parameters
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contact.EMail);

            // additional parameters
            if (contact.MainAddress != "")
            {
                driver.FindElement(By.Name("address")).Click();
                driver.FindElement(By.Name("address")).Clear();
                driver.FindElement(By.Name("address")).SendKeys(contact.MainAddress);
            }

            if (contact.MobilePhone != "")
            {
                driver.FindElement(By.Name("mobile")).Click();
                driver.FindElement(By.Name("mobile")).Clear();
                driver.FindElement(By.Name("mobile")).SendKeys(contact.MobilePhone);
            }
            
            if (contact.WorkPhone != "")
            {
                driver.FindElement(By.Name("work")).Click();
                driver.FindElement(By.Name("work")).Clear();
                driver.FindElement(By.Name("work")).SendKeys(contact.WorkPhone);
            }
            
            if (contact.SecondAddress != "")
            {
                driver.FindElement(By.Name("address2")).Click();
                driver.FindElement(By.Name("address2")).Clear();
                driver.FindElement(By.Name("address2")).SendKeys(contact.SecondAddress);
            }
            return this;
        }
        
    }
}