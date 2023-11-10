using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        private readonly string baseUrl;
        protected ContactHelper contactHelper;
        private readonly IWebDriver driver;
        protected GroupHelper groupHelper;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;

        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseUrl = "http://localhost/";

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseUrl);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        public LoginHelper Auth => loginHelper;
        public NavigationHelper Navigator => navigator;
        public GroupHelper Groups => groupHelper;
        public ContactHelper Contacts => contactHelper;

        public IWebDriver Driver => driver;

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}