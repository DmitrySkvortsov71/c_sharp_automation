using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (app.Groups.GetGroupsQuantityOnPage() == 0) 
                app.Groups.Create(new GroupData(""));
            
            var newData = new GroupData("modified")
            {
                Header = null,
                Footer = null
            };

            app.Groups.Modify(0, newData);
        }
        
    }
}