using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests: AuthTestBase
    {
        
        [Test]
        public void GroupCreationTest()
        {
            var group = new GroupData("bbb")
            {
                Header = "bbb header",
                Footer = "bbb footer"
            };
            app.Groups.Create(group);
            app.Auth.Logout();
        } 
        
        public void EmptyGroupCreationTest()
        {
            var group = new GroupData("")
            {
                Header = "",
                Footer = ""
            };
            app.Groups.Create(group);

            app.Navigator.GoToGroupsPage();
        } 
    }
}
