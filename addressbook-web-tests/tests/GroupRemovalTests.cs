using NUnit.Framework;
using System.Collections.Generic;

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
            
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            
            app.Groups.Remove(0);
            
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
