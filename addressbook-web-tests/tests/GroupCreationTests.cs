using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
  [TestFixture]
  public class GroupCreationTests : AuthTestBase
  {
    public static IEnumerable<GroupData> RandomGroupDataProvider()
    {
      var groups = new List<GroupData>();

      return groups;
    }
    
    [Test, TestCaseSource("RandomGroupDataProvider")]
    public void GroupCreationTest(GroupData group)
    {
      var oldGroups = app.Groups.GetGroupsList();
      
      app.Groups.Create(group);

      // verification
      Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCount());

      var newGroups = app.Groups.GetGroupsList();
      oldGroups.Add(group);
      oldGroups.Sort();
      newGroups.Sort();

      Assert.AreEqual(oldGroups, newGroups);
    }
  }
}