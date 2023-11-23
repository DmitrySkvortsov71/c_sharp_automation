using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
  public class GroupHelper : HelperBase
  {
    public GroupHelper(ApplicationManager manager) : base(manager)
    {
    }

    public GroupHelper Create(GroupData group)
    {
      manager.Navigator.GoToGroupsPage();

      InitGroupCreation();
      FillGroupForm(group);
      SubmitGroupCreation();

      manager.Navigator.ReturnToGroupsPage();

      return this;
    }

    public GroupHelper Modify(int index, GroupData newData)
    {
      manager.Navigator.GoToGroupsPage();

      SelectGroup(index);
      InitGroupModification();
      FillGroupForm(newData);
      SubmitGroupModification();

      manager.Navigator.ReturnToGroupsPage();

      return this;
    }

    public GroupHelper Remove(int index)
    {
      manager.Navigator.GoToGroupsPage();

      SelectGroup(index);
      RemoveGroup();

      return this;
    }


    public int GetGroupsCount()
    {
      manager.Navigator.GoToGroupsPage();
      return driver.FindElements(By.CssSelector("span.group [type='checkbox']")).Count;
    }

    public GroupHelper InitGroupModification()
    {
      driver.FindElement(By.CssSelector("input[value='Edit group']")).Click();
      return this;
    }

    public GroupHelper SubmitGroupModification()
    {
      driver.FindElement(By.CssSelector("input[value='Update']")).Click();
      groupsCache = null;

      return this;
    }

    public GroupHelper RemoveGroup()
    {
      driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
      groupsCache = null;

      return this;
    }

    public GroupHelper SelectGroup(int index)
    {
      var groups = driver.FindElements(By.CssSelector("span.group input[type='checkbox']"));
      groups[index].Click();
      return this;
    }

    public GroupHelper SubmitGroupCreation()
    {
      driver.FindElement(By.Name("submit")).Click();
      groupsCache = null;

      return this;
    }

    public GroupHelper FillGroupForm(GroupData group)
    {
      Type(By.Name("group_name"), group.Name);
      Type(By.Name("group_header"), group.Header);
      Type(By.Name("group_footer"), group.Footer);

      return this;
    }

    public GroupHelper InitGroupCreation()
    {
      driver.FindElement(By.Name("new")).Click();
      return this;
    }

    // cache operation's support
    private List<GroupData> groupsCache = null;

    public List<GroupData> GetGroupsList()
    {
      if (groupsCache == null)
      {
        groupsCache = new List<GroupData>();
        manager.Navigator.GoToGroupsPage();

        ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
        foreach (var element in elements)
          groupsCache.Add(new GroupData(element.Text)
              {
                  Id = element.FindElement(By.TagName("input")).GetAttribute("value")
              }
          );
      }

      // to return cache copy, not actual cache.
      return new List<GroupData>(groupsCache);
    }
  }
}