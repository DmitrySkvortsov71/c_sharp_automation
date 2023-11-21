using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests: AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (app.Groups.GetGroupsQuantityOnPage() == 0) 
                app.Groups.Create(new GroupData(""));
            
            app.Groups.Remove(1);
        }
    }
}
