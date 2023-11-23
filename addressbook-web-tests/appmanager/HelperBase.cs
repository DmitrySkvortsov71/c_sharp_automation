using OpenQA.Selenium;

namespace WebAddressbookTests
{
  public class HelperBase
  {
    protected IWebDriver driver;
    protected ApplicationManager manager;

    protected HelperBase(ApplicationManager manager)
    {
      this.manager = manager;
      driver = manager.Driver;
    }

    public void Type(By locator, string text)
    {
      if (text == null) return;

      driver.FindElement(locator).Click();
      driver.FindElement(locator).Clear();
      driver.FindElement(locator).SendKeys(text);
    }

    public bool IsElementPresent(By by)
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
  }
}