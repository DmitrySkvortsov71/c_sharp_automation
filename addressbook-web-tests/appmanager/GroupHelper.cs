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
            
            return this;
        }

        public GroupHelper Modify(int index, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(index);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int index)
        {
            manager.Navigator.GoToGroupsPage();
            
            SelectGroup(index);
            RemoveGroup();
            
            return this;
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
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            return this;
        }
        
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        
        public GroupHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            
            return this;
        }
        
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
    }
}