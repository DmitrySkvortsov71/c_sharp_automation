using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

    public void WaitTillElementPresence(int secondsToWait, string cssSelector)
    {
      new WebDriverWait(driver, TimeSpan.FromSeconds(secondsToWait))
          .Until(d => d.FindElements(By.CssSelector(cssSelector)).Count > 0);
    }
  }
}