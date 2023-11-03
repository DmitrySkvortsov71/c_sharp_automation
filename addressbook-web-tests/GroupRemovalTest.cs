using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests: TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            
            GoToGroupsPage();
            SelectGroup(1);
            RemoveGroup();
            
            GoToGroupsPage();
            Logout();
        }
    }
}
