using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests: TestBase
    {
        
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();

            var group = new GroupData("bbb")
            {
                Header = "bbb header",
                Footer = "bbb footer"
            };
            
            FillGroupForm(group);
            SubmitGroupCreation();

            GoToGroupsPage();
            Logout();
        }

    }
}
