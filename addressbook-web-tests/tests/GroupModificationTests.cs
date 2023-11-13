using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            var newData = new GroupData("modified")
            {
                Header = "modified Header",
                Footer = "modified Footer"
            };

            app.Groups.Modify(1, newData);
        }
        
    }
}