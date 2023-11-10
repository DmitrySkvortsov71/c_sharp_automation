using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper: HelperBase
    {
        private readonly string baseUrl;
        
        public NavigationHelper(ApplicationManager manager, string baseUrl) : base(manager)
        {
            this.baseUrl = baseUrl;
        }
        
        public NavigationHelper OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseUrl + "addressbook/");
            return this;
        }
        
        public NavigationHelper GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }
    }
}