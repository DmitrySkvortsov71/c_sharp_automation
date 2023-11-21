using NUnit.Framework;
using System.Collections.Generic;

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
            
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            
            var newData = new GroupData("modified")
            {
                Header = null,
                Footer = null
            };

            app.Groups.Modify(0, newData);
            
            // verification
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            
            Assert.AreEqual(oldGroups, newGroups);
        }
        
    }
}