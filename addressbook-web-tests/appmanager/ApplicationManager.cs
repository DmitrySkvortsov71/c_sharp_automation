using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        private readonly string baseUrl;
        protected ContactHelper contactHelper;
        private  IWebDriver driver;
        protected GroupHelper groupHelper;
        
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        
        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseUrl = "http://localhost/";

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseUrl);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }
        
        ~ApplicationManager()
        {
            driver.Quit();
        }
        
        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                app.Value = new ApplicationManager();
                app.Value.Navigator.OpenHomePage();
            }
            return app.Value;
        }
        
        public LoginHelper Auth => loginHelper;
        public NavigationHelper Navigator => navigator;
        public GroupHelper Groups => groupHelper;
        public ContactHelper Contacts => contactHelper;
        public IWebDriver Driver => driver;
        
    }
}