﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

      manager.Navigator.ReturnToHomePage();
      return this;
    }

    public ContactHelper Modify(int index, ContactData newContactData)
    {
      manager.Navigator.OpenHomePage();
      
      InitContactModification(index);
      FillContactForm(newContactData);
      SubmitContactModification();

      manager.Navigator.ReturnToHomePage();
      return this;
    }
    
    public ContactHelper Modify(ContactData contact, ContactData newContactData)
    {
      manager.Navigator.OpenHomePage();
      
      InitContactModification(contact);
      FillContactForm(newContactData);
      SubmitContactModification();

      manager.Navigator.ReturnToHomePage();
      return this;
    }

    public ContactHelper Remove(int index)
    {
      manager.Navigator.OpenHomePage();

      SelectContact(index);
      SubmitContactDeletion();

      manager.Navigator.OpenHomePage(true);
      return this;
    }

    public ContactHelper Remove(ContactData contact)
    {
      manager.Navigator.OpenHomePage();

      SelectContact(contact);
      SubmitContactDeletion();

      manager.Navigator.OpenHomePage(true);
      return this;
    }
    
    public int GetContactsCount()
    {
      manager.Navigator.OpenHomePage();

      // -1 for "Select All" (it always present on Page)
      return driver.FindElements(By.CssSelector("input[id]")).Count - 1;
    }

    public ContactHelper SubmitContactDeletion()
    {
      driver.FindElement(By.CssSelector("input[value='Delete']")).Click();
      driver.SwitchTo().Alert().Accept();

      contactsCache = null;
      return this;
    }

    public ContactHelper SelectContact(int index)
    {
      driver.FindElements(By.CssSelector("input[id]"))[index].Click();
      return this;
    }

    public ContactHelper InitContactModification(int index)
    {
      driver.FindElements(By.CssSelector("a[href^='edit.php?id=']"))[index].Click();
      return this;
    }
    
    public ContactHelper InitContactModification(ContactData contact)
    {
      driver.FindElement(By.CssSelector($"a[href^='edit.php?id={contact.Id}']")).Click();
      return this;
    }

    public ContactHelper SubmitContactModification()
    {
      driver.FindElement(By.Name("update")).Click();

      contactsCache = null;
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

      contactsCache = null;
      return this;
    }

    public ContactHelper FillContactForm(ContactData contact)
    {
      // mandatory parameters
      Type(By.Name("firstname"), contact.FirstName);
      Type(By.Name("lastname"), contact.LastName);
      Type(By.Name("email"), contact.EMail);

      // additional parameters
      if (contact.MainAddress != "") Type(By.Name("address"), contact.MainAddress);
      if (contact.MobilePhone != "") Type(By.Name("mobile"), contact.MobilePhone);
      if (contact.WorkPhone != "") Type(By.Name("work"), contact.WorkPhone);
      if (contact.SecondAddress != "") Type(By.Name("address2"), contact.SecondAddress);

      return this;
    }

    private List<ContactData> contactsCache = null;

    public List<ContactData> GetContactsList()
    {
      if (contactsCache == null)
      {
        contactsCache = new List<ContactData>();
        manager.Navigator.OpenHomePage();

        ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("[name='entry']"));
        foreach (var element in elements)
        {
          var fields = element.FindElements(By.TagName("td"));

          // 1 - last name, 2 - first name, 3 - address, 4 - e-mail
          contactsCache.Add(new ContactData(
              fields[2].Text, fields[1].Text, fields[4].Text));
        }
      }

      return new List<ContactData>(contactsCache);
    }

    public ContactData GetContactInformationFromTable(int index)
    {
      manager.Navigator.OpenHomePage(true);

      var cells = driver.FindElements(By.Name("entry"))[index]
          .FindElements(By.TagName("td"));

      var lastName = cells[1].Text;
      var firstName = cells[2].Text;
      var address = cells[3].Text;
      var eMail = cells[4].Text;
      var allPhones = cells[5].Text;

      return new ContactData(firstName, lastName, eMail)
      {
          MainAddress = address,
          AllPhones = allPhones
      };
    }

    public ContactData GetContactInformationFromEditForm(int index)
    {
      manager.Navigator.OpenHomePage(true);

      InitContactModification(index);

      var firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
      var lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
      var email = driver.FindElement(By.Name("email")).GetAttribute("value");
      var address = driver.FindElement(By.Name("address")).GetAttribute("value");
      var homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
      var mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
      var workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

      return new ContactData(firstName, lastName, email)
      {
          MainAddress = address,
          MobilePhone = mobilePhone,
          WorkPhone = workPhone,
          HomePhone = homePhone
      };
    }

    public int GetNumberOfSearchResults()
    {
      manager.Navigator.OpenHomePage();

      var text = driver.FindElement(By.TagName("label")).Text;
      var m = new Regex(@"\d+").Match(text);

      return int.Parse(m.Value);
    }

    public ContactHelper OpenContactDetailsPage(int index)
    {
      driver.FindElements(By.CssSelector("a[href^='view.php?id=']"))[index].Click();
      return this;
    }

    public string GetContactDetailedInformationFromDetailsPage(int index, bool trimmed = false)
    {
      manager.Navigator.OpenHomePage();
      OpenContactDetailsPage(index);

      var rawDetailsInformation = driver.FindElement(By.CssSelector("[id='content']")).Text;
      return !trimmed ? rawDetailsInformation : rawDetailsInformation.Replace($"\r\n", "");
    }

    public ContactHelper AddContactToGroup(ContactData contact, GroupData group)
    {
      manager.Navigator.OpenHomePage();

      ClearGroupFilter();
      SelectContact(contact);
      SelectGroupToAdd(group.Name);
      CommitAddToGroup();

      return this;
    }


    public ContactHelper SelectContact(ContactData contact)
    {
      driver.FindElement(By.CssSelector($"input[id='{contact.Id}']")).Click();
      return this;
    }

    public ContactHelper CommitAddToGroup()
    {
      driver.FindElement(By.Name("add")).Click();
      WaitTillElementPresence(10, "div.msgbox");
      return this;
    }

    public ContactHelper SelectGroupToAdd(string groupName)
    {
      new SelectElement(driver.FindElement(By.CssSelector("select[name='to_group']"))).SelectByText(groupName);
      return this;
    }

    public ContactHelper ClearGroupFilter()
    {
      new SelectElement(driver.FindElement(By.CssSelector("select[name='group']"))).SelectByText("[all]");
      return this;
    }

    public void RemoveContactFromGroup(ContactData contact, GroupData group)
    {
      manager.Navigator.OpenHomePage();

      SetGroupFilter(group);
      SelectContact(contact);
      CommitRemoveContactFromGroup();

    }

    private ContactHelper SetGroupFilter(GroupData group)
    {
      new SelectElement(driver.FindElement(By.CssSelector("select[name='group']"))).SelectByText(group.Name);
      return this;
    }

    private ContactHelper CommitRemoveContactFromGroup()
    {
      driver.FindElement(By.CssSelector("input[name='remove']")).Click();
      WaitTillElementPresence(10, "div.msgbox");
      return this;
    }
  }
}