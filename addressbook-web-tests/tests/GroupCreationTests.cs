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
            
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            
        } 
        
        [Test]
        public void EmptyGroupCreationTest()
        {

            var group = new GroupData("")
            {
                Header = "",
                Footer = ""
            };
            app.Groups.Create(group);
            
            
        } 
    }
}
