using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private readonly string baseUrl;

        public NavigationHelper(ApplicationManager manager, string baseUrl) : base(manager)
        {
            this.baseUrl = baseUrl;
        }

        public NavigationHelper OpenHomePage(bool refresh = false)
        {
            if (driver.Url != baseUrl + "addressbook/" | refresh) driver.Navigate().GoToUrl(baseUrl + "addressbook/");
            
            return this;
        }

        public NavigationHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public NavigationHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public NavigationHelper GoToGroupsPage()
        {
            if (driver.Url == baseUrl + "addressbook/group.php"
                && IsElementPresent(By.Name("new")))
                return this;

            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }
    }
}