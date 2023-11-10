using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests: TestBase
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
