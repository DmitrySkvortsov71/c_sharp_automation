﻿using OpenQA.Selenium;

namespace WebAddressbookTests
{
  public class LoginHelper : HelperBase
  {
    public LoginHelper(ApplicationManager manager) : base(manager)
    {
    }

    public LoginHelper Login(AccountData account)
    {
      if (IsLoggedIn())
      {
        if (IsLoggedIn(account)) return this;
        Logout();
      }

      Type(By.Name("user"), account.Username);
      Type(By.Name("pass"), account.Password);
      driver.FindElement(By.XPath("//input[@value='Login']")).Click();
      return this;
    }

    public bool IsLoggedIn(AccountData account)
    {
      return IsLoggedIn()
             && GetLoggedUserName() == account.Username;
    }

    private string GetLoggedUserName()
    {
      var text = driver.FindElement(By.CssSelector("form[name='logout'] b")).Text;

      // original: (name). "(" with index 0, -2 to cat ")"
      return text.Substring(1, text.Length - 2);
    }

    public bool IsLoggedIn()
    {
      return IsElementPresent(By.LinkText("Logout"));
    }

    public LoginHelper Logout()
    {
      if (IsElementPresent(By.LinkText("Logout"))) driver.FindElement(By.LinkText("Logout")).Click();
      return this;
    }
  }
}