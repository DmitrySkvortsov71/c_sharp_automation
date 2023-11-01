using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));

            InitContactCreation();

            ContactData contact = new ContactData("werty", "qwerty", "werty.qwert@gmail.com")
            {
                MobilePhone = "+711111111",
                MainAddress = "kjhdsfkhjskdhjf"
            };
            FillContactForm(contact);
            SubmitContactCreation();

            OpenHomePage();
            Logout();
        }

        private void FillContactForm(ContactData contact)
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
        }

        private void SubmitContactCreation()
        {
            driver.FindElement(By.CssSelector("input[name='submit']")).Click();
        }

        private void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        private void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}

