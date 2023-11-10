using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected  IWebDriver driver;
        protected ApplicationManager manager;

        protected HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }
    }
}