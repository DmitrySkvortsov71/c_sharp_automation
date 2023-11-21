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
            // preparation
            if (app.Groups.GetGroupsQuantityOnPage() == 0) 
                app.Groups.Create(new GroupData(""));
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            
            // action
            app.Groups.Remove(0);
            
            // verification
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
