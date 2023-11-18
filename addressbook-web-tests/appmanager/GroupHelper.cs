using System;
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
            if (GetGroupsQuantityOnPage() == 0) Create(new GroupData(""));

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

            if (GetGroupsQuantityOnPage() == 0) Create(new GroupData(""));
            
            SelectGroup(index);
            RemoveGroup();

            return this;
        }

        public int GetGroupsQuantityOnPage()
        {
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
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            var groups = driver.FindElements(By.CssSelector("span.group input[type='checkbox']"));
            groups[index - 1].Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
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
    }
}