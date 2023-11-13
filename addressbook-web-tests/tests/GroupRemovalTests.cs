using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests: TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.Remove(1);
        }
    }
}
