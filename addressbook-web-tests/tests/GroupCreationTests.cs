using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests: AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            
            var group = new GroupData("bbb")
            {
                Header = "bbb header",
                Footer = "bbb footer"
            };
            app.Groups.Create(group);
            
            // verification
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            
            var group = new GroupData("")
            {
                Header = "",
                Footer = ""
            };
            app.Groups.Create(group);
            
            // verification
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
