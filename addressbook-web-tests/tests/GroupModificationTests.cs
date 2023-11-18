using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            var newData = new GroupData("modified")
            {
                Header = null,
                Footer = null
            };

            app.Groups.Modify(1, newData);
        }
        
    }
}